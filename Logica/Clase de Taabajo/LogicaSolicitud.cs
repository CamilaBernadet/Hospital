using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Persistencia;
using EC;


namespace Logica
{
    internal class LogicaSolicitud : ILogicaSolicitud
    {
        private static LogicaSolicitud _instancia = null;
        private LogicaSolicitud() { }
        public static LogicaSolicitud GetInstancia()
        {
            if (_instancia == null)
                _instancia = new LogicaSolicitud();
            return _instancia;
        }

        //operaciones
        public void AltaSolicitud(Solicitud unaS)
        {
            FabricaPersistencia.GetPersistenciaSolicitud().AltaSolicitud(unaS);
        }

        public void MarcarSinAsistir(Solicitud unaSol)
        {
            FabricaPersistencia.GetPersistenciaSolicitud().MarcarSinAsistir(unaSol);
        }

        public List<Solicitud> ListarSolicitudes()
        {
            return Persistencia.FabricaPersistencia.GetPersistenciaSolicitud().ListarSolicitudes();
        }

        public List<Solicitud> ListarPorConsulta(Consulta unC)
        {
            return Persistencia.FabricaPersistencia.GetPersistenciaSolicitud().ListarPorConsulta(unC);
        }

        public List<Solicitud> ListSinAsistir()
        {
            return Persistencia.FabricaPersistencia.GetPersistenciaSolicitud().ListSinAsistir();
        }


    }
}
