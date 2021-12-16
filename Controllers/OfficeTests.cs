using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using VirtualDean.Controllers;
using VirtualDean.Data;
using VirtualDean.Models;
using VirtualDeanUnitTests.Data;

namespace VirtualDeanUnitTests.Controllers
{
    class OfficeTests
    {
        [Test]
        public async Task GetBrothers_WhenCall_ReturnsAllBrothers()
        {
            var mockedBrothers = new MockedBrothers().getMockedBrothers();

            var mockedRepositoryBrother = new Mock<IBrothers>();
            mockedRepositoryBrother
                .Setup(repo => repo.GetBrothers())
                .Returns(() => Task.FromResult(mockedBrothers.AsEnumerable()));

            var officeController = new VirtualDean.Controllers.Offices(mockedRepositoryBrother.Object, null, null, null);
            var result = await officeController.GetBrothers();
            Assert.Multiple(() =>
            {
                Assert.That(result, Has.Count.EqualTo(3));
                Assert.That(result.ElementAt(1).Id, Is.EqualTo(2));
                Assert.That(result.ElementAt(1).Name, Is.EqualTo("Bro"));
                Assert.That(result.ElementAt(1).Surname, Is.EqualTo("OP"));
                Assert.That(result.ElementAt(1).isSinging, Is.EqualTo(false));
                Assert.That(result.ElementAt(1).isLector, Is.EqualTo(true));
                Assert.That(result.ElementAt(1).isAcolit, Is.EqualTo(true));
                Assert.That(result.ElementAt(1).isDiacon, Is.EqualTo(false));
            });
        }
    }
}
