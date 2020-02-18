using System.IO;
using Grib.Reader.Standard.Grib2;

namespace ConsoleRun
{
    class Program
    {
        static void Main(string[] args)
        {
            ////using (var fileStream = File.OpenRead("C:\\temp\\SPOS_17.GRB2"))
            using (var fileStream = File.OpenRead("C:\\temp\\s3\\20190813T000000Z-sea_water_current_v_component_at_2_m-20190819T000000Z.grib"))
            {
                var rr = new Grib2Decoder(fileStream);
            }

        }
    }
}
