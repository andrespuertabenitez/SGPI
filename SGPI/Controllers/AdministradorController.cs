using Microsoft.AspNetCore.Mvc;
using SGPI.Models;
namespace SGPI.Controllers
{
    public class AdministradorController : Controller
    {
        SGPI_BDContext context = new SGPI_BDContext();

        public IActionResult Login()
        {
            

            return View();
        }
        [HttpPost]
        public IActionResult Login(Usuario user)
        {
            string numeroDoc = user.Documento;
            string pass = user.Password;

            
            var usuarioLogin = context.Usuarios 
                .Where(consulta => consulta.Documento == numeroDoc &&
                consulta.Password == pass).FirstOrDefault();

            if (usuarioLogin != null)
            {
                //administrador

                if (usuarioLogin.IdRol == 1)
                {
                    CrearUsuario();
                    return Redirect("Administrador/CrearUsuario");
                }
                //cordinador
                else if (usuarioLogin.IdRol == 2)
                {
                    return Redirect("Coordinador/BuscarCoordinador");
                }

                //estudainte
                else if (usuarioLogin.IdRol == 3)
                {
                    return Redirect("Estudiante/ModificarEstudiante/?Idusuario="+usuarioLogin.IdUsuario);
                }
                else { }
            }
            else
            {
                ViewBag.mensaje = "Usuario no existe " +
                     "o usuario y/o contraseña invalida";
            }
            return View();

        }
        public IActionResult OlvidoContraseña()
        {
            return View();
        }
        public IActionResult CrearUsuario()
        {
            ViewBag.genero = context.Generos.ToList();
            ViewBag.documento = context.Documentos.ToList();
            ViewBag.programa = context.Programas.ToList();
            ViewBag.rol = context.Rols.ToList();

            return View();
        }
        [HttpPost]
        public IActionResult CrearUsuario(Usuario usuario)
        {

            context.Usuarios.Add(usuario);
            context.SaveChanges();
            ViewBag.mensaje = "El Usuario Fue Ingresado Exitosamente!";
            ViewBag.genero = context.Generos.ToList();
            ViewBag.documento = context.Documentos.ToList();
            ViewBag.programa = context.Programas.ToList();
            ViewBag.rol = context.Rols.ToList();

            return View();
        }
        public IActionResult EditarUsuario(int? IdUsuario)
        {

            Usuario usuario = context.Usuarios.Find(IdUsuario);
            if (usuario != null)
            {
                ViewBag.mensaje = "El Usuario Fue Ingresado Exitosamente!";
                ViewBag.genero = context.Generos.ToList();
                ViewBag.documento = context.Documentos.ToList();
                ViewBag.programa = context.Programas.ToList();
                ViewBag.rol = context.Rols.ToList();
               
                return View(usuario);
            }
            else
            {
                return Redirect("/Administrador/BuscarUsuario");
            }

        }
        [HttpPost]

        public IActionResult EditarUsuario(Usuario usuario)
        {
            context.Update(usuario);
            context.SaveChanges();

            return Redirect("/Administrador/BuscarUsuario");

        }
        public IActionResult BuscarUsuario()
        {

            Usuario us = new Usuario();
            return View(us);
        }
        [HttpPost]
        public IActionResult BuscarUsuario(Usuario usuario)
        {
            String numeroDoc = usuario.Documento;
            var user = context.Usuarios
                .Where(consulta => consulta.Documento == numeroDoc).FirstOrDefault();
            if (user != null)
            {
                return View(user);
            }
            else
                return View();
        }
        public IActionResult EliminarUsuario(int? IdUsuario)
        {
            Usuario user = context.Usuarios.Find(IdUsuario);
            if (user != null)
            {
                context.Remove(user);
                context.SaveChanges();
            }

            return Redirect("/Administrador/BuscarUsuario");
        }

        public IActionResult ReportarUsuario()
        {
            ViewBag.tipodedocumento = context.Documentos.ToList();
            return View();
        }











    }
}

