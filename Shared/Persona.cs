namespace Shared
{
    public class Persona
    {
        public string Nombre { get; set; } = "-- Sin Nombre --";

        public String Apellido { get; set; } = "-- Sin Apellido --";

        private string documento = "";

        public int Telefono { get; set; } = 0;

        public String Direccion { get; set; } = "-- Sin direccion --";

        //public FechaNacimiento { get; set; };

        public string Documento
        {
            get
            {
                return documento;
            }
            set
            {
                if (value.Length >= 7)
                {
                    documento = value;
                }
                else
                {
                    throw new Exception("El formato del documento no es correcto.");
                }
            }
        }

        public void Print()
        {
            Console.WriteLine("-- Persona --");
            Console.WriteLine("Nombres: " + Nombre);
            Console.WriteLine("Apellidos: " + Apellido);
            Console.WriteLine("Documento: " + Documento);
            Console.WriteLine("Documento: " + Telefono);
            Console.WriteLine("Documento: " + Direccion);
        }

        public void PrintTable()
        {
            Console.WriteLine("| " + Documento + " | " + Nombre + " |");
        }
    }
}