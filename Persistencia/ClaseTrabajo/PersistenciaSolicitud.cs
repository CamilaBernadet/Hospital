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
    internal class PersistenciaSolicitud : IPersistenciaSolicitud
    {
        private static PersistenciaSolicitud _instancia = null;

        private PersistenciaSolicitud() { }

        public static PersistenciaSolicitud GetInstancia()
        {
            if (_instancia == null)
                _instancia = new PersistenciaSolicitud();
            return _instancia;

        }


        public void AltaSolicitud(Solicitud unaSol)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn);

            SqlCommand _comando = new SqlCommand("AltaSolicitud", _cnn);
            _comando.CommandType = CommandType.StoredProcedure;

            //Parametros de entrada
            //_comando.Parameters.AddWithValue("@NumeroSeleccionado", unaSol.NumeroSeleccionado);
            _comando.Parameters.AddWithValue("@CiPaciente", unaSol.UnP.CiPaciente);
            _comando.Parameters.AddWithValue("@NumeroConsulta", unaSol.UnC.NumConsulta);
            _comando.Parameters.AddWithValue("@NombreUsu", unaSol.UnE.NomUsu);
           


            //retorno
            SqlParameter _retorno = new SqlParameter("@Retrono", SqlDbType.Int);
            _retorno.Direction = ParameterDirection.ReturnValue;
            _comando.Parameters.Add(_retorno);

            try
            {
                _cnn.Open();
                _comando.ExecuteNonQuery();
                if ((int)_retorno.Value == -1)
                    throw new Exception("Ya existe una solicitud con el Numero Seleccionado");

                else if ((int)_retorno.Value == -2)
                    throw new Exception("Verifique el Paciente no existe o no esta Activo");

                else if ((int)_retorno.Value == -3)
                    throw new Exception("La consulta no Existe");

                else if ((int)_retorno.Value == -4)
                    throw new Exception("Verifique el empleado");

                else if ((int)_retorno.Value == -5)
                    throw new Exception("La consulta ya Expiro");

                else if ((int)_retorno.Value == -6)
                    throw new Exception("Consulta duplicada- Verifique los datos de el Paciente");
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

        public void MarcarSinAsistir(Solicitud unaSol)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn);

            SqlCommand _comando = new SqlCommand("MarcarAsistencia", _cnn);
            _comando.CommandType = CommandType.StoredProcedure;

            //Parametros de entrada
            _comando.Parameters.AddWithValue("@NumeroSolicitud", unaSol.NumeroInterno);


            SqlParameter _retorno = new SqlParameter("@Retrono", SqlDbType.Int);
            _retorno.Direction = ParameterDirection.ReturnValue;
            _comando.Parameters.Add(_retorno);

            try
            {
                _cnn.Open();
                _comando.ExecuteNonQuery();

                if ((int)_retorno.Value == -1)
                    throw new Exception("La Solicitud no Existe");

                else if ((int)_retorno.Value == -2)
                    throw new Exception("Error en la actualizaacion");

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

        public  List<Solicitud> ListarSolicitudes()
        {

            SqlConnection _cnn = new SqlConnection(Conexion.Cnn);
            Solicitud _unaSol = null;
            List<Solicitud> _lista = new List<Solicitud>();

            SqlCommand _comando = new SqlCommand("LisSolicitudesCompleta", _cnn);
            _comando.CommandType = System.Data.CommandType.StoredProcedure;

            try
            {
                _cnn.Open();
                SqlDataReader _lector = _comando.ExecuteReader();
                if (_lector.HasRows)
                {
                    while (_lector.Read())
                    {
                        Paciente _unP = null;
                        _unP = PersistenciaPaciente.GetInstancia().BuscarPacienteActivos((string)_lector["CI_Paciente"]);

                        Consulta _unC = null;
                        _unC = PersistenciaConsulta.GetInstancia().BuscarConsulta((int)_lector["NumeroConsulta"]);

                        Empleado _unE = null;
                        _unE = PersistenciaEmpleado.GetInstancia().Buscar((string)_lector["NombreUsu"]);

                        _unaSol = new Solicitud((int)_lector["NumeroInterno"],
                                                    Convert.ToDateTime(_lector["FechaHora"]),
                                                    
                                                     Convert.ToBoolean(_lector["Asistencia"]),
                                                     _unP, _unC, _unE);
                        _lista.Add(_unaSol);
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

        public List<Solicitud> ListarPorConsulta(Consulta unC)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn);
            Solicitud _unaSol = null;
            List<Solicitud> _lista = new List<Solicitud>();

            SqlCommand _comando = new SqlCommand("ListarPorConsulta", _cnn);
            _comando.CommandType = System.Data.CommandType.StoredProcedure;

            _comando.Parameters.AddWithValue("@NumConsulta", unC.NumConsulta);


            try
            {
                _cnn.Open();
                SqlDataReader _lector = _comando.ExecuteReader();
                if (_lector.HasRows)
                {
                    while (_lector.Read())
                    {
                        Paciente _unP = null;
                        _unP = PersistenciaPaciente.GetInstancia().BuscarPaciente((string)_lector["CI_Paciente"]);


                        Empleado _unE = null;
                        _unE = PersistenciaEmpleado.GetInstancia().Buscar((string)_lector["NombreUsu"]);

                      
                        _unaSol = new Solicitud((int)_lector["NumeroInterno"],
                                                    Convert.ToDateTime(_lector["FechaHora"]),
                                                    // (int)_lector["NumeroSeleccionado"],
                                                     Convert.ToBoolean(_lector["Asistencia"]),
                                                     _unP, unC, _unE);
                        _lista.Add(_unaSol);
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

        public List<Solicitud> ListSinAsistir()
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn);
            Solicitud _unaSol = null;
            List<Solicitud> _lista = new List<Solicitud>();

            SqlCommand _comando = new SqlCommand("ListSinAsistir", _cnn);
            _comando.CommandType = System.Data.CommandType.StoredProcedure;

            try
            {
                _cnn.Open();
                SqlDataReader _lector = _comando.ExecuteReader();
                if (_lector.HasRows)
                {
                    while (_lector.Read())
                    {
                        Paciente _unP = null;
                        _unP = PersistenciaPaciente.GetInstancia().BuscarPaciente((string)_lector["CI_Paciente"]);

                        Consulta _unC = null;
                        _unC = PersistenciaConsulta.GetInstancia().BuscarConsulta((int)_lector["NumeroConsulta"]);

                        Empleado _unE = null;
                        _unE = PersistenciaEmpleado.GetInstancia().Buscar((string)_lector["NombreUsu"]);

                       
                        _unaSol = new Solicitud((int)_lector["NumeroInterno"],
                                                    Convert.ToDateTime(_lector["FechaHora"]),
                                                    // (int)_lector["NumeroSeleccionado"],
                                                     Convert.ToBoolean(_lector["Asistencia"]),
                                                     _unP, _unC, _unE);
                        _lista.Add(_unaSol);
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


    }
}
