using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvtoText.Domain
{
    public class ReportWriter : IReportWriter
    {
        public void WriteAllLines(string path, string[] lines)
        {
            File.WriteAllLines(path, lines);
        }
    }
}
