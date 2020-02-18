namespace Grib.Reader.Standard.Grib2
{
    public class GridDefinition: Section
    {
        public const int LatLonGridDefinitionTemplateCode = 0;

        public GridDefinition(byte[] rawBytes) : base(rawBytes)
        {
            SourceOfGridDefinition = SectionReader.ReadByte();

            NumberOfDataPoints = SectionReader.ReadGribInt();

            NumberOfOctetsForOptionalListOfNumbersDefiningNumberOfPoints = SectionReader.ReadByte();
            InterpretationOfOptionalList = SectionReader.ReadByte();

            GridDefintionTemplateNumber = SectionReader.ReadGribShort();
            if (GridDefintionTemplateNumber == Constants.Section3.GridDefinitionTemplateNumber.LatitudeLongitude)
            {
                var def = new LatLonGridDefinitionTemplate();

            }

            GridDefinitionTemplateAndStuff = SectionReader.ReadBytes(Length - 14);
        }

        public byte SourceOfGridDefinition { get; internal set; }

        public int NumberOfDataPoints { get; internal set; }

        /// <summary>
        /// Number of octets for optional list of numbers defining number of points (see Note 2) 
        /// </summary>
        public byte NumberOfOctetsForOptionalListOfNumbersDefiningNumberOfPoints { get; internal set; }

        /// <summary>
        /// Interpretation of list of numbers defining number of points (see Code Table 3.11)
        /// </summary>
        public byte InterpretationOfOptionalList { get; internal set; }

        public short GridDefintionTemplateNumber { get; internal set; }

        public byte[] GridDefinitionTemplateAndStuff { get; set; }

        public byte[] OtherStuff { get; set; }
    }
}