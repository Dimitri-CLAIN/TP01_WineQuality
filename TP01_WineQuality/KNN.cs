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
        async float EuclideanDistance(Wine first_sample, Wine second_sample) {
            float res = 0;
            int i = 0;
            while(i <= 3) {
                float value = Math.Pow((first_sample.features[i] - second_sample.features[i]), 2);
                res += value;
            }
            res = Math.Sqrt(res);
            return res;
        }
        int Vote(List<int> sorted_labels) {
            return 0;
        }
        void ConfusionMatrix(List<int> predicted_labels, List<int> expert_labels) {

        }
        void ShellSort(List<float> distances, List<int> labels) {

        }
        void SelectionSort(List<float> distances, List<int> labels) {

        }
    }
}
