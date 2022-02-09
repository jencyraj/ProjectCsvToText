using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvtoText.Domain
{
    public class CSVFileFormatException : Exception
    {
        public CSVFileFormatException()
        {
        }

        public CSVFileFormatException(string message)
            : base(message)
        {
        }

        public CSVFileFormatException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
