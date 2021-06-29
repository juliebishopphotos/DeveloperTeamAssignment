using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperTeamAssignment
{
    public class DeveloperRepo
    {
        private List<DeveloperContent> _contentDirectory = new List<DeveloperContent>();

        public bool AddContentToDirectory(DeveloperContent content)
        {
            int startingCount = _contentDirectory.Count;
            _contentDirectory.Add(content);
            bool wasAdded = (_contentDirectory.Count > startingCount) ? true : false;
            return wasAdded;
        }
       
        public List<DeveloperContent> GetContent()
        {
            return _contentDirectory;
        }
        public DeveloperContent GetContentByFullName (string fullName)
        {
            foreach (DeveloperContent content in _contentDirectory)
            {
                if (content.FullName== fullName)
                {
                    return content; 
                }
            }
            return null;
        }

        public bool UpdateExistingContent(string originalFullName, DeveloperContent newContent)
        {
           DeveloperContent oldContent = GetContentByFullName(originalFullName);
            if (oldContent != null)
            {
                oldContent.FullName = newContent.FullName;
                oldContent.IdNumber = newContent.IdNumber;
                oldContent.PluralsightAccess = newContent.PluralsightAccess;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteExistingContent(DeveloperContent existingContent)
        {
            bool deleteResult = _contentDirectory.Remove(existingContent);
            return deleteResult;
        }



            
    }
}
