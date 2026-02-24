using Microsoft.AspNetCore.Mvc;
using WebATB.Data;
using WebATB.Data.Entities;
using WebATB.Models.Categories;

namespace WebATB.Controllers;
// робимо Injection для роботи з БД,
// але поки що просто виводимо сторінку
public class CategoriesController(MyContextATB myContextATB) 
    : Controller
{
    public IActionResult Index()
    {
        var categories = myContextATB.Categories.ToList();
        return View(categories);
    }
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Create(CategoryCreateViewModel model)
    {
        if (ModelState.IsValid) // зберігання в бд, якщо модель валідна
        {
            string fileName = "default.jpg";
            // як зберігати фото
            if (model.FileImage != null)
            {
                var dir = Directory.GetCurrentDirectory();
                var wwwroot = "wwwroot";
                fileName = Guid.NewGuid().ToString() + ".jpg";
                var savePath = Path.Combine(dir, wwwroot, "images", fileName);
                using (var stream = new FileStream(savePath, FileMode.Create))
                {
                    model.FileImage.CopyTo(stream);
                }
            }
            // Заповнюю таблицю катьегорії ДБ
            var category = new CategoryEntity
            {
                Name = model.Name,
                Slug = model.Slug,
                Image = fileName
            };
            myContextATB.Categories.Add(category);// Роблю SQL запит INSERT
            myContextATB.SaveChanges();// Зберігаю зміни в БД - виконую SQL запит
            return RedirectToAction(nameof(Index));
        }
        return View(model); // якщо модель не валідна, повертаємо її назад на сторінку
    }
}
