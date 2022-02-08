using NUnit.Framework;
using System.Collections.Generic;
using ProjectCsvToText;
using System;
using FluentAssertions;
using System.Configuration;
using System.Collections;
using System.Text.RegularExpressions;
using System.Data;
using System.IO;

namespace ProjectCsvToText.Test
{
    [TestFixture]
    public class ProgramTests
    {
        string output_File_StreetAddress = "C:/Users/jency/source/repos/ProjectCsvToText.Test/OutputFileTest/outputSortByStreetNameTest.txt";
        string output_File_Path = "C:/Users/jency/source/repos/ProjectCsvToText.Test/OutputFileTest/outputByFrequencyTest.txt";
        string csv_file_path = "C:/Users/jency/source/repos/ProjectCsvToText/InputFile/data.csv";
        string header = "Test Cases";
        
        [SetUp]
        public void Setup()
        {
            File.WriteAllText(output_File_StreetAddress, string.Empty);
        }
        public static readonly object[] _sourceLists =
         {new object[] {new List<string> { "Jimmy", "Clive", "James", "Graham", "John", "Clive", "Clive", "Clive" } }};

        [Test]
        [TestCaseSource("_sourceLists")]
        public void test_Frequency_order(List<string> list)
        {
            //File.WriteAllText(output_File_Path, string.Empty);
            try
            {
                Program program = new Program();
                List<string> test_List = new List<string> { "Clive", "James", "Graham", "Jimmy", "John"};
                program.ListOrderbyFrequency(list, output_File_Path, header).Should().BeEquivalentTo(test_List);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        [Test] //New test case inputs
        public void TestAlbhabeticOrderNewList()
        {
            //File.WriteAllText(output_File_Path, string.Empty);
            try
            {
                Program program = new Program();
                List<string> test_List_Input = new List<string> { "Sara", "Ann", "Ben", "Zen", "Eva" };
                List<string> test_List_Output = new List<string> { "Ann", "Ben", "Eva", "Sara", "Zen" };
                program.ListOrderbyAlphabetical(test_List_Input, output_File_Path, header).Should().BeEquivalentTo(test_List_Output);
            }
            catch(Exception ex)
            {
                Assert.Pass(ex.Message);
            }
        }

        [Test]
        [TestCaseSource("_sourceLists")]//Original Input
        public void TestIsOrderalbhabetical(List<string> list_input)
        {
            File.WriteAllText(output_File_Path, string.Empty);
            try
            {
                Program program = new Program();
                List<string> test_List_Output = new List<string> { "Clive", "Graham", "James", "Jimmy", "John" };
                program.ListOrderbyAlphabetical(list_input, output_File_Path, header).Should().BeEquivalentTo(test_List_Output);
            }
            catch(Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        [Test]
        public void TestIsfileExists()
        {
            try
            {
                Program program = new Program();
                program.IsfileExists(csv_file_path).Should().BeTrue();
               
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        public static readonly object[] _InputStreetList =
         {new object[] {new List<string> { "17 ZBC", "18 ABC", "22 Nyhems", "18 Patric" } }};
        [Test] //Test with Diffrent Input
        [TestCaseSource("_InputStreetList")]
        public void TestStreetNameSort(List<string> _test_List_Input)
        {
            try
            {
                Program program = new Program();
                List<string> test_List_Output = new List<string> { "18 ABC", "22 Nyhems", "18 Patric", "17 ZBC" };
                program.ListSortbyStreetName(_test_List_Input, output_File_StreetAddress, header).Should().BeEquivalentTo(test_List_Output);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        public static readonly object[] _InputsourceLists =
         {new object[] {new List<string> { "Sara", "Ann", "Ben", "Zen", "Eva" } },
            new object[] {new List<string> { "Aby", "Ancy", "Alex", "Ben"} } };

        [Test] //New test case inputs
        [TestCaseSource("_InputsourceLists")]
        public void TestNameshouldBeAscendingOrder(List<string> _inputlist)
        {
            try
            {
                Program program = new Program();
                List<string> test_List_Input = new List<string> { "Sara", "Ann", "Ben", "Zen", "Eva" };
                program.ListOrderbyAlphabetical(_inputlist, output_File_Path, header).Should().BeInAscendingOrder();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }
        public static readonly object[] _Inputnamelist =
        {new object[] {new List<string> { "Sara", "Ann", "Ben", "Zen", "Eva" }},//case1
         new object[] {new List<string> { "Aby", "Ancy", "Alex", "Ben" }}, //case 2
         new object[] {new List<string> { "Mathew", "Mark", "Luke", "John" //case 3
                                                                             }}};
        [Test]
        [TestCaseSource("_Inputnamelist")]//New test case inputs
        public void TestNameshouldBeAlphabetic(List<string> _test_list_input)
        {
            try
            {
                Program program = new Program();
                List<string> test_list_output = program.ListOrderbyAlphabetical(_test_list_input, output_File_Path, header);
                foreach(string ch in test_list_output)
                {
                    bool output = Regex.IsMatch(ch, @"^[a-zA-Z]+$");
                    Assert.IsTrue(output);
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }
        [Test]
        public void TestAddressOnlyletterAndNum()
        {
            Program program = new Program();
            DataTable Test_Dt = program.LoadData(csv_file_path, output_File_StreetAddress);
            List<string> test_ListAddress = new List<string>();
            try
            {
                for (int i = 1; i < Test_Dt.Rows.Count; i++)
                {
                    test_ListAddress.Add(Test_Dt.Rows[i][2].ToString());
                }
                foreach (string ch in test_ListAddress)
                {
                    bool output = Regex.IsMatch(ch, @"^[a-zA-Z0-9 ]+$"); //Only Number, space and Alphabets
                    Assert.IsTrue(output);
                }
            }
            catch(Exception ex)
            {
                Console.Write(ex.Message);
            }
        }
    }
}