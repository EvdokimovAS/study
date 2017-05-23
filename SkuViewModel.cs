using DubrovkaSupplyLazurin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DubrovkaSupplyLazurin.ViewModels
{
    public class SkuViewModel
    {
        [Required]
        [MaxLength(30,ErrorMessage ="Не более 30 символов")]
        [Display(Name="Наименование")]
        public string Name { get; set; }

        [MaxLength(255)]
        [Display(Name="Описание")]
        public string Description { get; set; }

        [Required]
        [Display(Name="Ед. измерения")]
        public SkuUnit SkuUnit { get; set; }

        [Required]
        [Display(Name="Категория")]
        public string CatergorSkuSelected { get; set; }
    }
}
