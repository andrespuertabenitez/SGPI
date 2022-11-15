﻿using System;
using System.Collections.Generic;

namespace SGPI.Models
{
    public partial class Entrevistum
    {
        public int IdEntrevista { get; set; }
        public int IdUsuario { get; set; }
        public int IdEstudiante { get; set; }
        public DateTime Fecha { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
        public virtual Estudiante? Estudiante { get; set; }
    }
}
