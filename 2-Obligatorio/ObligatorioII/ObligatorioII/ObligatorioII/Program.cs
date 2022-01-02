using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObligatorioII
{
    class Program
    {
        static void Main(string[] args)
        {
            //Bruno Fernandez 4822009-4
            //Pablo Ledesma   2612404-0

            ColCliente ListaCliente = new ColCliente();
            Cliente cli;
            Colecciones ListaTarjetas = new Colecciones();
            Tarjeta tar;
            Pagos pag;

            DateTime fecha = DateTime.MinValue;
            string nombre, apellido, error = "", categoria = "", personalizada = ""; 
            long cedula = 0, telefono = 0, cueasociadas = 0, limitecredito = 0, numero = 0, saldodisponible = 0, money = 0;
            int opcion; 
            bool salir = true;
            
                while (salir)
                {
                    salir = true; 
                    try
                    {
                        error = "";
                        Console.WriteLine("");
                        Console.WriteLine("---------------------------------------------------------");
                        Console.WriteLine("                FINANCIERA");
                        Console.WriteLine("---------------------------------------------------------");
                        Console.WriteLine("\t 1 - Mantenimiento de Clientes");
                        Console.WriteLine("\t 2 - Solicitar Tarjeta de Crédito");
                        Console.WriteLine("\t 3 - Solicitar Tarjeta de Débito");
                        Console.WriteLine("\t 4 - Cargar Saldo / Realizar Pago");
                        Console.WriteLine("\t 5 - Listado de Clientes ");
                        Console.WriteLine("\t 6 - Listado de Tarjetas ");
                        Console.WriteLine("\t 7 - Listado de Pagos ");
                        Console.WriteLine("\t 8 - Salir ");
                        Console.WriteLine();
                        Console.Write("Ingrese opción : ");
                        opcion = Convert.ToInt32(Console.ReadLine());
                       
                        switch (opcion)
                        {
                            case 1:
                                try
                                {
                                    try
                                    {
                                        Console.Write("Ingrese la Cédula : ");
                                        cedula = Convert.ToInt64(Console.ReadLine());
                                    }
                                    catch
                                    {
                                        error = " - La Cédula es obligatoria \n"; 
                                    }

                                    cli = ListaCliente.Buscar(cedula);
                                    if (cli != null && error == "")
                                    {
                                        Console.WriteLine(); 
                                        Console.WriteLine(cli);
                                        Console.WriteLine(); 
                                        Console.WriteLine("1 - Eliminar Cliente");
                                        Console.WriteLine("2 - Salir");
                                        Console.Write("Ingrese opción : ");
                                        try
                                        {
                                            opcion = Convert.ToInt32(Console.ReadLine());
                                        }
                                        catch
                                        {
                                            error = error + "Debes elegir una opción"; 
                                        }
                                        if (error == "")
                                        {
                                            switch (opcion)
                                            {
                                                case 1:
                                                        ListaCliente.Eliminar(cedula);
                                                        ListaTarjetas.Eliminartodo(cedula);
                                                        Console.WriteLine();
                                                        Console.WriteLine("Cliente Eliminado");
                                                        Console.ReadLine();
                                                    break;

                                                case 2:
                                                   break;

                                                default:
                                                    Console.WriteLine(); 
                                                    Console.WriteLine("Opción Invalida");
                                                    Console.ReadLine(); 
                                                    break;
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine(" \n LISTADO DE ERRORES");
                                            Console.WriteLine();
                                            Console.WriteLine(error);
                                            Console.ReadLine();
                                            Console.Clear();
                                        }

                                    }

                                    else
                                    {
                                        Console.Write("Ingrese el Nombre : ");
                                        nombre = Console.ReadLine();
                                        if (nombre == "")
                                            error = error + " - El Nombre es obligatorio \n";

                                        Console.Write("Ingrese el Apellido : ");
                                        apellido = Console.ReadLine();
                                        if (apellido == "")
                                            error = error + " - El Apellido es obligatorio \n";



                                        try
                                        {
                                            Console.Write("Ingrese número Telefónico : ");
                                            telefono = Convert.ToInt64(Console.ReadLine());
                                        }
                                        catch
                                        {
                                            error = error + " - El Número de Telefono es obligatorio \n"; 
                                        }

                                        if (error != "")
                                        {
                                            
                                            Console.WriteLine(" \n LISTADO DE ERRORES");
                                            Console.WriteLine();
                                            Console.WriteLine(error);
                                            Console.ReadLine();
                                            Console.Clear();
                                        }
                                        else
                                        {
                                            cli = new Cliente(nombre, apellido, cedula, telefono);

                                            if (ListaCliente.Agregar(cli))
                                            {
                                                Console.WriteLine("Se agregó el cliente");
                                                Console.ReadLine();
                                                Console.Clear();
                                            }
                                        }
                                    }
                                }
                                catch (Exception m)
                                {
                                    Console.WriteLine(m.Message);
                                    Console.ReadLine();
                                }
                                Console.Clear();
                                break;

                            case 2:                               
                                       try
                                            {
                                                try
                                                {
                                                    Console.Write("Ingrese la cédula : ");
                                                    cedula = Convert.ToInt64(Console.ReadLine());
                                                }
                                                catch
                                                {
                                                    error = error + " - Debe ingresar la cédula\n";
                                                }
                                                    cli = ListaCliente.Buscar(cedula);


                                    if (cli != null && error == "")
                                    {
                                        Console.WriteLine(cli);
                                        Console.WriteLine();
                                        Console.WriteLine("¿Tarjeta Personalizada?");
                                        Console.WriteLine("1 - SI");
                                        Console.WriteLine("2 - NO");
                                        Console.Write("Ingrese la opción deseada : ");
                                        try
                                        {
                                            opcion = Convert.ToInt32(Console.ReadLine());
                                        }
                                        catch
                                        {
                                            error = error + " - Debe elegir una opción\n";
                                        }
                                        if (opcion <= 0 || opcion > 2)
                                        {
                                            error = " - Opción incorrecta\n ";
                                        }
                                        switch (opcion)
                                        {
                                            case 1:
                                                personalizada = "Si";
                                                break;
                                            case 2:
                                                personalizada = "No";
                                                break;
                                        }

                                        Console.WriteLine();
                                        Console.WriteLine("Categoría de su tarjeta : ");
                                        Console.WriteLine("1 - Clásica");
                                        Console.WriteLine("2 - Plata");
                                        Console.WriteLine("3 - Oro");
                                        Console.WriteLine("4 - Platinium");
                                        Console.Write("Ingrese la opción deseada : ");
                                        try
                                        {
                                        opcion = Convert.ToInt32(Console.ReadLine());
                                        }
                                        catch
                                        {
                                            error = error + " - Debe elegir una categoría\n";
                                        }
                                        if (opcion <=0 || opcion > 4)
                                        {
                                            error = error + "- Error al elegir la categoría de la tarjeta\n"; 
                                        }
                                            switch (opcion)
                                            {
                                                case 1:
                                                    categoria = "Clásica";
                                                    break;
                                                case 2:
                                                    categoria = "Plata";
                                                    break;
                                                case 3:
                                                    categoria = "Oro";
                                                    break;
                                                case 4:
                                                    categoria = "Platinium";
                                                    break;
                                            }

                                            Console.WriteLine();

                                            try
                                            {
                                                Console.Write("Ingrese el límite de Crédito : ");
                                                limitecredito = Convert.ToInt64(Console.ReadLine());
                                            }
                                            catch
                                            {
                                                error = error + " - Debes ingresar un límite de saldo"; 
                                            }

                                            if (error == "")
                                            {
                                                tar = new TCredito(limitecredito, categoria, numero, personalizada, cli);

                                                if (ListaTarjetas.Agregar(tar))
                                                {
                                                    ListaTarjetas.ContarClientes(cli);
                                                    Console.WriteLine();
                                                    Console.WriteLine(tar);
                                                    Console.ReadLine();

                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine(" \n LISTADO DE ERRORES");
                                                Console.WriteLine();
                                                Console.WriteLine(error);
                                                Console.ReadLine();
                                                Console.Clear();
                                            }
                                        }                                   
                                    else if(error == "")
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine("No se encontró ningún cliente");
                                        Console.ReadLine();
                                    }
                                    else
                                    {
                                        Console.WriteLine(" \n LISTADO DE ERRORES");
                                        Console.WriteLine();
                                        Console.WriteLine(error);
                                        Console.ReadLine();
                                        Console.Clear();
                                    }

                                            }
                                       catch (Exception lmcredto)
                                       {
                                           Console.WriteLine(); 
                                           Console.WriteLine(lmcredto.Message);
                                           Console.ReadLine();
                                       }
                                  
                                    Console.Clear();
                                    
                                break;

                            case 3:
                                try
                                {
                                    Console.Write("Ingrese la cedula :");
                                    try
                                    {
                                        cedula = Convert.ToInt64(Console.ReadLine());
                                    }
                                    catch
                                    {
                                        error = " - Debes ingresar la cédula\n"; 
                                    }
                                    cli = ListaCliente.Buscar(cedula);

                                    if (cli != null && error == "")
                                    {
                                        Console.WriteLine(cli);
                                        Console.WriteLine();
                                        Console.WriteLine("¿Tarjeta Personalizada?");
                                        Console.WriteLine("1 - SI");
                                        Console.WriteLine("2 - NO");
                                        Console.Write("Ingrese la opción deseada : ");
                                        try
                                        {
                                            opcion = Convert.ToInt32(Console.ReadLine());
                                        }
                                        catch
                                        {
                                            error = error + " - Debe elegir una opción\n";
                                        }
                                        if (opcion <= 0 || opcion > 2)
                                        {
                                            error = error + " - Error al decidir sobre Tarjeta Personalizada\n ";
                                        }
                                        switch (opcion)
                                        {
                                            case 1:
                                                personalizada = "Si";
                                                break;
                                            case 2:
                                                personalizada = "No";
                                                break;
                                        }
                                        try
                                        {
                                            Console.WriteLine();
                                            Console.Write("Ingrese la cantidad de Cuentas Asociadas : ");
                                            cueasociadas = Convert.ToInt64(Console.ReadLine());
                                        }
                                        catch
                                        {
                                            error = error + " - Debe ingresar la información solicitada\n";
                                        }

                                        try
                                        {
                                            Console.WriteLine();
                                            Console.Write("Ingrese el Saldo Disponible : "); //Para usar el constructor completo.
                                            saldodisponible = Convert.ToInt64(Console.ReadLine());
                                        }
                                        catch
                                        {
                                            error = error + " - Debe ingresarse el Saldo Disponible\n";
                                        }
                                        if (error == "")
                                        {
                                            tar = new TDebito(numero, saldodisponible, personalizada, cli, cueasociadas);
                                            if (ListaTarjetas.Agregar(tar))
                                            {
                                                ListaTarjetas.ContarClientes(cli);
                                                Console.WriteLine();
                                                Console.WriteLine(tar);
                                                Console.ReadLine();

                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine(" \n LISTADO DE ERRORES");
                                            Console.WriteLine(); 
                                            Console.WriteLine(error);
                                            Console.ReadLine();
                                            Console.Clear();

                                        }

                                    }
                                    else if (error == "")
                                    {
                                        Console.WriteLine(); 
                                        Console.WriteLine("No se encontró ningún Cliente");
                                        Console.ReadLine();
                                    }

                                    else
                                    {
                                        Console.WriteLine(" \n LISTADO DE ERRORES");
                                        Console.WriteLine();
                                        Console.WriteLine(error);
                                        Console.ReadLine();
                                        Console.Clear();
                                    }
                                }
                                catch (Exception m)
                                {
                                    Console.WriteLine(); 
                                    Console.WriteLine(m.Message);
                                    Console.ReadLine();
                                }
                                Console.Clear();
                                break;

                            case 4:
                                try
                                {
                                    
                                    try
                                    {
                                        Console.Write("Ingrese su cédula :");
                                        cedula = Convert.ToInt64(Console.ReadLine());
                                    }
                                    catch
                                    {
                                        error = " - Debes ingresar la cédula";
                                    }

                                    cli = ListaCliente.Buscar(cedula);
                                    if (error == "")
                                    {
                                        Console.WriteLine(cli);
                                        Console.WriteLine();
                                    }
                                    if (cli != null && error == "")
                                    {
                                        int n = 0;

                                        while (n < ListaTarjetas.Contar)
                                        {

                                            tar = ListaTarjetas.Tarcliente(cedula, n);
                                          
                                            if (tar != null)
                                            {
                                                Console.WriteLine(tar);
                                            }
                                            n++;

                                        }

                                        Console.WriteLine();
                                        try
                                        {
                                            Console.Write("Ingrese el Número de Tarjeta :");
                                            numero = Convert.ToInt64(Console.ReadLine());
                                        }
                                        catch
                                        {
                                            error = error + " - Debe ingresar un Número de Tarjeta\n";
                                        }

                                        tar = ListaTarjetas.Buscar(numero);


                                        if (tar != null && error == "")
                                        {
                                            if (tar.Comparar(cedula))
                                            {

                                                if (tar is TCredito)
                                                {
                                                    try
                                                    {
                                                        Console.WriteLine();
                                                        Console.Write("Ingese la fecha actual :");
                                                        fecha = Convert.ToDateTime(Console.ReadLine());
                                                    }
                                                    catch
                                                    {
                                                        error = error + " - Debe Ingresar la fecha\n";
                                                    }
                                                    try
                                                    {
                                                        Console.WriteLine();
                                                        Console.Write("Ingese el monto a pagar :");
                                                        money = Convert.ToInt64(Console.ReadLine());
                                                    }
                                                    catch
                                                    {
                                                        error = error + " - Debe ingresar un monto\n";
                                                    }



                                                    if (error == "")
                                                    {
                                                        ListaTarjetas.MontoDinero(numero, money);
                                                        pag = new Pagos(fecha, tar, money);
                                                        ListaTarjetas.Agregarpagos(pag);
                                                        Console.WriteLine();
                                                        Console.Write("Pago realizado con exito");
                                                        Console.ReadLine();

                                                        if (money > limitecredito)
                                                        {
                                                            Console.WriteLine("NI"); 
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine(" \n LISTADO DE ERRORES");
                                                        Console.WriteLine();
                                                        Console.WriteLine(error);
                                                        Console.ReadLine();
                                                        Console.Clear();
                                                    }
                                                }
                                                else//ES DÉBITO
                                                {
                                                    try
                                                    {
                                                        Console.Write("Ingese el Dinero a Cargar :");
                                                        money = Convert.ToInt64(Console.ReadLine());
                                                        if (money <= 0)
                                                        {
                                                            error = error + "La cifra ingresada es incorrecta : ";
                                                        }
                                                    }
                                                    catch
                                                    {
                                                        error = "Debe ingresar un monto ";
                                                    }
                                                    if (error == "")
                                                    {
                                                        ListaTarjetas.MontoDinero(numero, money);
                                                        Console.Write("Se ha cargado con exito el dinero en su tarjeta");
                                                        Console.ReadLine();
                                                    }

                                                    else
                                                    {
                                                        Console.WriteLine(" \n LISTADO DE ERRORES");
                                                        Console.WriteLine();
                                                        Console.WriteLine(error);
                                                        Console.ReadLine();
                                                        Console.Clear();
                                                    }
                                                }

                                            }
                                           


                                           

                                            else if (error != "")
                                            {
                                                Console.WriteLine(" \n LISTADO DE ERRORES");
                                                Console.WriteLine();
                                                Console.WriteLine(error);
                                                Console.ReadLine();
                                                Console.Clear();

                                            }

                                            else 
                                            {
                                                Console.WriteLine("La Tarjeta no pertenece al Cliente ");
                                                Console.ReadLine();
                                            }
                                           
                                        }

                                        else if (tar == null)
                                        {
                                            Console.WriteLine("\nDebe ingresar el número de una tarjeta registarada anteriormente");
                                            Console.ReadLine();
                                        }

                                       
                                    }
                                    else if (error != "")
                                    {
                                        Console.WriteLine(" \n LISTADO DE ERRORES");
                                        Console.WriteLine();
                                        Console.WriteLine(error);
                                        Console.ReadLine();
                                        Console.Clear();

                                    }
                                    else
                                    {
                                        Console.WriteLine("\nLa cedula no corresponde a ningun cliente");
                                        Console.ReadLine();
                                        Console.Clear();
                                    }
                                }
                                catch (Exception nue)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine(nue.Message);
                                    Console.ReadLine();
                                }
                                Console.Clear(); 
                                    break;
                               

                            case 5:
                                if (ListaCliente.Contar == 0)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("  NO HAY CLIENTES REGISTRADOS");
                                }
                                else
                                {
                                    Console.WriteLine();
                                    ListaCliente.Ordenar(); 
                                    for (int i = 0; i < ListaCliente.Contar; i++)
                                    {
                                        Console.WriteLine(ListaCliente[i].ToString());
                                    }
                                    
                                }
                                Console.ReadLine();
                                Console.Clear();
                                break;

                            case 6:
                                
                                if (ListaTarjetas.Contar == 0)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("  NO HAY TARJETAS REGISTRADAS");
                                }
                                Console.WriteLine();

                                 for (int t = 0; t < ListaTarjetas.Contar; t++)
                                {
                                    Console.WriteLine(ListaTarjetas[t].ToString());
                                }
                                Console.ReadLine();
                                Console.Clear();
                                break;
                            case 7:
                                int j = 0;
                                int cont = 0; 
                                try
                                {
                                    Console.Write("Ingrese el número de tarjeta : ");
                                    numero = Convert.ToInt64(Console.ReadLine());
                                }
                                catch
                                {
                                    error = error + "Debes ingresar un número"; 
                                }
                                
                                    tar = ListaTarjetas.Buscar(numero);
                                    Console.WriteLine();

                                    if (tar != null && tar is TCredito && error == "")
                                    {
                                        while (j < ListaTarjetas.Contarlas)
                                        {
                                            pag = ListaTarjetas.Listapagos(tar, j);
                                            if (pag != null)
                                            {
                                                Console.WriteLine(pag);
                                                cont++; 
                                            }
                                           
                                            j++;

                                            if (j == ListaTarjetas.Contarlas && cont == 0)
                                            {
                                                Console.WriteLine();
                                                Console.WriteLine("No hay pagos de la tarjeta ingresada");
                                                Console.ReadLine();
                                            }
                                        }
                                        Console.ReadLine();
                                        
                                        
                                    }
                                        
                                    
                                
                                else if (tar is TDebito)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("NO EXISTEN PAGOS DE TARJETAS DE DÉBITO");
                                    Console.ReadLine(); 
                                }

                                    else if (error != "")
                                    {
                                        Console.WriteLine(" \n LISTADO DE ERRORES");
                                        Console.WriteLine();
                                        Console.WriteLine(error);
                                        Console.ReadLine();
                                        Console.Clear();

                                    }

                                    else
                                    {
                                        Console.WriteLine("\n El número ingresado no corresponde a una tarjeta");
                                        Console.ReadLine();
                                        Console.Clear();
                                    }
                                    Console.Clear(); 
                                break;

                            case 8:
                                salir = false;
                                break;
                            default:
                               
                                Console.WriteLine(" OPCIÓN INCORRECTA");
                                Console.ReadLine();
                                Console.Clear(); 
                                break;                               

                        }//fin de witch case                   
                    }
                    catch
                    {
                        Console.Clear(); 
                    }
                   
                }//fin del while
            
           
            }
            
        }
    }

