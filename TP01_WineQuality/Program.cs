using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP01_WineQuality
{
    internal class Program
    {

        static void printHelp() {
            Console.WriteLine("__ Système de mesure de qualité du vin __");
            Console.WriteLine("_ Commande:");
            Console.WriteLine("\t[-e | -p] 'testeFile.csv': Le fichier (nos) teste(s)");
            Console.WriteLine("\t-t 'trainFile.csv': Le fichier d'entrainement");
            Console.WriteLine("\t-k {10}: Les k premiere valeurs");
            Console.WriteLine("\t-s {1} {2}: L'algorithme de trie {1} Shell et {2} Selection sort");
        }
        static void Main(string[] args)
        {
            try {
                int i = 0;
                int algo = 1;
                int kValue = 1;
                bool tes = false;
                bool samp = false;
                String trainFilePath = null;
                String file = null;
                KNN knn = new KNN();

                foreach (var arg in args) {
                    switch(arg) {
                        case "-e":
                            i += 1;
                            file = args[i];
                            tes = true;
                            break;
                        case "-p":
                            i += 1;
                            file = args[i];
                            samp = true;
                            break;
                        case "-t":
                            i +=1;
                            trainFilePath = args[i];
                            break;
                        case "-k":
                            i +=1;
                            kValue = Int32.Parse(args[i]);
                            break;
                        case "-s":
                            i +=1;
                            algo = Int32.Parse(args[i]);
                            break;
                        case "-h":
                            printHelp();
                            throw new Exception("");
                        default:
                            i +=1;
                            break;
                    }
                }
                knn.Train(trainFilePath, kValue, algo);
                if (tes == true) {
                    knn.Evaluate(file);
                } else if (samp == true) {
                    knn.Predict(file);
                } else {
                    printHelp();
                    throw new Exception("Arguments error");
                }

            } catch (Exception e) {
                Console.WriteLine(e.Message);
            }
        }
    }
}
