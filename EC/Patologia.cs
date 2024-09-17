using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EC
{
  public  class Patologia
    {
        private string _Patologia;




        public string patologia
        {
            get { return _Patologia; }
            set
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(value, "^.{0,50}$"))
                {
                    throw new ArgumentException("El total de caracteres no puede exceder los 50.");
                }

                _Patologia = value;
            }

        }



        public Patologia(string pPatologia)
        {  
           patologia = pPatologia;
        }
    }

    }

