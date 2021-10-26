using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entidades;

namespace parcial.Models
{
    public class PersonaInputModel
    {
        public string numeroIdentificacion { get; set; }
        public string tipoIdentificacion { get; set; }
        public string nombrePersona { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public DateTime fechaAfiliacion { get; set; }
        public string estado { get; set; }
    }

        public class PersonaViewModel : PersonaInputModel
        {
            public PersonaViewModel(Persona persona)
        {
            tipoIdentificacion = persona.tipoIdentificacion;
            numeroIdentificacion = persona.numeroIdentificacion;
            nombrePersona = persona.nombrePersona;
            fechaNacimiento = persona.fechaNacimiento;
            fechaAfiliacion = persona.fechaAfiliacion;
            estado = persona.estado;
        }
    }

}
