using System;
using System.Collections.Generic;

namespace SGPI.Models
{
    public partial class Programa
    {
        public Programa()
        {
            Modulos = new HashSet<Modulo>();
            Usuarios = new HashSet<Usuario>();
        }

        public int IdPrograma { get; set; }
        public string Programa1 { get; set; } = null!;

        public virtual ICollection<Modulo> Modulos { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
