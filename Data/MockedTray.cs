using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualDean.Models;
using VirtualDean.Enties;

namespace VirtualDeanUnitTests.Data
{
    public class MockedTray
    {
        public IEnumerable<TrayOfficeAdded> GetTrays()
        {
            var trays = new List<TrayOfficeAdded>();
            var constTrays = new Hours().TrayHours;
            for(int i = 1; i <= 3; i++)
            {
                trays.Add(new TrayOfficeAdded
                {
                    Id = i,
                    BrotherId = i,
                    WeekOfOffices = 1,
                    TrayHour = constTrays.ElementAt(i)
                });
            }
            return trays;
        }

        public IEnumerable<TrayOfficeAdded> GetFakeTrays()
        {
            var trays = new List<TrayOfficeAdded>();
            var constTrays = new Hours().TrayHours;
            for (int i = 1; i <= 3; i++)
            {
                trays.Add(new TrayOfficeAdded
                {
                    Id = i,
                    BrotherId = i,
                    WeekOfOffices = 1,
                    TrayHour = "2.53"
                });
            }
            return trays;
        }
    }
}
