using System;
using System.Collections.Generic;
using System.Text;

namespace ProductKata1._0
{
    public class ProductPersister
    {
        private IProductRepository _productRepository;

        public ProductPersister(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void Save(Product product)
        {
            if (product.ExpirationDate.Date < DateTime.Now.Date)
            {
                throw new ArgumentException("Expiration Date can not be less than the current date");
            }
            else
            {
                _productRepository.Save(product);
            }
        }

        public List<Product> Find()
        {
            return _productRepository.Find();
        }

        public Product FindByName(string productName)
        {
            return new Product();
        }

    }
}
