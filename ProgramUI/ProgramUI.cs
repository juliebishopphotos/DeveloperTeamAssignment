using DeveloperTeamAssignment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamConsoleApp
{
    public class ProgramUI
    {
        private DeveloperRepo _developerRepo = new DeveloperRepo();

        private DevTeamRepo _devTeamRepo = new DevTeamRepo();

        public void Run()
        {
            SeedContentList();

            DisplayMenu();
        }

        private void DisplayMenu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                
                Console.WriteLine(
                    "Enter the number of the option you would like to select: \n" +
                    "1. Show list of developers \n" +
                    "2. Find developer by full name \n" +
                    "3. Add Developer content\n" +
                    "4. Remove Developer content\n" +
                    "5. Update content\n" +
                    "6. Show list of developer teams \n" +
                    "7. Create new team \n" +
                    "8. Add Developer to team \n" +
                    "9.Remove Developer from team \n" +
                    "10. Exit \n");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        ShowListOfDevelopers();
                    
                        break;
                    case "2":
                        FindDeveloperByFullName();
                        
                        break;
                    case "3":
                        AddDeveloperContent();
                        
                        break;
                    case "4":
                        DeleteDeveloperContent();
                        
                        break;
                    case "5":
                        UpdateContent();
                       
                        break;
                    case "6":
                        ShowTeamList();

                        break;
                    case "7":
                        CreateNewTeam();

                        break;
                    case "8":
                        AddDeveloperToTeam();

                        break;
                    case "9":
                        DeleteDeveloperFromTeam();

                        break;
                    case "10":
                        
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number between 1 and 5");
                        ReduceRed();
                        break;

                }
            }
        }
        private void AddDeveloperContent() 
        {
            Console.Clear();
            
            Console.Write("Please enter developers full name: ");
            string fullName = Console.ReadLine();

            Console.Write("Please enter developers ID Number: ");
            int idNumber = int.Parse(Console.ReadLine());

            Console.Write("Do they have access to Pluralsight: ");
            bool pluralSightAcess = bool.Parse(Console.ReadLine());

            _developerRepo.AddContentToDirectory(new DeveloperContent(fullName, idNumber, pluralSightAcess));
        }

        private void CreateNewTeam()
        {
            Console.Clear();

            Console.Write("Please enter new team name: ");
            string teamName = Console.ReadLine();

            Console.Write("Please enter new team members: ");
            List<DeveloperContent> TeamMembers = new List<DeveloperContent>();

            Console.Write("Please enter new team ID: ");
            int teamId = int.Parse(Console.ReadLine());

            _devTeamRepo.AddContentToDirectory(new DevTeamContent(teamName, TeamMembers, teamId));
        }

        private void AddDeveloperToTeam()
        {
            Console.Clear();

            Console.Write("Please enter the team name: ");
            string teamName = Console.ReadLine();

            Console.Write("Please enter the team member: ");
            List<DeveloperContent> TeamMembers = new List<DeveloperContent>();

            Console.Write("Please enter the team ID: ");
            int teamId = int.Parse(Console.ReadLine());

            _devTeamRepo.AddContentToDirectory(new DevTeamContent(teamName, TeamMembers, teamId));
        }

        private void ShowListOfDevelopers()
        {
            Console.Clear();

            List<DeveloperContent> listOfContent = _developerRepo.GetContent();

            foreach (DeveloperContent content in listOfContent)
            {
                DisplayContent(content);
            }

            ReduceRed();
        }

        private void ShowTeamList()
        {
            Console.Clear();

            List<DevTeamContent> listOfContent = _devTeamRepo.GetContent();

            foreach (DevTeamContent content in listOfContent)
            {
                DisplayContent(content);
            }

            ReduceRed();
        }


        private void FindDeveloperByFullName() 
        {
            Console.Clear();
            
            Console.WriteLine("What is the Full Name of the Developer you're searcing for?");
            
            string fullName = Console.ReadLine();

            DeveloperContent content = _developerRepo.GetContentByFullName(fullName);

            if (content != null)
            {
                DisplayContent(content);
            }
            else
            {
                Console.WriteLine("Failed to find Developer by Full Name");
            }

            ReduceRed();
        }

        private void DeleteDeveloperContent()   
        {
            Console.Clear();
            
            Console.WriteLine("Which Developer would you like to remove?");

            int count = 0;

            List<DeveloperContent> contentList = _developerRepo.GetContent();
            foreach (DeveloperContent content in contentList)
            {
                count++;
                Console.WriteLine($"{count}. {content.FullName}");
            }

            int userInput = int.Parse(Console.ReadLine());
            int targetIndex = userInput - 1;

            if (targetIndex >= 0 && targetIndex < contentList.Count())
            {
                DeveloperContent targetContent = contentList[targetIndex];
                
                if (_developerRepo.DeleteExistingContent(targetContent))
                {
                    Console.WriteLine($"{targetContent.FullName} removed from repo");
                }
                else
                {
                    Console.WriteLine("Sorry something went wrong");
                }
            }
 
            else
            {
                Console.WriteLine("Invalid Selection");
            }
            ReduceRed();
        }

        private void DeleteDeveloperFromTeam()
        {
            Console.Clear();

            Console.WriteLine("Which Team Member would you like to remove?");

            int count = 0;

            List<DevTeamContent> contentList = _devTeamRepo.GetContent();
            foreach (DevTeamContent content in contentList)
            {
                count++;
                Console.WriteLine($"{count}. {content.TeamMembers}");
            }

            int userInput = int.Parse(Console.ReadLine());
            int targetIndex = userInput - 1;

            if (targetIndex >= 0 && targetIndex < contentList.Count())
            {
                DevTeamContent targetContent = contentList[targetIndex];

                if (_devTeamRepo.DeleteExistingContent(targetContent))
                {
                    Console.WriteLine($"{targetContent.TeamMembers} removed from repo");
                }
                else
                {
                    Console.WriteLine("Sorry something went wrong");
                }
            }

            else
            {
                Console.WriteLine("Invalid Selection");
            }
            ReduceRed();
        }

        private void UpdateContent()
        {
            Console.Clear();
            
            Console.WriteLine("Which Developer's information would you like to update?");
            string userInput = Console.ReadLine();

            DeveloperContent updatedContent = new DeveloperContent();
            
            Console.Write("What is their new FullName:");
            updatedContent.FullName = Console.ReadLine();
      
            Console.Write("Please enter their new ID Number:");
            updatedContent.IdNumber = int.Parse(Console.ReadLine());

            Console.Write("Do they have Pluralsight access: ");
            updatedContent.PluralsightAccess = bool.Parse(Console.ReadLine());

            Console.Write("What is their new Team Name: ");
            string teamName = Console.ReadLine();

            Console.Write("Please enter their new Team ID: ");
            int teamID = int.Parse(Console.ReadLine());



            _developerRepo.UpdateExistingContent(userInput, updatedContent);
            
            ReduceRed();
        }
        
        //Helper Methods
        
        private void DisplayContent(DeveloperContent content)
        {
            Console.WriteLine($"FullName: {content.FullName}\n" +
                    $"IdNumber: {content.IdNumber}\n" +
                    $"PluralsightAccess: {content.PluralsightAccess}\n");
        }

        private void DisplayContent(DevTeamContent content)
        {
            Console.WriteLine($"TeamName: {content.TeamName}\n" +
                    $"TeamMembers: {content.TeamMembers}\n" +
                    $"TeamId: {content.TeamId}\n");
        }


        private void ReduceRed()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        //Seed Method

        private void SeedContentList()
        {
            DeveloperContent julieBishop = new DeveloperContent("Julie Bishop", 3454, true);
            DeveloperContent steveMartin = new DeveloperContent("Steve Martin", 8656, false);
            DeveloperContent jimmyJohn = new DeveloperContent("Jimmy John", 2131, true);

            _developerRepo.AddContentToDirectory(julieBishop);
            _developerRepo.AddContentToDirectory(steveMartin);
            _developerRepo.AddContentToDirectory(jimmyJohn);

            DevTeamContent redTeam = new DevTeamContent("Red Team", new List<DeveloperContent>(), 20);
            DevTeamContent blueTeam = new DevTeamContent("Blue Team", new List<DeveloperContent>(), 13);

            _devTeamRepo.AddContentToDirectory(redTeam);
            redTeam.TeamMembers.Add(julieBishop);
            redTeam.TeamMembers.Add(jimmyJohn);

            _devTeamRepo.AddContentToDirectory(blueTeam);
            blueTeam.TeamMembers.Add(steveMartin);
        }
    }
}
