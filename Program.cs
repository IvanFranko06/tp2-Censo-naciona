using System.Collections.Generic;
using System.Globalization;
namespace tp2
{
    class Program
    {
        static void Main()
        {
            Dictionary<int, Persona> dicPersona = new Dictionary<int, Persona>();
            int opcion;
            opcion = menu();
            while (opcion != 5)
            {

                switch (opcion)
                {

                    case 1:
                        cargarPersona();
                        break;
                    case 2:
                        mostrarEstadisticas();
                        break;
                    case 3:
                        buscarPersona();
                        break;
                    case 4:
                        modificarMail();
                        break;
                }







                opcion = menu();

            }


            void modificarMail()
            {
                Console.Clear();
                string mailNvo;
                Persona modificar;
                System.Console.WriteLine("ingrese el DNI de la persona que desea modificar");
                int dni = int.Parse(Console.ReadLine());
                modificar = buscar(dni);
                if (modificar != null)
                {
                    System.Console.WriteLine("ingrese el mail nuevo (el mail anterior era: {0})", modificar.Mail);
                    mailNvo = Console.ReadLine();
                    modificar.Mail = mailNvo;
                    System.Console.WriteLine("el nuevo mail es: {0}", modificar.Mail);
                }
                else
                {
                    System.Console.WriteLine("No se encontro el dni");
                }
                System.Console.WriteLine("presiona enter para volver");
                 Console.ReadLine();

            }


            Persona buscar(int dni)
            {
                Persona dniEncontrado = null;

                if (dicPersona.ContainsKey(dni))
                {
                    dniEncontrado = dicPersona[dni];
                }
                return dniEncontrado;

            }






            void buscarPersona()
            {
                Console.Clear();
                Persona perEncontrada;
                System.Console.WriteLine("ingrese el DNI de la persona que desea buscar");
                int buscador = int.Parse(Console.ReadLine());
                perEncontrada = buscar(buscador);
                if (perEncontrada != null)
                {

                    System.Console.WriteLine("Nombre: " + perEncontrada.Nombre);
                    System.Console.WriteLine("Apellido: " + perEncontrada.Apellido);
                    System.Console.WriteLine("DNI: " + perEncontrada.DNI);
                    System.Console.WriteLine("Mail: " + perEncontrada.Mail);
                    System.Console.WriteLine("Fecha de nacimiento: " + perEncontrada.FechaNac);
                    System.Console.WriteLine("Edad: " + perEncontrada.ObtenerEdad());
                    System.Console.WriteLine("puede votar: " + (perEncontrada.puedeVotar() ? "si" : "no"));

                }
                else
                {
                    System.Console.WriteLine("persona no encontrada");
                }
                System.Console.WriteLine("presiona enter para volver");
                 Console.ReadLine();
            }




            void mostrarEstadisticas()
            {
                int edad;
                int acum = 0;
                int puedenVotar = 0;
                Console.Clear();
                System.Console.WriteLine("la cantida de personas es de: " + dicPersona.Count);
                foreach (KeyValuePair<int, Persona> keyValue in dicPersona)
                {
                    edad = keyValue.Value.ObtenerEdad();
                    if (edad >= 16)
                    {
                        puedenVotar++;
                    }
                    acum = acum + edad;


                }


                System.Console.WriteLine("La cantidad de personas habilitadas para votar es de: " + puedenVotar);

                System.Console.WriteLine("el promedio de edades es de: " + acum / dicPersona.Count);
                 System.Console.WriteLine("presiona enter para volver");
                 Console.ReadLine();
            }



            void cargarPersona()
            {
                Console.Clear();
                string nombre;
                System.Console.WriteLine("ingrese el nombre de la persona");
                nombre = Console.ReadLine();
                System.Console.WriteLine("ingrese el apellido de la persona");
                string apellido = Console.ReadLine();
                System.Console.WriteLine("ingrese el dni de la persona");
                int dni = int.Parse(Console.ReadLine());
                System.Console.WriteLine("ingrese el mail de la persona");
                string mail = Console.ReadLine();
                System.Console.WriteLine("ingrese la fecha de nacimiento de la persona(dd/mm/aaaa)");
                string nac = Console.ReadLine();
                DateTime fechaNac = DateTime.ParseExact(nac, "dd/MM/yyyy", new CultureInfo("es-AR", true));
                
                Persona unaPersona = new Persona(nombre, apellido, dni, mail, fechaNac);
                dicPersona.Add(dni, unaPersona);

            }










            int menu()
            {
                
                string seguro = "a";
                int opcion;
                Console.Clear();
                System.Console.WriteLine("///////////////////menu/////////////////////");
                System.Console.WriteLine("1-Cargar nueva persona");
                System.Console.WriteLine("2-Estadisticas del senso");
                System.Console.WriteLine("3-Buscar persona");
                System.Console.WriteLine("4-Modificar mail");
                System.Console.WriteLine("5-Salir");
                opcion = int.Parse(System.Console.ReadLine());

                while (opcion < 0 || opcion > 5)
                {
                    System.Console.WriteLine("Opcion invalida, intente ingresar un numero entre 1 y 5");
                    opcion = int.Parse(System.Console.ReadLine());
                }



                return opcion;
            }



        }

    }
}
