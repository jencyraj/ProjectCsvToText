using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvtoText.Domain
{
    public interface IReportWriter
    {
        void WriteAllLines(string path, string[] lines);
    }
}
