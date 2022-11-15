using Microsoft.AspNetCore.Mvc;
using SGPI.Models;
using System.Security.Cryptography.X509Certificates;

namespace SGPI.Controllers
{

    public class EstudianteController : Controller

    {
        SGPI_BDContext context = new SGPI_BDContext();

        //Agrego modificar estudiante
        public IActionResult ModificarEstudiante(int? IdUsuario)
        {
            Usuario usr = context.Usuarios.Find(IdUsuario);
            if (usr != null)
            {
                ViewBag.genero = context.Generos.ToList();
                ViewBag.documento = context.Documentos.ToList();
                ViewBag.programa = context.Programas.ToList();


                return View(usr);
            }
            else
            {
                return Redirect("/Estudiante/ModificarEstudiante");
            }

        }

        [HttpPost]
        public IActionResult ModificarEstudiante(Usuario usuario)
        {

            var usract = context.Usuarios.Where(consulta => consulta.IdUsuario == usuario.IdUsuario).FirstOrDefault();

            usract.IdDoc = usuario.IdDoc;
            usract.IdGenero = usuario.IdGenero;
            usract.IdPrograma = usuario.IdPrograma;
            usract.Nombre = usuario.Nombre;
            usract.Apellido = usuario.Apellido;
            usract.Documento = usuario.Documento;
            usract.Email = usuario.Email;
            usract.Password = usuario.Password;

            context.Update(usract);
            context.SaveChanges();

            ViewBag.genero = context.Generos.ToList();
            ViewBag.documento = context.Documentos.ToList();
            ViewBag.programa = context.Programas.ToList();

            return View();
        }

        //Agrego modificar estudiante
        public IActionResult PagosEstudiante()
        {
            Pago us = new Pago();

                return View(us);
        

         



        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PagosEstudiante(Pago pago)
        {
            context.Pagos.Add(pago);
            context.SaveChanges();

            return View(pago);


        }

    }
}



