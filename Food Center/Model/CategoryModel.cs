using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Food_Center.Model
{
    public class CategoryModel
    {
        [Required(ErrorMessage = "Category required")]
        public string CategoryName { get; set; }
        public string Descritption { get; set; }
    }
}
