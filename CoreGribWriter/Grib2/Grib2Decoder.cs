using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Grib.Reader.Standard.Grib2
{
    public class Grib2Decoder: IEnumerable<GribMessage>, IEnumerable
    {
        public long TotalLength { get; private set; }
        public byte Version { get; private set; }
        public byte Discipline { get; private set; }

        private const int SectionLengthAndNumberLength = 5;
        private const int Section0Length = 16;
        
        private const int EndSectionLength = 4;


        public Grib2Decoder(Stream s)
        {
            
            var reader = new BinaryReader(s);
            while (s.Position < s.Length)
            {
                var message = ReadMessage(reader);
            }

            

        }

        public GribMessage ReadMessage(BinaryReader reader)
        {
            var startPosition = reader.BaseStream.Position;

            var messageStart = new string(reader.ReadChars(4));
            if (!messageStart.Equals("grib", StringComparison.InvariantCultureIgnoreCase))
            {
                throw new Exception($"not start of message {messageStart}");
            }

            var someShit = reader.ReadInt16();

            var message = new GribMessage();

            message.Discipline = reader.ReadByte();
            message.Version = reader.ReadByte();

            var messageLength = reader.ReadGribLong();

            DataGroup dataGroup;

            while (reader.BaseStream.Position < startPosition + messageLength - EndSectionLength)
            {
                var sectionLength = reader.ReadGribInt();
                var sectionNumber = reader.ReadByte();
                reader.BaseStream.Seek(-5, SeekOrigin.Current);

                switch (sectionNumber)
                {
                    case 1:
                        var id = new IdentificationSection(reader.ReadBytes(sectionLength));
                        message.Identification = id;
                        break;
                    case 2:
                        //skipped for now
                        var localUse = ReadLocalUseSection(reader, sectionLength);
                        break;

                    case 3:
                        dataGroup = new DataGroup();
                        dataGroup.GridDefinition = ReadGridDefinition(reader, sectionLength);
                        break;

                    case 4:
                        ReadProductDefinition(reader, sectionLength);
                        break;

                    default:
                        reader.BaseStream.Position += sectionLength - SectionLengthAndNumberLength;
                        break;
                }
            }

            var messageEnd = new string(reader.ReadChars(EndSectionLength));
            if (!messageEnd.Equals("7777", StringComparison.InvariantCultureIgnoreCase))
            {
                throw new Exception($"not end of message: {messageEnd}");
            }

            return message;
        }

        private static byte[] ReadLocalUseSection(BinaryReader reader, int sectionLength)
        {
            return reader.ReadBytes(sectionLength - 5);
        }

        private static GridDefinition ReadGridDefinition(BinaryReader reader, int sectionLength)
        {
            var section = new GridDefinition();

            section.SourceOfGridDefinition = reader.ReadByte();

            section.NumberOfDataPoints = reader.ReadGribInt();

            section.NumberOfOctetsForOptionalListOfNumbersDefiningNumberOfPoints = reader.ReadByte();
            section.InterpretationOfOptionalList = reader.ReadByte();

            section.GridDefintionTemplateNumber = reader.ReadGribShort();
            if (section.GridDefintionTemplateNumber == GridDefinition.LatLonGridDefinitionTemplateCode)
            {
                var def = new LatLonGridDefinitionTemplate();

            }

            section.GridDefinitionTemplateAndStuff = reader.ReadBytes(sectionLength - 14);

            return section;

        }

        private static void ReadProductDefinition(BinaryReader reader, int sectionLength)
        {
            var numberOfCoordinatesValuesAfterTemplate = reader.ReadGribShort();
            var productDefinitionTemplateNumber = reader.ReadGribShort();
            
            ////

            var gridDefinitionTemplateAndStuff = reader.ReadBytes(sectionLength - 9);

        }

        public IEnumerator<GribMessage> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}