using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EC
{
    public class Empleado
    {
        private string _NomUsu;
        private string _PassUsu;


        public string NomUsu
        {
            get { return _NomUsu; }

            set
            {
                if ((value.Trim().Length != 8))
                    throw new Exception("Error - El Nombre de usuario tiene que tener 8 letras");
                else
                    _NomUsu = value;
            }
        }



        public string PassUsu
        {
            get { return _PassUsu; }

            set
            {

                if (System.Text.RegularExpressions.Regex.IsMatch(value, "[a-z]{3}[0-9]{3}"))
                    throw new Exception("Error la contraseñe tiene que tener 6 caracteres");
                else
                    _PassUsu = value;
            }
        }

        //Constructor Completo
        public Empleado(string eNomUsu, string ePassUsu)
        {
            NomUsu = eNomUsu;
            PassUsu = ePassUsu;
        }
    }
    }