using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class Alumno1Controller : Controller
    {
        // GET: Alumno1
        public ActionResult GetAll(ML.Alumno alumno)
        {

            //ML.Alumno alumno = new ML.Alumno();
            //ViewData["Mensaje"] = null; 
            if (alumno.Mensaje == null)
            {
                alumno.Mensaje = "hide";
            }
            else
            {
                alumno.Mensaje = "show";
            }
            List<object> list = BL.Alumno.GetAll();
            if (list != null)
            {
                alumno.Alumnos = list;
                //alumno.Mensaje = Mss;
                return View(alumno);
            }
            else
            {
                return View(alumno);
            }
        }
        [HttpGet]
        public ActionResult Form(int? IdAlumno)
        {
            ML.Alumno alumno = new ML.Alumno();
            if (IdAlumno == null)
            {
                return View();
            }
            else
            {
                //GetById
                object list = BL.Alumno.GetById(IdAlumno.Value);
                if (list != null)
                {
                    alumno = (ML.Alumno)list;

                    return View(alumno);
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al consultar la informacion";
                    return View("Modal");
                }
            }
        }
        [HttpPost]
        public ActionResult Form(ML.Alumno alumno)
        {
            bool correct = false;
            if (alumno.IdAlumno == 0)
            {
                //Add
                correct = BL.Alumno.Add(alumno);

                if (correct == true)
                {
                    alumno.Mensaje = "show";
                    ViewBag.Message = "Se completo el registro satisfactoriamente";
                }
                else
                {
                    alumno.Mensaje = "hide";
                    ViewBag.Message = "Ocurrio un error al insertar el registro";
                }
                //return View("Modal");
                return RedirectToAction("GetAll",alumno);
            }
            else
            {
                //Update
                correct = BL.Alumno.Update(alumno);
                if (correct == true)
                {
                    ViewBag.Message = "Se actualizo el registro satisfactoriamente";
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al actualizar el registro";
                }
                return View("Modal");
            }
        }
        public ActionResult Delete(int IdAlumno)
        {
            bool correct = false;
            correct = BL.Alumno.Delete(IdAlumno);
            if (correct == true)
            {
                ViewBag.Message = "Se actualizo el registro satisfactoriamente";
            }
            else
            {
                ViewBag.Message = "Ocurrio un error al actualizar el registro";
            }
            return View("Modal");
        }
    }
}