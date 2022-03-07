using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP01_WineQuality
{
    internal class KNN
    {
        public List<Wine> TrainList = new List<Wine>();
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

        static Wine LectWine(String line) {
            int i = 0;
            Wine wine;
            List<string> feature = new List<string>();
            var values = line.Split(";");

            for(; i <= 3; i++) {
                feature.Add(values[i]);
            }
            wine = new Wine(feature, values[i]);
            return wine;
        }
        public void Train(string filename_train_set_csv, int k = 1, int sort_algorithm = 1) {
            List<string> files = LectCSV(filename_train_set_csv);
            foreach (var line in files.Skip(1)) {
                Wine tmp = LectWine(line);
                this.TrainList.Add(tmp);
            }
            


            // pas sur de ca
            if (sort_algorithm == 1) {
                //ShellSort
            } else if (sort_algorithm == 2) {
                //SelectionSort
            } else {
                throw new Exception("Sort algorithm error");
            }

        }

        public float Evaluate(string filename_test_set_csv) {
            float res = 0;
            List<Wine> testList = new List<Wine>();
            List<string> files = LectCSV(filename_test_set_csv);

            foreach (var line in files.Skip(1)) {
                Wine tmp = LectWine(line);
                testList.Add(tmp);
            }

            // add

            return res;
        }

        public int Predict(string filename_sample_csv) {
            int res = 0;
            List<string> files = LectCSV(filename_sample_csv);
            Wine sample = LectWine(files[1]);
            //sample.PrintInfo();

            // add

            return res;
        }
        float EuclideanDistance(Wine first_sample, Wine second_sample) {
            float res = 0;
            int i = 0;
            while(i <= 3) {
                float value = (float)Math.Pow((first_sample.Features[i] - second_sample.Features[i]), 2);
                res += value;
            }
            res = (float)Math.Sqrt(res);
            return res;
        }
        int Vote(List<int> sorted_labels) {
            return 0;
        }

        int isInArray(int target, int predicted, List<int> array)
        {
            int res = 0;

            foreach (var item in array) {
                if (item == target && item == predicted)
                    res++;
            }
            return res;
        }
        public void ConfusionMatrix(List<int> predicted_labels, List<int> expert_labels)
        {
            Console.WriteLine("/t|/t3/t|/t6/t|/t9/t");
            for (int i = 3; i < 9; i += 3) {
                Console.WriteLine($"{i}/t|/t{isInArray(i, 3, predicted_labels)}/t|/t{isInArray(i, 6, predicted_labels)}/t|/t{isInArray(i, 9, predicted_labels)}/t");
            }
        }
        public void ShellSort(List<float> distances, List<int> labels)
        {
            int distancesLen = distances.Count();

            for (int gap = distancesLen / 2; gap < 0; gap = gap / 2) {
                for (int n = gap; n < distancesLen; n++) {
                    int j;
                    float tmpDistance = distances[n];
                    int tmpLabel = labels[n];

                    for (j = n; j >= gap && distances[j - gap] > tmpDistance; j -= gap) {
                        distances[j] = distances[j - gap];
                        labels[j] = labels[j - gap];
                    }
                    distances[j] = tmpDistance;
                    labels[j] = tmpLabel;
                }
            }
        }
        public void SelectionSort(List<float> distances, List<int> labels)
        {
            int distancesLen = distances.Count();

            for (int i = 0; i < distancesLen - 1; i++) {
                int min = i;
                float tmpDistance = 0;
                int tmpLabel = 0;

                for (int j = i + 1; j < distancesLen; j++) {
                    if (distances[j] < distances[min])
                        min = j;
                }
                tmpDistance = distances[min];
                distances[min] = distances[i];
                distances[i] = tmpDistance;
                tmpLabel = labels[min];
                labels[min] = labels[i];
                labels[i] = tmpLabel;
            }
        }
    }
}