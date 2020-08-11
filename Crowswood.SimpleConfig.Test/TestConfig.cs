using System;
using System.Xml.Serialization;

namespace Crowswood.SimpleConfig.Test
{
    [Serializable]
    [XmlType(AnonymousType = true)]
    [XmlRoot("Config", Namespace = "", IsNullable = false)]
    public class TestConfig : BaseConfig,
        ITestConfig
    {
        [XmlElement("String")]
        public string TestString { get; set; }

        [XmlElement("Int")]
        public int TestInt { get; set; }

        [XmlElement("Bool")]
        public bool TestBool { get; set; }

        [XmlElement("Decimal")]
        public decimal TestDecimal { get; set; }

        [XmlElement("DateTime")]
        public DateTime TestDateTime { get; set; }
    }
}
