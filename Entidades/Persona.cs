using System;
using System.ComponentModel.DataAnnotations;
namespace Entidades
{
    public class Persona
    {
        public string numeroIdentificacion { get; set; }
        public string tipoIdentificacion { get; set; }
        public string nombrePersona { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public DateTime fechaAfiliacion { get; set; }
        public string estado { get; set; }

    }
}