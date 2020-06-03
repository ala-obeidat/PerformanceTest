using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Linq;

namespace PerformanceTest
{
    class Program
    {
        #region Variables

        public static List<item> numberElements = new List<item>();
        const int NUMBER = 50000000;
        const string FirstMeasureName = "For";
        const string SecondMeasureName = "LINQ";

        #endregion

        #region Measure methods

        static void FirstMeasure()
        {
            var result = new List<Guid>();
            for (int i = 0; i < numberElements.Count; i++)
            {
                 result.Add(numberElements[i].Key);
            }
            result.Clear();
            result = null;
        }

        static void SecondMeasure()
        {
            var result = new List<Guid>();
            numberElements.Select(i => i.Key);
            //foreach (var item in numberElements)
            //{
            //    result.Add(item.ToString());
            //}
            result.Clear();
            result = null;
        }

        #endregion

        #region main method

        static void Main(string[] args)
        {
            for (int i = 0; i < NUMBER; i++)
            {
                numberElements.Add(new item { Key = Guid.NewGuid(), value = i });
            }
            Console.WriteLine("=====================================================");
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            FirstMeasure();
            stopwatch.Stop();
            Console.WriteLine(string.Format("- ( {0} ) => {1} ms", FirstMeasureName, stopwatch.ElapsedMilliseconds));
            Console.WriteLine();
            stopwatch = new Stopwatch();
            stopwatch.Start();
            SecondMeasure();
            stopwatch.Stop();
            Console.WriteLine(string.Format("- ( {0} ) => {1} ms", SecondMeasureName, stopwatch.ElapsedMilliseconds));
            Console.WriteLine("=====================================================");
            Console.ReadLine();
        }

        public class item
        {
            public Guid Key { get; set; }
            public int value { get; set; }
        }
        #endregion
    }
}