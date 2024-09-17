using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EC;
using Persistencia;

namespace Logica
{
    internal class LogicaConsulta : ILogicaConsulta
    {
        private static LogicaConsulta _instancia = null;
        private LogicaConsulta() { }
        public static LogicaConsulta GetInstancia()
        {
            if (_instancia == null)
                _instancia = new LogicaConsulta();
            return _instancia;
        }

        public List<Consulta> ListarConsulta()
        {


            return Persistencia.FabricaPersistencia.GetPersistenciaConsulta().ListarConsulta();
           
        }

        public List<Consulta> ListarConsultaAFuturo()
        {
            return Persistencia.FabricaPersistencia.GetPersistenciaConsulta().ListarConsultaAFuturo();
        }

        public Consulta BuscarConsulta(int unC)
        {
            return (Persistencia.FabricaPersistencia.GetPersistenciaConsulta().BuscarConsulta(unC));
        }

        public void AltaConsulta(Consulta unC)
        {
            Persistencia.FabricaPersistencia.GetPersistenciaConsulta().AltaConsulta(unC);
        }

    }
}
