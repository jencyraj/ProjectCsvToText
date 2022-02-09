using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CsvtoText.Domain;
using System.IO;

namespace CsvtoText.IntegraionUnitTests
{
    [TestClass]
    public class ReportWritingTests
    {
        private People people;
        [TestInitialize]
        public void initialize()
        {
            people = new People();
            CSVReader reader = new CSVReader();
            string filePath = System.IO.Path.GetFullPath(@"..\..\..\") + "CSV\\data.csv";
            people.PeopleCSVReader(reader, filePath);
        }

        [TestMethod]
        public void WriteReport1()
        {
            Dictionary<string, int> firstNameAndSurnameGrouping = Sorter.GetWordCountDescendingOrder(people.GetFirstAndLastNameList());
            List<string> fullNameSortedList = Sorter.GetAsendingSortedList(people.GetFullNameList());
            IReportWriter reportWriter = new ReportWriter();
            string reportFilePath = System.IO.Path.GetFullPath(@"..\..\..\") + "Reports\\Report1.txt";
            ReportCreator.CreateReport1(reportWriter, reportFilePath, firstNameAndSurnameGrouping, fullNameSortedList);
            string[] actualReportFileText = File.ReadAllLines(reportFilePath);
            string[] expectedReportFileText = new string[] { "Names ordered by frequency descending:",
                "Name\t\tCount", "----------\t------", "Brown\t\t2", "Clive\t\t2", "Graham\t\t2", "Howe\t\t2",
                "James\t\t2", "Owen\t\t2", "Smith\t\t2", "Jimmy\t\t1", "John\t\t1", "", "", "", "",
                "Names ordered alphabetically ascending:", "Names", "---------------", "Clive Owen", "Clive Smith",
                "Graham Brown", "Graham Howe", "James Brown", "James Owen", "Jimmy Smith", "John Howe"};
            CollectionAssert.AreEqual(expectedReportFileText, actualReportFileText);
        }
        [TestMethod]
        public void WriteReport2()
        {
            List<string> addressSortedList = Sorter.GetAsendingSortedListIgnoringNumbers(people.GetAddressList());
            IReportWriter reportWriter = new ReportWriter();
            string reportFilePath = System.IO.Path.GetFullPath(@"..\..\..\") + "Reports\\Report2.txt";
            ReportCreator.CreateReport2(reportWriter, reportFilePath, addressSortedList);
            string[] actualReportFileText = File.ReadAllLines(reportFilePath);
            string[] expectedReportFileText = new string[] { "Addresses sorted alphabetically by street name:",
                "Address", "-------------------", "65 Ambling Way", "8 Crimson Rd", "12 Howard St", "102 Long Lane",
                "94 Roland St", "78 Short Lane", "82 Stewart St",  "49 Sutherland St"};
            CollectionAssert.AreEqual(expectedReportFileText, actualReportFileText);
        }

        [TestMethod]
        [ExpectedException(typeof(DirectoryNotFoundException))]
        public void loadCSVFile_throw_fileNotFoundException()
        {
            List<string> addressSortedList = Sorter.GetAsendingSortedListIgnoringNumbers(people.GetAddressList());
            IReportWriter reportWriter = new ReportWriter();
            string reportFilePath = System.IO.Path.GetFullPath(@"..\..\..\") + "NotValidDirecotry\\Report2.txt";
            ReportCreator.CreateReport2(reportWriter, reportFilePath, addressSortedList);
        }
    }
}
