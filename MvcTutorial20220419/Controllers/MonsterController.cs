using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcTutorial20220419.Models;

namespace MvcTutorial20220419.Controllers
{
    public class MonsterController : Controller
    {
        private static List<Monster> _heroes = new List<Monster>()
        {
            new Monster() { Id = 1, Name = "女武神", Atk = 999, Def = 500},
            new Monster() { Id = 2, Name = "火焰巨人", Atk = 600, Def = 1000},
            new Monster() { Id = 3, Name = "無頭騎士", Atk = 100, Def = 300},
            new Monster() { Id = 4, Name = "獅子王", Atk = 700, Def = 1200},
            new Monster() { Id = 5, Name = "艾爾登之獸", Atk = 850, Def = 2000},
        };
        public ActionResult LinqDemo()
        {
            // 不等於 !=
            //return RedirectToAction(nameof(Index));
            var Lionking = _heroes.FirstOrDefault(x => x.Name == "獅子王");
            var Valkyrie = _heroes.FirstOrDefault(x => x.Name == "女武神");
            var MonsterAtk600 = _heroes.Where(x => x.Atk > 600).ToList();
            var manpower = _heroes.Where(x => x.Atk > 500 && x.Id != 2);
            var aaa = _heroes.OrderByDescending(x => x.Id).ToList();
            var bbb = _heroes.OrderBy(x => x.Def).ToList();
            var MonsterMax = _heroes.Max(x => x.Def);
            var allAtk = _heroes.Sum(x => x.Atk);
            return RedirectToAction("Index");
            
        }


        // GET: MonsterController
        public ActionResult Index()
        {
            return View();
        }

        // GET: MonsterController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MonsterController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MonsterController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Monster collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MonsterController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MonsterController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MonsterController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MonsterController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
