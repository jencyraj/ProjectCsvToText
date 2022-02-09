using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Moq;
using System.IO;
using CsvtoText.Domain;
using Moq;
namespace CsvtoText.Domain.UnitTest
{
    [TestClass]
    public class PeopleTests
    {
        [TestMethod]
        [ExpectedException(typeof(CSVFileReadingException))]
        public void PeopleCSVReader_Throw_FileNotFoundException()
        {
            People people = new People();
            var mock = new Mock<ICSVReader>();
            mock.Setup(CSVReader => CSVReader.ReadAllLines(It.IsAny<string>())).Throws(new FileNotFoundException());
            ICSVReader ICSVReaderMock = mock.Object;
            people.PeopleCSVReader(ICSVReaderMock, "InvalidFileName");
        }

        [TestMethod]
        [ExpectedException(typeof(CSVFileFormatException))]
        public void PeopleCSVReader_not_all_needed_arguments()
        {
            People people = new People();
            var mock = new Mock<ICSVReader>();
            mock.Setup(CSVReader => CSVReader.ReadAllLines(It.IsAny<string>())).Returns(new string[] { "firstName,lastName,adress,phonenumber", "firstName1,lastname1" });
            ICSVReader ICSVReaderMock = mock.Object;
            people.PeopleCSVReader(ICSVReaderMock, "InvalidFileName");
            Console.WriteLine(people.PeopleList);
        }
    }

}
