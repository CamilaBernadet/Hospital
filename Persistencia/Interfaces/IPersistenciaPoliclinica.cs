using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EC;

namespace Persistencia
{
   public interface IPersistenciaPoliclinica
    {
        void AltaPoliclinica(Policlinica unPol);

        Policlinica BuscarPoliclinica(string unP);

        List<Policlinica> ListarPoliclinica();

    }
}
