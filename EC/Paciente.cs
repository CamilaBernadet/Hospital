using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EC
{
   public class Paciente
    {
        private string _CiPaciente;
        private string _NombreCompleto;
        private DateTime _FechaNacimiento;

        //ASOC
        private List<Patologia> _Patologias;


        public string CiPaciente
        {
            get { return _CiPaciente; }

            set
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(value.Trim(), "[1-6]{1}[0-9]{7}"))
                {
                    _CiPaciente = value;
                }
                else
                {
                    throw new Exception("El CI debe tener 8 dígitos y comenzar con un número entre 1 y 6.");
                }
            }
        }

        public string NomCompleto
        {
            get { return _NombreCompleto; }
            set
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(value.Trim(), "[A-Za-z]{50}"))
                    throw new Exception("Debe ingresar el un Nombre Completo");
                else
                    _NombreCompleto = value;
            }
        }

        public DateTime FechaNacimiento
        {
            get { return _FechaNacimiento; }
            set
            {
                if (DateTime.Now >= value)
                    _FechaNacimiento = value;
                else
                    throw new Exception("La fecha de naciemiento no puede ser actual");
                
            }
        }

        public List<Patologia> Patologias
        {
            get { return _Patologias; }
            set 
            {
                    if (value == null)
                    throw new Exception("Error con la patologia");
                   else
                 _Patologias = value;
               
            }
            
        }

        //Constructor completo
        public Paciente(string pCiPaciente, string pNomCompleto, DateTime pFechaNacimiento, List<Patologia>  pPatologia)
        {
            CiPaciente = pCiPaciente;
            NomCompleto = pNomCompleto;
            FechaNacimiento = pFechaNacimiento;
            Patologias = pPatologia;
        }


        //OP
        public override string ToString()
        {
            return (this.NomCompleto);
        }
    }

   
}
