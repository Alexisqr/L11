using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace L11
{
    public class NameChangeEventArgs : EventArgs
    {
        public NameChangeEventArgs(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }
    }
    public delegate void NameChangeEventHandler(object sender, NameChangeEventArgs args);//Делегати представляють такі об'єкти, які вказують на методи.
    public class Dispatcher
    {
        private string name;
        public event NameChangeEventHandler NameChange;//Події сигналізують системі про те, що сталася певна дія.
        public string Name
        {
            get { return this.name; }
           
            set
            {
                this.name = value;
                OnNameChange(new NameChangeEventArgs(value));
            }
        }
        public void OnNameChange(NameChangeEventArgs args)
        {
            
                NameChange?.Invoke(this, args);//Виклик делегата з перевіркою на null

        }
    }
    public class Hendler
    {
        public void OnDispatcherNameChange(object sender, NameChangeEventArgs args)
        {
            Console.WriteLine($"Dispatcher's name changed to {args.Name}.");
        }
    }
        internal class Program
    {
        static void Main(string[] args)
        {
            var dispatcher = new Dispatcher();
            var hendler = new Hendler();
            dispatcher.NameChange += hendler.OnDispatcherNameChange;
            var Name = Console.ReadLine();

            while (Name != "End")
            {
                dispatcher.Name = Name;
                Name = Console.ReadLine();
            }
        }
    }
 }

