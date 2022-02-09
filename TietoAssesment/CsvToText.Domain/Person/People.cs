using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace CsvtoText.Domain
{
    public class People
    {
        private List<Person> peopleList = new List<Person>();

        public ReadOnlyCollection<Person> PeopleList
        {
            get { return this.peopleList.AsReadOnly(); } 
        }

        public void PeopleCSVReader(ICSVReader reader, string CSVFileName)
        {
            try
            {
                peopleList = reader.ReadAllLines(CSVFileName)
                   .Skip(1) // Skip Header line
                   .Select(x => x.Split(','))
                   .Select(x => Person.CreatePerson(x[0], x[1], x[2], x[3])).ToList();
            }
            catch (Exception fileReadingException) when (fileReadingException is FileNotFoundException ||
                    fileReadingException is ArgumentException ||
                    fileReadingException is ArgumentNullException ||
                    fileReadingException is PathTooLongException ||
                    fileReadingException is DirectoryNotFoundException ||
                    fileReadingException is IOException ||
                    fileReadingException is UnauthorizedAccessException ||
                    fileReadingException is NotSupportedException ||
                    fileReadingException is SecurityException)
            { 
                throw new CSVFileReadingException("Can not read File", fileReadingException);
            }
            catch (Exception fileFormatException ) when 
                (fileFormatException is IndexOutOfRangeException ||
                fileFormatException is ArgumentException)
            {
                throw new CSVFileFormatException("File format not correct", fileFormatException);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<string> GetFirstAndLastNameList()
        {
            List<string> returnList = new List<string>();
            returnList.AddRange(GetFirstNameList());
            returnList.AddRange(GetLastNameList());
            return returnList;
        }

        public List<string> GetFullNameList()
        {
            return peopleList.Select(x => x.FirstName + " " + x.LastName).ToList<string>();
        }

        public List<string> GetFirstNameList()
        {
            return peopleList.Select(x => x.FirstName).ToList<string>();
        }

        public List<string> GetLastNameList()
        {
            return peopleList.Select(x => x.LastName).ToList<string>();
        }

        public List<string> GetAddressList()
        {
            return peopleList.Select(x => x.Address).ToList<string>();
        }
    }
}
