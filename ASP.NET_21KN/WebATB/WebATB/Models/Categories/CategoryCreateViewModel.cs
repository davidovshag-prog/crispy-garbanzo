using System.ComponentModel.DataAnnotations;

namespace WebATB.Models.Categories;

public class CategoryCreateViewModel
{
    [Display(Name = "Вкажіть назву категорії")]
    [Required(ErrorMessage = "Вкажіть назву категорії.")]
    public string Name { get; set; } = null!;
    [Display(Name = "Вкажіть slug категорії")]
    [Required(ErrorMessage = "Вкажіть slug.")]
    public string Slug { get; set; } = null!;
    [Display(Name = "Оберіть фото категорії")]
    [Required(ErrorMessage = "Вкажіть фото категорії.")]
    public IFormFile? FileImage { get; set; }
}
