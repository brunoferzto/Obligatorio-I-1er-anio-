using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObligatorioII
{
    class Colecciones
    {
        List<Tarjeta> listas;
        List<Pagos> pagoslis;

        public Colecciones()
        {
            listas = new List<Tarjeta>();
            pagoslis = new List<Pagos>();
        }



        public Tarjeta Buscar(long num)
        {
            Tarjeta TarBusca = null;

            for (int i = 0; i < listas.Count; i++)
            {
                if (num == listas[i].Numero)
                {
                    TarBusca = listas[i];


                }
            }
            return TarBusca;

        }



        public bool Eliminartodo(long ced)
        {
            bool tEliminado = false;
            int i = 0;
            while (i < listas.Count)
            {
                if (listas[i].Comparar(ced))
                {
                    if (listas[i] != null && pagoslis.Count != 0)
                    {
                        if (pagoslis[i].Tarj == listas[i])
                        {
                            pagoslis.RemoveAt(i);
                        }
                    }
                    listas.RemoveAt(i);
                    tEliminado = true;
                    i = 0;

                }
                else
                    i++;

            } return tEliminado;
        }

        public Tarjeta Tarcliente(long c, int n)
        {
            Tarjeta tj = null;

            int p = 0;
            p = p + n;

            while (p >= n)
            {

                if (listas[n].Comparar(c))
                {

                    tj = listas[n];

                    n = listas.Count;
                }

                else
                    n++;

            }
            return tj;
        }



        public void MontoDinero(long num, long money)
        {

            Tarjeta p = Buscar(num);
            p.Monto(money);

        }



        public int Contar
        {
            get
            {
                return listas.Count;

            }
        }



        public bool Agregar(Tarjeta e)
        {

            bool oAgregar = true;
            listas.Add(e);
            return oAgregar;
        }


        public void ContarClientes(Cliente cli)
        {
            cli.Contartarjetas(cli);
        }



        public Tarjeta this[int pPosicion]
        {
            get
            {
                if (pPosicion < 0 || pPosicion >= listas.Count)
                {
                    return null;
                }
                else
                {
                    return listas[pPosicion];
                }
            }
        }


        public List<Tarjeta> Lista()
        {
            return listas;
        }

        ////////////////////////////////////////////////////////////////////////////////

        public bool Agregarpagos(Pagos e)
        {

            bool Agrego = true;
            pagoslis.Add(e);
            return Agrego;
        }

        public int Contarlas
        {
            get
            {
                return pagoslis.Count;

            }
        }

        public Pagos Listapagos(Tarjeta c, int n)
        {
            Pagos tj = null;
            int p = 0;
            p = p + n;

            while (p >= n)
            {
                if (pagoslis[n].Tarj == c)
                {
                    tj = pagoslis[n];
                    n = pagoslis.Count;
                }
                else
                    n++;
            }
            return tj;
        }

        public List<Pagos> Pagolista()
        {
            return pagoslis;
        }

    }
}
