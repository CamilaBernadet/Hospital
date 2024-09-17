using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EC
{
   public class Solicitud
    {
       
        private int _NumeroInterno;
        private DateTime _FechaHora;
        private bool _Asistencia;

        //Atributos de relacion

        private Paciente _UnP;
        private Consulta _UnC;
        private Empleado _UnE;

        public int NumeroInterno
        {
            get { return _NumeroInterno; }

            set { _NumeroInterno = value; }
        }


        public DateTime FechaHora
        {
            get { return _FechaHora; }
            set
            {
              _FechaHora = value;
            }
        }
        

        public bool Asistencia
        {
            get { return _Asistencia; }
            set { _Asistencia = value; }
        }

        public Paciente UnP
        {
            get { return _UnP; }
            set
            {
                if (value == null)
                    throw new Exception("Debe existir un paciente");

                _UnP = value;
            }
        }
        public Consulta UnC
        {
            get { return _UnC; }
            set
            {
                if (value == null)
                    throw new Exception("Debe esxistir la consulta");

                _UnC = value;
            }
        }
        public Empleado UnE
        {
            get { return _UnE; }
            set
            {
                if (value == null)
                    throw new Exception("Debe Existir un Empleado");

                _UnE = value;
            }
        }

        public Solicitud(int sNumeroInterno, DateTime sFechaHora, bool sAsistencia, Paciente sUnP, Consulta sUnC, Empleado sUnE)
        {
            NumeroInterno = sNumeroInterno;
            FechaHora = sFechaHora;
            Asistencia = sAsistencia;
            UnP = sUnP;
            UnC = sUnC;
            UnE = sUnE;
        }
            
            
    }
}
