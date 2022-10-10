using Microsoft.AspNetCore.Mvc;
using CRUDCORE.Datos;
using CRUDCORE.Models;


namespace CRUDCORE.Controllers
{
    public class MantenedorController : Controller
    {
        ContactoDatos _ContactoDatos = new ContactoDatos();
        public IActionResult listar()
        {
            //mostrara una lista dfe contactos
            var olista = _ContactoDatos.Listar();
            return View(olista);
        }

        public IActionResult Guardar()
        {
            //debuelve vista
            
            return View();
        }
        //
        [HttpPost]
        public IActionResult Guardar(ContactoModel oContacto)
        {
            // guardar en nuiestra base de datos
            if (!ModelState.IsValid)
               return View();
            
            var respuesta = _ContactoDatos.Guardar(oContacto);
            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
            
        }
    }
}
