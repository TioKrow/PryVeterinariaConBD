using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PryVeterinariaConBD.Models;
using PryVeterinariaConBD.Models.ViewModel;
using System.Linq;
using System.Threading.Tasks;

namespace PryVeterinariaConBD.Controllers
{
    public class PetController : Controller
    {
        public IActionResult Index(string name, int IdTypes)
        {
            using (var x = new VeterinariaContext())
            {
                ViewData["PetTypes"] = new SelectList(x.Types.ToList(), "Id", "Type1");
                if (name != null && IdTypes != 0)
                {
                    var lst = from d in x.PetFiles.Include(f => f.IdTypeNavigation)
                               where d.Name == name && d.IdType == IdTypes
                              select d;
                    return View(lst.ToList());
                }
                else
                {
                    if (name == null && IdTypes == 0)
                    {
                        var lst = from d in x.PetFiles.Include(f => f.IdTypeNavigation)
                                  select d;
                        return View(lst.ToList());
                    }
                    else
                    {
                        if (IdTypes != 0)
                        {
                            var lst = from d in x.PetFiles.Include(f => f.IdTypeNavigation)
                                       where d.IdType == IdTypes
                                      select d;
                            return View(lst.ToList());
                        }
                        if (name != null)
                        {
                            var lst = from d in x.PetFiles.Include(f => f.IdTypeNavigation)
                                       where d.Name == name
                                       select d;
                            return View(lst.ToList());
                        }
                    }
                }
                return View();
            }
            
        }
        public IActionResult Create()
        {
            using (var x = new VeterinariaContext())
            {
                ViewData["PetTypes"] = new SelectList(x.Types.ToList(), "Id", "Type1");
                return View();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Create(PetFilesViewModel model)
        {
            if (ModelState.IsValid)
            {
                using (var x = new VeterinariaContext())
                {
                    var file = new PetFile()
                    {
                        Name = model.Name,
                        BirthdayDate = model.BirthdayDate,
                        OwnerName = model.OwnerName,
                        OwnerPhone = model.OwnerPhone,
                        CreationDate = model.CreationDate,
                        IdType = model.IdType,
                    };
                    x.Add(file);
                    await x.SaveChangesAsync();
                }
            }
            return View(model);
        }

        public IActionResult Check(int PetId)
        {
            using (var x = new VeterinariaContext())
            {
                var lst = from d in x.PetFiles.Include(f => f.IdTypeNavigation)
                          where d.Id == PetId
                          select d;
                return View(lst.ToList());
            }
        }
    }
}
