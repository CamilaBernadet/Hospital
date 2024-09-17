using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EC;

namespace Persistencia
{
   public interface IPersistenciaPaciente
    {
        void AltaPaciente(Paciente unPaciente);
        void BajaPaciente(Paciente unPaciente);
        void ModificarPaciente(Paciente unPaciente);

        Paciente BuscarPacienteActivos(string pCiPaciente);
       
        List<Paciente> ListPaciente();
        
    }
}
