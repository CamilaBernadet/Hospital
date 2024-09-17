using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EC
{
    public class Consulta
    {
        private int _NumConsulta;
        private DateTime _FechaHoraConsulta;
        private int _CanConsulta;
        private string _MedicoNombre;
        private string _Especialidad;
       
        

        // Atributo de relación
        private Consultorio _UnConsultorio;
        

        public int NumConsulta
        {
            get { return _NumConsulta; }
            set { _NumConsulta = value; }
        }

        public string MedicoNombre
        {
            get { return _MedicoNombre; }
            set
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(value.Trim(), "[A-Za-z]{30}"))
                    throw new Exception("Error - Debe ingresar un nombre de médico válido que no sobrepase los 20 caracteres.");
                _MedicoNombre = value.Trim(); 
            }
        }

        public string Especialidad
        {
            get { return _Especialidad; }
            set
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(value.ToUpper(), "[A-Za-z]{50}"))
                    throw new Exception("Error - Debe ingresar un nombre de especialidad válido que no sobrepase los 25 caracteres.");
                _Especialidad = value.Trim(); 
            }
        }

        public DateTime FechaHoraConsulta
        {
            get { return _FechaHoraConsulta; }
            set { _FechaHoraConsulta = value; }
        }

        public int CanConsulta
        {
            get { return _CanConsulta; }
            set
            {
                if (value < 0 || value > 20)
                    throw new Exception("Error - La cantidad de consultas no puede exceder 20.");
                _CanConsulta = value;
            }
        }

        public Consultorio UnConsultorio
        {
            get { return _UnConsultorio; }
            set
            {
                if (value == null)
                    throw new Exception("El consultorio debe existir");

                _UnConsultorio = value;
            }
        }



        public Consulta(int cNumConsulta, DateTime cFechaHoraConsulta, int cCanConsulta, string cMedicoNombre, string cEspecialidad,  Consultorio cUnConsultorio)
        {
            NumConsulta = cNumConsulta;
            FechaHoraConsulta = cFechaHoraConsulta;
            CanConsulta = cCanConsulta;
            MedicoNombre = cMedicoNombre;
            Especialidad = cEspecialidad;
            UnConsultorio = cUnConsultorio;
            
        }
    }
}
