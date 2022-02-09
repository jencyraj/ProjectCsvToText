using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Collections;

namespace CsvtoText.Domain.UnitTest
{
    [TestClass]
    public class SorterTests
    {
        [TestMethod]
        public void GetWordCountDescendingOrder()
        {
            List<string> personList = new List<string>();
            personList.AddRange(new string[]{"Jimmy", "Clive", "James", "Graham", "John", "Clive",
                "James", "Graham", "Smith", "Owen", "Brown",  "Howe", "Howe", "Smith", "Owen", "Brown"});
            Dictionary<string, int> expectedResult = new Dictionary<string, int>();
            expectedResult.Add("Brown", 2);
            expectedResult.Add("Clive", 2);
            expectedResult.Add("Graham", 2);
            expectedResult.Add("Howe", 2);
            expectedResult.Add("James", 2);
            expectedResult.Add("Owen", 2);
            expectedResult.Add("Smith", 2);
            expectedResult.Add("Jimmy", 1);
            expectedResult.Add("John", 1);

            Dictionary<string, int> actualResult = Sorter.GetWordCountDescendingOrder(personList);
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void GetAsendingSortedList()
        {
            List<string> personList = new List<string>();
            personList.AddRange(new string[]{"Jimmy Smith", "Clive Owen", "James Brown", "Graham Howe",
                "John Howe", "Clive Smith", "James Owen", "Graham Brown"});
            List<string> expectedResults = new List<string>();
            expectedResults.AddRange(new string[]{"Clive Owen", "Clive Smith", "Graham Brown", "Graham Howe",
                "James Brown", "James Owen", "Jimmy Smith", "John Howe"});

            List<string> actualResult = Sorter.GetAsendingSortedList(personList);
            CollectionAssert.AreEqual(expectedResults, actualResult);
        }

        [TestMethod]
        public void GetAsendingSortedListIgnoringNumbers()
        {
            List<string> addressList = new List<string>();
            addressList.AddRange(new string[] {"102 Long Lane", "65 Ambling Way", "82 Stewart St", "12 Howard St",
                "78 Short Lane", "49 Sutherland St", "8 Crimson Rd", "94 Roland St"});
            List<string> expectedResults = new List<string>();
            expectedResults.AddRange(new string[] {"65 Ambling Way", "8 Crimson Rd", "12 Howard St", "102 Long Lane",
                "94 Roland St", "78 Short Lane", "82 Stewart St", "49 Sutherland St"});
            List<string> actualResult = Sorter.GetAsendingSortedListIgnoringNumbers(addressList);
            CollectionAssert.AreEqual(expectedResults, actualResult);
        }
    }
}
