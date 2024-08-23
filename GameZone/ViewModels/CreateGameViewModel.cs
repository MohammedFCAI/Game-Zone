using GameZone.Attributes;
using GameZone.Settings;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace GameZone.ViewModels
{
    public class CreateGameViewModel
    {
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; } = Enumerable.Empty<SelectListItem>();

        [Display(Name = "Supported Devices")]
        public List<int> SelectedDevices { get; set; } = default!;

        public IEnumerable<SelectListItem> Devices { get; set; } = Enumerable.Empty<SelectListItem>();

        public string Description { get; set; } = string.Empty;


        // With API Is Good To Use ==> [Extension]
        [AllowedExtension(FileSettings.AllowedExtension),
            MaxFileSize(FileSettings.MaxFileSizeInMB)]
        public IFormFile Cover { get; set; } = default!;
    }
}
