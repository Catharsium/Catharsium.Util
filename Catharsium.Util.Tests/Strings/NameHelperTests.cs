using Catharsium.Util.Strings;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catharsium.Util.Tests.Strings;

[TestClass]
public class NameHelperTests : TestFixture<NameFormatter>
{
    [TestMethod]
    [DataRow("P F I L", "P F I L")]
    [DataRow("P. F. I. L.", "P. F. I. L.")]
    [DataRow("PP FF II LL", "PREFIX FIRSTNAME INFIX LASTNAME")]
    [DataRow("pp ff ii ll", "prefix firstname infix lastname")]
    [DataRow("Pp Ff Ii Ll", "Prefix Firstname Infix Lastname")]
    [DataRow("Ll, Pp F. Ii", "Lastname, Prefix F. Infix")]
    public void Format_AllNameParts(string format, string expected) {
        var prefix = "Prefix";
        var firstName = "Firstname";
        var infix = "Infix";
        var lastName = "Lastname";

        var actual = this.Target.Format(format, prefix, firstName, infix, lastName);
        Assert.AreEqual(expected, actual);
    }


    [TestMethod]
    [DataRow("F I L", "F I L")]
    [DataRow("ff ii ll", "firstname infix lastname")]
    [DataRow("Ll, F. Ii", "Lastname, F. Infix")]
    public void Format_NoPrefix(string format, string expected) {
        var firstName = "Firstname";
        var infix = "Infix";
        var lastName = "Lastname";

        var actual = this.Target.Format(format, null, firstName, infix, lastName);
        Assert.AreEqual(expected, actual);
    }


    [TestMethod]
    [DataRow("P F L", "P F L")]
    [DataRow("pp ff ll", "prefix firstname lastname")]
    [DataRow("Ll, Pp F.", "Lastname, Prefix F.")]
    public void Format_NoInfix(string format, string expected) {
        var prefix = "Prefix";
        var firstName = "Firstname";
        var lastName = "Lastname";

        var actual = this.Target.Format(format, prefix, firstName, null, lastName);
        Assert.AreEqual(expected, actual);
    }


    [TestMethod]
    public void Format_PrefixRequestedButMissing_RemovesPrefix() {
        var firstName = "Firstname";
        var infix = "Infix";
        var lastName = "Lastname";

        var actual = this.Target.Format("Pp Ff Ii Ll", null, firstName, infix, lastName);
        Assert.AreEqual($"{firstName} {infix} {lastName}", actual);
    }


    [TestMethod]
    public void Format_FirstNameRequestedButMissing_RemovesFirstName() {
        var prefix = "Prefix";
        var infix = "Infix";
        var lastName = "Lastname";

        var actual = this.Target.Format("Pp Ff Ii Ll", prefix, null, infix, lastName);
        Assert.AreEqual($"{prefix} {infix} {lastName}", actual);
    }


    [TestMethod]
    public void Format_InfixRequestedButMissing_RemovesInfix() {
        var prefix = "Prefix";
        var firstName = "Firstname";
        var lastName = "Lastname";

        var actual = this.Target.Format("Pp Ff Ii Ll", prefix, firstName, null, lastName);
        Assert.AreEqual($"{prefix} {firstName} {lastName}", actual);
    }


    [TestMethod]
    public void Format_LastNameRequestedButMissing_RemovesLastName() {
        var prefix = "Prefix";
        var firstName = "Firstname";
        var infix = "Infix";

        var actual = this.Target.Format("Pp Ff Ii LL", prefix, firstName, infix, null);
        Assert.AreEqual($"{prefix} {firstName} {infix}", actual);
    }


    [TestMethod]
    public void Format_PrefixRequestedButNotProvided_RemovesPrefix() {
        var firstName = "Firstname";
        var infix = "Infix";
        var lastName = "Lastname";

        var actual = this.Target.Format("Pp Ff Ii Ll", firstName, infix, lastName);
        Assert.AreEqual($"{firstName} {infix} {lastName}", actual);
    }


    [TestMethod]
    public void Format_InfixRequestedButNotProvided_RemovesInfix() {
        var firstName = "Firstname";
        var lastName = "Lastname";

        var actual = this.Target.Format("Pp Ff Ii Ll", firstName, lastName);
        Assert.AreEqual($"{firstName} {lastName}", actual);
    }
}