using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObligatorioII
{
    public  class Cliente
    {

        private long cantidad; 
        private string nombre;
        private string apellido;
        private long cedula;
        private long telefono;
       

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
       }

        

        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }

        public  long Cedula
        {
           get { return cedula; }

          set
            {
                if(Convert.ToString(value).Length != 7)
                    throw new Exception("La cédula debe tener 7 caracteres");
                else
                    cedula = value;
            }
         }

        public long Telefono
        {
            get { return telefono; }
            set
            {
                if (Convert.ToString(value).Length < 8 || Convert.ToString(value).Length > 9)
                    throw new Exception("El Número Telefónico debe contener 8 o 9 dígitos");
                else
                    telefono = value;
            }
            
        }

        public long Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        
          
          public Cliente(string nom, string ape, long ced, long tel) 
          {
              nombre = nom;
              apellido = ape;
              Cedula = ced; 
              Telefono = tel;
              Cantidad = cantidad; 
              
          
          }

     
         public override string ToString()
          {
              return nombre + "\t\t" + apellido + "\t\t" + cedula + "\t\t" + telefono  + "\t Cantidad de Tarjetas : " + Cantidad;
          }

        

         public virtual long Contartarjetas(Cliente c)
         {
             if (c.cedula == cedula)
                 return  cantidad = cantidad + 1;
             else
                 return cantidad;
                
         }
    }
}
