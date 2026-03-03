using System.ComponentModel.DataAnnotations;

namespace WebATB.Models.Categories;

public class CategoryEditViewModel
{
    public int Id { get; set; } // вказуємо id категорії, яку ми редагуємо, щоб знати яку категорію оновлювати в БД
    [Display(Name = "Вкажіть назву категорії")]
    [Required(ErrorMessage = "Вкажіть назву категорії.")]
    public string Name { get; set; } = null!;
    [Display(Name = "Вкажіть slug категорії")]
    [Required(ErrorMessage = "Вкажіть slug.")]
    public string Slug { get; set; } = null!;
    public string ? OldImage { get; set; }
    [Display(Name = "Оберіть фото категорії")]
    [Required(ErrorMessage = "Вкажіть фото категорії.")]
    public IFormFile? FileImage { get; set; }
}
