using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PryVeterinariaConBD.Models;
using System.Linq;
using System.Threading.Tasks;

namespace PryVeterinariaConBD.Controllers
{
    public class PetController : Controller
    {
        public IActionResult Index()
        {
            using (var context = new VeterinariaContext())
            {
                var pets = context.PetFiles.Include(b => b.IdTypeNavigation);
                ViewData["PetTypes"] = new SelectList(context.Types, "Id", "Type1");
                return View(pets.ToList());
            }
        }
        public async Task<IActionResult> Create()
        {
            await using (var context = new VeterinariaContext())
            {
                //ViewData["PetTypes"] = new SelectList(context.Types, "Id", "Type1");
                return View();
            }
        }
        [HttpPost]
        public IActionResult Create(int PetId)
        {
            
            return View();
        }

        public IActionResult Check(int PetId)
        {
            

            return View();
        }
    }
}
