using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace JubatusAdmin.ViewModels
{
    public class CategoriesViewModel
    {

        [Required(ErrorMessage = "Boş Bırakılamaz!")]
        [Display(Name = "Kategori ismi")]
        [StringLength(50, ErrorMessage = "En fazla 50 karakter olmalı!")]
        public string CategorieName { get; set; }

        public int CategorieId { get; set; }

        public int CreatedBy { get; set; }

        public System.DateTime CreateTime { get; set; }
        public bool IsEnabled { get; set; }

        public string ResultMessage { get; set; }
    }

}