using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP01_WineQuality
{
    internal class Program
    {

        static void LectCSV(string filename)
        {
            var reader = new StreamReader(File.OpenRead(filename));
            List<string> alcohol = new List<string>();
            List<string> sulphates = new List<string>();
            List<string> acidCitric = new List<string>();
            List<string> volatileAcididy = new List<string>();
            List<string> quality = new List<string>();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(';');

                // Console.WriteLine(values[0].GetType());
                // Console.WriteLine(line);
                // alcohol.Add(values[0]);
                // sulphates.Add(values[1]);
                // acidCitric.Add(values[2]);
                // volatileAcididy.Add(values[3]);
                // quality.Add(values[4]);
/*
                foreach (var col in alcohol) {
                    Console.WriteLine("alc {0}",  col);
                }
                foreach (var col in sulphates) {
                    Console.WriteLine("sul {0}",col);
                }
                foreach (var col in acidCitric) {
                    Console.WriteLine("aci {0}", col);
                }
                foreach (var col in volatileAcididy) {
                    Console.WriteLine("vol {0}", col);
                }
                foreach (var col in quality) {
                    Console.WriteLine("qual {0}", col);
                }*/
            }
        }

        static void Main(string[] args)
        {
            List<string> file;
            List<string> train_file;


            LectCSV(args[1]);
        }
    }
}
