using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Data.SqlTypes;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;

namespace Name
{
    class Neuron
    { //item b
        private double[] inputsList;
        private double[] weightsList;
        public static Random random;

        public Neuron(double[] inputList)
        { //constructor
            inputsList = inputList;
            weightsList = new double[25];
            random = new Random();

            for (int i = 0; i < 25; i++)
            {
                weightsList[i] = (random.NextDouble() * 2) - 1; //random double number between -1 and 1
            }
        }
        public double Calculate()
        { //calculate neuron output
            double result = 0.0;

            for (int i = 0; i < inputsList.Length; i++)
            {
                result += inputsList[i] * weightsList[i];
            }
            if (result > 0.5)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public void IncreaseWeights(double[] inputs, int expectedOutput)
        {
            double output = Calculate();
            double error = expectedOutput - output;

            for (int i = 0; i < weightsList.Length; i++)
            {
                weightsList[i] += 0.03 * error * inputs[i];
            }
        }

        public void DecreaseWeights(double[] inputs, int expectedOutput)
        {
            double output = Calculate();
            double error = expectedOutput - output;

            for (int i = 0; i < weightsList.Length; i++)
            {
                weightsList[i] -= 0.03 * error * inputs[i];
            }
        }
    }

    class NeuralNetwork
    {
        private Neuron neuron1;
        private Neuron neuron2;

        double[] firstNeuronOneOutputs = new double[10];
        double[] firstNeuronTwoOutputs = new double[10];
        double[] secondNeuronOneOutputs = new double[10];
        double[] secondNeuronTwoOutputs = new double[10];


        private double[] FlattenedPattern(int[,] pattern)
        {
            double[] flattened = new double[25];
            for (int i = 0, index = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    flattened[index++] = pattern[i, j];
                }
            }
            return flattened;
        }

        private void Train(Neuron neuron, List<int[,]> patternList, int expectedOutput)
        {
            for (int epoch = 0; epoch < 40; epoch++)
            {
                foreach (var pattern in patternList)
                {
                    double[] flattenPattern = FlattenedPattern(pattern);
                    double output = neuron.Calculate();
                    if (output == expectedOutput)
                    {
                        continue;
                    }
                    if (output > expectedOutput)
                    {
                        neuron.DecreaseWeights(flattenPattern, expectedOutput);
                    }
                    else
                    {
                        neuron.IncreaseWeights(flattenPattern, expectedOutput);
                    }
                }
            }
        }
        public NeuralNetwork()
        {
            neuron1 = new Neuron(new double[25]);
            neuron2 = new Neuron(new double[25]);
            //Program onePattern,twoPattern;
            List<int[,]> onePatternList = Program.GenerateOnePattern();
            List<int[,]> twoPatternList = Program.GenerateTwoPattern();

            Train(neuron1, onePatternList, expectedOutput: 1);
            Train(neuron1, twoPatternList, expectedOutput: 0);
            Train(neuron2, onePatternList, expectedOutput: 1);
            Train(neuron2, twoPatternList, expectedOutput: 0);

        }

        public double Test(List<int[,]> testPatterns, int expectedOutput)
        {
            int correctCount = 0;
            foreach (var pattern in testPatterns)
            {
                double[] flattenPattern = FlattenedPattern(pattern);
                double output1 = neuron1.Calculate();
                double output2 = neuron2.Calculate();

                int predictedOutput = (output1 > output2) ? 1 : 0;

                if (predictedOutput == expectedOutput)
                {
                    correctCount++;
                }
                Console.WriteLine($"Expected: {expectedOutput}, Predicted: {predictedOutput}");

            }
            return correctCount / testPatterns.Count;

        }
        class Program
        {

            //item a
            //create first character
            public static List<int[,]> GenerateOnePattern()
            {
                List<int[,]> firstPatternsList = new List<int[,]>();
                int[,] firstPattern = {
                { 0, 0, 1, 0, 0 },
                { 0, 1, 1, 0, 0 },
                { 0, 0, 1, 0, 0 },
                { 0, 0, 1, 0, 0 },
                { 0, 0, 1, 0, 0 }
            };

                int[,] variation1 ={
                {0,0,1,0,0},
                {0,1,1,0,0},
                {0,0,1,0,0},
                {0,0,1,0,0},
                {1,1,1,1,1}
            };

                int[,] variation2 ={
                {0,0,1,0,0},
                {0,0,1,0,0},
                {0,0,1,0,0},
                {0,0,1,0,0},
                {1,1,1,1,1}
            };

                int[,] variation3 ={
                {0,0,1,0,0},
                {0,1,1,0,0},
                {1,0,1,0,0},
                {0,0,1,0,0},
                {1,1,1,1,1}
            };

                int[,] variation4 ={
                {0,0,1,0,0},
                {0,1,1,0,0},
                {1,0,1,0,0},
                {0,0,1,0,0},
                {0,0,1,0,0}
            };

                int[,] variation5 ={
                {0,0,1,0,0},
                {0,0,1,0,0},
                {0,0,1,0,0},
                {0,0,1,0,0},
                {0,0,1,0,0}
            };

                int[,] variation6 ={
                {0,0,0,1,0},
                {0,0,1,1,0},
                {0,0,0,1,0},
                {0,0,0,1,0},
                {0,0,0,1,0}
            };

                int[,] variation7 ={
                {0,0,0,0,1},
                {0,0,0,1,1},
                {0,0,0,0,1},
                {0,0,0,0,1},
                {0,0,0,0,1}
            };

                int[,] variation8 ={
                {0,1,0,0,0},
                {1,1,0,0,0},
                {0,1,0,0,0},
                {0,1,0,0,0},
                {0,1,0,0,0}
            };

                int[,] variation9 ={
                {0,1,0,0,0},
                {0,1,0,0,0},
                {0,1,0,0,0},
                {0,1,0,0,0},
                {0,1,0,0,0}
            };

                firstPatternsList.AddRange(new List<int[,]> { firstPattern, variation1, variation2, variation3, variation4, variation5, variation6, variation7, variation8, variation9 });

                return firstPatternsList;
            }

