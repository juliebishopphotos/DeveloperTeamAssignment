using DeveloperTeamAssignment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DeveloperContentTest
{
    [TestClass]
    public class DeveloperContentTest
    {
        [TestMethod]
        public void SetFullName_ShouldSetCorrectString()
        {
            //Arrange
            DeveloperContent newContent = new DeveloperContent();
            //ACT
            newContent.FullName = "Julie Bishop";
            //Assert
            string expected = "Julie Bishop";
            string actual = newContent.FullName;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SetIdNumber_ShouldSetCorrectInt()
        {
            DeveloperContent newContent = new DeveloperContent();
            newContent.IdNumber = 432;
            int expected = 432;
            int actual = newContent.IdNumber;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OnlineAccess_ShouldSetCorrectBool()
        {
            DeveloperContent newContent = new DeveloperContent();
            newContent.OnlineAccess = true;
            bool expected = true;
            bool actual = newContent.OnlineAccess;
        }

        [TestMethod]
        public void SetIsFamilyFriendly_ShouldSetCorrectString()
        {
            DeveloperContent newContent = new DeveloperContent();
            newContent.TeamName = "Blue";
            string expected = "Blue";
            string actual = newContent.TeamName;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SetGenre_ShouldSetCorrentString()
        {

        }

        [DataTestMethod]
        [DataRow(MaturityRating.G, MaturityRating.G)]
        [DataRow(MaturityRating.NC_17, MaturityRating.NC_17)]
        [DataRow(MaturityRating.PG, MaturityRating.PG)]
        [DataRow(MaturityRating.R, MaturityRating.R)]
        public void SetMaturityRating_ShouldGetCorrectMaturityRating(MaturityRating rating, MaturityRating expectedOutcome)
        {
            //Arrange
            DeveloperContent testingContent = new DeveloperContent();
            //ACT
            testingContent.TypeOfMaturityRating = rating;
            //Assert
            Assert.AreEqual(expectedOutcome, testingContent.TypeOfMaturityRating);
        }
    }
}
