using System;
using System.Collections.Generic;

namespace SGPI.Models
{
    public partial class Estudiante
    {
        public int IdEstudiante { get; set; }
        public string Archivo { get; set; } = null!;
        public int IdPago { get; set; }
        public int IdUsuario { get; set; }
        public bool Egresado { get; set; }

        public virtual Entrevistum IdEstudianteNavigation { get; set; } = null!;
        public virtual Homologacion? Homologacion { get; set; }
        public virtual Pago? Pago { get; set; }
        public virtual Usuario? Usuario { get; set; }

    }
}
