using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class ProfesorController : Controller
    {
        // GET: Profesor
        public ActionResult GetAll()
        {
            ML.Profesor profesor = new ML.Profesor();
            List<object> list = BL.Profesor.GetAll();
            if (list != null)
            {
                profesor.Profesores= list;
                return View(profesor);
            }
            else
            {
                return View(profesor);
            }
        }
        [HttpGet]
        public ActionResult Form(int? IdProfesor)
        {
            ML.Profesor profesor = new ML.Profesor();
            if (IdProfesor == null)
            {
                return View();
            }
            else
            {
                //GetById
                object list = BL.Profesor.GetById(IdProfesor.Value);
                if (list != null)
                {
                    profesor = (ML.Profesor)list;

                    return View(profesor);
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al consultar la informacion";
                    return View("Modal");
                }
            }
        }
        [HttpPost]
        public ActionResult Form(ML.Profesor profesor)
        {
            bool correct = false;
            if (profesor.IdProfesor == 0)
            {
                //Add
                correct = BL.Profesor.Add(profesor);

                if (correct == true)
                {
                    ViewBag.Message = "Se completo el registro satisfactoriamente";
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al insertar el registro";
                }
                //return View("Modal");
                return RedirectToAction("GetAll");
            }
            else
            {
                //Update
                correct = BL.Profesor.Update(profesor);
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
        public ActionResult Delete(int IdProfesor)
        {
            bool correct = false;
            correct = BL.Profesor.Delete(IdProfesor);
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