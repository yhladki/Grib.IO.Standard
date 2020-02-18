using System.Collections.Generic;

namespace Grib.Reader.Standard.Grib2
{
    public class GribMessage
    {
        public int Discipline { get; internal set; }
        public int Version { get; internal set; }

        public IdentificationSection Identification { get; internal set; }

        public List<DataGroup> DataGroups { get; internal set; } = new List<DataGroup>();
    }
}