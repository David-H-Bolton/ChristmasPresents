using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace bruteforce
{
    internal class Toyrec
    {
        public const int FailScore = 10000000;
        // public string ToyName { get; set; }
        public int[] Commodities = {0,0,0,0,0};
        
        public int NumberElves { get; set; }
        public string ToyName { get; set; }
    }

    internal class Program
    {
        public static int[] MaxToys = new[] {84, 51, 67,  71, 50};
        public static List<Toyrec> Toys = new List<Toyrec>();

        public static Toyrec Totals = new Toyrec()
        {
            Commodities = new []{5600,8000,600,500,500},
            NumberElves = 80
        };

        public static Toyrec Maximums= new Toyrec();

        public static void Init()
        {
            Toys.Add(
                new Toyrec()
                {
                    ToyName=@"Wooden Tractor",
                    Commodities = new []{3, 12, 1, 0, 1},
                    NumberElves = 4
                });
            Toys.Add(new Toyrec()
            {
                ToyName =@"Rocking Chair Horse",
                Commodities = new []{15, 20, 0, 0, 1},
                NumberElves = 6
            });
            Toys.Add( new Toyrec()
            {
                ToyName =@"Wooden Steam Train",
                Commodities = new [] {7, 24, 1, 0, 1},
                NumberElves = 4
            });
            Toys.Add(new Toyrec()
            {
                ToyName =@"Dolls House",
                Commodities = new [] {10, 20, 1, 2, 2},
                NumberElves = 8
            });
            Toys.Add(new Toyrec()
            {
                ToyName =@"Toy Castle", 
                Commodities = new [] {8, 32, 1, 2, 2},
                NumberElves = 6
            });
            Toys.Add(new Toyrec()
            {
                ToyName =@"12 Wooden Puzzles", 
                Commodities = new [] {6, 24, 2, 0, 0},
                NumberElves = 4
            });
            Toys.Add(new Toyrec()
            {
                ToyName =@"Noah's Ark", 
                Commodities = new [] {18, 25, 3, 3, 3},
                NumberElves = 7
            });
        }


        private static void Main(string[] args)
        {
            Init();
            BruteForce();
        }

        private static int Evaluate(ref int[] toyscount)
        {
            var totalCommodities = Totals.Commodities;
            var toyindex = 0;
            foreach (var toy in Toys)
            {
                var toycount = toyscount[toyindex];
                for (var commodindex = 0; commodindex < 5; commodindex++)
                {
                    totalCommodities[commodindex] -= toy.Commodities[commodindex]*toycount;
                }
                toyindex++;
            }
            var total = 0;
            for (var commodindex = 0; commodindex < 5; commodindex++)
            {
                if (totalCommodities[commodindex] < 0)
                {
                    return Toyrec.FailScore;
                }
                total += totalCommodities[commodindex];
            }
            return total;
        }

        private static void BruteForce()
        {
            var tries = new[] {1, 1, 1, 1, 1, 1, 1};
            var winningtries = tries;
            var MaxScore = Toyrec.FailScore - 1;
            for (var index1 = 1; index1 <= 500; index1++)
            {
                tries[0] = index1;
                for (var index2 = 1; index2 <= 500; index2++)
                {
                    tries[1] = index2;
                    for (var index3 = 1; index3 <= 500; index3++)
                    {
                        tries[2] = index3;
                        for (var index4 = 1; index4 <= 500; index4++)
                        {
                            tries[3] = index4;
                            for (var index5 = 1; index5 <= 500; index5++)
                            {
                                tries[4] = index5;
                                for (var index6 = 1; index6 <= 500; index6++)
                                {
                                    tries[5] = index6;
                                    for (var index7 = 1; index7 <= 500; index7++)
                                    {
                                        tries[6] = index7;
                                        if (!Pass8pcRule(ref tries)) continue;
                                        var score=Evaluate(ref tries);
                                        if (score == Toyrec.FailScore) continue;
                                        if (score < MaxScore)
                                        {
                                            MaxScore = score;
                                            winningtries = tries;
                                            WriteLine($"Best Score so far :{MaxScore} {winningtries}");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                WriteLine($"Best Score :{MaxScore} {winningtries}");
            }
        }

        private static bool Pass8pcRule(ref int[] tries)
        {
            var total = tries.Sum();
            foreach(var atry in tries)
            {
                if (atry/total < 0.08) return false;
            }
            return true;
        }
    }
}
