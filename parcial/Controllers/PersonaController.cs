using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Datos;
using Logica;
using Entidades;
using parcial.Models;

namespace parcial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly PersonaService _personaService;
        public PersonaController(PersonaAfiliacionContext context)
        {
            _personaService = new PersonaService(context);
        }

        [HttpPost]
        public ActionResult<PersonaViewModel> Post(PersonaInputModel personaInput)
        {
            Persona persona = MapearPersona(personaInput);
            var response = _personaService.Guardar(persona);
            if (response.Error)
            {
                return BadRequest(response.Mensaje);
            }
            return Ok(response.Persona);
        }

        private Persona MapearPersona(PersonaInputModel personaInput)
        {
            var persona = new Persona();
            {
                persona.numeroIdentificacion = personaInput.numeroIdentificacion;
                persona.tipoIdentificacion = personaInput.tipoIdentificacion;
                persona.nombrePersona = personaInput.nombrePersona;
                persona.fechaNacimiento = personaInput.fechaNacimiento;
                persona.fechaAfiliacion = personaInput.fechaAfiliacion;
                persona.estado = personaInput.estado;
            };
            return persona;
        }

        [HttpGet]
        public IEnumerable<PersonaViewModel> Gets()
        {
            var personas = _personaService.ConsultarTodasLasPersonas().Select(p => new PersonaViewModel(p));
            return personas;
        }

    }
}
