using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadesOfGray
{
    class Program
    {
        static void Main(string[] args)
        {
            var distance = new ManhattanDistance();
            var classifier = new BasicClassifier(distance);

            var trainingPath = @"D:\工作\资料\技术资料\人工智能\训练数据\trainingsample.csv";
            var training = DataReader.GetObservations(trainingPath);
            classifier.Train(training);

            var validationPath= @"D:\工作\资料\技术资料\人工智能\训练数据\validationsample.csv";
            var validation = DataReader.GetObservations(validationPath);

            var correct = Evaluator.Correct(validation, classifier);
            Console.WriteLine("正确分类：{0:P2}", correct);
            Console.ReadLine();
        }
    }
}
