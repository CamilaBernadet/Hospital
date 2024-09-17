using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EC;
namespace Persistencia 
{
    public interface IPersistenciaConsulta
    {
        void AltaConsulta(Consulta unaConsulta);
        Consulta BuscarConsulta(int numCons);
        List<Consulta> ListarConsulta();
        List<Consulta> ListarConsultaAFuturo();


    }
}
