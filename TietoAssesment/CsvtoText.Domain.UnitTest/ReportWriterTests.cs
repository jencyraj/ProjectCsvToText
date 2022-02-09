using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Moq;

namespace CsvtoText.Domain.UnitTest
{
    [TestClass]
    public class ReportWriterTests
    {
        private Mock<IReportWriter> mock;
        [TestInitialize]
        public void initialize()
        {
            mock = new Mock<IReportWriter>();
        }
        [TestMethod]
        [ExpectedException(typeof(IOException))]
        public void CreateReport1_Throw_IOException()
        {
            mock.Setup(ReportWriter => ReportWriter.WriteAllLines(It.IsAny<string>(), It.IsAny<string[]>())).Throws(new IOException());
            IReportWriter reportWriterMock = mock.Object;

            Dictionary<string, int> namesDictionary = new Dictionary<string, int>();
            namesDictionary.Add("Brown", 2);
            namesDictionary.Add("Clive", 2);
            namesDictionary.Add("Graham", 2);
            namesDictionary.Add("Howe", 2);
            namesDictionary.Add("James", 2);
            namesDictionary.Add("Owen", 2);
            namesDictionary.Add("Smith", 2);
            namesDictionary.Add("Jimmy", 1);
            namesDictionary.Add("John", 1);

            List<string> namesList = new List<string>();
            namesList.AddRange(new string[]{"Clive Owen", "Clive Smith", "Graham Brown", "Graham Howe",
                "James Brown", "James Owen", "Jimmy Smith", "John Howe"});

            ReportCreator.CreateReport1(reportWriterMock, "disk is full", namesDictionary, namesList);
        }
        [TestMethod]
        public void CreateReport1()
        {
            mock.Setup(ReportWriter => ReportWriter.WriteAllLines(It.IsAny<string>(), It.IsAny<string[]>()));
            IReportWriter reportWriterMock = mock.Object;

            Dictionary<string, int> namesDictionary = new Dictionary<string, int>();
            namesDictionary.Add("Brown", 2);
            namesDictionary.Add("Clive", 2);
            namesDictionary.Add("Graham", 2);
            namesDictionary.Add("Howe", 2);
            namesDictionary.Add("James", 2);
            namesDictionary.Add("Owen", 2);
            namesDictionary.Add("Smith", 2);
            namesDictionary.Add("Jimmy", 1);
            namesDictionary.Add("John", 1);

            List<string> namesList = new List<string>();
            namesList.AddRange(new string[]{"Clive Owen", "Clive Smith", "Graham Brown", "Graham Howe",
                "James Brown", "James Owen", "Jimmy Smith", "John Howe"});

            string[] expectedResult = new string[] {"Names ordered by frequency descending:", "Name\t\tCount",
                "----------\t------","Brown\t\t2","Clive\t\t2","Graham\t\t2","Howe\t\t2","James\t\t2",
                "Owen\t\t2","Smith\t\t2", "Jimmy\t\t1", "John\t\t1", "\r\n", "\r\n",
                "Names ordered alphabetically ascending:", "Names", "---------------", "Clive Owen", "Clive Smith",
                "Graham Brown", "Graham Howe", "James Brown", "James Owen", "Jimmy Smith", "John Howe"};
            ReportCreator.CreateReport1(reportWriterMock, "Valid Path", namesDictionary, namesList);
            mock.Verify(m => m.WriteAllLines("Valid Path", expectedResult), Times.AtLeastOnce);
        }

        [TestMethod]
        public void CreateReport2()
        {
            mock.Setup(ReportWriter => ReportWriter.WriteAllLines(It.IsAny<string>(), It.IsAny<string[]>()));
            IReportWriter reportWriterMock = mock.Object;

            List<string> addressList = new List<string>();
            addressList.AddRange(new string[] {"65 Ambling Way", "8 Crimson Rd", "12 Howard St", "102 Long Lane",
                "94 Roland St", "78 Short Lane", "82 Stewart St", "49 Sutherland St"});
            string[] expectedResult = new string[] {"Addresses sorted alphabetically by street name:",
                "Address", "-------------------", "65 Ambling Way", "8 Crimson Rd", "12 Howard St", "102 Long Lane",
                "94 Roland St", "78 Short Lane", "82 Stewart St", "49 Sutherland St"};
            ReportCreator.CreateReport2(reportWriterMock, "valid Path", addressList);
            mock.Verify(m => m.WriteAllLines("valid Path", new string[] {"Addresses sorted alphabetically by street name:",
                "Address", "-------------------", "65 Ambling Way", "8 Crimson Rd", "12 Howard St", "102 Long Lane",
                "94 Roland St", "78 Short Lane", "82 Stewart St", "49 Sutherland St"}), Times.AtLeastOnce);
        }

    }
}
