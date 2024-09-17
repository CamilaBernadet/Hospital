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
   internal class PersistenciaConsultorio : IPersistenciaConsultorio
    {
        private static PersistenciaConsultorio _instancia = null;

        private PersistenciaConsultorio() { }

        public static PersistenciaConsultorio GetInstancia()
        {
            if (_instancia == null)
                _instancia = new PersistenciaConsultorio();
            return _instancia;

        }


        public void AltaConsultorio(Consultorio unConsultorio)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn);
            SqlCommand _comando = new SqlCommand("AltaConsultorio", _cnn);
            _comando.CommandType = CommandType.StoredProcedure;

            // Parámetros de entrada
            _comando.Parameters.AddWithValue("@NumeroConsultorio", unConsultorio.NumConsultorio);
            _comando.Parameters.AddWithValue("@CodigoPol", unConsultorio.UnaPol.Codigo);
            _comando.Parameters.AddWithValue("@Descripcion", unConsultorio.Descripcion);

            // Parámetro de retorno
            SqlParameter _retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _retorno.Direction = ParameterDirection.ReturnValue;
            _comando.Parameters.Add(_retorno);

            try
            {
                _cnn.Open();
                _comando.ExecuteNonQuery();

                int retorno = (int)_retorno.Value;

                if (retorno == -1)
                {
                    throw new Exception("Código de policlínica no existe");
                }
                else if (retorno == -2)
                {
                    throw new Exception("El consultorio ya existe o está activo");
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

        }

        public void BajaConsultorio(Consultorio unConsultorio)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn);

            SqlCommand _comando = new SqlCommand("BajaConsultorio", _cnn);
            _comando.CommandType = System.Data.CommandType.StoredProcedure;

            _comando.Parameters.AddWithValue("@NumeroConsultorio", unConsultorio.NumConsultorio);
            _comando.Parameters.AddWithValue("@CodPol", unConsultorio.UnaPol.Codigo);
            SqlParameter _retorno = new SqlParameter("@Retorno", System.Data.SqlDbType.Int);

            _retorno.Direction = System.Data.ParameterDirection.ReturnValue;
            _comando.Parameters.Add(_retorno);

            try
            {
                _cnn.Open();
                _comando.ExecuteNonQuery();
                if ((int)_retorno.Value == -2)
                    throw new Exception("El consultorio no Existe o Tiene policlinicas Asoc");

                else if ((int)_retorno.Value == 3)
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

        public void ModificarConsultorio(Consultorio unConsultorio)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn);

            SqlCommand _comando = new SqlCommand("ModificarConsultorio", _cnn);
            _comando.CommandType = System.Data.CommandType.StoredProcedure;

            _comando.Parameters.AddWithValue("@NumeroConsultorio", unConsultorio.NumConsultorio);
            _comando.Parameters.AddWithValue("@CodigoPol", unConsultorio.UnaPol.Codigo);
            _comando.Parameters.AddWithValue("@Descripcion", unConsultorio.Descripcion);

            SqlParameter _retorno = new SqlParameter("@Retorno", System.Data.SqlDbType.Int);

            _retorno.Direction = System.Data.ParameterDirection.ReturnValue;
            _comando.Parameters.Add(_retorno);

            try
            {
                _cnn.Open();
                _comando.ExecuteNonQuery();
                if ((int)_retorno.Value == -2)
                    throw new Exception("Verifique el Consultorio no Existe o no esta activo");

                else if ((int)_retorno.Value == -3)
                    throw new Exception("Error al modificar verifique los datos");

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

       internal Consultorio BuscarConsultorio(int numeroConsultorio, string codP)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn);
            Consultorio _unCons = null;

            SqlCommand _comando = new SqlCommand("BuscarConsultorio", _cnn);
            _comando.CommandType = System.Data.CommandType.StoredProcedure;
            _comando.Parameters.AddWithValue("@NumeroConsultorio", numeroConsultorio);
            _comando.Parameters.AddWithValue("@CodPol", codP);

            try
            {
                _cnn.Open();
                SqlDataReader _lector = _comando.ExecuteReader();
                if (_lector.HasRows)
                {
                    _lector.Read();
                    string descripcion = (string)_lector["Descripcion"];

                    Policlinica _unPol = PersistenciaPoliclinica.GetInstancia().BuscarPoliclinica(codP);
                    _unCons = new Consultorio(numeroConsultorio, descripcion, _unPol);
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
            return _unCons;
        }

        public List<Consultorio> ListarConsultorios()
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn);
            Consultorio _unConsultorio = null;
            List<Consultorio> _lista = new List<Consultorio>();

            SqlCommand _comando = new SqlCommand("ListarConsultorio", _cnn);
            _comando.CommandType = System.Data.CommandType.StoredProcedure;

            try
            {
                _cnn.Open();
                SqlDataReader _lector = _comando.ExecuteReader();
                if (_lector.HasRows)
                {
                    while (_lector.Read())
                    {
                        //Busco la policlinica
                        Policlinica _unPol = null;
                        _unPol = PersistenciaPoliclinica.GetInstancia().BuscarPoliclinica((string)_lector["CodigoPol"]);

                        _unConsultorio = new Consultorio((int)_lector["NumeroConsultorio"],
                                                    (string)_lector["Descripcion"],
                                                    _unPol);
                        _lista.Add(_unConsultorio);
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


        
        public Consultorio BuscarConsultorioActivo(int cConsultorio, string unP)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn);
            Consultorio _unCons = null;
            

            SqlCommand _comando = new SqlCommand("BuscarActivo", _cnn);
            _comando.CommandType = System.Data.CommandType.StoredProcedure;
            _comando.Parameters.AddWithValue("@NumeroConsulta", cConsultorio);
            _comando.Parameters.AddWithValue("@CodPol", unP);

            try
            {
                _cnn.Open();
                SqlDataReader _lector = _comando.ExecuteReader();
                if (_lector.HasRows)
                {
                    _lector.Read();
                    string descripcion = (string)_lector["Descripcion"];

                    Policlinica _unPol = PersistenciaPoliclinica.GetInstancia().BuscarPoliclinica(unP);
                    _unCons = new Consultorio(cConsultorio, descripcion, _unPol);
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
            return _unCons;
        }

    }
}
