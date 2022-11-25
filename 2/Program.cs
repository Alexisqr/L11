using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2
{
    public delegate void KingUnderAttackHandler();//Делегати представляють такі об'єкти, які вказують на методи.
    public abstract class Subordinate //для опису сутностей, які мають конкретного втілення, призначені абстрактні класи.
    {
        public Subordinate (string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }

        public abstract void KingUnderAttack();
    }
    public class Footman : Subordinate
    {
        public Footman(string name)
            : base(name)
        {
        }
        public override void KingUnderAttack()
        {
            Console.WriteLine($"Footman {this.Name} is panicking!");
        }
    }
    public class Royal_Guards : Subordinate
    {
       
        public Royal_Guards(string name)
            : base(name)
        {
        }
        public override void KingUnderAttack()
        {
            Console.WriteLine($"Royal Guard  {this.Name}  is defending!");
        }

    }
    public class King
    {
        public event KingUnderAttackHandler Attack;
        public King (string name)
        {
            this.Name = name;
        }
        public string Name { get; private set; }
        public void OnAttack()
        {
            Console.WriteLine($"King {this.Name} is under attack!");
            Attack?.Invoke();
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            var str1 = Console.ReadLine();
            var king = new King(str1);
            var subordinate = new List<Subordinate>();
            var guards = (Console.ReadLine()).Split();
            var footmens = (Console.ReadLine()).Split();
             for(int i=0;i<guards.Length;i++)
            {
                //Console.WriteLine(guards[i]);
                var Royal_Guards = new Royal_Guards(guards[i]);
                subordinate.Add(Royal_Guards);
                king.Attack += Royal_Guards.KingUnderAttack;
            }

            for (int i = 0; i < footmens.Length; i++)
            {
                var Footman = new Footman(footmens[i]);
                subordinate.Add(Footman);
                king.Attack += Footman.KingUnderAttack;
            }
            var command = Console.ReadLine().Split();

            while (command[0] != "End")
            {
                switch (command[0])
                {
                    case "Attack":
                        king.OnAttack();
                        break;
                    case "Kill":
                        var Name = command[1];
                        int i = 0;
                        for ( i = 0; i < subordinate.Count; i++)
                        {
                            if (Name== subordinate[i].Name)
                            {
                                break;
                            }
                        }
                        king.Attack -= subordinate[i].KingUnderAttack;
                        subordinate.Remove(subordinate[i]);
                        break;
                    default:
                        break;
                }

                 command = Console.ReadLine().Split();
            }
        }
    }
}
