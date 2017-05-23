using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DubrovkaSupplyLazurin.Models
{
    public class CategorySku
    {
        [Required]
        public int CategorySkuId { get; set; }

        [Required]
        [MaxLength(15)]
        public string Name { get; set; }

        public string ImgThambnail { get; set; }

        public List<Sku> Skus { get; set; }
    }
}
