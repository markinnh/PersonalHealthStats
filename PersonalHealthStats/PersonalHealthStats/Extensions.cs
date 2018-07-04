using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PersonalHealthStats
{
    public static class Extensions
    {
        public static decimal AverageDeviation(this IEnumerable<int> values)
        {
            var average = values.Average();
            var valuesCount = values.Count();

            var deviation = 0.0m;

            if (valuesCount == 0)
                return deviation;

            foreach (var item in values)
            {
                deviation += (decimal)Math.Abs(item - average) / valuesCount;
            }
            return deviation;
        }
        public static decimal AverageDeviation(this IEnumerable<double> values)
        {
            var average = values.Average();
            var count = values.Count();

            var deviation = 0.0m;

            if (count == 0)
                return deviation;

            foreach (var item in values)
            {
                deviation += (decimal)Math.Abs(item - average) / count;
            }
            return deviation;
        }

        public static decimal AverageDeviation(this IEnumerable<decimal> values)
        {
            var average = values.Average();
            var count = values.Count();

            var deviation = 0.0m;

            if (count == 0)
                return deviation;

            foreach (var item in values)
            {
                deviation += (decimal)Math.Abs(item - average) / count;
            }
            return deviation;

        }
    }
}
