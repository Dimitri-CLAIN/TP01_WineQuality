using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP01_WineQuality
{
    internal class KNN
    {
        void Train(string filename_train_set_csv, int k = 1, int sort_algorithm = 1) {

        }

        float Evaluate(string filename_test_set_csv) {
            return 0;
        }

        int Predict(string filename_sample_csv) {
            return 0;
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