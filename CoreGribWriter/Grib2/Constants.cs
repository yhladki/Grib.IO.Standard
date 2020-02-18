namespace Grib.Reader.Standard.Grib2
{
    /// <summary>
    /// CODE TABLES USED IN SECTION 1
    /// https://www.wmo.int/pages/prog/www/DPS/FM92-GRIB2-11-2003.pdf
    /// </summary>
    public static class Constants
    {
        public static class Section1
        {
            public const int DefaultLength = 21;
            public const byte MissingByteValue = 255;
            public static class LocalTablesVersions
            {
                public const int NotUsed = 0;
            }

            public static class SignificanceOfReferenceTime
            {
                public const byte Analysis = 0;
                public const byte StartOfForecast = 1;
                public const byte VerifyingTimeOfForecast = 2;
                public const byte ObservationTime = 3;

                public const byte Missing = MissingByteValue;
            }

            public static class ProductionStatusOfData
            {
                public const byte OperationalProducts = 0;
                public const byte OperationalTestProducts = 1;
                public const byte ResearchProducts = 2;
                public const byte ReAnalysisProducts = 3;

                public const byte Missing = MissingByteValue;
            }

            public static class TypeOfData
            {
                public const byte AnalysisProducts = 0;
                public const byte ForecastProducts = 1;
                public const byte AnalysisAndForecastProducts = 2;
                public const byte ControlForecastProducts = 3;
                public const byte PerturbedForecastProducts = 4;
                public const byte ControlAndPerturbedForecastProducts = 5;
                public const byte ProcessedSatelliteObservations = 6;
                public const byte ProcessedRadarObservations = 7;

                public const byte Missing = MissingByteValue;
            }
        }

        public static class Section2
        {
            
        }

        public static class Section3
        {
            /// <summary>
            /// Code Table 3.0: Source of Grid Definition
            /// Code figure Meaning Comments
            /// 0 Specified in Code table 3.1
            /// 1 Predetermined grid definition Defined by originating centre
            /// 2-191 Reserved
            /// 192-254 Reserved for local use
            /// 255 A grid definition does not apply to this product
            /// </summary>
            public static class GridDefinitionSource
            {
                public const byte CodeTableSpecified = 0;

                /// <summary>
                /// Defined by originating centre
                /// </summary>
                public const byte PredeterminedGridDefinition = 1;

                public const byte GridDefinitionNotApplied = 255;
            }

            /// <summary>
            /// Code Table 3.1: Grid Definition Template Number
            /// Code figure Meaning Comments
            /// 0 Latitude/longitude Also called equidistant cylindrical, or Plate Carree.
            /// 1 Rotated latitude/longitude
            /// 2 Stretched latitude/longitude
            /// 3 Stretched and rotated latitude/longitude
            /// 4-9 Reserved
            /// 10 Mercator
            /// 11-19 Reserved
            /// 20 Polar stereographic can be south or north.
            /// 21-29 Reserved
            /// 30 Lambert Conformal can be secant or tangent, conical or bipolar.
            /// 31 Albers equal-area
            /// 32-39 Reserved
            /// 40 Gaussian latitude/longitude
            /// 41 Rotated Gaussian latitude/longitude
            /// 42 Stretched Gaussian latitude/longitude
            /// 43 Stretched and rotated Gaussian latitude/longitude
            /// 44-49 Reserved
            /// 50 Spherical harmonic coefficients
            /// 51 Rotated spherical harmonic coefficients
            /// 52 Stretched spherical harmonic coefficients
            /// 53 Stretched and rotated spherical harmonic coefficients
            /// 54-89 Reserved
            /// 90 Space view perspective orthographic.
            /// 91-99 Reserved
            /// 100 Triangular grid based on an icosahedron
            /// 101-109 Reserved
            /// 110 Equatorial azimuthal equidistant projection
            /// 111-119 Reserved
            /// 120 Azimuth-range projection
            /// 121- 999 Reserved
            /// 1000 Cross-section grid, with points equally spaced on the horizontal
            /// 1001-1099 Reserved
            /// 1100 Hovmˆller diagram grid, with points equally spaced on the horizontal
            /// 1101- 1199 Reserved
            /// 1200 Time section grid
            /// 1201-32767 Reserved
            /// 32768-65534 Reserved for local use
            /// 65535 Missing
            /// </summary>
            public static class GridDefinitionTemplateNumber
            {
                /// <summary>
                /// Also called equidistant cylindrical, or Plate Carree.
                /// </summary>
                public const short LatitudeLongitude = 0;

                public const short RotatedLatitudeLongitude = 1;
            }

            /// <summary>
            /// Code Table 3.2: Shape of the Earth
            /// Code figure Meaning
            /// 0 Earth assumed spherical with radius = 6,367,470.0 m
            /// 1 Earth assumed spherical with radius specified by data producer
            /// 2 Earth assumed oblate spheroid with size as determined by IAU in 1965 (major axis = 6,378,160.0 m,
            /// minor axis = 6,356,775.0 m, f = 1/297.0)
            /// 3 Earth assumed oblate spheroid with major and minor axes specified by data producer
            /// 4 Earth assumed oblate spheroid as defined in IAG-GRS80 model(major axis = 6,378,137.0 m, minor
            ///     axis = 6,356,752.314 m, f = 1 / 298.257222101)
            /// 5 Earth assumed represented by WGS84(as used by ICAO since 1998)
            /// 6 Earth assumed spherical with radius of 6,371,229.0 m
            /// 7-191 Reserved
            /// 192-254 Reserved for local use
            /// 255 Missing
            /// </summary>
            public static class ShapeOfEarth
            {
                
            }
        }
    }
}
