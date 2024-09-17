using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Persistencia;
using EC;

namespace Logica
{
   public interface ILogicaSolicitud
    {
        void AltaSolicitud(Solicitud unaS);
        void MarcarSinAsistir(Solicitud unaSol);
        List<Solicitud> ListarSolicitudes();
        List<Solicitud> ListarPorConsulta(Consulta unC);
        List<Solicitud> ListSinAsistir();

    }
}
