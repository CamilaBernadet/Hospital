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
   internal class PersistenciaPoliclinica : IPersistenciaPoliclinica
    {
        //Singleton
        private static PersistenciaPoliclinica _instancia = null;

        private PersistenciaPoliclinica() { }

        public static PersistenciaPoliclinica GetInstancia()
        {
            if (_instancia == null)
                _instancia = new PersistenciaPoliclinica();
            return _instancia;

        }


        //Op

        public void AltaPoliclinica(Policlinica unPol)
        {

            SqlConnection _cnn = new SqlConnection(Conexion.Cnn);

            SqlCommand _comando = new SqlCommand("AltaPoliclinica", _cnn);
            _comando.CommandType = CommandType.StoredProcedure;

            //Parametros de entrada
            _comando.Parameters.AddWithValue("@Codigo", unPol.Codigo);
            _comando.Parameters.AddWithValue("@Nombre", unPol.Nombre);
            _comando.Parameters.AddWithValue("@Direccion", unPol.Direccion);


            //retorno
            SqlParameter _pRetorno = new SqlParameter("@Retorono", SqlDbType.Int);
            _pRetorno.Direction = ParameterDirection.ReturnValue;
            _comando.Parameters.Add(_pRetorno);



            try
            {
                _cnn.Open();

               
                _comando.ExecuteNonQuery();


                if ((int)_pRetorno.Value == -1)
                    throw new Exception("La Policlinica no existe");
                else if ((int)_pRetorno.Value == -2)
                    throw new Exception("Verifique los datos ingresados error en el Alta");
                
                    
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

        public Policlinica BuscarPoliclinica(string unP)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn);
            Policlinica _unaPoliclinica = null;

            SqlCommand _comando = new SqlCommand("BuscarPoliclinica", _cnn);
            _comando.CommandType = System.Data.CommandType.StoredProcedure;
            _comando.Parameters.AddWithValue("@Codigo", unP);

            try
            {
                _cnn.Open();
                SqlDataReader _lector = _comando.ExecuteReader();
                if (_lector.HasRows)
                {
                    _lector.Read();
                    string codigo = (string)_lector["Codigo"];
                    string nombre = (string)_lector["Nombre"];
                    string direccion = (string)_lector["Direccion"];
                   

                    _unaPoliclinica = new Policlinica(codigo, nombre, direccion);
                }
                _lector.Close();
            }
            catch (Exception ex)
            {
                throw new Exception( ex.Message, ex);
            }
            finally
            {
                _cnn.Close();
            }

            return _unaPoliclinica;
        }


        public List<Policlinica> ListarPoliclinica()
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn);
            Policlinica _unaPoliclinica = null;
            List<Policlinica> _lista = new List<Policlinica>();

            SqlCommand _comando = new SqlCommand("ListarPoliclinica", _cnn);
            _comando.CommandType = System.Data.CommandType.StoredProcedure;

            try
            {
                _cnn.Open();
                SqlDataReader _lector = _comando.ExecuteReader();
                if (_lector.HasRows)
                {
                    while (_lector.Read())
                    {
                        _unaPoliclinica = new Policlinica((string)_lector["Codigo"],
                                                            (string)_lector["Nombre"],
                                                            (string)_lector["Direccion"]);
                        _lista.Add(_unaPoliclinica);
                    }
                }
                _lector.Close();
            }
            catch (Exception ex)
            {

                throw new Exception (ex.Message);
            }
            finally
            {
                _cnn.Close();
            }
            return _lista;
        }
    }
}
