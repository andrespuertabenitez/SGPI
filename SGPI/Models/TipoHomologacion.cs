using System;
using System.Collections.Generic;

namespace SGPI.Models
{
    public partial class TipoHomologacion
    {
        public int IdTipoHomologacion { get; set; }
        public string TipoHomologacion1 { get; set; } = null!;

        public virtual Homologacion? Homologacion { get; set; }
    }
}
