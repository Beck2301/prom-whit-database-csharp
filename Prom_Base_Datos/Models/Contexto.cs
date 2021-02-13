using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//AGREGAMOS propiedades de Entity
using System.Data.Entity;

namespace Prom_Base_Datos.Models
{
    //para eredar propiedades de Entity eredamos Dbcontext
    public class Contexto: DbContext
    {
        public DbSet<Alumno> Alumnos { get; set; }
    }
}