using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Materia
    {
        public static List<object> GetAll()
        {
            List<object> list = new List<object>();
            try
            {
                using (DL.JSanchezBarreraEntities context = new DL.JSanchezBarreraEntities())
                {
                    var query = context.MateriaGetAll().ToList();
                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            ML.Materia materia = new ML.Materia();

                            materia.IdMateria = obj.IdMateria;
                            materia.Nombre = obj.Nombre;
                            materia.Creditos = obj.Creditos;

                            list.Add(materia);
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
        public static object GetById(int IdMateria)
        {
            object list = new object();
            try
            {
                using (DL.JSanchezBarreraEntities context = new DL.JSanchezBarreraEntities())
                {
                    var query = context.MateriaGetById(IdMateria).FirstOrDefault();

                    if (query != null)
                    {
                        var obj = query;

                        ML.Materia materia = new ML.Materia();

                        materia.IdMateria = obj.IdMateria;
                        materia.Nombre = obj.Nombre;
                        materia.Creditos = obj.Creditos;
                        list = materia;
                    }
                }
            }
            catch (Exception)
            {
                list = null;
            }
            return list;
        }
        public static bool Add(ML.Materia materia)
        {
            bool correct = false;
            try
            {
                using (DL.JSanchezBarreraEntities context = new DL.JSanchezBarreraEntities())
                {
                    var query = context.MateriaAdd(materia.Nombre,materia.Creditos);

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
        public static bool Update(ML.Materia materia)
        {
            bool correct = false;
            try
            {
                using (DL.JSanchezBarreraEntities context = new DL.JSanchezBarreraEntities())
                {
                    var query = context.MateriaUpdate(materia.IdMateria,materia.Nombre,materia.Creditos);

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
        public static bool Delete(int IdMateria)
        {
            bool correct = false;
            try
            {
                using (DL.JSanchezBarreraEntities context = new DL.JSanchezBarreraEntities())
                {
                    var query = context.MateriaDelete(IdMateria);

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
