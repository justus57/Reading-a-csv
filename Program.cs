
using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csv
{
    class Program
    {
        static void Main(string[] args)
        {
            // Write sample data to CSV file
            using (CsvFileWriter writer = new CsvFileWriter("EMPLOYEES.csv"))
            {

                for (int i = 0; i <5 ; i++)
                {
                    CsvRow row = new CsvRow();
                    for (int j = 0; j < 3; j++)
                        row.Add(String.Format("Column{0}", j));
                    writer.WriteRow(row);
                }
            }
            Console.ReadLine();
        }
    }
    /// </summary>
    public class CsvRow : List<string>
    {
        public string LineText { get; set; }
    }

    /// <summary>
    /// Class to write data to a CSV file
    /// </summary>
    public class CsvFileWriter : StreamWriter
        {
            public CsvFileWriter(Stream stream)
                : base(stream)
            {
            }

            public CsvFileWriter(string filename)
                : base(filename)
            {
            }

            /// <summary>
            /// Writes a single row to a CSV file.
            /// </summary>
            /// <param name="row">The row to be written</param>
            public void WriteRow(CsvRow row)
            {
                StringBuilder builder = new StringBuilder();
                bool firstColumn = true;
                foreach (string value in row)
                {
                    // Add separator if this isn't the first value
                    if (!firstColumn)
                        builder.Append(',');
                    // Implement special handling for values that contain comma or quote
                    // Enclose in quotes and double up any double quotes
                    if (value.IndexOfAny(new char[] { '"', ',' }) != -1)
                        builder.AppendFormat("\"{0}\"", value.Replace("\"", "\"\""));
                    else
                        builder.Append(value);
                    firstColumn = false;
                }
                row.LineText = builder.ToString();
                WriteLine(row.LineText);
            }
        }
    
    public class Project
    {
        public string EmployeeID;
        public string Managerid;
        public string Salary;
    }
}

