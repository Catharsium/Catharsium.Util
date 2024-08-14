using Catharsium.Util.IO.Files.Csv;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Catharsium.Util.IO.Files.Tests.Csv;

[TestClass]
public class CsvReaderTests : TestFixture<CsvReader>
{
    #region Fixture

    private static readonly string Column1 = "Column 1";
    private static readonly string Column2 = "Column 2";
    private static readonly string Column3 = "Column 3";

    #endregion

    #region Parse (Multiple lines)


    [TestMethod]
    public void ParseMultiple_WithDelimiter_ReturnsDelimiterSeparatedColumns() {
        var record1 = $"{Column1};{Column2};{Column3}";
        var record2 = $"{Column2};{Column3};{Column1}";

        var actual = this.Target.Parse([record1, record2], false, ';').ToList();
        Assert.AreEqual(2, actual.Count);
    }


    [TestMethod]
    public void ParseMultiple_SkipFirst_IgnoresFirstRecord() {
        var record1 = $"{Column1},{Column2},{Column3}";
        var record2 = $"{Column2},{Column3},{Column1}";

        var actual = this.Target.Parse(new[] { "Header", record1, record2 }).ToList();
        Assert.AreEqual(2, actual.Count);
    }


    [TestMethod]
    public void ParseMultiple_NotSkipFirst_IncludesFirstRecord() {
        var record1 = $"{Column1},{Column2},{Column3}";
        var record2 = $"{Column2},{Column3},{Column1}";

        var actual = this.Target.Parse([record1, record2], false).ToList();
        Assert.AreEqual(2, actual.Count);
    }

    #endregion

    #region Parse (Single line)

    [TestMethod]
    public void ParseSingle_ValidLineWithDelimiter_ReturnsColumns() {
        var record = $"\"{Column1}\";\"{Column2}\";\"{Column3}\"";
        var actual = this.Target.Parse(record, ';').ToList();
        Assert.AreEqual(3, actual.Count);
        Assert.AreEqual(Column1, actual[0]);
        Assert.AreEqual(Column2, actual[1]);
        Assert.AreEqual(Column3, actual[2]);
    }


    [TestMethod]
    public void ParseSingle_ValidLineWithoutDelimiter_ReturnsColumns() {
        var record = $"\"{Column1}\",\"{Column2}\",\"{Column3}\"";
        var actual = this.Target.Parse(record).ToList();
        Assert.AreEqual(3, actual.Count);
        Assert.AreEqual(Column1, actual[0]);
        Assert.AreEqual(Column2, actual[1]);
        Assert.AreEqual(Column3, actual[2]);
    }

    #endregion
}