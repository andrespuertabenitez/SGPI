using System;
using System.Collections.Generic;

namespace SGPI.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Entrevista = new HashSet<Entrevistum>();
        }

        public int IdUsuario { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Documento { get; set; } = null!;
        public int IdDoc { get; set; }
        public string Email { get; set; } = null!;
        public int Telefono { get; set; }
        public int IdPrograma { get; set; }
        public int IdRol { get; set; }
        public int IdGenero { get; set; }
        public string Password { get; set; } = null!;

        public virtual Documento IdDocNavigation { get; set; } = null!;
        public virtual Genero IdGeneroNavigation { get; set; } = null!;
        public virtual Programa IdProgramaNavigation { get; set; } = null!;
        public virtual Rol IdRolNavigation { get; set; } = null!;
        public virtual Estudiante IdUsuarioNavigation { get; set; } = null!;
        public virtual ICollection<Entrevistum> Entrevista { get; set; }
        public virtual ICollection<Estudiante> Estudiantes { get; set; }
        public virtual ICollection<Programacion> Programacions { get; set; }

    }
}
