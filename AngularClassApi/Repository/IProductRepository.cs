using AngularClassApi.Models;
using System.Collections.Generic;

namespace AngularClassApi.Repository
{
    public interface IProductRepository
    {
        void Create(ProductModel data);
        void Delete(int id);
        IList<ProductModel> GetAll();
        ProductModel GetById(int id);
        void Update(ProductModel data);
        ProductModel Last();
    }
}