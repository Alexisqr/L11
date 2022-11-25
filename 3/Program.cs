using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3
{


    public interface IStrategy
    {
        int Calculate(int leftOperand, int rightOperand);
    }
    public interface ICalculator
    {
        int PerformCalculation(int firstOperand, int secondOperand);

        void ChangeStrategy(IStrategy strategy);
    }
    public class Calculator : ICalculator
    {

        private IStrategy strategy;
        public Calculator(IStrategy strategy)
        {
            ChangeStrategy(strategy);
        }
        public void ChangeStrategy(IStrategy strategy)
        {
            this.strategy = strategy;
        }
        public int PerformCalculation(int firstOperand, int secondOperand)
        {
            return this.strategy.Calculate(firstOperand, secondOperand);
        }
    }
    class AdditionStrategy : IStrategy
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand + secondOperand;
        }
    }
    class SubtractionStrategy : IStrategy
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand - secondOperand;
        }
    }
    class MultiplicationStrategy : IStrategy
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand * secondOperand;
        }
    }
    class DivisionStrategy : IStrategy
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand / secondOperand;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            ICalculator calculator = new Calculator(new AdditionStrategy());
            string data = Console.ReadLine();
            while (data != "End")
            {
                var data_ar = data.Split();
                if (data_ar[0] == "mode")
                {
                    char op = Char.Parse(data_ar[1]);
                 
                    switch (op)
                    {
                        case '+':
                            calculator.ChangeStrategy(new AdditionStrategy());
                            
                            break;
                        case '-':
                            calculator.ChangeStrategy(new SubtractionStrategy());
                            
                            break;
                        case '*':
                            calculator.ChangeStrategy(new MultiplicationStrategy());
                           
                            break;
                        case '/':
                            calculator.ChangeStrategy(new DivisionStrategy());

                            break;
                    }

                   
                }
                else
                {
                    int result = calculator.PerformCalculation(int.Parse(data_ar[0]), int.Parse(data_ar[1]));
                    Console.WriteLine(result);
                }
                data = Console.ReadLine();
            }
        }
    }
}
