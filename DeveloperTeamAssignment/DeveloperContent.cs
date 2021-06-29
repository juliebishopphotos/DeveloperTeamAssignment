using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperTeamAssignment
{
    public class DeveloperContent
    {
        public string FullName { get; set; }
        public int IdNumber { get; set; }
        public bool PluralsightAccess { get; set; }


        public DeveloperContent() { }

        public DeveloperContent(string fullName, int idNumber, bool pluralsightAccess)
        {
            FullName = fullName;
            IdNumber = idNumber;
            PluralsightAccess = pluralsightAccess;
        }

    }
}
