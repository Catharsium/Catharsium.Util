using Catharsium.Util.IO.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;

namespace Catharsium.Util.IO.Json
{
    [ExcludeFromCodeCoverage]
    public class JsonFileWriter : IJsonFileWriter
    {
        private readonly JsonTextWriter jsonTextWriter;


        public JsonFileWriter(JsonTextWriter jsonTextWriter)
        {
            this.jsonTextWriter = jsonTextWriter;
        }

        #region WriteObject

        public void WriteStartObject()
        {
            this.jsonTextWriter.WriteStartObject();
        }


        public void WriteEndObject()
        {
            this.jsonTextWriter.WriteEndObject();
        }

        #endregion

        #region WriteValue

        public void WriteValue(bool value)
        {
            this.jsonTextWriter.WriteValue(value);
        }


        public void WriteValue(bool? value)
        {
            this.jsonTextWriter.WriteValue(value);
        }


        public void WriteValue(byte value)
        {
            this.jsonTextWriter.WriteValue(value);
        }


        public void WriteValue(byte? value)
        {
            this.jsonTextWriter.WriteValue(value);
        }


        public void WriteValue(byte[] value)
        {
            this.jsonTextWriter.WriteValue(value);
        }


        public void WriteValue(char value)
        {
            this.jsonTextWriter.WriteValue(value);
        }


        public void WriteValue(char? value)
        {
            this.jsonTextWriter.WriteValue(value);
        }


        public void WriteValue(DateTime value)
        {
            this.jsonTextWriter.WriteValue(value);
        }


        public void WriteValue(DateTime? value)
        {
            this.jsonTextWriter.WriteValue(value);
        }


        public void WriteValue(DateTimeOffset value)
        {
            this.jsonTextWriter.WriteValue(value);
        }


        public void WriteValue(DateTimeOffset? value)
        {
            this.jsonTextWriter.WriteValue(value);
        }


        public void WriteValue(decimal value)
        {
            this.jsonTextWriter.WriteValue(value);
        }


        public void WriteValue(decimal? value)
        {
            this.jsonTextWriter.WriteValue(value);
        }


        public void WriteValue(float value)
        {
            this.jsonTextWriter.WriteValue(value);
        }


        public void WriteValue(float? value)
        {
            this.jsonTextWriter.WriteValue(value);
        }


        public void WriteValue(Guid value)
        {
            this.jsonTextWriter.WriteValue(value);
        }


        public void WriteValue(Guid? value)
        {
            this.jsonTextWriter.WriteValue(value);
        }


        public void WriteValue(int value)
        {
            this.jsonTextWriter.WriteValue(value);
        }


        public void WriteValue(int? value)
        {
            this.jsonTextWriter.WriteValue(value);
        }


        public void WriteValue(long value)
        {
            this.jsonTextWriter.WriteValue(value);
        }


        public void WriteValue(long? value)
        {
            this.jsonTextWriter.WriteValue(value);
        }


        public void WriteValue(object value)
        {
            this.jsonTextWriter.WriteValue(value);
        }


        public void WriteValue(sbyte value)
        {
            this.jsonTextWriter.WriteValue(value);
        }


        public void WriteValue(sbyte? value)
        {
            this.jsonTextWriter.WriteValue(value);
        }


        public void WriteValue(short value)
        {
            this.jsonTextWriter.WriteValue(value);
        }


        public void WriteValue(short? value)
        {
            this.jsonTextWriter.WriteValue(value);
        }


        public void WriteValue(string value)
        {
            this.jsonTextWriter.WriteValue(value);
        }


        public void WriteValue(TimeSpan value)
        {
            this.jsonTextWriter.WriteValue(value);
        }


        public void WriteValue(TimeSpan? value)
        {
            this.jsonTextWriter.WriteValue(value);
        }


        public void WriteValue(uint value)
        {
            this.jsonTextWriter.WriteValue(value);
        }


        public void WriteValue(uint? value)
        {
            this.jsonTextWriter.WriteValue(value);
        }


        public void WriteValue(ulong value)
        {
            this.jsonTextWriter.WriteValue(value);
        }


        public void WriteValue(ulong? value)
        {
            this.jsonTextWriter.WriteValue(value);
        }


        public void WriteValue(Uri value)
        {
            this.jsonTextWriter.WriteValue(value);
        }


        public void WriteValue(ushort value)
        {
            this.jsonTextWriter.WriteValue(value);
        }


        public void WriteValue(ushort? value)
        {
            this.jsonTextWriter.WriteValue(value);
        }


        public void WriteNull()
        {
            this.jsonTextWriter.WriteNull();
        }


        public Task WriteNullAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.jsonTextWriter.WriteNullAsync(cancellationToken);
        }

        #endregion

        #region WriteComment

        public void WriteComment(string text)
        {
            this.jsonTextWriter.WriteComment(text);
        }


        public Task WriteCommentAsync(string text, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.jsonTextWriter.WriteCommentAsync(text, cancellationToken);
        }

        #endregion

        #region WriteArray

        public void WriteArray<T>(IEnumerable<T> values)
        {
            this.jsonTextWriter.WriteStartArray();
            foreach (var value in values) {
                this.WriteValue(value);
            }

            this.jsonTextWriter.WriteEndArray();
        }

        #endregion
    }
}