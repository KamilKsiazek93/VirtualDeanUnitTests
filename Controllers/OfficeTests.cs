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
using VirtualDean.Enties;
using VirtualDeanUnitTests.Data;

namespace VirtualDeanUnitTests.Controllers
{
    class OfficeTests
    {
        [Test]
        public async Task GetBrothers_WhenCall_ReturnsAllBrothers()
        {
            var mockedBrothers = new MockedBrothers().GetMockedBrothers();

            var mockedRepositoryBrother = new Mock<IBrothers>();
            mockedRepositoryBrother
                .Setup(repo => repo.GetBrothers())
                .Returns(() => Task.FromResult(mockedBrothers.AsEnumerable()));

            var officeController = new VirtualDean.Controllers.Offices(mockedRepositoryBrother.Object, null, null, null, null);
            var result = await officeController.GetBrothers();
            Assert.Multiple(() =>
            {
                Assert.That(result, Has.Count.EqualTo(3));
                Assert.That(result.ElementAt(1).Id, Is.EqualTo(2));
                Assert.That(result.ElementAt(1).Name, Is.EqualTo("Bro"));
                Assert.That(result.ElementAt(1).Surname, Is.EqualTo("OP"));
                Assert.That(result.ElementAt(1).IsSinging, Is.EqualTo(false));
                Assert.That(result.ElementAt(1).IsLector, Is.EqualTo(true));
                Assert.That(result.ElementAt(1).IsAcolit, Is.EqualTo(true));
                Assert.That(result.ElementAt(1).IsDiacon, Is.EqualTo(false));
                Assert.That(result.ElementAt(1).StatusBrother, Is.EqualTo(BrotherStatus.BRAT));
            });
        }

        [Test]
        public async Task GetBrothers_WhenProvideId_ReturnsBrotherWithProvidedId()
        {
            var mockedBrothers = new MockedBrothers().GetMockedBrothers();
            var mockedRepositoryBrother = new Mock<IBrothers>();
            mockedRepositoryBrother
                .Setup(repo => repo.GetBrother(2))
                .Returns(() => Task.FromResult(mockedBrothers.ElementAt(1)));
            var officeController = new VirtualDean.Controllers.Offices(mockedRepositoryBrother.Object, null, null, null, null);
            var result = await officeController.GetBrothers(2);
            Assert.Multiple(() =>
            {
                Assert.That(result.Id, Is.EqualTo(2));
                Assert.That(result.Name, Is.EqualTo("Bro"));
                Assert.That(result.Surname, Is.EqualTo("OP"));
                Assert.That(result.IsSinging, Is.EqualTo(false));
                Assert.That(result.IsLector, Is.EqualTo(true));
                Assert.That(result.IsAcolit, Is.EqualTo(true));
                Assert.That(result.IsDiacon, Is.EqualTo(false));
            });
        }

        [Test]
        public async Task GetTrays_WhenCall_ReturnListOfTrays()
        {
            var mockedTrays = new MockedTray().GetTrays();
            var mockedTrayRepository = new Mock<ITrayCommunionHour>();
            mockedTrayRepository
                .Setup(repo => repo.GetTrayHours())
                .Returns(() => Task.FromResult(mockedTrays));

            var officeController = new Offices(null, null, mockedTrayRepository.Object, null, null);
            var result = await officeController.GetTrayHour();
            Assert.Multiple(() =>
            {
                Assert.That(result.ElementAt(0).TrayHour, Is.EqualTo("9.00"));
                Assert.That(result.ElementAt(1).TrayHour, Is.EqualTo("10.30"));
                Assert.That(result.ElementAt(2).TrayHour, Is.EqualTo("12.00"));
            });
        }
    }
}
