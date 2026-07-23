namespace Ais.Net.Models.Specs;

using System;

using Ais.Net;
using Ais.Net.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Shouldly;

[TestClass]
public class AisMessageExtensionsTests
{
    [TestMethod]
    [DataRow(0u, 0.0f)]
    [DataRow(123u, 12.3f)]
    [DataRow(1022u, 102.2f)]     // one below the sentinel is still a real value
    public void FromTenthsScalesByTenth(uint raw, float expected)
    {
        raw.FromTenths().ShouldBe(expected);
    }

    [TestMethod]
    public void FromTenthsTreats1023AsNotAvailable()
    {
        // 1023 is the AIS sentinel meaning "speed over ground not available".
        1023u.FromTenths().ShouldBeNull();
    }

    [TestMethod]
    [DataRow(0u, 0.0f)]
    [DataRow(1234u, 123.4f)]
    [DataRow(3599u, 359.9f)]     // one below the sentinel is still a real value
    public void FromTenthsToDegreesScalesByTenth(uint raw, float expected)
    {
        raw.FromTenthsToDegrees().ShouldBe(expected);
    }

    [TestMethod]
    public void FromTenthsToDegreesTreats3600AsNotAvailable()
    {
        // 3600 (== 360.0 degrees) is the AIS sentinel meaning "course over ground not available".
        3600u.FromTenthsToDegrees().ShouldBeNull();
    }

    [TestMethod]
    [DataRow("VESSEL", "VESSEL")]
    [DataRow("VESSEL@@@@@", "VESSEL")]              // trailing '@' padding is removed
    [DataRow("@@@@@VESSEL", "VESSEL")]              // leading '@' padding is removed
    [DataRow("VESSEL NAME  ", "VESSEL NAME")]       // trailing whitespace is trimmed, interior single space kept
    [DataRow("QUEEN MARY 2", "QUEEN MARY 2")]       // legitimate interior single spaces are preserved
    [DataRow("TWO  WORDS", "TWO WORDS")]            // a run of interior spaces collapses to one
    [DataRow("A   B", "A B")]                       // three-plus interior spaces collapse fully (not just paired)
    [DataRow("QUEEN  MARY   2", "QUEEN MARY 2")]    // multiple interior runs each collapse
    [DataRow("NAME@ ", "NAME")]                     // '@' followed by a space is still stripped (padding order-independent)
    [DataRow(" @@ VESSEL @@ ", "VESSEL")]           // mixed leading/trailing '@' and spaces are all stripped
    [DataRow("AB@CD", "AB@CD")]                     // an interior '@' is left untouched (only end padding is stripped)
    [DataRow("@@@@@", "")]                          // an all-padding name becomes empty
    [DataRow("", "")]                               // an empty name stays empty
    public void CleanVesselNameStripsPaddingAndCollapsesInteriorSpaceRuns(string raw, string expected)
    {
        raw.CleanVesselName().ShouldBe(expected);
    }

    [TestMethod]
    public void GetStringDecodesAsciiBytes()
    {
        ReadOnlySpan<byte> ascii = "Hello"u8;

        ascii.GetString().ShouldBe("Hello");
    }

    [TestMethod]
    public void TextFieldToStringDecodesSixBitAsciiField()
    {
        // AIS packs text as 6-bit characters where 'H' == 8 and 'I' == 9. Those values are
        // carried in the ASCII-armoured payload as (value + 48), i.e. '8' and '9'.
        ReadOnlySpan<byte> armoured = "89"u8;
        NmeaAisBitVectorParser bits = new(armoured, padding: 0);
        NmeaAisTextFieldParser field = new(bits, bitLength: 12, bitOffset: 0);

        field.TextFieldToString().ShouldBe("HI");
    }

    [TestMethod]
    public void CleanVesselNameHandlesNamesLongerThanTheStackBuffer()
    {
        // 260 characters (> 256) forces the heap-buffer fallback path.
        string longName = new('A', 260);

        longName.CleanVesselName().ShouldBe(longName);
    }

    [TestMethod]
    public void TextFieldToStringHandlesFieldsLongerThanTheStackBuffer()
    {
        // 300 characters (> 256) forces the heap-buffer fallback. Each armoured '1' is 6-bit
        // value 1, which decodes to 'A'.
        byte[] armoured = new byte[300];
        armoured.AsSpan().Fill((byte)'1');
        NmeaAisBitVectorParser bits = new(armoured, padding: 0);
        NmeaAisTextFieldParser field = new(bits, bitLength: (uint)(armoured.Length * 6), bitOffset: 0);

        field.TextFieldToString().ShouldBe(new string('A', 300));
    }
}
