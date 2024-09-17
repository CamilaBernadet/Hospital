using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EC
{
   public class Policlinica
    {
        private string _Codigo;
        private string _Nombre;
        private string _Direccion;

        public string Codigo
        {
            get { return _Codigo;}

            set {

                if (System.Text.RegularExpressions.Regex.IsMatch(value.Trim(), "[A-Za-z]{6}"))
                    _Codigo = value;
                else
                  throw new Exception("Error - el código debe tener exactamente 6 letras.");
               
              

            }
        }


        public string Nombre
        {
            get { return _Nombre; }
            set {
                if (System.Text.RegularExpressions.Regex.IsMatch(value.Trim(), "[A-Za-z0-9]{20}"))
                    throw new Exception("Error - DEbe ingresar un nombre");
                else
                            _Nombre = value;
                
               

                }
        }


        public string Direccion
        {
            get { return _Direccion; }

            set {
                    if (System.Text.RegularExpressions.Regex.IsMatch(value.Trim(), "[A-Za-z0-9]{5,50}"))
                    _Direccion = value;
                else
                    
                throw new Exception("Error - Al ingresaar la Direccion de la Policlinica");
            }
        }


        public Policlinica (string pCodigo, string pNombre, string pDireccion)
        {
            Codigo = pCodigo;
            Nombre = pNombre;
            Direccion = pDireccion;
        }

        public override string ToString()
        {
            return (this.Codigo.Trim() + Direccion + "-");
        }
    }
       
}
