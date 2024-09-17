using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EC;
using Persistencia;

namespace Logica
{
   internal class LogicaConsultorio : ILogicaConsultorio
    {

        private static LogicaConsultorio _instancia = null;
        private LogicaConsultorio() { }
        public static LogicaConsultorio GetInstancia()
        {
            if (_instancia == null)
                _instancia = new LogicaConsultorio();
            return _instancia;
        }

        public void AltaConsultorio(Consultorio unC)
        {
            Persistencia.FabricaPersistencia.GetPersistenciaConsultorio().AltaConsultorio(unC);
        }

        public void BajaConsultorio (Consultorio unC)
        {
            Persistencia.FabricaPersistencia.GetPersistenciaConsultorio().BajaConsultorio(unC);

        }

        public void ModificarConsultorio(Consultorio unC)
        {
            Persistencia.FabricaPersistencia.GetPersistenciaConsultorio().ModificarConsultorio(unC);

        }

        public Consultorio BuscarConsultorio(int unC, string unP)
        {
            return (FabricaPersistencia.GetPersistenciaConsultorio().BuscarConsultorioActivo(unC,unP));
        }

        public List<Consultorio> ListarConsultorio()
        {
            return (Persistencia.FabricaPersistencia.GetPersistenciaConsultorio().ListarConsultorios());
        }

    }
}
