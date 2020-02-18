using System.IO;

namespace Grib.Reader.Standard.Grib2
{
    public abstract class Section
    {
        protected BinaryReader SectionReader;
        public Section(byte[] rawBytes)
        {
            RawBytes = rawBytes;
            SectionReader = new BinaryReader(new MemoryStream(RawBytes));

            Length = SectionReader.ReadGribInt();
            Number = SectionReader.ReadByte();
        }
        public byte Number { get; internal set; }
        public int Length { get; internal set; }

        public byte[] RawBytes { get; internal set; }
    }
}