using System;
namespace tp2
{
    class Persona
    {

        public string Nombre { get; set; }
        public int DNI { get; private set; }
        public string Mail { get; set; }
        public DateTime FechaNac { get; set; }
        public string Apellido { get; set; }

        public Persona()
        {
         Nombre ="";
         Apellido = "";
         DNI=0;
         Mail="";
         FechaNac=new DateTime();
        }
        public Persona(string nom, string ape, int dni, string correoE, DateTime nacimiento)
        {
            Nombre = nom;
            DNI = dni;
            Mail = correoE;
            FechaNac = nacimiento;
            Apellido = ape;
        }


        public bool puedeVotar()
        {

            return this.ObtenerEdad() >= 16;
        }
        public int ObtenerEdad()
        {
            int edad = 0;
            DateTime FechaNacimientoHoy = new DateTime(DateTime.Today.Year, FechaNac.Month, FechaNac.Day);
            if (FechaNacimientoHoy < DateTime.Today) edad = DateTime.Today.Year - FechaNac.Year;
            else edad = DateTime.Today.Year - FechaNac.Year - 1;
            return edad;
        }
    }
}
