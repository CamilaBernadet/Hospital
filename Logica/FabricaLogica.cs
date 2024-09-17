using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class FabricaLogica
    {
        public static ILogicaEmpleado GetLogicaEmpleado()
        {
            return (LogicaEmpleado.GetInstancia());
        }

        public static ILogicaConsulta GetLogicaConsulta()
        {
            return (LogicaConsulta.GetInstancia());

        }


        public static ILogicaPoliclinica GetLogicaPoliclinica()
        {
            return (LogicaPoliclinica.GetInstancia());
        }

        public static ILogicaConsultorio GetLogicaConsultorio()
        {
            return (LogicaConsultorio.GetInstancia());
        }

        public static ILogicaPaciente GetLogicaPaciente()
        {
            return (LogicaPaciente.GetInstancia());
        }

        public static ILogicaSolicitud GetLogicaSolicitud()
        {
            return (LogicaSolicitud.GetInstancia());
        }



    }
}
