using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EC;

namespace Logica
{
    internal class LogicaPaciente: ILogicaPaciente
    {
        private static LogicaPaciente _instancia = null;
        private LogicaPaciente() { }
        public static LogicaPaciente GetInstancia()
        {
            if (_instancia == null)
                _instancia = new LogicaPaciente();
            return _instancia;
        }

        public void AltaPaciente(Paciente unp)
        {
            Persistencia.FabricaPersistencia.GetPersistenciaPaciente().AltaPaciente(unp);
        }

        public Paciente BuscarPaciente(string unP)
        {
            return (Persistencia.FabricaPersistencia.GetPersistenciaPaciente().BuscarPacienteActivos(unP));
        }

        public List<Paciente> ListarPaciente()
        {

            return Persistencia.FabricaPersistencia.GetPersistenciaPaciente().ListPaciente();

        }
        public void ModificarPaciente(Paciente unP)
        {
            Persistencia.FabricaPersistencia.GetPersistenciaPaciente().ModificarPaciente(unP);
        }

        public void EliminarPaciente(Paciente unP)
        {
            Persistencia.FabricaPersistencia.GetPersistenciaPaciente().BajaPaciente(unP);
        }

    }


   


}
