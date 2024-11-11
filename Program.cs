using System;
using System.Collections.Generic;

namespace Name
{
    class Neuron
    { //item b
        private double[] inputsList;
        private double[] weightsList;
        private Random random;

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

            return result;
        }
    }

    class NeuralNetwork
    {
        private Neuron neuron1;
        private Neuron neuron2;
        double[] FirstNeurononePatternsInput = new double[25];
        double[] SecondNeurontwoPatternsInput = new double[25];
        double[] FirstNeurontwoPatternsInput = new double[25];
        double[] SecondNeurononePatternsInput = new double[25];

        double[] firstNeuronOneOutputs = new double[10];
        double[] firstNeuronTwoOutputs = new double[10];
        double[] secondNeuronOneOutputs = new double[10];
        double[] secondNeuronTwoOutputs = new double[10];

        public NeuralNetwork()
        {

            //Program onePattern,twoPattern;
            List<int[,]> onePatternList = Program.GenerateOnePattern();
            List<int[,]> twoPatternList = Program.generateTwoPattern();

            int index = 0;
            int index2 = 0;
            foreach (var item in onePatternList) //generateonepatternden donen listeyi dolasip icindeki matrislere erismek istemek
            {
                index = 0;
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        FirstNeurononePatternsInput[index] = item[i, j];
                        index++;
                    }
                }
                neuron1 = new Neuron(FirstNeurononePatternsInput);
                firstNeuronOneOutputs[index2] = neuron1.Calculate();
                firstNeuronOneOutputs = new double [25];
                index2++;
            }

            index = 0;
            index2 = 0;
            foreach (var item in twoPatternList)
            {
                index = 0;
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        SecondNeurontwoPatternsInput[index] = item[i, j];
                        index++;
                    }
                }
                neuron2 = new Neuron(SecondNeurontwoPatternsInput);
                secondNeuronTwoOutputs[index2] = neuron2.Calculate();
                SecondNeurontwoPatternsInput = new Double[25];
                index2++;
            }

            index = 0;
            index2 = 0;
            foreach (var item in twoPatternList)
            {
                index = 0;
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        FirstNeurontwoPatternsInput[index] = item[i, j];
                        index++;
                    }
                }
                neuron1 = new Neuron(FirstNeurontwoPatternsInput);
                firstNeuronTwoOutputs[index2] = neuron1.Calculate();
                FirstNeurontwoPatternsInput = new Double[25];
                index2++;
            }

            index = 0;
            index2 = 0;
            foreach (var item in onePatternList)
            {
                index = 0;
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        SecondNeurononePatternsInput[index] = item[i, j];
                        index++;
                    }
                }
                neuron2 = new Neuron(SecondNeurononePatternsInput);
                secondNeuronOneOutputs[index2] = neuron2.Calculate();
                SecondNeurontwoPatternsInput = new Double[25];
                index2++;
            }

        }

        public void Print() //calculate sonuclarini yazdirmak icin olusturuldu
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(secondNeuronOneOutputs[i]);
            }
        }
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
        public static List<int[,]> generateTwoPattern()
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
            NeuralNetwork deneme = new NeuralNetwork();
            deneme.Print();
            Console.ReadKey();
        }
    }

}