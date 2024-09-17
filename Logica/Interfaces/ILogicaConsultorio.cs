using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EC;

namespace Logica
{
    public interface ILogicaConsultorio
    {
        void AltaConsultorio(Consultorio unC);
        void BajaConsultorio(Consultorio unC);

        void ModificarConsultorio(Consultorio unC);

        Consultorio BuscarConsultorio(int unC, string unP);

        List<Consultorio> ListarConsultorio();
    }
}
