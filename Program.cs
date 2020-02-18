using System;
using Grib.Api;

namespace DotnetFrameworkGrib
{
    class Program
    {
        static void Main(string[] args)
        {
            var gr = new GribFile(args[0]);
            foreach (var message in gr)
            {
                var vals = message.GridCoordinateValues;
                Console.WriteLine($"Time: {message.Time}");
                Console.WriteLine($"Ref time: {message.ReferenceTime}");
                Console.WriteLine($"Param name: {message.ParameterName}");
            }

        }
    }
}
