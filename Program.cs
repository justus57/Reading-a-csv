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
            var data = new[]
        {
                new Project { CustomerName = "Big Corp", Title = "CRM updates", Deadline = DateTime.Today.AddDays(-2) },
                new Project { CustomerName = "Imaginary Corp", Title = "Sales system", Deadline = DateTime.Today.AddDays(1) }
            };

            using (var mem = new MemoryStream())
            using (var writer = new StreamWriter(mem))
            using (var csvWriter = new CsvWriter(writer))
            {
                csvWriter.Configuration.Delimiter = ";";

                csvWriter.WriteField("Customer");
                csvWriter.WriteField("Title");
                csvWriter.WriteField("Deadline");
                csvWriter.NextRecord();

                foreach (var project in data)
                {
                    csvWriter.WriteField(project.CustomerName);
                    csvWriter.WriteField(project.Title);
                    csvWriter.WriteField(project.Deadline);
                    csvWriter.NextRecord();
                }

                writer.Flush();
                var result = Encoding.UTF8.GetString(mem.ToArray());
                Console.WriteLine(result);
            }
        }
    }
}
