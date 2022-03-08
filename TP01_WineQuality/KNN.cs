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
        List<Wine> TrainList = new List<Wine>();
        int k = 1;
        int sort_algorithm = 1;

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
        Wine ImportOneSample(string filename_sample_csv) {
            List<string> files = LectCSV(filename_sample_csv);
            Wine res = LectWine(files[1]);
            return res;
        }
        List<Wine> ImportAllSamples(string filename_samples_csv) {
            List<string> files = LectCSV(filename_samples_csv);
            List<Wine> list = new List<Wine>();
            foreach (var line in files.Skip(1)) {
                Wine tmp = LectWine(line);
                list.Add(tmp);
            }
            return list;
        }
        public void Train(string filename_train_set_csv, int k = 1, int sort_algorithm = 1) {
            this.TrainList = ImportAllSamples(filename_train_set_csv);
            if (k > 0)
                this.k = k;
            else
                throw new Exception("incorrect value for k");
            if (sort_algorithm == 1 || sort_algorithm == 2)
                this.sort_algorithm = sort_algorithm;
            else
                throw new Exception("incorrect value for sort_algorithm");
        }
        public void ShellSort(List<float> distances, List<int> labels)
        {
            int distancesLen = distances.Count();

            for (int gap = distancesLen / 2; gap > 0; gap = gap / 2) {
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
        float EuclideanDistance(Wine first_sample, Wine second_sample) {
            double res = 0;
            for(int i = 0; i <= 3; i++) {
                double tmp = first_sample.Features[i] - second_sample.Features[i];
                double value = Math.Pow(tmp, 2);
                res += value;
            }
            res = Math.Sqrt(res);
            return float.Parse(res.ToString());
        }
        public int Predict(string filename_sample_csv) {
            int res = 0;
            Wine sample = ImportOneSample(filename_sample_csv);
            List<float> distances = new List<float>();
            List<int> expert_label = new List<int>();

            foreach(Wine wine in this.TrainList) {
                distances.Add(EuclideanDistance(sample, wine));
                expert_label.Add(wine.Label);
            }
            if (this.sort_algorithm == 1) {
                ShellSort(distances, expert_label);
            } else if (this.sort_algorithm == 2) {
                SelectionSort(distances, expert_label);
            } else {
                throw new Exception("error valie of sort algorithm");
            }
            res = Vote(expert_label);
            Console.WriteLine("[ {0} ] Prediction by model -> {1} | by expert -> {2}", filename_sample_csv, res, sample.Label);
            return res;
        }

        int isInArray(int target, int predicted, List<int> array)
        {
            int res = 0;

            foreach (var item in array) {
                //Console.WriteLine("{0} {1} {2}", item, target, predicted);
                if (item == target && item == predicted)
                    res++;
            }
            return res;
        }
        public void ConfusionMatrix(List<int> predicted_labels, List<int> expert_labels)
        {
            Console.WriteLine("\t\t|\t3\t|\t6\t|\t9\t");
            for (int i = 3; i <= 9; i += 3) {
                Console.WriteLine($"{i}\t |\t {isInArray(i, 3, predicted_labels)}\t |\t {isInArray(i, 6, predicted_labels)}\t |\t {isInArray(i, 9, predicted_labels)}\t");
            }
        }
        public float Evaluate(string filename_test_set_csv) {
            float res = 0;
            List<Wine> testLists = ImportAllSamples(filename_test_set_csv);
            List<float> distances = new List<float>();
            List<int> expert_labels = new List<int>();
            List<int> knn = new List<int>();
            foreach(Wine sample in testLists) {
                foreach(Wine wine in this.TrainList) {
                    distances.Add(EuclideanDistance(sample, wine));
                    expert_labels.Add(wine.Label);
                }
                if (this.sort_algorithm == 1) {
                    ShellSort(distances, expert_labels);
                } else if (this.sort_algorithm == 2) {
                    SelectionSort(distances, expert_labels);
                } else {
                    throw new Exception("error valie of sort algorithm");
                }
                knn.Add(Vote(expert_labels));
            }
            for (int i = 0; i < knn.Count(); i++) {
                if (knn[i] == expert_labels[i])
                    res += 1;
            }
            res = (res / knn.Count()) * 100;
            ConfusionMatrix(knn, expert_labels);
            Console.WriteLine();
            Console.WriteLine("Classification Accuracy -> {0} %", res);
            return res;
        }

        int Vote(List<int> sorted_labels)
        {
            (int Label, int Count) res = (0, 0);
            var votes = new List<(int Label, int Count)>();

            for (int n = 0; n <= this.k; n++) {
                bool isNewLabel = true;

                for (int i = 0; i < votes.Count(); i++) {
                    if (sorted_labels[n] == votes[i].Label) {
                        votes[i] = (votes[i].Label, votes[i].Count + 1);
                        isNewLabel = false;
                    }
                    if (votes[i].Count > res.Count)
                        res = votes[i];
                }
                if (isNewLabel)
                    votes.Add((sorted_labels[n], 1));
            }
            return res.Label;
        }
        

        
        
    }
}
