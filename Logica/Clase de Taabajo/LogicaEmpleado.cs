using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EC;
using Persistencia;

namespace Logica
{
   internal class LogicaEmpleado : ILogicaEmpleado
    {

        //Singleton

        private static LogicaEmpleado _instancia = null;
        private LogicaEmpleado() { }
        public static LogicaEmpleado GetInstancia()
        {
            if (_instancia == null)
                _instancia = new LogicaEmpleado();
            return _instancia;
        }


        //op

        public Empleado Logueo(string NomUSu, string PassUsu)
        {
            return Persistencia.FabricaPersistencia.GetPersistenciaEmpleado().Logueo(NomUSu, PassUsu);
        }

        public void AltaEmpleado(Empleado unE)
        {

            Persistencia.FabricaPersistencia.GetPersistenciaEmpleado().AltaEmpleado(unE);
        }


        public Empleado BuscarEmpleado(string unE)
        {
            return (Persistencia.FabricaPersistencia.GetPersistenciaEmpleado().Buscar(unE));
        }

    }
}
