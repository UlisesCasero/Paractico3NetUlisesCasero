using DataAccessLayer.EFModels;
using DataAccessLayer.IDALs;
using Microsoft.Data.SqlClient;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DALs
{
    public class DAL_Personas_EF : IDAL_Personas
    {
        private DBContextCore _dbContext;

        public DAL_Personas_EF(DBContextCore dbContext)
        {
            _dbContext = dbContext;
        }

        public void Delete(string documento)
        {
            throw new NotImplementedException();
        }

        public List<Persona> Get()
        {
            return _dbContext.Personas
                             .Select(p => new Persona { Documento = p.Documento, Nombre = p.Nombres })
                             .ToList();
        }

        public Persona Get(string documento)
        {
            var personaEntity = _dbContext.Personas.FirstOrDefault(p => p.Documento == documento);

            if (personaEntity != null)
            {
                return new Persona
                {
                    Documento = personaEntity.Documento,
                    Nombre = personaEntity.Nombres,
                    Apellido = personaEntity.Apellidos,
                    Telefono = personaEntity.Telefono,
                    Direccion = personaEntity.Direccion                  
                };
            }

            return null;
        }

        public void Insert(Persona persona)
        {
            _dbContext.Personas.Add(new Personas() { Documento = persona.Documento, Nombres = persona.Nombre, Apellidos = persona.Apellido, Direccion = persona.Direccion, Telefono = persona.Telefono });
            _dbContext.SaveChanges();

        }

        public void Update(Persona persona)
        {
            throw new NotImplementedException();
        }
    }
}
