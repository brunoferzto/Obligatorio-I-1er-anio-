using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObligatorioII
{
    class Pagos
    {
     private  DateTime fecha;
       Tarjeta tarj;
      private long monto;


      public DateTime Fecha
      {
          get
          { return fecha; }

          set {
              if(value != DateTime.Today)
                  throw new Exception("Debe ingresar la fecha actual");
              else
              fecha = value; }

      }

      public Tarjeta Tarj
      {
          set
          {
              if (value == null)
                  throw new Exception("Tarjeta inexistente");
              else
                  tarj = value;
          }
          get { return tarj; }

      }

      public long Monto
      {
          get { return monto; }
          set {
              if(value < 0 )
                  throw new Exception("Monto de Pago - Valor Incorrecto");
              else
              monto = value; }

      }

      public Pagos(DateTime n, Tarjeta t, long m)
      {
          Fecha = n;
          Tarj = t;
          Monto = m; 

      }


      public override string ToString()
      {

          return ("Monto : " +monto + "\tFecha : "+fecha.ToShortDateString());  

      }
    }
}
