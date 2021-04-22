using System;
using System.Collections.Generic;
using System.Linq;

namespace Arrays
{
    public class CakeType
    {
        public readonly int Weight;
        public readonly long Value;

        public CakeType(int weight, long value)
        {
            Weight = weight;
            Value = value;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            CakeType[] cakeTypes = new[]
            {
                new CakeType(7, 160),
                new CakeType(3, 90),
                new CakeType(2, 15),
                //new CakeType(4, 160),
            };

            int capacity = 20;

            // Returns 555 (6 of the middle type of cake and 1 of the last type of cake)
            long result = MaxDuffelBagValue(cakeTypes, capacity);

            Console.WriteLine(result);
        }

        public static long MaxDuffelBagValue(CakeType[] cakeTypes, int capacity)
        {
            //1. order the cakes by max value per kg
            IEnumerable<CakeType> query = cakeTypes.OrderByDescending(c => c.Value / c.Weight);

            long maxValue = 0;
            int remainder, count = 0;

            foreach (var cake in query)
            {
                //2. check if this cake can fill the bag with the max kg's. any remainder will continue the loop

                // check how many cakes with this value we can steal mwahahahahahahahaha :)
                count = Math.DivRem(capacity, cake.Weight, out  remainder);

                if (count > 0)
                    maxValue += count * cake.Value;

                //make capacity equal to remainder
                capacity = remainder;

                //stop the loop if we  filled our capacity haul and start running :D while eating ofcourse :@
                if (capacity == 0)
                    break;
            }

            return maxValue;
        }
    }
}
