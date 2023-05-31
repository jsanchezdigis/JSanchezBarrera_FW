using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class MateriaController : Controller
    {
        // GET: Materia
        public ActionResult GetAll()
        {
            ML.Materia materia = new ML.Materia();
            List<object> list = BL.Materia.GetAll();
            if (list != null)
            {
                materia.Materias= list;
                return View(materia);
            }
            else
            {
                return View(materia);
            }
        }
        [HttpGet]
        public ActionResult Form(int? IdMateria)
        {
            ML.Materia materia = new ML.Materia();
            if (IdMateria == null)
            {
                return View();
            }
            else
            {
                //GetById
                object list = BL.Materia.GetById(IdMateria.Value);
                if (list != null)
                {
                    materia = (ML.Materia)list;

                    return View(materia);
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al consultar la informacion";
                    return View("Modal");
                }
            }
        }
        [HttpPost]
        public ActionResult Form(ML.Materia materia)
        {
            bool correct = false;
            if (materia.IdMateria== 0)
            {
                //Add
                correct = BL.Materia.Add(materia);

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
                correct = BL.Materia.Update(materia);
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
        public ActionResult Delete(int IdMateria)
        {
            bool correct = false;
            correct = BL.Materia.Delete(IdMateria);
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