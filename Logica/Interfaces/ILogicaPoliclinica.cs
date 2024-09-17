using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EC;

namespace Logica
{
    public interface ILogicaPoliclinica
    {
        List<Policlinica> ListarPoliclinica();

        Policlinica BuscarPoliclinica(string unP);

        void AltaPoliclinica(Policlinica unPol);

    }
}
