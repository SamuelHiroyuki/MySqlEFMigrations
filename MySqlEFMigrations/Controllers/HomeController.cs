using MySqlEFMigrations.Context;
using MySqlEFMigrations.Models;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace MySqlEFMigrations.Controllers
{
    public class HomeController : Controller
    {
        private readonly MySqlContext _db;

        public HomeController()
        {
            _db = new MySqlContext();
        }

        public ActionResult Index()
        {
            return View(_db.Livros.OrderBy(x => x.ID));
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            return View(_db.Livros.FirstOrDefault(x => x.ID == id));
        }

        [HttpPost]
        public ActionResult Create(Livro livro)
        {
            if (ModelState.IsValid)
            {
                if (!_db.Livros.Any(x => x.ID == livro.ID))
                {
                    _db.Livros.Add(livro);
                    _db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            else
                return View("NovoLivro", livro);
        }

        [HttpPost]
        public ActionResult Edit(Livro livro)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(livro).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return View("EditarLivro", livro);
        }

        public ActionResult Delete(int id)
        {
            var livro = _db.Livros.FirstOrDefault(x => x.ID == id);
            _db.Set<Livro>().Remove(livro);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}