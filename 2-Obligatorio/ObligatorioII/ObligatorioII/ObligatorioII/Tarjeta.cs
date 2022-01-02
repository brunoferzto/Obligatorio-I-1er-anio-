using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObligatorioII
{
      abstract class Tarjeta
    {
         
        private string personalizada;
        static long contador = 1000;
       private long numero;

        Cliente clente;


        public  long Numero
        {
            get { return numero; }

            set { numero = value; }
        }

        public static long Contador
        {
            get { return contador; }

        }        

        public string Personalizada
        {
            get { return personalizada; }
            set { personalizada = value; }
        }


        public Cliente Clente
        {
            set
            {Clente = value;}
            get { return Clente; }

        }


       
        
     
       
        public Tarjeta(long num, string per, Cliente cli)
        {
            contador++;
            numero = contador; 
            Personalizada = per;
            clente = cli;  
       
        }

        public override string ToString()
        {
        
        return("Numero: " +numero+"  " +"¿Personalizada? : " +personalizada +""); 
        
        }

        public abstract long Monto(long p); 


        public  bool Comparar(long c)
        {
            return c == clente.Cedula;
        }

      
      
    }
}
