using BusinessLayer.BLs;
using BusinessLayer.IBLs;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticoClase1
{
    public class Commands
    {
        IBL_Personas _personasBL;

        public Commands(IBL_Personas personasBL)
        {
            _personasBL = personasBL;
        }

        public void AddPersona()
        {

            Persona persona = new Persona();
            Console.WriteLine("Ingrese los nombres de la persona: ");
            persona.Nombre = Console.ReadLine();
            Console.WriteLine("Ingrese los apellidos de la persona: ");
            persona.Apellido = Console.ReadLine();
            Console.WriteLine("Ingrese el documento de la persona: ");
            persona.Documento = Console.ReadLine();
            Console.WriteLine("Ingrese el telefono de la persona: ");
            string telefonoInput = Console.ReadLine();
            if (int.TryParse(telefonoInput, out int telefono)) {
                persona.Telefono = telefono;
            }
            else {
                Console.WriteLine("Entrada inválida para el teléfono, debe ser un número.");
            }
            Console.WriteLine("Ingrese la direccion de la persona: ");
            persona.Direccion = Console.ReadLine();

            _personasBL.Insert(persona);

            _personasBL.Get(persona.Documento).Print();
        }

        public void GetPersona() {
            Persona persona;
            string documento = "";
            Console.WriteLine("Ingrese el documento de la persona: ");
            documento = Console.ReadLine();
            persona = _personasBL.Get(documento);

            if (persona != null) {
                persona.Print();
            } else {
                Console.WriteLine("El documento ingresado no pertenece a ninguna persona registrada.");
            }
        }

        public void ListPersonas()
        {
            List<Persona> personas = _personasBL.Get();

            Console.WriteLine("Listado de personas:");
            Console.WriteLine("| Documento | Nombre |");

            foreach (Persona persona in personas)
            {
                persona.PrintTable();
            }
        }

        public void RemovePersona()
        {
            Console.WriteLine("Ingrese el documento de la persona a eliminar: ");
            string documento = Console.ReadLine();

            _personasBL.Delete(documento);

            Console.WriteLine("Persona eliminada correctamente.");
        }
    }
}
