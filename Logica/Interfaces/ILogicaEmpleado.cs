using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EC;

namespace Logica
{
   public interface ILogicaEmpleado
    {

        Empleado Logueo(string NomUSu, string PassUsu);
        void AltaEmpleado(Empleado unE);
        Empleado BuscarEmpleado(string unE);
    }

   
}
