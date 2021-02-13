using Prom_Base_Datos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prom_Base_Datos.Controllers
{
    public class AlumnoController : Controller
    {
        // GET: Alumno
        public ActionResult Index()
        {
            return View();
        }

        //agregamos para el update int id_alumno=0
        public ActionResult CreateORUpdateAlumno(int? id_alumno)
        {
            //upda
            if (id_alumno > 0)
            {
                using (var context = new Contexto())
                {
                    var model = context.Alumnos.Where(c => c.id == id_alumno).FirstOrDefault();
                    return View(model);
                }
            }
            else
            {
                //agregamos el modelo para enviar a la vista
                Alumno model = new Alumno();
                return View(model);
            }
           
        }

        //ahora aca vamos a recibir el modelo
        [HttpPost]
        public ActionResult CreateORUpdateAlumno(Alumno model)
        {
            //agregamos el modelo para enviar a la vista
            if (ModelState.IsValid)
            {
                model.promedio = (model.nota1 + model.nota2 + model.nota3) / 3;
                model.estado = model.promedio > 6 ? "Aprobado" : "Reprobado";

                //si el registro es nuevo es parte de guardar o editar 
                var isnew = model.id == 0 ? true : false;
                if (isnew)
                {
                    //agregmos a base de datos
                    using (var context = new Contexto())
                    {
                        context.Alumnos.Add(model);
                        context.SaveChanges();
                    }
                }
                else
                {
                    using (var context = new Contexto())
                    {
                        //update
                        var data = context.Alumnos.Where(x => x.id == model.id).FirstOrDefault();
                        data.nombre = model.nombre;
                        data.nota1 = model.nota1;
                        data.nota2 = model.nota2;
                        data.nota3 = model.nota3;
                        data.promedio = model.promedio;
                        data.estado = model.estado;

                        context.SaveChanges();
                    }
                }

              
                return View("Correcto");
            }

            else
            {
                return View(model);
            }

        }
        public ActionResult MostrarDatos()
        {
            //para capturar datos desde la base
            using (var context = new Contexto())
            {
                var data = context.Alumnos.ToList();
                ViewBag.Datos = data;
                return View();
            }

            
        }

        public ActionResult DeleteAlumno(int id_alumno)
        {

            using (var context =new Contexto())
            {
                var data = context.Alumnos.Where(c => c.id == id_alumno).FirstOrDefault();
                context.Alumnos.Remove(data);
                context.SaveChanges();

                return View();
                //return RedirectToAction("MostrarDatos");
            }

        }
    }
}