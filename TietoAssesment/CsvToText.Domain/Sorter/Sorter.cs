using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvtoText.Domain
{
    public static class Sorter
    {
        public static Dictionary<string,int> GetWordCountDescendingOrder(List<string> listToProcess)
        {
            return listToProcess.GroupBy(x => x)
                .OrderByDescending(x => x.Count())
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Count());
        }

        public static List<string> GetAsendingSortedList(List<string> listToProcess)
        {
            return listToProcess.OrderBy(x => x)
                .ToList<string>();
        }

        public static List<string> GetAsendingSortedListIgnoringNumbers(List<string> listToProcess)
        {
            return listToProcess.OrderBy(x => TextOnly(x))
                .ToList<string>();
        }

        private static string TextOnly(String input)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Char c in input)
                if (!Char.IsDigit(c))
                    sb.Append(c);

            return sb.ToString();
        }
    }
}
