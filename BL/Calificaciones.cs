using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Calificaciones
    {
        public static List<object> GetMateriasAlumnos(int IdAlumno)
        {
            List<object> list = new List<object>();
            try
            {
                using (DL.JSanchezBarreraEntities context = new DL.JSanchezBarreraEntities())
                {
                    var query = context.MateriasAlumno(IdAlumno).ToList();

                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            ML.Calificaciones calificaciones = new ML.Calificaciones();

                            calificaciones.IdCalificaciones = obj.IdCalificaciones;
                            calificaciones.Calificacion = obj.Calificacion;
                            calificaciones.Materia = new ML.Materia();
                            calificaciones.Materia.IdMateria = obj.IdMateria;
                            calificaciones.Materia.Nombre = obj.MateriaNom;
                            calificaciones.Alumno = new ML.Alumno();
                            calificaciones.Alumno.IdAlumno = obj.IdAlumno;
                            calificaciones.Alumno.Nombre = obj.AlumnoNom;
                            calificaciones.Alumno.ApellidoPaterno = obj.ApellidoPaterno;
                            calificaciones.Alumno.ApellidoMaterno = obj.ApellidoMaterno;
                            calificaciones.Profesor = new ML.Profesor();
                            calificaciones.Profesor.IdProfesor = obj.IdProfesor.Value;
                            list.Add(calificaciones);
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

        public static object MateriasAlumnoGetById(int IdCalificaciones)
        {
            object list = new object();
            try
            {
                using (DL.JSanchezBarreraEntities context = new DL.JSanchezBarreraEntities())
                {
                    var query = context.MateriasAlumnoGetById(IdCalificaciones).FirstOrDefault();

                    if (query != null)
                    {
                        var obj = query;

                        ML.Calificaciones calificaciones = new ML.Calificaciones();

                        calificaciones.IdCalificaciones = obj.IdCalificaciones;
                        calificaciones.Calificacion = obj.Calificacion;
                        calificaciones.Materia = new ML.Materia();
                        calificaciones.Materia.IdMateria = obj.IdMateria;
                        calificaciones.Materia.Nombre = obj.MateriaNom;
                        calificaciones.Alumno = new ML.Alumno();
                        calificaciones.Alumno.IdAlumno = obj.IdAlumno;
                        calificaciones.Alumno.Nombre = obj.AlumnoNom;
                        calificaciones.Alumno.ApellidoPaterno = obj.ApellidoPaterno;
                        calificaciones.Alumno.ApellidoMaterno = obj.ApellidoMaterno;
                        calificaciones.Profesor = new ML.Profesor();
                        calificaciones.Profesor.IdProfesor = obj.IdProfesor.Value;
                        list = calificaciones;
                    }
                }
            }
            catch (Exception)
            {
                list = null;
            }
            return list;
        }

        public static bool Add(ML.Calificaciones calificaciones)
        {
            bool correct = false;
            try
            {
                using (DL.JSanchezBarreraEntities context = new DL.JSanchezBarreraEntities())
                {
                    var query = context.CalificacionesProfesor(calificaciones.Calificacion, calificaciones.Materia.IdMateria, calificaciones.Alumno.IdAlumno, calificaciones.Profesor.IdProfesor);
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
        public static bool Update(ML.Calificaciones calificaciones)
        {
            bool correct = false;
            try
            {
                using (DL.JSanchezBarreraEntities context = new DL.JSanchezBarreraEntities())
                {
                    var query = context.CalificacionesProfesorUpdate(calificaciones.IdCalificaciones,calificaciones.Calificacion, calificaciones.Materia.IdMateria, calificaciones.Profesor.IdProfesor);
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
        public static bool Delete(int IdCalificaciones)
        {
            bool correct = false;
            try
            {
                using (DL.JSanchezBarreraEntities context = new DL.JSanchezBarreraEntities())
                {
                    var query = context.CalificacionesProfesorDelete(IdCalificaciones);
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
