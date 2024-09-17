using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EC;

namespace Persistencia
{
    public interface IPersistenciaConsultorio
    {
        void AltaConsultorio(Consultorio unConsultorio);
        void BajaConsultorio(Consultorio unConsultorio);
        void ModificarConsultorio(Consultorio unConsultorio);
        List<Consultorio> ListarConsultorios();


        Consultorio BuscarConsultorioActivo(int numeroConsultorio, string unP);
    }
}
