using System;
using System.IO;
using System.Net;

namespace Algebra
{
    class Program
    {
        static int SIZE = 5;
        static int squareSIZE = SIZE * SIZE;
        static void Main(string[] args)
        {
            bool[] pureA = new bool[SIZE * SIZE];
            bool[] a = new bool[SIZE * SIZE];
            int[] indexs;
            bool isTransitive, isAntisymmetric, isSymmetric, isReflexive;
            int CountTransitiveRelation = 1;
            int CountAntisymmetricRelation = 1;
            int CountSymmetricRelation = 1;
            int CountReflexiveRelation = 0;
            int CountOrderRelation = 0;
            int CountEquivalenceRelation = 0;
            int count = 1;
            for (var i = 1; i <= squareSIZE; i++)
            {
                indexs = GetIncreasingArray(i);
                do
                {
                    Array.Copy(pureA, a, a.Length);
                    foreach (var x in indexs)
                    {
                        a[x] = true;
                    }
                    isTransitive = IsTransitive(a);
                    isAntisymmetric = IsAntisymmetric(a);
                    isReflexive = IsReflexive(a);
                    isSymmetric = IsSymmetric(a);
                    if (isTransitive) CountTransitiveRelation++;
                    if (isAntisymmetric) CountAntisymmetricRelation++;
                    if (isReflexive) CountReflexiveRelation++;
                    if (isSymmetric) CountSymmetricRelation++;
                    if (isSymmetric && isTransitive && isReflexive) CountEquivalenceRelation++;
                    if (isAntisymmetric && isTransitive && isReflexive) CountOrderRelation++;
                    count++;
                }
                while (Next(indexs));
            }
            Console.WriteLine("Count Transitive Relation {0}", CountTransitiveRelation);
            Console.WriteLine("Count Antisymmetric Relation {0}", CountAntisymmetricRelation);
            Console.WriteLine("Count Symmetric Relation {0}", CountSymmetricRelation);
            Console.WriteLine("Count Reflexive Relation {0}", CountReflexiveRelation);
            Console.WriteLine("Count Order Relation {0}", CountOrderRelation);
            Console.WriteLine("Count Equivalence Relation {0}", CountEquivalenceRelation);
            Console.WriteLine("Count All Relation {0}", count);
            Console.Beep();
            Console.Beep();
            Console.Beep();
            Console.Beep();
            Console.Beep();
            Console.Beep();
            Console.Beep();
            Console.Beep();
            Console.Read();
        }
        static bool Next(int[] indexs)
        {

            int i = indexs.Length;
            while (i > 0)
            {
                i--;
                indexs[i]++;
                if (indexs[i] < squareSIZE - indexs.Length + 1 + i) break;
            }
            if (indexs[0] == squareSIZE - indexs.Length + 1) return false;
            i++;
            while (i < indexs.Length)
            {
                indexs[i] = indexs[i - 1] + 1;
                i++;
            }
            return true;
        }
        static int[] GetIncreasingArray(int size)
        {
            int[] o = new int[size];
            for (var i = 0; i < size; i++)
            {
                o[i] = i;
            }
            return o;
        }
        static bool IsSymmetric(bool[] a)
        {
            for (var i = 0; i < SIZE; i++)
            {
                for (var j = i; j < SIZE; j++)
                {
                    if (a[i * SIZE + j] != a[j * SIZE + i]) return false;
                }
            }
            return true;
        }
        static bool IsAntisymmetric(bool[] a)
        {
            for (var i = 0; i < SIZE; i++)
            {
                for (var j = i + 1; j < SIZE; j++)
                {
                    if (a[i * SIZE + j] && a[j * SIZE + i]) return false;
                }
            }
            return true;
        }
        static bool IsReflexive(bool[] a)
        {
            for (var i = 0; i < SIZE; i++)
            {
                if (!a[i * SIZE + i]) return false;
            }
            return true;
        }
        static bool IsTransitive(bool[] a)
        {
            for (var i = 0; i < SIZE; i++)
            {
                for (var j = 0; j < SIZE; j++)
                {
                    for (var h = 0; h < SIZE; h++)
                    {
                        if (a[i * SIZE + j] && a[j * SIZE + h] && !a[i * SIZE + h]) return false;
                    }
                }
            }
            return true;
        }
    }
}
