using System;

namespace Grib.Reader.Standard.Grib2
{
    public class IdentificationSection: Section
    {
        

        public IdentificationSection(byte[] rawBytes) : base(rawBytes)
        {
            CenterId = SectionReader.ReadGribShort();

            SubCenterId = SectionReader.ReadGribShort();

            MasterTablesVersionNumber = SectionReader.ReadByte();

            LocalTablesVersionNumber = SectionReader.ReadByte();

            SignificanceOfReferenceTime = SectionReader.ReadByte();

            var year = SectionReader.ReadGribShort();
            var month = SectionReader.ReadByte();
            var day = SectionReader.ReadByte();
            var hour = SectionReader.ReadByte();
            var minute = SectionReader.ReadByte();
            var second = SectionReader.ReadByte();

            ReferenceTime = new DateTime(year, month, day, hour, minute, second, DateTimeKind.Utc);

            ProductionStatusOfMessage = SectionReader.ReadByte();

            ProcessedDataTypeOfMessage = SectionReader.ReadByte();

            Reserved = SectionReader.ReadBytes(Length - Constants.Section1.DefaultLength);
        }

        public short CenterId { get; internal set; }

        public short SubCenterId { get; internal set; }

        public byte MasterTablesVersionNumber { get; internal set; }

        public byte LocalTablesVersionNumber { get; internal set; }

        public byte SignificanceOfReferenceTime { get; internal set; }

        public DateTime ReferenceTime { get; internal set; }

        public byte ProductionStatusOfMessage { get; internal set; }

        public byte ProcessedDataTypeOfMessage { get; internal set; }

        public byte[] Reserved { get; internal set; }
    }
}