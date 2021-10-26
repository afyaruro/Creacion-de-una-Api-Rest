using System;
using Datos;
using Entidades;
using System.Collections.Generic;
using System.Linq;

namespace Logica
{
    public class PersonaService
    {
        private readonly PersonaAfiliacionContext _context;


        public PersonaService(PersonaAfiliacionContext context)
        {
            _context = context;
        }

        public GuardarPersonaResponse Guardar(Persona persona)
        {
            try
            {
                var PersonaBuscada = _context.personas.Find(persona.numeroIdentificacion);
                if (PersonaBuscada != null)
                {
                    return new GuardarPersonaResponse("Error la Persona ya esta Registrada");
                }
                _context.personas.Add(persona);
                _context.SaveChanges();
                return new GuardarPersonaResponse(persona);
            }
            catch (Exception e)
            {
                return new GuardarPersonaResponse($"Error de la aplicacion: {e.Message}");
            }
        }

        public List<Persona> ConsultarTodasLasPersonas()
        {
            List<Persona> personas = _context.personas.ToList();
            return personas;
        }
    }


    public class GuardarPersonaResponse
    {
        public GuardarPersonaResponse(Persona persona)
        {
            Error = false;
            Persona = persona;
        }
        public GuardarPersonaResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Persona Persona { get; set; }
    }
}