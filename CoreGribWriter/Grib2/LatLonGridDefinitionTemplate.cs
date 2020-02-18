using System.IO;

namespace Grib.Reader.Standard.Grib2
{
    public class LatLonGridDefinitionTemplate
    {
        /// <summary>
        /// Shape of the earth (see Code Table 3.2)
        /// </summary>
        public byte ShapeOfEarth { get; internal set; }

        /// <summary>
        /// Scale factor of radius of spherical earth
        /// </summary>
        public byte RadiusScaleFactor { get; internal set; }

        /// <summary>
        /// Scaled value of radius of spherical earth
        /// </summary>
        public int ScaledRadiusValue { get; internal set; }

        public LatLonGridDefinitionTemplate(BinaryReader reader)
        {
            ShapeOfEarth = reader.ReadByte();
            RadiusScaleFactor = reader.ReadByte();
        }
    }
}