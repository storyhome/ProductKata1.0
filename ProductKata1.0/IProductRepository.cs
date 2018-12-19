using System.Collections.Generic;

namespace ProductKata1._0
{
    public interface IProductRepository
    {
        void Save(Product product);
        List<Product> Find();
    }
}
