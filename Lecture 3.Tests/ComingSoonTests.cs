using Lecture3.Controllers;
using Lecture3.Infrastructure;
using Lecture3.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Lecture3.Tests
{
    public class FakedBookRepository : IBookRepository
    {

        public IEnumerable<Book> Books
        {
            get
            {
                yield return new Book { Id = 1, AvailabilityDate = new DateTime(2001, 1, 1) };
                yield return new Book { Id = 2, AvailabilityDate = new DateTime(2001, 2, 1) };
                yield return new Book { Id = 3, AvailabilityDate = new DateTime(2001, 3, 1) };

            }
        }
    }

    public class FakedCurrentDateProvider : ICurrentDateProvider
    {

        public DateTime Now
        {
            get { return new DateTime(2001, 1, 2); }
        }
    }

    [TestClass]
    public class ComingSoonTests
    {
         [TestMethod]
        public void Test()
        {
            MakeTest(
                new FakedCurrentDateProvider(),
                new FakedBookRepository()
                );
       
        }

        void MakeTest(ICurrentDateProvider dateProvider, IBookRepository bookRepository)
        {
            var controller = new TestableComingSoonController(bookRepository, dateProvider);
            var actionResult = controller.Index();
            Assert.IsInstanceOfType(actionResult, typeof(ViewResult));
            var viewResult = actionResult as ViewResult;
            Assert.IsInstanceOfType(viewResult.Model, typeof(IEnumerable<Book>));
            var list = (viewResult.Model as IEnumerable<Book>).ToList();
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(2, list[0].Id);
        }

        [TestMethod]
        public void MockTest()
        {
            var dateMock = new Mock<ICurrentDateProvider>();
            dateMock.Setup(z => z.Now).Returns(new DateTime(2001, 1, 2));
            var repMock = new Mock<IBookRepository>();
            repMock.Setup(z => z.Books).Returns(
                new List<Book>
                {
                    new Book { Id=1, AvailabilityDate=new DateTime(2001,1,1)},
                    new Book { Id=2, AvailabilityDate=new DateTime(2001,2,1)},
                    new Book { Id=3, AvailabilityDate=new DateTime(2001,3,1)},

                });
            MakeTest(dateMock.Object, repMock.Object);
        }
    }
}
