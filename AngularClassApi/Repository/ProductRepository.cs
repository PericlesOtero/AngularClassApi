using AngularClassApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace AngularClassApi.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly IList<ProductModel> _products;

        public ProductRepository()
        {
            _products = new List<ProductModel>
            {
                new ProductModel(){Id= 1, Name= "Lapis", Price= 2.5M },
                new ProductModel(){Id= 2, Name= "Caderno", Price= 15},
                new ProductModel(){Id= 3, Name= "Borracha",Price= 5},
                new ProductModel(){Id= 4, Name= "Mochila", Price=45},
                new ProductModel(){Id= 5, Name= "Apontador",Price= 8.5M}
            };
        }

        public IList<ProductModel> GetAll()
        {
            return _products.ToList();
        }

        public ProductModel GetById(int id)
        {
            return _products.FirstOrDefault(x => x.Id == id);
        }

        public void Create(ProductModel data)
        {
            var newId = _products.Last().Id + 1;

            data.Id = newId;

            _products.Add(data);
        }
        public void Update(ProductModel data)
        {
            var product = _products.FirstOrDefault(x => x.Id == data.Id);

            if (product != null)
            {
                product.Id = data.Id;
                product.Name = data.Name;
                product.Price = data.Price;
            }
        }

        public void Delete(int id)
        {
            var product = _products.FirstOrDefault(x => x.Id == id);

            if (product != null)
                _products.Remove(product);
        }
        public ProductModel Last()
        {
            return _products.Last();
        }
    }
}
