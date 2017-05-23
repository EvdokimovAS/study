using DubrovkaSupplyLazurin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DubrovkaSupplyLazurin.Models
{
    public interface ICategorySkuRepository
    {
        IEnumerable<CategorySku> CategorySkus { get; }
        CategorySkuViewModel Get(int id);
        void Create(CategorySkuViewModel model);
        void Edit(int id, CategorySkuViewModel model);
    }
    public class CategorySkuRepository : ICategorySkuRepository
    {
        private readonly AppDbContext _appDbContext;

        public CategorySkuRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<CategorySku> CategorySkus => _appDbContext.CategerySkus;

        public void Create(CategorySkuViewModel model)
        {
            if (model.ImgThambnail == null)
                model.ImgThambnail = @"/images/CategorySku/default.png";

            var _categorySku = new CategorySku
            {
                Name = model.Name,
                ImgThambnail = model.ImgThambnail
            };

            _appDbContext.CategerySkus.Add(_categorySku);
            _appDbContext.SaveChanges();
        }

        public void Edit(int id, CategorySkuViewModel model)
        {
            var _categorySku = _appDbContext.CategerySkus
                .FirstOrDefault(c => c.CategorySkuId == id);
            _categorySku.Name = model.Name;
            _categorySku.ImgThambnail = model.ImgThambnail;

            _appDbContext.SaveChanges();
        }

        public CategorySkuViewModel Get(int id)
        {
            var _categorySku = _appDbContext.CategerySkus
                .FirstOrDefault(c => c.CategorySkuId == id);
            var _model = new CategorySkuViewModel
            {
                Name = _categorySku.Name
            };

            return _model;
        }
    }
}
