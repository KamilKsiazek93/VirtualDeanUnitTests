using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualDean.Models;
using VirtualDean.Enties;

namespace VirtualDeanUnitTests.Data
{
    public class MockedCommunion
    {
        public IEnumerable<CommunionOfficeAdded> GetCommunions()
        {
            var communions = new List<CommunionOfficeAdded>();
            var constCommunion = new Hours().CommunionHours;
            for (int i = 1; i <= 3; i++)
            {
                communions.Add(new CommunionOfficeAdded
                {
                    Id = i,
                    BrotherId = i,
                    WeekOfOffices = 1,
                    CommunionHour = constCommunion.ElementAt(i)
                });
            }
            return communions;
        }
    }
}
