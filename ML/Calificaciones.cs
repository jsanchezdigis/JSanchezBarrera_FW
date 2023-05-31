using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Calificaciones
    {
        public int IdCalificaciones { get; set; }
        public string Calificacion { get; set; }
        public Materia Materia { get; set; }
        public Alumno Alumno { get; set; }
        public Profesor Profesor { get; set; }
        public List<object> Calificaciones1 { get; set; }
    }
}
