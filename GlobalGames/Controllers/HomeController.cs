using GlobalGames.Data;
using GlobalGames.Data.Entidades;
using GlobalGames.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;



namespace GlobalGames.Controllers
{
    public class HomeController : Controller
    {

        private readonly DataContext _context;

        public HomeController(DataContext context)
        {
            _context = context;
        }



        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Sobre()
        {

            return View();
        }

        public IActionResult Servicos()
        {

            return View();
        }

        public IActionResult Inscricao()
        {

            return View();
        }
        // POST: Contactos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.           //FEITO POR JD
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Servicos([Bind("Id,Name,Email,msg")] Contactos contactos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contactos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }



        // POST: Contactos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.  FEITO POR JD
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Inscricoes([Bind("Id,Name,LastName,Address,Localidade,CCidadao,Birthday,ImageFile")] InscricaoViewModel view)
        {
            if (ModelState.IsValid)
            {
                var path = string.Empty;

                if (view.ImageFile != null && view.ImageFile.Length > 0)
                {
                    var guid = Guid.NewGuid().ToString();
                    var file = $"{guid}.jpg";



                    path = Path.Combine(
                        Directory.GetCurrentDirectory(),
                        "wwwroot\\images\\Img",
                        file);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await view.ImageFile.CopyToAsync(stream);
                    }

                    path = $"~/images/Img/{file}";

                }

                var inscricao = this.ToInscricoes(view, path);






                _context.Add(inscricao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(view);
        }

        private Inscricoes ToInscricoes(InscricaoViewModel view, string path)
        {
            return new Inscricoes
            {
                
                Id = view.Id,
                ImageUrl = path,
                Address = view.Address,
                Localidade = view.Localidade,
                Name = view.Name,
                LastName = view.LastName,
                CCidadao = view.CCidadao,
                Birthday = view.Birthday,
                User = view.User
            };
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}