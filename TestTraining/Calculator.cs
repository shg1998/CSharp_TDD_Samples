using System.Collections.Generic;

namespace TestTraining
{
    public class Calculator
    {
        public List<int> Fibo { get; set; } = new List<int> {1, 1, 2, 3, 5, 8, 13};
        public int Add(int num1, int num2) => num1 + num2;
        public double AddDouble(double a, double b) => a + b;
        public bool IsOdd(int value) => value % 2 == 1;
    }
}
