using System;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Ejemplo01.Models;
using Ejemplo01.ViewModels;
using Microsoft.AspNetCore.Hosting;

namespace Ejemplo01.Controllers
{
    public class HomeController : Controller
    {

        private IAmigoAlmacen _amigoAlmacen; 
        private readonly IWebHostEnvironment _hosting;

        public HomeController(IAmigoAlmacen amigoAlmacen, IWebHostEnvironment hosting)
        {
            _amigoAlmacen = amigoAlmacen;
            _hosting = hosting;
        }

        // [Route("")]
        // [Route("Home")]
        // [Route("Home/Index")]
        public ViewResult Index()
        {
            //return _amigoAlmacen.DameDatosAmigo(1).Email;
            var modelo = _amigoAlmacen.DameTodosLosAmigos();
            return View(modelo);
        }

        // [Route("Home/Details/{id?}")]
        public ViewResult Details(int? id)
        {
            throw new Exception("Error forzado....");

            Amigo modelo = _amigoAlmacen.DameDatosAmigo(1);
            //ViewBag.Titulo = "Lista de Amigos";

            DetailsView detalles = new DetailsView();
            detalles.Amigo = _amigoAlmacen.DameDatosAmigo(id ?? 1);
            detalles.Titulo = "Lista de Amigos";
            detalles.SubTitulo = "--------------------";

            return View(detalles);
        }

        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CrearAmigoModelo crearAmigo)
        {

            if (ModelState.IsValid)
            {
                string guidImagen = null;
                if (crearAmigo.Foto != null)
                {
                    string archivoImagen = Path.Combine(_hosting.WebRootPath, "img");
                    guidImagen = Guid.NewGuid().ToString() + crearAmigo.Foto.FileName;

                    string ruta = Path.Combine(archivoImagen, guidImagen);
                    using (var file = new FileStream(ruta, FileMode.Create))
                    {
                        crearAmigo.Foto.CopyTo(file);
                    }
                }

                Amigo amigo = new Amigo();
                amigo.Nombre = crearAmigo.Nombre;
                amigo.Email = crearAmigo.Email;
                amigo.Ciudad = crearAmigo.Ciudad;
                amigo.Rutafoto = guidImagen;

                 _amigoAlmacen.Nuevo(amigo);
                return RedirectToAction("details", new
                {
                    id = amigo.Id
                });
            }
            return View();
        }

        public ViewResult Edit(int id)
        {
            Amigo amigo = _amigoAlmacen.DameDatosAmigo(id);
            EditarAmigoModelo amigoEditar = new EditarAmigoModelo
            {
                Id = amigo.Id,
                Nombre = amigo.Nombre,
                Email = amigo.Email,
                Ciudad = amigo.Ciudad,
                RutaFotoExistente = amigo.Rutafoto
            };

            return View(amigoEditar);
        }

        [HttpPost]
        public IActionResult Edit(EditarAmigoModelo amigo)
        {
            if (ModelState.IsValid)
            {
                Amigo _amigo = _amigoAlmacen.DameDatosAmigo(amigo.Id);
                _amigo.Nombre = amigo.Nombre;
                _amigo.Email = amigo.Email;
                _amigo.Ciudad = amigo.Ciudad;

                if (amigo.Foto != null)
                {
                    if (amigo.RutaFotoExistente != null)
                    {
                        string ruta = Path.Combine(_hosting.WebRootPath, "img", amigo.RutaFotoExistente);
                        System.IO.File.Delete(ruta);
                    }

                    _amigo.Rutafoto = SubirImagen(amigo);
                }

                Amigo amigoModificado = _amigoAlmacen.Modificar(_amigo);
                return RedirectToAction("index");
            }

            return View(amigo);
        }

        private string SubirImagen(EditarAmigoModelo amigo)
        {   
            string guidImagen = null;

            if (amigo.Foto != null)
            {
                string archivoImagen = Path.Combine(_hosting.WebRootPath, "img");
                guidImagen = Guid.NewGuid().ToString() + amigo.Foto.FileName;

                string ruta = Path.Combine(archivoImagen, guidImagen);
                using (var file = new FileStream(ruta, FileMode.Create))
                {
                    amigo.Foto.CopyTo(file);
                }   
                
            }

            return guidImagen;
        }

    }
}
