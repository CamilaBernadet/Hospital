using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EC;


namespace Persistencia
{
    public interface IPersistenciaSolicitud
    {
        void AltaSolicitud(Solicitud unaSol);

        void MarcarSinAsistir(Solicitud unaSol);
        List<Solicitud> ListarSolicitudes();
        List<Solicitud> ListarPorConsulta(Consulta unC);
        List<Solicitud> ListSinAsistir();

    }
}
