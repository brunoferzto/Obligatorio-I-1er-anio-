using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObligatorioII
{
    class TDebito:Tarjeta
    {
       
      
      private long cantcuentasaso;
      private  long saldodisponible;
    

      public  long Saldodisponible
        {
            get { return saldodisponible; }
            set { 
                if(value < 0 )
                    throw new Exception("Saldodisponible - Valor Incorrecto");
                else
                saldodisponible = value; 
            }
        
        }
      
        public long Cantcuentasaso
        {
            get { return cantcuentasaso; }
            set { 
                if(value < 0)
                    throw new Exception("Cuentas Asociadas - Valor Incorrecto");
                else
                cantcuentasaso = value; }

        }
       
        public TDebito(long num, long sald, string per, Cliente cli, long cuetas)
            : base(num, per, cli)
        {
            Saldodisponible = sald; 

            Cantcuentasaso = cuetas;

        }       
        
        public override string ToString()
        {
                                                                      
            return " T.Debito  : "+ base.ToString() + "\tSaldo disponible  : " + "$"  + saldodisponible + " \tCuentas asociadas : " + cantcuentasaso ; 
        }

        public override long Monto(long p)
        {
            return Saldodisponible = p + Saldodisponible;
           
           
        }

       
     


    }
}
