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
   internal class PersistenciaPatologia
    {
        //Aplicamos singleton
        private static PersistenciaPatologia _instancia = null;

        private PersistenciaPatologia() { }

        public static PersistenciaPatologia GetInstancia()
        {
            if (_instancia == null)
                _instancia = new PersistenciaPatologia();
            return _instancia;

        }

        //op

        internal static void AltaPatologia(Patologia unPatologia, string Cipaciente, SqlTransaction _pTransaccion)
        {

            SqlCommand _comando = new SqlCommand("AltaPatologia", _pTransaccion.Connection);
            _comando.CommandType = CommandType.StoredProcedure;

            //Parametros de entrada
            _comando.Parameters.AddWithValue("@CiPaciente", Cipaciente);
            _comando.Parameters.AddWithValue("@Patologia", unPatologia.patologia);


            //retorno
            SqlParameter _ParmRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _ParmRetorno.Direction = ParameterDirection.ReturnValue;
            _comando.Parameters.Add(_ParmRetorno);

            try
            {
                _comando.Transaction = _pTransaccion;
                _comando.ExecuteNonQuery();

                int oAfectado = Convert.ToInt32(_ParmRetorno.Value);

                if (oAfectado == -1)
                    throw new Exception("Error en Paciente");

                else if (oAfectado == 0)
                    throw new Exception("Error no Esperado");

            }

            catch (Exception ex)
            {
                throw ex;
            }

        }

        internal static List<Patologia> ListarPatologiaPorCliente(string pCiPaciente)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn);

            SqlCommand _comando = new SqlCommand("ListadoDePacientePorPatoligia", _cnn);
            _comando.CommandType = CommandType.StoredProcedure;
            _comando.Parameters.AddWithValue("@CiPaciente", pCiPaciente);

            List<Patologia> _ListaPatologia = new List<Patologia>();

            try
            {
                
                _cnn.Open();

               
                SqlDataReader _lector = _comando.ExecuteReader();

               
                if (_lector.HasRows)
                {
                    while (_lector.Read())
                    {
                        _ListaPatologia.Add(new Patologia((string)_lector["Patologia"]));
                    }
                }

                _lector.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _cnn.Close();
            }

            return _ListaPatologia;
        }


        internal static void EliminarPatologiasDePaciente(Paciente unP, SqlTransaction _pTransaccion)
        {
            SqlCommand _comando = new SqlCommand("BajaPatologia", _pTransaccion.Connection);

            _comando.CommandType = CommandType.StoredProcedure;
            _comando.Parameters.AddWithValue("@CiPaciente", unP.CiPaciente);
            SqlParameter _ParmRetorno = new SqlParameter("@Retorno", SqlDbType.Int);

            _ParmRetorno.Direction = ParameterDirection.ReturnValue;
            _comando.Parameters.Add(_ParmRetorno);

            try
            {
               
                _comando.Transaction = _pTransaccion;

                _comando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
