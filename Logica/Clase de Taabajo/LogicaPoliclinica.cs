using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EC;

namespace Logica
{
   internal class LogicaPoliclinica : ILogicaPoliclinica
    {

        private static LogicaPoliclinica _instancia = null;
        private LogicaPoliclinica() { }
        public static LogicaPoliclinica GetInstancia()
        {
            if (_instancia == null)
                _instancia = new LogicaPoliclinica();
            return _instancia;
        }

        public List<Policlinica> ListarPoliclinica()
        {

            return Persistencia.FabricaPersistencia.GetPersistenciaPoliclinica().ListarPoliclinica();

        }

        public Policlinica BuscarPoliclinica(string unP)
        {
            return (Persistencia.FabricaPersistencia.GetPersistenciaPoliclinica().BuscarPoliclinica(unP));
        }

        public void AltaPoliclinica (Policlinica unP)
        {
           Persistencia.FabricaPersistencia.GetPersistenciaPoliclinica().AltaPoliclinica(unP);
        }



    }
}
