using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Catharsium.Util.IO.Interfaces
{
    public interface IJsonTextWriter
    {
        void WriteStartObject();
        void WriteEndObject();
        void WriteValue(bool value);
        void WriteValue(bool? value);
        void WriteValue(byte value);
        void WriteValue(byte? value);
        void WriteValue(byte[] value);
        void WriteValue(char value);
        void WriteValue(char? value);
        void WriteValue(DateTime value);
        void WriteValue(DateTime? value);
        void WriteValue(DateTimeOffset value);
        void WriteValue(DateTimeOffset? value);
        void WriteValue(decimal value);
        void WriteValue(decimal? value);
        void WriteValue(float value);
        void WriteValue(float? value);
        void WriteValue(Guid value);
        void WriteValue(Guid? value);
        void WriteValue(int value);
        void WriteValue(int? value);
        void WriteValue(long value);
        void WriteValue(long? value);
        void WriteValue(object value);
        void WriteValue(sbyte value);
        void WriteValue(sbyte? value);
        void WriteValue(short value);
        void WriteValue(short? value);
        void WriteValue(string value);
        void WriteValue(TimeSpan value);
        void WriteValue(TimeSpan? value);
        void WriteValue(uint value);
        void WriteValue(uint? value);
        void WriteValue(ulong value);
        void WriteValue(ulong? value);
        void WriteValue(Uri value);
        void WriteValue(ushort value);
        void WriteValue(ushort? value);
        void WriteNull();
        Task WriteNullAsync(CancellationToken cancellationToken = default);
        void WriteComment(string text);
        Task WriteCommentAsync(string text, CancellationToken cancellationToken = default);
        void WriteArray<T>(IEnumerable<T> values);
    }
}