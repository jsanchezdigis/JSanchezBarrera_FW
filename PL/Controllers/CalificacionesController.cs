using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class CalificacionesController : Controller
    {
        // GET: Calificaciones
        public ActionResult GetAllAlumnos()
        {
            ML.Alumno alumno = new ML.Alumno();
            List<object> list = BL.Alumno.GetAll();
            if (list != null)
            {
                alumno.Alumnos = list;
                return View(alumno);
            }
            else
            {
                return View(alumno);
            }
        }
        public ActionResult GetAllMateriasAlumno(int IdAlumno)
        {
            Session["IdAlumno"] = IdAlumno;
            List<object> listProfesor = BL.Profesor.GetAll();
            List<object> listMateria = BL.Materia.GetAll();
            object listAlumno = BL.Alumno.GetById(IdAlumno);
            List<object> list = BL.Calificaciones.GetMateriasAlumnos(IdAlumno);
            ML.Calificaciones calificaciones = new ML.Calificaciones();
            if (list != null)
            {
                calificaciones.Calificaciones1 = list;
                calificaciones.Alumno = (ML.Alumno)listAlumno;
                calificaciones.Materia = new ML.Materia();
                calificaciones.Materia.Materias = listMateria;
                calificaciones.Profesor = new ML.Profesor();
                calificaciones.Profesor.Profesores = listProfesor;
                return View(calificaciones);
            }
            else
            {
                return View(calificaciones);
            }
        }
        [HttpGet]
        public ActionResult Add(int? IdCalificaciones)
        {
            List<object> listProfesor = BL.Profesor.GetAll();
            List<object> listMateria = BL.Materia.GetAll();
            ML.Calificaciones calificaciones = new ML.Calificaciones();
            if (IdCalificaciones == null)
            {
                return View();
            }
            else
            {
                //GetById
                object list = BL.Calificaciones.MateriasAlumnoGetById(IdCalificaciones.Value);
                if (list != null)
                {
                    calificaciones = (ML.Calificaciones)list;
                    calificaciones.Materia.Materias = listMateria;
                    calificaciones.Profesor.Profesores = listProfesor;
                    //return View(calificaciones);
                    return View("GetAllMateriasAlumno", calificaciones);
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al consultar la informacion";
                }
                return View("Modal");
            }
        }
        [HttpPost]
        public ActionResult Add(ML.Calificaciones calificaciones)
        {
            bool correct = false;
            if (calificaciones.IdCalificaciones == 0)
            {
                //Add
                correct = BL.Calificaciones.Add(calificaciones);

                if (correct == true)
                {
                    ViewBag.Message = "Se completo el registro satisfactoriamente";
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al insertar el registro";
                }
                return View("Modal",calificaciones);
                //return RedirectToAction("GetAll");
            }
            else
            {
                //Update
                correct = BL.Calificaciones.Update(calificaciones);
                if (correct == true)
                {
                    ViewBag.Message = "Se actualizo el registro satisfactoriamente";
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al actualizar el registro";
                }
                return View("Modal",calificaciones);
            }
        }
        public ActionResult Delete(int IdCalificaciones)
        {
            int IdAlumno = (int)(Session["IdAlumno"]);
            bool correct = false;
            ML.Calificaciones calificaciones = new ML.Calificaciones();
            calificaciones.Alumno = new ML.Alumno();
            calificaciones.Alumno.IdAlumno = IdAlumno;
            correct = BL.Calificaciones.Delete(IdCalificaciones);
            if (correct == true)
            {
                ViewBag.Message = "Se actualizo el registro satisfactoriamente";
            }
            else
            {
                ViewBag.Message = "Ocurrio un error al actualizar el registro";
            }
            return View("Modal",calificaciones);
        }
    }
}