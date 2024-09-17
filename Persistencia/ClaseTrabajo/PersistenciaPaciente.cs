using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EC;
using System.Data;
using System.Data.SqlClient;

namespace Persistencia
{
    internal class PersistenciaPaciente : IPersistenciaPaciente
    {
        //Aplicamos singleton
        private static PersistenciaPaciente _instancia = null;

        private PersistenciaPaciente() { }

        public static PersistenciaPaciente GetInstancia()
        {
            if (_instancia == null)
                _instancia = new PersistenciaPaciente();
            return _instancia;

        }


        //Op

        public  void AltaPaciente(Paciente unPaciente)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn);

            SqlCommand _comando = new SqlCommand("AltaPaciente", _cnn);
            _comando.CommandType = CommandType.StoredProcedure;

            // Parámetros de entrada
            _comando.Parameters.AddWithValue("@CiPaciente", unPaciente.CiPaciente);
            _comando.Parameters.AddWithValue("@Nombre", unPaciente.NomCompleto);
            _comando.Parameters.AddWithValue("@Fecha_Nacimiento", unPaciente.FechaNacimiento);

            // Parámetro de retorno
            SqlParameter _ParmRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _ParmRetorno.Direction = ParameterDirection.ReturnValue;
            _comando.Parameters.Add(_ParmRetorno);

            SqlTransaction _pTransaccion = null;

            try
            {
                _cnn.Open();
                _pTransaccion = _cnn.BeginTransaction();

                _comando.Transaction = _pTransaccion;
                _comando.ExecuteNonQuery();

                int oAfectado = (int)_comando.Parameters["@Retorno"].Value;

                if (oAfectado == -1)
                    throw new Exception("El Paciente ya existe");

                else if (oAfectado == -2)
                    throw new Exception("Error, verifique los datos");

                foreach (Patologia unap in unPaciente.Patologias)
                {
                    PersistenciaPatologia.AltaPatologia(unap, unPaciente.CiPaciente, _pTransaccion);
                }

                _pTransaccion.Commit();
            }
            catch (Exception ex)
            {
                _pTransaccion.Rollback();
                throw new Exception(ex.Message);
            }
            finally
            {
                _cnn.Close();
            }

        }

        public  void BajaPaciente(Paciente unPaciente)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn);

            SqlCommand _comando = new SqlCommand("BajaPaciente", _cnn);
            _comando.CommandType = System.Data.CommandType.StoredProcedure;

            _comando.Parameters.AddWithValue("@CiPaciente", unPaciente.CiPaciente);
            SqlParameter _retorno = new SqlParameter("@Retorno", System.Data.SqlDbType.Int);

            _retorno.Direction = System.Data.ParameterDirection.ReturnValue;
            _comando.Parameters.Add(_retorno);

            try
            {
                _cnn.Open();
                _comando.ExecuteNonQuery();
                if ((int)_retorno.Value == -2)
                    throw new Exception("El cliente tiene Solicitudes asociada");

                else if ((int)_retorno.Value == -3)
                    throw new Exception("Error al darle baja");

            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                _cnn.Close();
            }
        }

        public  void ModificarPaciente(Paciente unPaciente)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn);

            SqlCommand _comando = new SqlCommand("ModificarPaciente", _cnn);
            _comando.CommandType = System.Data.CommandType.StoredProcedure;

            _comando.Parameters.AddWithValue("@CiPaciente", unPaciente.CiPaciente);
            _comando.Parameters.AddWithValue("@Nombre", unPaciente.NomCompleto);
            _comando.Parameters.AddWithValue("@Fecha_Nacimiento", unPaciente.FechaNacimiento);

            SqlParameter _retorno = new SqlParameter("@Retorno", System.Data.SqlDbType.Int);
            _retorno.Direction = System.Data.ParameterDirection.ReturnValue;
            _comando.Parameters.Add(_retorno);

            SqlTransaction _miTransaccion = null;

            try
            {
                _cnn.Open();
                _miTransaccion = _cnn.BeginTransaction();

                PersistenciaPatologia.EliminarPatologiasDePaciente(unPaciente, _miTransaccion);
                _comando.Transaction = _miTransaccion;

                _comando.ExecuteNonQuery();
                if ((int)_retorno.Value == -2)
                    throw new Exception("Verifique el paciente no Existe o no esta activo");

                else if ((int)_retorno.Value == -3)
                    throw new Exception("Error al modificar verifique los datos");

                foreach (Patologia unap in unPaciente.Patologias)
                {
                    PersistenciaPatologia.AltaPatologia(unap, unPaciente.CiPaciente, _miTransaccion);
                }

                _miTransaccion.Commit();

            }

            catch (Exception ex)
            {
                _miTransaccion.Rollback();
                throw new Exception(ex.Message);
            }

            finally
            {
                _cnn.Close();
            }

        }


       internal Paciente BuscarPaciente(string pCiPaciente)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn);
           

            SqlCommand _comando = new SqlCommand("BuscarPaciente", _cnn);
            _comando.CommandType = System.Data.CommandType.StoredProcedure;
            _comando.Parameters.AddWithValue("@CiPaciente", pCiPaciente);

            Paciente _unPaciente = null;

            try
            {
                _cnn.Open();
                SqlDataReader _lector = _comando.ExecuteReader();
                if (_lector.HasRows)
                {
                    _lector.Read();
                    _unPaciente = new Paciente(pCiPaciente, (string)_lector["Nombre"],
                       Convert.ToDateTime(_lector["Fecha_Nacimiento"]),
                    PersistenciaPatologia.ListarPatologiaPorCliente(pCiPaciente));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                _cnn.Close();
            }
            return _unPaciente;
        }

       public  List<Paciente> ListPaciente()
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn);
            SqlCommand _comando = new SqlCommand("ListarPaciente", _cnn);
            _comando.CommandType = System.Data.CommandType.StoredProcedure;

            Paciente _unPaciente = null;
            List<Paciente> _lista = new List<Paciente>();

            try
            {
                _cnn.Open();
                SqlDataReader _lector = _comando.ExecuteReader();

                if (_lector.HasRows)
                {
                    while (_lector.Read())
                    {
                        _unPaciente = new Paciente(
                            (string)_lector["CiPaciente"],
                            (string)_lector["Nombre"],
                            (DateTime)_lector["Fecha_Nacimiento"],
                            PersistenciaPatologia.ListarPatologiaPorCliente((string)_lector["Patologia"])
                        );
                        _lista.Add(_unPaciente);
                    }
                }

                _lector.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                _cnn.Close();
            }

            return _lista;
        }

        
       public Paciente BuscarPacienteActivos(string pCiPaciente)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn);
            Paciente _unPaciente = null;

            SqlCommand _comando = new SqlCommand("BuscarPacienteActivo", _cnn);
            _comando.CommandType = System.Data.CommandType.StoredProcedure;
            _comando.Parameters.AddWithValue("@CiPaciente", pCiPaciente);

            try
            {
                _cnn.Open();
                SqlDataReader _lector = _comando.ExecuteReader();
                if (_lector.HasRows)
                {
                    _lector.Read();
                    _unPaciente = new Paciente(pCiPaciente, (string)_lector["Nombre"],
                       Convert.ToDateTime(_lector["Fecha_Nacimiento"]),
                    PersistenciaPatologia.ListarPatologiaPorCliente(pCiPaciente));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                _cnn.Close();
            }
            return _unPaciente;
        }

    }
}
