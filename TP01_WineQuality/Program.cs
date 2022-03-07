using System;
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
                Wine sample;
                int kValue = 0;
                int i = 0;
                string algo = null;

                foreach (var arg in args) {
                    switch(arg) {
                        case "-e":
                            i += 1;
                            files = LectCSV(args[i]);
                            break;
                        case "-p":
                            i +=1;
                            List<string> feature = new List<string>();
                            int j = 0;
                            files = LectCSV(args[i]);
                            var values = files[1].Split(";");
                            for(; j <= 3; j++) {
                                feature.Add(values[j]);
                            }
                            sample = new Wine(feature, values[j]);
                            // sample.PrintInfo();
                            break;
                        case "-t":
                            i +=1;
                            trainFiles = LectCSV(args[i]);
                            break;
                        case "-k":
                            i +=1;
                            kValue = Int32.Parse(args[i]);
                            break;
                        case "-s":
                            i +=1;
                            algo = args[i];
                            break;
                        default:
                            i +=1;
                            break;
                    }
                }

                //
                //  ADD reste des appels de fonction
                //


            } catch (Exception e) {
                Console.WriteLine(e.Message);
            }
        }
    }
}
