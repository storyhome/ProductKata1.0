using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using ProductKata1._0;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace ProductKata1._0Test
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void ProductExpirationDateBeforeCurrentSaves()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();

            Product p = new Product() { Id = 1, ExpirationDate = DateTime.Now.AddDays(1), Name = "product1" };

            ProductPersister sut = new ProductPersister(mock.Object);
            sut.Save(p);
            mock.Verify(x => x.Save(p), Times.Once);
        }

        [Test]
        //[ExpectedException(typeof(ArgumentException))]
        public void AProductWithAnInvalidExpirationDateShouldThrowException()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(x => x.Save(It.IsAny<Product>()));

            Product p = new Product() { Id = 1, ExpirationDate = DateTime.Now.AddDays(-1), Name = "product1" };

            ProductPersister sut = new ProductPersister(mock.Object);
            
            //mock.Verify(x => x.Save(p), Times.Never);
            Assert.ThrowsException<ArgumentException>(() => sut.Save(p));
        }
    }
}
