using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.VisualBasic.FileIO;



namespace CSVTest
{
    public class CSVDaten
    {
        public string LocName;
        public string LocAddress;
        public CSVDaten(string CName, string CAddress)
        {
            LocName = CName;
            LocAddress = CAddress;
        }
        
        public override string ToString()
        {
            return "Name: " + LocName + " Adresse: " + LocAddress;
        }

        public string SetName
        {
            set => LocName = value; 
            get => LocName;
        }
    } //CSVDaten

    class Class1
    {
        static void Main()
        {
            Console.WriteLine("LINQ und CSV");

            List<CSVDaten> daten = new List<CSVDaten>();
                        
            
            var path = @"C:\test.csv";
            using (TextFieldParser csvParser = new TextFieldParser(path))
            {
                csvParser.CommentTokens = new string[] { "#" };
                csvParser.SetDelimiters(new string[] { ";" });
                csvParser.HasFieldsEnclosedInQuotes = true;
                csvParser.ReadLine();

                while (!csvParser.EndOfData)
                {
                    // Read current line fields, pointer moves to the next line.
                    string[] fields = csvParser.ReadFields();                  
                    daten.Add(new CSVDaten(fields[0], fields[1]));
                }
            };
            foreach (CSVDaten d in daten)
            {
                Console.WriteLine(d.ToString());
            }

            var test = from d in daten where d.LocName.Length < 5 select new { Name = d.LocName, Adresse = d.LocAddress };
            foreach(var t in test)
            {
                Console.WriteLine(t.Name);
            }

        }
    }
}