            //create second character
            public static List<int[,]> GenerateTwoPattern()
            {
                List<int[,]> secondPatternsList = new List<int[,]>();
                int[,] secondPattern = {
                { 0, 1, 1, 1, 0 },
                { 1, 0, 0, 0, 1 },
                { 0, 0, 0, 1, 0 },
                { 0, 0, 1, 0, 0 },
                { 1, 1, 1, 1, 1 }
            };
                int[,] variation1 = {
                { 1, 1, 1, 1, 1 },
                { 0, 0, 0, 0, 1 },
                { 1, 1, 1, 1, 1 },
                { 1, 0, 0, 0, 0 },
                { 1, 1, 1, 1, 1 }
            };

                int[,] variation2 = {
                { 1, 1, 1, 1, 0 },
                { 0, 0, 0, 0, 1 },
                { 0, 1, 1, 1, 0 },
                { 1, 0, 0, 0, 0 },
                { 0, 1, 1, 1, 1 }
            };

                int[,] variation3 = {
                { 0, 1, 1, 1, 0 },
                { 0, 0, 0, 1, 0 },
                { 0, 1, 1, 1, 0 },
                { 0, 1, 0, 0, 0 },
                { 0, 1, 1, 1, 0 }
            };

                int[,] variation4 = {
                { 1 ,1 ,1 ,1 ,1 },
                { 0 ,0 ,0 ,1 ,1 },
                { 1 ,1 ,1 ,1 ,1 },
                { 1 ,1 ,0 ,0 ,0 },
                { 1 ,1 ,1 ,1 ,1 }
            };

                int[,] variation5 = {
                { 1 ,1 ,1 ,1 ,0},
                { 0 ,0 ,0 ,1 ,0},
                { 1 ,1 ,1 ,1 ,0},
                { 1 ,0 ,0 ,0 ,0},
                { 1 ,1 ,1 ,1 ,0}
            };

                int[,] variation6 = {
                { 0, 1, 1, 1, 0 },
                { 0, 0, 0, 0, 1 },
                { 0, 0, 0, 1, 0 },
                { 0, 0, 1, 0, 0 },
                { 1, 1, 1, 1, 1 }
            };

                int[,] variation7 = {
                { 0, 1, 1, 1, 0 },
                { 0, 0, 0, 0, 1 },
                { 0, 0, 0, 1, 0 },
                { 0, 0, 1, 0, 0 },
                { 0, 1, 1, 1, 1 }
            };

                int[,] variation8 = {
                { 1, 1, 1, 0, 0 },
                { 0, 0, 0, 1, 0 },
                { 0, 0, 1, 0, 0 },
                { 0, 1, 0, 0, 0 },
                { 1, 1, 1, 1, 0 }
            };

                int[,] variation9 = {
                { 0, 1 ,1 ,1 ,1},
                { 0, 0 ,0 ,0 ,1},
                { 0, 1 ,1 ,1 ,1},
                { 0, 1 ,0 ,0 ,0},
                { 0, 1 ,1 ,1 ,1}
            };

                secondPatternsList.AddRange(new List<int[,]> { secondPattern, variation1, variation2, variation3, variation4, variation5, variation6, variation7, variation8, variation9 });

                return secondPatternsList;
            }
            static void Main(string[] args)
            {
                NeuralNetwork network = new NeuralNetwork();

                List<int[,]> onePatternsList = Program.GenerateOnePattern();
                List<int[,]> twoPatternsList = Program.GenerateTwoPattern();

                double accuracyOne = network.Test(onePatternsList, expectedOutput: 1);
                double accuracyTwo = network.Test(twoPatternsList, expectedOutput: 0);

                Console.WriteLine($"Accuracy for 1: {accuracyOne * 100}%");
                Console.WriteLine($"Accuracy for 2: {accuracyTwo * 100}%");

                List<int[,]> newTestPatterns = new List<int[,]>
{
    new int[,] {
        {0, 0, 1, 0, 0},
        {0, 1, 1, 0, 0},
        {0, 0, 1, 0, 0},
        {1, 0, 1, 0, 0},
        {1, 1, 1, 1, 1}
    },
    new int[,] {
        {0, 0, 0, 1, 0},
        {0, 0, 0, 1, 0},
        {0, 0, 0, 1, 0},
        {0, 0, 0, 1, 0},
        {0, 0, 0, 1, 0}
    },
    new int[,] {
        {0, 0, 0, 1, 0},
        {0, 0, 0, 1, 1},
        {0, 0, 0, 1, 0},
        {0, 0, 0, 1, 0},
        {0, 0, 1, 1, 1}
    }
};

                Console.WriteLine("New :");
                int patternIndex = 1;
                foreach (var pattern in newTestPatterns)
                {
                    double[] flattenPattern = network.FlattenedPattern(pattern);
                    double output1 = network.neuron1.Calculate();
                    double output2 = network.neuron2.Calculate();
                    int predictOutput = (output1 > output2) ? 1 : 0;
                    Console.WriteLine($"Desen {patternIndex++}: Tahmin edilen değer: {predictOutput}");
                    Console.ReadKey();
                }

            }
        }

    }
}
