using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcTutorial20220419.Models;

namespace MvcTutorial20220419.Controllers
{
    // Action 就是控制器的 function / method
    public class HeroController : Controller
    {
        private static List<Hero> _heroes = new List<Hero>()
        {
            new Hero() { Id = 1, Name = "鋼鐵人", Atk = 10, Hp = 50},
            new Hero() { Id = 2, Name = "索爾", Atk = 15, Hp = 40},
            new Hero() { Id = 3, Name = "美國隊長", Atk = 5, Hp = 60},
            new Hero() { Id = 4, Name = "黑寡婦", Atk = 20, Hp = 40},
            new Hero() { Id = 5, Name = "古魯特", Atk = 10, Hp = 70},
        };
        public ActionResult LinqDemo()
        {// Lambda 運算式（箭頭運算式）：
         //      左邊：宣告暫時變數    右邊：運算式，根據不同的 LINQ function 會有不同寫法
            #region hide
            // LINQ 就是拿來做資料查詢
            // First 取得第一筆符合條件的資料，如果找不到會出錯
            
            var ironman = _heroes
                .First(x => x.Name == "鋼鐵人");

            // 取得第一筆符合條件的資料，如果找不到就回傳預設值（大部分是 null）
            var thor = _heroes
                .FirstOrDefault(x => x.Id == 2);
            var eric = _heroes
                .FirstOrDefault(x => x.Name == "Eric"); // 大部分 class 預設值是 null

            // Where: 取得所有符合條件的資料
            // && => 且；|| => 或
            // ToList() 是讓我們可以預覽多筆回傳資料的結果
            var ironmanAndThor = _heroes
                .Where(x => x.Name == "鋼鐵人" || x.Id == 2)
                .ToList();

            var hightAtk = _heroes.Where(x => x.Atk > 10)
                .ToList();

            // OrderBy: 按照指定的欄位由低到高排序
            var orderByHp = _heroes.OrderBy(x => x.Hp);
            //OrderByDescending 按照指定的欄位由高到低排序 
            var orderByAtk = _heroes.OrderByDescending(x => x.Atk)
                .ToList();
            #endregion

            // Max: 按照指定的欄位，取得所有資料中這個欄位的最大值
            var maxAtkValue = _heroes.Max(x => x.Atk);
            // Min: 按照指定的欄位，取得所有資料中這個欄位的最小值
            var minHpValue = _heroes.Min(x => x.Hp);
            // Sum: 加總指定的欄位
            var hpSum = _heroes.Sum(x => x.Hp);

            // return RedirectToAction(nameof(Index));
            return RedirectToAction("Index");
        }

        // GET: HeroController
        public ActionResult Index()
        {
            return View(_heroes);
        }

        // GET: HeroController/Details/5
        public ActionResult Details(int id)
        {
            var hero = _heroes.First(x => x.Id == id);
            return View(hero);
        }

        // 1. HttpGet 取得表單
        // 2. HttpPost 提交表單

        // GET: https://localhost:7049/Hero/Create
        public ActionResult Create()
        {
            // return View() 會尋找一個網頁樣板，然後把資料打包，一起回傳給瀏覽器
            // Views/Hero/Create.cshtml
            return View();
        }

        // POST: HeroController/Create
        // 處理 POST 請求的 Action 必須在前面加上 [HttpPost]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Hero model)
        {
            try
            {
                _heroes.Add(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(model);
            }
        }

        // GET: HeroController/Edit/5
        public ActionResult Edit(int id)
        {
            var hero = _heroes.First(x => x.Id == id);
            return View(hero);
        }

        // POST: HeroController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Hero model)
        {
            try
            {
                var hero = _heroes.First(x => x.Id == id);
                hero.Name = model.Name;
                hero.Atk = model.Atk;
                hero.Hp = model.Hp;
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HeroController/Delete/5
        public ActionResult Delete(int id)
        {
            var hero = _heroes.First(x => x.Id == id);
            return View(hero);
        }

        // POST: HeroController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var hero = _heroes.First(x => x.Id == id);
                _heroes.Remove(hero);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}
