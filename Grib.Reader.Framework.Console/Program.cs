using System;
using Grib.Api;

namespace Grib.Reader.Framework
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var f = new GribFile("C:\\temp\\SPOS_17.GRB2");
        }

    }
}
