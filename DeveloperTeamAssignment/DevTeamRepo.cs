using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperTeamAssignment
{
    public class DevTeamRepo
    {
        private List<DevTeamContent> _contentDirectory = new List<DevTeamContent>();

        public bool AddContentToDirectory(DevTeamContent content) 
        {
            int startingCount = _contentDirectory.Count;
            _contentDirectory.Add(content); 
            bool wasAdded = (_contentDirectory.Count > startingCount) ? true : false;
            return wasAdded;
        }
        
        public List<DevTeamContent> GetContent()
        {
            return _contentDirectory;
        }
        public DevTeamContent GetContentByTeamName(string teamName) 
        {
            foreach (DevTeamContent content in _contentDirectory)
            {
                if (content.TeamName == teamName) 
                    {
                    return content;
                }
            }
            return null;
        }

        public bool UpdateExistingContent(string originalTeamName, DevTeamContent newContent)
        {
            DevTeamContent oldTeamContent = GetContentByTeamName(originalTeamName);
            if (oldTeamContent != null)
            {
                oldTeamContent.TeamName = newContent.TeamName;
                oldTeamContent.TeamMembers = newContent.TeamMembers;
                oldTeamContent.TeamId = newContent.TeamId;
                return true;
            }
            else
            {
                return false;
            }
        }
       
        public bool DeleteExistingContent(DevTeamContent existingContent)
        {
            bool deleteResult = _contentDirectory.Remove(existingContent);
            return deleteResult;
        }

    }
}
