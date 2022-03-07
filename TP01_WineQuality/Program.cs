﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP01_WineQuality
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try {
                string res = null;
                int i = 0;
                int algo = 1;
                int kValue = 1;
                bool tes = false;
                bool samp = false;
                String train = null;
                String test = null;
                String sample = null;
                KNN knn = new KNN();
                foreach (var arg in args) {
                    switch(arg) {
                        case "-e":
                            i += 1;
                            test = args[i];
                            tes = true;
                            break;
                        case "-p":
                            i += 1;
                            sample = args[i];
                            samp = true;
                            break;
                        case "-t":
                            i +=1;
                            train = args[i];
                            break;
                        case "-k":
                            i +=1;
                            kValue = Int32.Parse(args[i]);
                            break;
                        case "-s":
                            i +=1;
                            algo = Int32.Parse(args[i]);
                            break;
                        default:
                            i +=1;
                            break;
                    }
                }
                knn.Train(train, kValue, algo);
                if (tes == true) {
                    res = knn.Evaluate(test).ToString();
                } else if (samp == true) {
                    res = knn.Predict(sample).ToString();
                } else {
                    throw new Exception("Argument error");
                }
                Console.WriteLine(res);
                //Print

            } catch (Exception e) {
                Console.WriteLine(e.Message);
            }
        }
    }
}
