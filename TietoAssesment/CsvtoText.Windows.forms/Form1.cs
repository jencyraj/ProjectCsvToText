using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CsvtoText.Domain;
namespace CsvtoText.Windows.forms
{
    public partial class Form1 : Form
    {
        private People people;
        private bool peopleFileLoaded = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void GetCSVFileBtn_Click(object sender, EventArgs e)
        {
            openFileDialog.InitialDirectory = System.IO.Path.GetFullPath(@"..\..\..\") + "CSV\\"; ;
            openFileDialog.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var csvFileName = openFileDialog.FileName;
                    people = new People();
                    CSVReader reader = new CSVReader();
                    people.PeopleCSVReader(reader, csvFileName);
                    peopleFileLoaded = true;
                    DialogResult result = MessageBox.Show("Information of file is loaded", "File Loaded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (CSVFileReadingException fileReadingException)
                {
                    DialogResult result = MessageBox.Show(fileReadingException.InnerException.Message, fileReadingException.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (CSVFileFormatException fileFormatException)
                {
                    DialogResult result = MessageBox.Show(fileFormatException.InnerException.Message, fileFormatException.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    DialogResult result = MessageBox.Show(ex.Message, "Unexpected Error Occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void GetReportDirectoryBtn_Click(object sender, EventArgs e)
        {
            if (!peopleFileLoaded)
            {
                DialogResult result = MessageBox.Show("Please load the csv File first", "Load CSV file first.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DialogResult folderBrowserResult = folderBrowserDialog.ShowDialog();
                if (folderBrowserResult == DialogResult.OK)
                {
                    try
                    {
                        var folderName = folderBrowserDialog.SelectedPath;
                        Dictionary<string, int> firstNameAndSurnameGrouping = Sorter.GetWordCountDescendingOrder(people.GetFirstAndLastNameList());
                        List<string> fullNameSortedList = Sorter.GetAsendingSortedList(people.GetFullNameList());
                        List<string> addressSortedList = Sorter.GetAsendingSortedListIgnoringNumbers(people.GetAddressList());
                        IReportWriter reportWriter = new ReportWriter();
                        ReportCreator.CreateReport1(reportWriter, folderName + "\\Report1.txt", firstNameAndSurnameGrouping, fullNameSortedList);
                        ReportCreator.CreateReport2(reportWriter, folderName + "\\Report2.txt", addressSortedList);
                        DialogResult result = MessageBox.Show("Report created in the selected folder", "Report Files Created", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        DialogResult result = MessageBox.Show(ex.Message, "Error Occurred Writing The Report Files", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void SelectCSVFileLbl_Click(object sender, EventArgs e)
        {

        }

        private void SelectReportDIrectoryLbl_Click(object sender, EventArgs e)
        {

        }
    }
}
