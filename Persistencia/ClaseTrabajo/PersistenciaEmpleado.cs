using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using EC;

namespace Persistencia
{
   internal class PersistenciaEmpleado: IPersistenciaEmpleado
    {
        //Aplicamos singleton
        private static PersistenciaEmpleado _instancia = null;

        private PersistenciaEmpleado() { }

        public static PersistenciaEmpleado GetInstancia()
        {
            if (_instancia == null)
                _instancia = new PersistenciaEmpleado();
            return _instancia;

        }



        //Opperaciones

        public void AltaEmpleado(Empleado unEmp)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn);

            SqlCommand _comando = new SqlCommand("AltaEmpleado", _cnn);
            _comando.CommandType = System.Data.CommandType.StoredProcedure;

            _comando.Parameters.AddWithValue("@NomUsu", unEmp.NomUsu);
            _comando.Parameters.AddWithValue("@PassUsu", unEmp.PassUsu);

            SqlParameter _pRetorno = new SqlParameter("@Retorono", SqlDbType.Int);
            _pRetorno.Direction = ParameterDirection.ReturnValue;
            _comando.Parameters.Add(_pRetorno);

            try
            {
                _cnn.Open();
                _comando.ExecuteNonQuery();

                if ((int)_pRetorno.Value == -1)
                    throw new Exception("No existe el empleado");

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

        public Empleado Logueo(string eNomUsu, string ePassUsu)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn);
            Empleado _unEmpleado = null;

            SqlCommand _comando = new SqlCommand("LogueoEmpleado", _cnn);
            _comando.CommandType = System.Data.CommandType.StoredProcedure;
            _comando.Parameters.AddWithValue("@NomUsu", eNomUsu);
            _comando.Parameters.AddWithValue("@PassUsu", ePassUsu);

            try
            {
                _cnn.Open();
                SqlDataReader _lector = _comando.ExecuteReader();
                if(_lector.HasRows)
                {
                    _lector.Read();
                    _unEmpleado = new Empleado(eNomUsu, ePassUsu);
                }
            
            }

            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            finally
            {
                _cnn.Close();
            }
            return _unEmpleado;


        }

        public Empleado Buscar(string eNomUsu)
        {

          
                SqlConnection _cnn = new SqlConnection(Conexion.Cnn);
                Empleado _unEmpleado = null;

                SqlCommand _comando = new SqlCommand("BuscarEmpleado", _cnn);
                _comando.CommandType = System.Data.CommandType.StoredProcedure;
                _comando.Parameters.AddWithValue("@NomUsu", eNomUsu);


                try
                {
                    _cnn.Open();
                    SqlDataReader _lector = _comando.ExecuteReader();
                    if (_lector.HasRows)
                    {
                        _lector.Read();
                        _unEmpleado = new Empleado(eNomUsu, (string)_lector["PassUsu"]);
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
                return _unEmpleado;
            }
        


    }
}
