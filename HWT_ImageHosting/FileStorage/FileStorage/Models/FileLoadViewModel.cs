using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;
using FileStorage.CustomAttributes;

namespace FileStorage.Models
{
    public class FileLoadViewModel
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Название файла обязательно для заполнения")]
        [StringLength(7, ErrorMessage = "Слишком длиное названание")]
        public string Name { get; set; }

        [StringLength(40, ErrorMessage = "Слишком длинное описание")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Вы должны выбрать файл")]
        [MaxFileSize(2 * 1024 * 1024, ErrorMessage = "Максимальный размер файла {0} байт")]
        [Remote("CheckFileExtension", "Home")]
        public HttpPostedFileBase Content { get; set; }

        public bool IsPublic { get; set; }

        public IList<CheckboxRoleViewModel> VisibleForRole { get; set; }

        public FileLoadViewModel()
        {
            VisibleForRole = new List<CheckboxRoleViewModel>();
        }
    }
}