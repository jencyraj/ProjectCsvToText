using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvtoText.Domain
{
    public static class ReportCreator
    {
        public static void CreateReport1(IReportWriter writer, string path, Dictionary<string, int> namesDictionary, List<string> namesList)
        {
            List<string> report = new List<string>();
            report.Add("Names ordered by frequency descending:");
            report.Add("Name\t\tCount");
            report.Add("----------\t------");
            foreach (KeyValuePair<string, int> kvp in namesDictionary)
            {
                report.Add(kvp.Key + "\t\t" + kvp.Value);
            }
            report.Add("\r\n");
            report.Add("\r\n");
            report.Add("Names ordered alphabetically ascending:");
            report.Add("Names");
            report.Add("---------------");
            foreach (string name in namesList)
            {
                report.Add(name);
            }
            writer.WriteAllLines(path, report.ToArray<string>());
        }

        public static void CreateReport2(IReportWriter writer, string path, List<string> addressList)
        {
            List<string> report = new List<string>();
            report.Add("Addresses sorted alphabetically by street name:");
            report.Add("Address");
            report.Add("-------------------");
            foreach (string address in addressList)
            {
                report.Add(address);
            }
            writer.WriteAllLines(path, report.ToArray<string>());
        }
    }
}
