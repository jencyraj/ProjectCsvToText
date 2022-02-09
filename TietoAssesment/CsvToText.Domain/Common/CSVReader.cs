using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CsvtoText.Domain
{
    public class CSVReader : ICSVReader
    {
        public string[] ReadAllLines(string path)
        {
            return File.ReadAllLines(path);
        }

    }
}
