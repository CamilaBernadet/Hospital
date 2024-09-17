using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EC;

namespace Persistencia
{
    public interface IPersistenciaEmpleado
    {
        void AltaEmpleado(Empleado unEmpleado);
        Empleado Logueo(string NomUsu, string PassUsu);
        Empleado Buscar(string NomUsu);
    }
}
