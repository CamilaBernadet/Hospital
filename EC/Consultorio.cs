using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 namespace EC
{
    public class Consultorio
    {
        
        private int _NumConsultorio;
        private string _Descripcion;
        private Policlinica _UnaPol; // Atributo de asociación

        public int NumConsultorio
        {
            get { return _NumConsultorio; }

            set {
                if (value > 0)
                    _NumConsultorio = value;
                else
                 throw new Exception("El número debe ser mayor a 0");

            }
        }

        public string Descripcion
        {
            get { return _Descripcion; }
            set
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(value.Trim(), "[A-Za-z]{100}"))
                    throw new Exception("Error - La descripción debe tener entre 1 y 100 caracteres.");
                _Descripcion = value.Trim(); 
            }
        }

        public Policlinica UnaPol
        {
            get { return _UnaPol; }
            set
            {
                if (value == null)
                    throw new Exception("Error - La policlínica no puede ser nula.");
               
                else
                    _UnaPol = value;

            }
        }

        
        public Consultorio(int cNumIConsultorio, string cDescripcion, Policlinica cUnaPol)
        {
            NumConsultorio = cNumIConsultorio; 
            Descripcion = cDescripcion;
            UnaPol = cUnaPol;
        }
        
    }
}
