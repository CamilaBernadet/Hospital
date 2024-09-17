using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EC;

namespace Logica
{
   public interface ILogicaConsulta 
    {
        List<Consulta> ListarConsulta();

        List<Consulta> ListarConsultaAFuturo();

        void AltaConsulta(Consulta unC);

        Consulta BuscarConsulta(int unC);
    }
}
