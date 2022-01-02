using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObligatorioII
{
    class TCredito:Tarjeta
    {
        private long limitecredito;
        private string categoria;


        public long Limitedecredito
        {
            get { return limitecredito; }
            set { 
                if(value < 0)
                    throw new Exception("Límite de crédito - Valor Incorrecto");
                else
                limitecredito = value;
            
            }

        }
         
        public string Categoria
        {
            get { return categoria; }
            set { categoria = value; }

        }

       
          public TCredito(long limi, string ca,  long num, string per, Cliente cli) 
            :base(num,per,cli) 
        {



            Limitedecredito = limi;
            categoria = ca; 
          
        
}

        public override string ToString()
        {
            return " T.Crédito : " + base.ToString() + "\tLímite de Crédito : " + "$" + Limitedecredito + "\tCategoría : " + categoria; 
        }

        public override long Monto(long p)
        {
            if (p < Limitedecredito) 
                return Limitedecredito = Limitedecredito - p;
            else
                return Limitedecredito = 0; 
        }

     
       
    }
}
