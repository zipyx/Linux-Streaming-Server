using Clam.Utilities;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Clam.UnitTests
{
    [TestClass]
    public class FilePathUrlHelperTests
    {
        [TestMethod]
        public void YoutubePathFilter_ConvertYoutubeUrl_ReturnsEmbeddedUrl()
        {
            // Method Name --> MethodName_Scenario_ExpectedBehavior()

            //Arrange
            string url = "https://www.youtube.com/watch?v=HYrXogLj7vg";
            string expectedUrl = "https://www.youtube.com/embed/HYrXogLj7vg";

            //Act
            var resultUrl = FilePathUrlHelper.YoutubePathFilter(url);

            //Assert
            Assert.AreEqual(expectedUrl, resultUrl);
        }

        [TestMethod]
        public void FirstIndexGuidPath_GetFirstFractionGuid_ReturnsFractoredGuidFirst()
        {
            //Arrange
            string guid_string = "face78ee-821a-40fa-bf20-50941e37840e";
            string expectedResult = "face78ee";
            Guid guid_value = Guid.Parse(guid_string);

            //Act
            var result = FilePathUrlHelper.FirstIndexGuidPath(guid_value);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void LastIndexGuidPath_GetLastFractionGuid_ReturnsFractoredGuidLast()
        {
            //Arrange
            string guid_String = "cd49cefe-c302-4b85-91cc-da0c7eb7f6e3";
            string exptectedResult = "da0c7eb7f6e3";
            Guid guid_value = Guid.Parse(guid_String);

            //Act
            var result = FilePathUrlHelper.LastIndexGuidPath(guid_value);

            //Assert
            Assert.AreEqual(exptectedResult, result);
        }

        [TestMethod]
        public void SimpleDateComparison_TestDateWithStringParse_ReturnsTrue()
        {
            //Arrange
            string yearDate = "2020";
            var dateTimeNowYear = DateTime.Now.Year;

            //Act
            var result = int.Parse(yearDate).Equals(dateTimeNowYear);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void DataFilePathFilterIndex_GetDirectoryPathOfCategoryToDelete_ReturnsTrue()
        {
            //Arrange
            var testPath = "c:\\ClamData\\n8vV5-fr9h2-qWy5Y94s0-Ml9iqU0zoRc\\haxajh0v.qdr08d7f7f7c1d1fzq3nply.zku232132cffysaawlhyu\\zzIhI8Li2U85PgjX9_fB0Q\\toco31c3.zrd\\World of Warcraft 12_11_2018 6_00_24 PM.mp4";
            int expectedIndexNumber = 45;
            string expectedScenarioAnswer = "c:\\ClamData\\n8vV5-fr9h2-qWy5Y94s0-Ml9iqU0zoRc";
            string expectedSubstringAnswer = "\\haxajh0v.qdr08d7f7f7c1d1fzq3nply.zku232132cffysaawlhyu\\zzIhI8Li2U85PgjX9_fB0Q\\toco31c3.zrd\\World of Warcraft 12_11_2018 6_00_24 PM.mp4";

            //Act
            var firstResult = FilePathUrlHelper.DataFilePathFilterIndex(testPath, 3);
            var secondResult = testPath.Substring(0, firstResult);
            var thirdResult = testPath.Substring(firstResult, testPath.Length - firstResult);

            //Assert
            Assert.AreEqual(expectedIndexNumber, firstResult);
            Assert.AreEqual(expectedScenarioAnswer, secondResult);
            Assert.AreEqual(expectedSubstringAnswer, thirdResult);
        }

        [TestMethod]
        public void GetFileAtEndOfPath_GetFileNameFromStoredPathInDatabase_MatchFileName()
        {
            //Arrange
            var testFileName = "helloworld.txt";
            var testPathName = "test\\file\\path\\at\\this\\string\\helloworld.txt";
            var expectedResult = testFileName;
            //Act
            var result = FilePathUrlHelper.GetFileAtEndOfPath(testPathName);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void UrlString_ConvertParameterStringForEndPointUrl_ReturnsEqual()
        {
            //Arrange
            string testParameter = "controller Action ID ParaMEteRS";
            string expectedResult = "controller-action-id-parameters";

            //Act
            var result = FilePathUrlHelper.UrlString(testParameter);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void GetFileName_RemoveExtensionFromStoredTableTitle_ReturnsEqual()
        {
            // Arrange
            List<string> testFileNames = new List<string>()
            {
                "hello.txt",
                "world.txt",
                "program.ext",
                "software.exe",
                "picture.png",
                "image.jpg"
            };

            List<string> expectedResult = new List<string>()
            {
                "hello",
                "world",
                "program",
                "software",
                "picture",
                "image"
            };

            List<string> listResult = new List<string>();

            // Act
            foreach (var fileName in testFileNames)
            {
                listResult.Add(FilePathUrlHelper.GetFileName(fileName));
            }


            // Assert
            for (int i = 0; i < testFileNames.Count; i++)
            {
                Assert.AreEqual(expectedResult[i], listResult[i]);
            }
        }

        [TestMethod]
        public void ContainsString_CheckForMovieTitle_ReturnsEqual()
        {
            // Arrange
            List<string> testMovieTitleList = new List<string>()
            {
                "average marvel",
                "centipede marvel",
                "FAINas marvel",
                "supermarvel sapin",
                "super marvel"
            };

            // Act
            var testInput = "marvel";

            // Assert
            for (int i = 0; i < testMovieTitleList.Count; i++)
            {
                Assert.IsTrue(testMovieTitleList[i].Contains(testInput));
            }
        }
    }
}
