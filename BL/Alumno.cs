using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Alumno
    {
        public static List<object> GetAll()
        {
            List<object> list = new List<object>();
            try
            {
                using (DL.JSanchezBarreraEntities context = new DL.JSanchezBarreraEntities())
                {
                    var query = context.AlumnoGetAll().ToList();
                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            ML.Alumno alumno = new ML.Alumno();

                            alumno.IdAlumno = obj.IdAlumno;
                            alumno.Nombre = obj.Nombre;
                            alumno.ApellidoPaterno = obj.ApellidoPaterno;
                            alumno.ApellidoMaterno = obj.ApellidoMaterno;
                            list.Add(alumno);
                        }
                    }
                }
            }
            catch (Exception)
            {
                list = null;
            }
            return list;
        }
        public static object GetById(int IdAlumno)
        {
            object list = new object();
            try
            {
                using (DL.JSanchezBarreraEntities context = new DL.JSanchezBarreraEntities())
                {
                    var query = context.AlumnoGetById(IdAlumno).FirstOrDefault();

                    if (query != null)
                    {
                        var obj = query;

                        ML.Alumno alumno = new ML.Alumno();

                        alumno.IdAlumno = obj.IdAlumno;
                        alumno.Nombre = obj.Nombre;
                        alumno.ApellidoPaterno = obj.ApellidoPaterno;
                        alumno.ApellidoMaterno = obj.ApellidoMaterno;
                        list = alumno;
                    }
                }
            }
            catch (Exception)
            {
                list = null;
            }
            return list;
        }
        public static bool Add(ML.Alumno alumno)
        {
            bool correct = false;
            try
            {
                using (DL.JSanchezBarreraEntities context = new DL.JSanchezBarreraEntities())
                {
                    var query = context.AlumnoAdd(alumno.Nombre,alumno.ApellidoPaterno,alumno.ApellidoMaterno);

                    if (query != null)
                    {
                        correct = true;
                    }
                    else
                    {
                        correct = false;
                    }
                }
            }
            catch (Exception)
            {
                correct = false;
            }
            return correct;
        }
        public static bool Update(ML.Alumno alumno)
        {
            bool correct = false;
            try
            {
                using (DL.JSanchezBarreraEntities context = new DL.JSanchezBarreraEntities())
                {
                    var query = context.AlumnoUpdate(alumno.IdAlumno,alumno.Nombre, alumno.ApellidoPaterno, alumno.ApellidoMaterno);

                    if (query != null)
                    {
                        correct = true;
                    }
                    else
                    {
                        correct = false;
                    }
                }
            }
            catch (Exception)
            {
                correct = false;
            }
            return correct;
        }
        public static bool Delete(int IdAlumno)
        {
            bool correct = false;
            try
            {
                using (DL.JSanchezBarreraEntities context = new DL.JSanchezBarreraEntities())
                {
                    var query = context.AlumnoDelete(IdAlumno);

                    if (query != null)
                    {
                        correct = true;
                    }
                    else
                    {
                        correct = false;
                    }
                }
            }
            catch (Exception)
            {
                correct = false;
            }
            return correct;
        }
    }
}
