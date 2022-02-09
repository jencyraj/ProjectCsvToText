using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using CsvtoText.Domain;
namespace CsvtoText.IntegraionUnitTests
{
    [TestClass]
    public class FIleLoadingTests
    {
        [TestMethod]
        public void loadCSVFile()
        {
            People people = new People();
            CSVReader reader = new CSVReader();
            string filePath = System.IO.Path.GetFullPath(@"..\..\..\") + "CSV\\data.csv";
            people.PeopleCSVReader(reader, filePath);

            List<string> exprectedFirstNameList = new List<string>();
            exprectedFirstNameList.AddRange(new string[] {"Jimmy", "Clive", "James", "Graham", "John",
                "Clive", "James", "Graham" });
            List<string> exprectedLastNameList = new List<string>();
            exprectedLastNameList.AddRange(new string[] { "Smith", "Owen", "Brown", "Howe", "Howe",
                "Smith", "Owen", "Brown" });
            List<string> exprectedAddressList = new List<string>();
            exprectedAddressList.AddRange(new string[] { "102 Long Lane", "65 Ambling Way", "82 Stewart St",
                "12 Howard St", "78 Short Lane", "49 Sutherland St", "8 Crimson Rd", "94 Roland St" });

            List<string> actualFirstNameList = people.GetFirstNameList();
            List<string> actualLastNameList = people.GetLastNameList();
            List<string> actualAddressList = people.GetAddressList();
            CollectionAssert.AreEqual(exprectedFirstNameList, actualFirstNameList);
            CollectionAssert.AreEqual(exprectedLastNameList, actualLastNameList);
            CollectionAssert.AreEqual(exprectedAddressList, actualAddressList);
        }

        [TestMethod]
        [ExpectedException(typeof(CSVFileReadingException))]
        public void loadCSVFile_throw_fileNotFoundException()
        {
            People people = new People();
            CSVReader reader = new CSVReader();
            string filePath = System.IO.Path.GetFullPath(@"..\..\..\") + "CSV\\NotValidFileName.csv";
            people.PeopleCSVReader(reader, filePath);
        }
    }
}
