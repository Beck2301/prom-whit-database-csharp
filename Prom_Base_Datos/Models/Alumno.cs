using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Prom_Base_Datos.Models
{
    public class Alumno
    {
       
        public int id { get; set; }


        [Required(ErrorMessage = "Por favor ingrese un nombre")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "Por favor ingrese la nota")]
        [Range(0,10, ErrorMessage ="Debe estar entre 0 y 10")]
        public int nota1 { get; set; }

        [Required(ErrorMessage = "Por favor ingrese la nota")]
        [Range(0, 10, ErrorMessage = "Debe estar entre 0 y 10")]
        public int nota2 { get; set; }

        [Required(ErrorMessage = "Por favor ingrese la nota")]
        [Range(0, 10, ErrorMessage = "Debe estar entre 0 y 10")]
        public int nota3 { get; set; }

        public double promedio { get; set; }

        public string estado { get; set; }
    
    }
}