using Buinness.Servicios;
using Data.DataContext;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebAppMVC.Models;
using WebAppMVC.Models.VM;

namespace WebAppMVC.Controllers
{
    public class HomeController : Controller    
    {
        private readonly IBalerosService _baleroService;

        public HomeController(IBalerosService baleroServ)
        {
            _baleroService = baleroServ;
        }

        public async Task<IActionResult>  Index()
        {
            var balero = await _baleroService.ObtenerTodos();
            return View(balero);
        }

        [HttpPost]
        public async Task<IActionResult> Insertar([Bind("IdBaleros,Marca,Codigo,Precio,Fecha_Create")]Balero balero)
        {
            if(ModelState.IsValid)
            {
                bool respuesta = await _baleroService.Insertar(balero);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.ErrorMessage = "Hubo un error al ingresar el balero";
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Actualizar([Bind("IdBaleros,Marca,Codigo,Precio,Fecha_Create")] Balero balero)
        {


            if (ModelState.IsValid)
            {

                bool respuesta = await _baleroService.Actualizar(balero);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.ErrorMessage = "Hubo un error al Actualizar el producto en la base de datos";
                return View();
            }
        }
        [HttpDelete]
        public async Task<IActionResult> Eliminar(int id)
        {
            bool respuesta = await _baleroService.Eliminar(id);
            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });
        }
        [HttpPost]
        public async Task<IActionResult> Obtener(int id)
        {
            Balero respuesta = await _baleroService.Obtener(id);
            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}