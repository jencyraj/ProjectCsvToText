using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvtoText.Domain
{
    public class CSVFileReadingException : Exception
    {
        public CSVFileReadingException()
        {
        }

        public CSVFileReadingException(string message)
            : base(message)
        {
        }

        public CSVFileReadingException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}

