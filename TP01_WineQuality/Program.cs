﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP01_WineQuality
{
    internal class Program
    {

        static List<String> LectCSV(string filename)
        {
            List<string> lines = new List<string>();
            string line = null;
            
            using (StreamReader reader = new StreamReader(File.OpenRead(filename)))
            {
                while (!reader.EndOfStream) {
                    line = reader.ReadLine();
                    lines.Add(line);
                }
            }
            return lines;
        }

        static void Main(string[] args)
        {
            try {
                List<string> files = new List<string>();
                List<string> trainFiles = new List<string>();
                int kValue = 0;
                string algo = null;

                //  ADD aleatoire argument with the differents flags

                files = LectCSV(args[1]);
                trainFiles = LectCSV(args[3]);
                kValue = Int32.Parse(args[5]);
                algo = args[7];

                //
                //  ADD reste des appels de fonction
                //


            } catch (Exception e) {
                Console.WriteLine(e.Message);
            }
            
        }
    }
}
