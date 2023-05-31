using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Profesor
    {
        public static List<object> GetAll()
        {
            List<object> list = new List<object>();
            try
            {
                using (DL.JSanchezBarreraEntities context = new DL.JSanchezBarreraEntities())
                {
                    var query = context.ProfesorGetAll().ToList();
                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            ML.Profesor profesor = new ML.Profesor();

                            profesor.IdProfesor = obj.IdProfesor;
                            profesor.Nombre = obj.Nombre;
                            profesor.ApellidoPaterno = obj.ApellidoPaterno;
                            list.Add(profesor);
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
        public static object GetById(int IdProfesor)
        {
            object list = new object();
            try
            {
                using (DL.JSanchezBarreraEntities context = new DL.JSanchezBarreraEntities())
                {
                    var query = context.ProfesorGetById(IdProfesor).FirstOrDefault();

                    if (query != null)
                    {
                        var obj = query;

                        ML.Profesor profesor = new ML.Profesor();

                        profesor.IdProfesor = obj.IdProfesor;
                        profesor.Nombre = obj.Nombre;
                        profesor.ApellidoPaterno = obj.ApellidoPaterno;
                        list = profesor;
                    }
                }
            }
            catch (Exception)
            {
                list = null;
            }
            return list;
        }
        public static bool Add(ML.Profesor profesor)
        {
            bool correct = false;
            try
            {
                using (DL.JSanchezBarreraEntities context = new DL.JSanchezBarreraEntities())
                {
                    var query = context.ProfesorAdd(profesor.Nombre,profesor.ApellidoPaterno);

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
        public static bool Update(ML.Profesor profesor)
        {
            bool correct = false;
            try
            {
                using (DL.JSanchezBarreraEntities context = new DL.JSanchezBarreraEntities())
                {
                    var query = context.ProfesorUpdate(profesor.IdProfesor,profesor.Nombre,profesor.ApellidoPaterno);

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
        public static bool Delete(int IdProfesor)
        {
            bool correct = false;
            try
            {
                using (DL.JSanchezBarreraEntities context = new DL.JSanchezBarreraEntities())
                {
                    var query = context.ProfesorDelete(IdProfesor);

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
