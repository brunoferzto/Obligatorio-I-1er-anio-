using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Obligatorio
{
    class Program
    {
        static int[,] GenerarJugadas()
        {


            Console.WriteLine();
            int[,] Jugadas = new int[5, 10];
            Random aleatorio = new Random();
            int valor = aleatorio.Next(1, 49);




            for (int fila = 0; fila < Jugadas.GetLength(0); fila++)
            {

                for (int columnas = 0; columnas < Jugadas.GetLength(1); columnas++)
                {

                    valor = aleatorio.Next(1, 49);

                    for (int a = 0; a < Jugadas.GetLength(0); a++)
                    {

                        if (valor == Jugadas[a, columnas])
                        {
                            bool VER = true;
                            while (VER)
                            {
                                if (valor == Jugadas[a, columnas])
                                {

                                    valor = aleatorio.Next(1, 49);
                                    a = 0;
                                }

                                else
                                {
                                    VER = false;

                                }

                            }

                        }

                    }

                    Jugadas[fila, columnas] = valor;


                }


            }
            Console.WriteLine("Se han generado las jugadas \n");
            Console.WriteLine("Presione Enter para seguir");
            Console.ReadLine();

            return Jugadas;
        }

        static void VerificarJugada(int[,] b)
        {





            int g = 0;
            int num;
            int[] Jugada = new int[5];

            for (int i = 0; i < Jugada.Length; i++)
            {
                bool tr = true;
                Console.Write("Ingrese un valor (1-48) : ");
                num = Convert.ToInt32(Console.ReadLine());

                if (num <= 0 || num > 48)
                {
                    Console.WriteLine("Valor incorrecto");
                    i--;
                    tr = false;
                }

                for (int a = 0; a < Jugada.Length; a++)
                {
                    if (num == Jugada[a])
                    {
                        Console.WriteLine("ERROR -  El " + num + " ya está en la jugada...");
                        i--;
                        tr = false;
                        a = 5;
                    }
                }

                while (tr)
                {
                    Jugada[i] = num;
                    tr = false;
                }

            }


            int contadornegativo = 0;

            for (int fila = 0; fila < b.GetLength(0); fila++)
            {

                for (int columnas = 0; columnas < b.GetLength(1); columnas++)
                {

                    bool bul = true;
                    int contador = 0;
                    int n = 0;
                    int verificar = Jugada[0];

                    contadornegativo++;

                    while (bul)
                    {



                        for (int f = 0; f < b.GetLength(0); f++, n++)
                        {


                            if (verificar == b[f, columnas])
                            {
                                if (contador <= b.GetLength(0))
                                {
                                    n = 0;
                                    contador++;

                                    if (contador == b.GetLength(0))
                                    {

                                        Console.WriteLine();
                                        Console.WriteLine("Su jugada está en los sorteos");
                                        f = b.GetLength(0);
                                        fila = b.GetLength(0);
                                        columnas = b.GetLength(1);
                                        bul = false;
                                        contadornegativo = 0;
                                        //g++;
                                    }



                                    else
                                        verificar = Jugada[contador];

                                }



                            }



                            if (n > b.GetLength(0))
                            {
                                f = b.GetLength(0);
                                bul = false;
                            }



                        }//fin del for verificar



                    }//fin while



                }//fin columnas






            }//fin filas


            if (g == 0)
            {
                Console.WriteLine("\n Su jugada no está en los sorteos");


            }


            Console.ReadLine();




        }

        static void ÚltimaJugada(int[,] c)
        {

            Console.WriteLine();

            int[] Jugadas = new int[5];
            for (int fila = 0; fila < c.GetLength(0); fila++)
            {

                for (int columnas = 0; columnas < c.GetLength(1); columnas++)
                {
                    if (columnas == c.GetLength(1) - 1)
                    {
                        Jugadas[fila] = c[fila, columnas];
                        Console.Write(Jugadas[fila] + "  ");
                    }



                }
            }

            Console.ReadLine();

        }

        static void ÚltimasJugadas(int[,] c)
        {

            Console.WriteLine();


            for (int fila = 0; fila < c.GetLength(0); fila++)
            {

                for (int columnas = 0; columnas < c.GetLength(1); columnas++)
                {
                    if (c[fila, columnas] != 0)

                        Console.Write(c[fila, columnas] + "\t");


                }



                Console.WriteLine();
            }
            Console.ReadLine();




        }

        static void Masorteados(int[,] c)
        {
            Console.WriteLine();
            int[] Vector = new int[50];
            int x = 0;


            for (int fila = 0; fila < c.GetLength(0); fila++)
            {

                for (int columnas = 0; columnas < c.GetLength(1); columnas++)
                {


                    Vector[x] = c[fila, columnas];
                    x++;

                }


            }


            int verificar = 0, contador = 0, maxima = 0, nmas = 0, t = 0, nuevalor = 0;
            bool w = true;

            verificar = Vector[t];

            while (w)
            {

                if (Vector[t] == verificar)
                {
                    contador++;

                    if (contador > maxima)
                    {
                        nmas = Vector[t];
                        maxima++;
                    }

                }


                if (verificar == Vector[49] && t == Vector.Length - 1)
                {

                    w = false;
                    Console.WriteLine("El número mas sorteado es el " + nmas + " en " + maxima + " jugadas");

                }

                else if (t == Vector.Length - 1)
                {
                    t = 0;
                    nuevalor++;
                    verificar = Vector[t + nuevalor];
                    contador = 0;


                }
                else
                    t++;

            }






            Console.ReadLine();

        }


        static void menú()
        {
            Console.Clear();
            Console.WriteLine("1 -Generar Jugadas \t");
            Console.WriteLine("2 -Últimos diez sorteos \t  ");
            Console.WriteLine("3 -Verificar Jugada ");
            Console.WriteLine("4 -Última Jugada Verificada");
            Console.WriteLine("5 -Número mas sorteado  ");
            Console.WriteLine("6 -Salir  ");

        }

        static void Main(string[] args)
        {
            //Bruno Fernandez - 4.822.009-4
            //Pablo Ledesma -   2.612.404-0

            int[,] Jugadas = new int[5, 10];

            int opción;
            bool salir = true;
            while (salir)
            {
                try
                {

                    menú();
                    Console.WriteLine();
                    Console.Write("Ingrese la opción desdeada : ");
                    opción = Convert.ToInt32(Console.ReadLine());

                    switch (opción)
                    {
                        case 1:

                            Jugadas = GenerarJugadas();
                            break;

                        case 2:
                            int[,] array = new int[5, 10];
                            array = Jugadas;
                            ÚltimasJugadas(array);






                            break;

                        case 3:

                            int[,] matriz = new int[5, 10];
                            matriz = Jugadas;
                            VerificarJugada(matriz);



                            break;

                        case 4:

                            int[,] vector = new int[5, 10];
                            vector = Jugadas;
                            ÚltimaJugada(vector);





                            break;
                        case 5:
                            int[,] arrayy = new int[5, 10];
                            arrayy = Jugadas;
                            Masorteados(Jugadas);

                            break;
                        case 6:
                            salir = false;
                            break;
                        default:
                            Console.WriteLine("Opción incorrecta ");
                            Console.ReadLine();
                            break;
                    }

                }
                catch
                {
                    Console.WriteLine("Error - Ingrese solo números");
                    Console.ReadLine(); 
                }
            }
        }
    }
}
