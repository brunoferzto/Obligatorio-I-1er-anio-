using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObligatorioII
{
     class ColCliente
    {
        List<Cliente> lista;
        


        public ColCliente()
        {
            lista =  new List<Cliente>();
        }

        public int Contar
        {
            get
            {
                return lista.Count;
            }
        }

        public bool Agregar(Cliente e)
        {
            bool oAgregar = true;
            lista.Add(e);
            return oAgregar;
        }

         public Cliente Buscar(long ced)
        {
            Cliente cBuscado = null;
    
            for (int i = 0; i < lista.Count; i++)
            {
                if (ced == lista[i].Cedula)
                {
                    
                    cBuscado = lista[i];
                    
                }
            }
            return cBuscado;
         }

          public void  Ordenar()
         {
             Cliente swapp = null; 
             for (int iP = 0; iP < lista.Count; iP++)
             {
                 for (int iR = lista.Count - 1; iR > iP; iR--)
                 {
                     if (lista[iR].Nombre.CompareTo(lista[iR - 1].Nombre) < 0)
                     {                      
                         swapp = lista[iR]; 
                         lista[iR] = lista[iR - 1];
                         lista[iR - 1] = swapp;                        
                     }
                 }                
             }                  
         }

        public bool Eliminar(long  ced)
         {
             bool cliEliminado = false;
             for (int i = 0; i < lista.Count; i++)
             {
                 if (ced == lista[i].Cedula)
                 {
                     lista.RemoveAt(i);
                     cliEliminado = true;
                 }
             } return cliEliminado;
         }

        public Cliente this[int pPosicion] 
        {
            get
            {
                if (pPosicion < 0 || pPosicion >= lista.Count)
                {
                    return null;
                }
                else
                {
                    return lista[pPosicion];
                }

                  
            }
        }
    }
}
