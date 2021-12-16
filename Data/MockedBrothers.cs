using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualDean.Models;

namespace VirtualDeanUnitTests.Data
{
    class MockedBrothers
    {
        public IEnumerable<VirtualDean.Models.Brother> getMockedBrothers()
        {
            var mockBrothers = new List<VirtualDean.Models.Brother>();
            for (int i = 1; i <= 3; i++)
            {
                mockBrothers.Add(new Brother
                {
                    Id = i,
                    Name = "Bro",
                    Surname = "OP",
                    precedency = DateTime.Today,
                    isSinging = false,
                    isLector = true,
                    isAcolit = true,
                    isDiacon = false
                }); ;
            }
            return mockBrothers;
        }
    }
}
