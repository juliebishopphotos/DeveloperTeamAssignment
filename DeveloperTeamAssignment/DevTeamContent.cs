using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperTeamAssignment
{
    public class DevTeamContent 
    {
        public string TeamName { get; set; }

        public List<DeveloperContent> TeamMembers { get; set; }

        public int TeamId { get; set; }

        public DevTeamContent() { } 

        public DevTeamContent(string teamName, List<DeveloperContent> teamMembers, int teamId)
        {
            TeamName = teamName; 

            TeamMembers = teamMembers;

            TeamId = teamId;
        }
    }
}
