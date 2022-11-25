using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4
{
    public abstract class Employee //для опису сутностей, які мають конкретного втілення, призначені абстрактні класи.
    {
        protected Employee(string name, int hours)
        {
            this.Name = name;
            this.HoursPerWeek = hours;
        }

        public int HoursPerWeek { get; private set; }

        public string Name { get; private set; }
    }
    public class PartTimeEmployee : Employee
    {
        public PartTimeEmployee(string name)
            : base(name, 20)
        {
        }
    }
    public class StandardEmployee : Employee
    {
        public StandardEmployee(string name)
            : base(name, 40)
        {
        }
    }
    public delegate void JobCompleted(Job job);

    public class Job
    {
        private int hours;
        private Employee employee;
        public event JobCompleted Jobevent;

        public Job(string name, int hours, Employee employee)
        {
            this.Name = name;
            this.hours = hours;
            this.employee = employee;
        }
        public string Name { get; private set; }
        public void Update()
        {
            this.hours -= this.employee.HoursPerWeek;

            if (hours <= 0)
            {
                Console.WriteLine($"Job {this.Name} done!");
                this.Jobevent.Invoke(this);
            }
        }

        public override string ToString()
        {
            return $"Job: {this.Name} Hours Remaining: {this.hoursRequired}";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
