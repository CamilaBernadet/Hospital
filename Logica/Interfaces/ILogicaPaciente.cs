using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EC;
namespace Logica
{
   public interface ILogicaPaciente
    {
        void AltaPaciente(Paciente unp);
        Paciente BuscarPaciente(string unP);
        void ModificarPaciente(Paciente unP);
        void EliminarPaciente(Paciente unP);
        List<Paciente> ListarPaciente();
    }
}
