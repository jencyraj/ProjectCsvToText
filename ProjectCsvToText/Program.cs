using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Data;
using System.Configuration;

namespace ProjectCsvToText
{
    public  class Program : Ifileexists
    {
        public static void Main()
        {
            string csv_file_path = ConfigurationManager.AppSettings["csv_file_path"];
            string output_File_Path = ConfigurationManager.AppSettings["outputFilePath"];
            GetdataTableCsv(csv_file_path, output_File_Path);

        }
        public bool IsfileExists(string path) { return path != null; }
        public static DataTable GetdataTableCsv(string csv_file_path, string output_File_Path)
        {
            DataTable csvData = new DataTable();
            csvData.Columns.Add("FirstName", typeof(string));
            csvData.Columns.Add("LastName", typeof(string));
            csvData.Columns.Add("Address", typeof(string));
            using (StreamReader sr = new StreamReader(csv_file_path))
            {
                try
                {
                    string line = string.Empty;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] strRow = line.Split(',');
                        DataRow dr = csvData.NewRow();
                        dr["FirstName"] = strRow[0];
                        dr["LastName"] = strRow[1];
                        dr["Address"] = strRow[2];
                        csvData.Rows.Add(dr);
                    }
                    sr.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(" Exception: " + ex);
                }
            }
            WritedataIntoTxtfile(csvData, output_File_Path);
            return csvData;
        }
        private static void WritedataIntoTxtfile(DataTable csvData,string output_File_Path)
        {
            try
            {
                File.WriteAllText(output_File_Path, string.Empty); // remove all text before written
                List<string> ListDataFirstName = new List<String>();
                List<string> ListDataLastName = new List<string>();
                List<string> ListAddress = new List<string>();
                for (int i = 1; i < csvData.Rows.Count; i++)
                {
                    ListDataFirstName.Add(csvData.Rows[i][0].ToString());
                    ListDataLastName.Add(csvData.Rows[i][1].ToString());
                    ListAddress.Add(csvData.Rows[i][2].ToString());
                }

                string output_File_StreetAddress = ConfigurationManager.AppSettings["outputFileBystreet"];
                ListOrderbyFrequency(ListDataFirstName, output_File_Path, "List FirstNames orderBy Frequency");
                ListOrderbyFrequency(ListDataLastName, output_File_Path,"List LastNames orderBy Frequency");
                ListOrderbyAlphabetical(ListDataFirstName, output_File_Path,"List FirstNames orderBy Alphabets");
                ListOrderbyAlphabetical(ListDataLastName, output_File_Path, "List LastNames orderBy Alphabets");
                ListSortbyStreetName(ListAddress, output_File_StreetAddress, "List Of Addess Sort by StreetName");
            }
            catch (Exception ex)
            {
                Console.WriteLine(" Exception : " + ex);
            }
        }
        public static List<string> ListSortbyStreetName(List<string> listAddress,string output_File_StreetAddress, string header)
        {
            File.WriteAllText(output_File_StreetAddress, string.Empty);

            bool header_line = true;
            List<string> list_test = new List<string>();
            foreach (var grp in listAddress.OrderBy(item => item.Split(' ').ElementAtOrDefault(1)))
            {
                using (TextWriter Tw = new StreamWriter(output_File_StreetAddress, true))
                {
                    if (header_line)
                    {
                        Tw.WriteLine(header);
                        header_line = false;
                    }
                    Tw.WriteLine(grp);
                    list_test.Add(grp.ToString());
                }
            }
            return list_test;
        }
        public static List<string> ListOrderbyFrequency(List<string> listData,string output_File_Path, string Header)
        {
            bool header_line = true;
            List<string> list_test = new List<string>();
            foreach (var namelist in listData.GroupBy(i => i).OrderByDescending(x => x.Count()))
            {
                using (TextWriter Tw = new StreamWriter(output_File_Path, true))
                {
                    if (header_line)
                    {
                        Tw.WriteLine(Header);
                        header_line = false;
                    }

                    Tw.WriteLine("{0} : {1}", namelist.Key, namelist.Count());
                    list_test.Add((namelist.Key).ToString());
                }
            }
            return list_test;
        }
        public static List<string> ListOrderbyAlphabetical(List<string> listData,string output_File_Path, string Header)
        {
            List<string> Test_list = new List<string>();
            bool header_line = true;
            var frequency = from f in listData
                            group f by f into namefrequency
                            orderby namefrequency.Key
                            select
                            (
                                Name: namefrequency.Key,
                                Frequency: namefrequency.Count()
                            );
            foreach (var (Name, Frequency) in frequency)
            {
                using (TextWriter Tw = new StreamWriter(output_File_Path, true))
                {
                    if (header_line)
                    {
                        Tw.WriteLine(Header);
                        header_line = false;
                    }
                    Tw.WriteLine($" {Name} : {Frequency}");
                    Test_list.Add(Name);
                }
            }
            return Test_list;
        }
    }
}
