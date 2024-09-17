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
    internal class PersistenciaConsulta : IPersistenciaConsulta
    {
        private static PersistenciaConsulta _instancia = null;

        private PersistenciaConsulta() { }

        public static PersistenciaConsulta GetInstancia()
        {
            if (_instancia == null)
                _instancia = new PersistenciaConsulta();
            return _instancia;

        }


        public void AltaConsulta(Consulta unaConsulta)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn);
            SqlCommand _comando = new SqlCommand("AltaConsulta", _cnn);
            _comando.CommandType = CommandType.StoredProcedure;

            // Pasar los valores correctos como parámetros
            _comando.Parameters.AddWithValue("@Id_Consultorio", unaConsulta.UnConsultorio.NumConsultorio);
            _comando.Parameters.AddWithValue("@CodPol", unaConsulta.UnConsultorio.UnaPol.Codigo);
            _comando.Parameters.AddWithValue("@Fecha_Consulta", unaConsulta.FechaHoraConsulta);
            _comando.Parameters.AddWithValue("@Medico", unaConsulta.MedicoNombre);
            _comando.Parameters.AddWithValue("@Especialidad", unaConsulta.Especialidad);
            _comando.Parameters.AddWithValue("@CantidadNumeros", unaConsulta.CanConsulta);

            // Parámetro de retorno
            SqlParameter _retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _retorno.Direction = ParameterDirection.ReturnValue;
            _comando.Parameters.Add(_retorno);

            try
            {
                _cnn.Open();
                _comando.ExecuteNonQuery();
                int result = (int)_retorno.Value;

                // Manejo del código de retorno
                if (result == -1)
                {
                    throw new Exception("Verifique La Policlinica o Consultorio");
                }
                else if (result == -2)
                {
                    throw new Exception("Error Verifique los datos ingresados");
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

        public  Consulta BuscarConsulta(int numCons)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn);
            Consulta _unaConsulta = null;

            SqlCommand _comando = new SqlCommand("BuscarConsulta", _cnn);
            _comando.CommandType = System.Data.CommandType.StoredProcedure;
            _comando.Parameters.AddWithValue("@NumeroConsulta", numCons);

            try
            {
                _cnn.Open();
                SqlDataReader _lector = _comando.ExecuteReader();
                if (_lector.HasRows)
                {
                    _lector.Read(); 

                    string codPol = (string)_lector["CodigoPol"];
                    int consultorioNum = (int)_lector["Id_Consultorio"];

                    
                    Consultorio _unCons = PersistenciaConsultorio.GetInstancia().BuscarConsultorio(consultorioNum, codPol);

                    _unaConsulta = new Consulta(
                        (int)_lector["NumeroInterno"],
                         Convert.ToDateTime(_lector["Fecha_Consulta"]),
                         (int)_lector["CantidadNumeros"],
                        (string)_lector["Medico"],
                        (string)_lector["Especialidad"],
                        _unCons
                        
                    );
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
            return _unaConsulta;

        }


        public  List<Consulta> ListarConsulta()
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn);

            SqlCommand _comando = new SqlCommand("ListarConsulta", _cnn);
            _comando.CommandType = System.Data.CommandType.StoredProcedure;

            Consulta _unConsulta = null;
            List<Consulta> _lista = new List<Consulta>();

            try
            {
                _cnn.Open();
                SqlDataReader _lector = _comando.ExecuteReader();
                if (_lector.HasRows)
                {
                    while (_lector.Read())
                    {
                        int consultorioNum = Convert.ToInt32(_lector["Id_Consultorio"]);
                        string codPol = Convert.ToString(_lector["CodigoPol"]);
                        Consultorio _unCons = PersistenciaConsultorio.GetInstancia().BuscarConsultorio(consultorioNum, codPol);
                       

                        _unConsulta = new Consulta(
                            (int)_lector["NumeroInterno"],
                            (DateTime)_lector["Fecha_Consulta"],
                            (int)_lector["CantidadNumeros"],
                            (string)_lector["Medico"],
                            (string)_lector["Especialidad"],
                            _unCons
                        );
                        _lista.Add(_unConsulta); 
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


        public  List<Consulta> ListarConsultaAFuturo()
        {

            SqlConnection _cnn = new SqlConnection(Conexion.Cnn);

            SqlCommand _comando = new SqlCommand("ListarConsultasFuturas", _cnn);
            _comando.CommandType = System.Data.CommandType.StoredProcedure;

            Consulta _unConsulta = null;
            List<Consulta> _lista = new List<Consulta>();

            try
            {
                _cnn.Open();
                SqlDataReader _lector = _comando.ExecuteReader();
                if (_lector.HasRows)
                {
                    while (_lector.Read())
                    {
                        int consultorioNum = Convert.ToInt32(_lector["Id_Consultorio"]);
                        string codPol = Convert.ToString(_lector["CodigoPol"]);
                        Consultorio _unCons = PersistenciaConsultorio.GetInstancia().BuscarConsultorio(consultorioNum, codPol);
                        

                        _unConsulta = new Consulta(
                            (int)_lector["NumeroInterno"],
                            (DateTime)_lector["Fecha_Consulta"],
                            (int)_lector["CantidadNumeros"],
                            (string)_lector["Medico"],
                            (string)_lector["Especialidad"],
                            _unCons
                           
                        );
                        _lista.Add(_unConsulta);
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

