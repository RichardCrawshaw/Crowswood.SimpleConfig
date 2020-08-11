using System;
using System.Xml.Serialization;

namespace Crowswood.SimpleConfig
{
    [Serializable]
    [XmlType(AnonymousType = true)]
    public abstract class BaseConfig :
        ISimpleConfig
    {
        [XmlIgnore]
        public bool IsLoaded { get; internal set; }

        [XmlIgnore]
        public string Path { get; internal set; }
    }
}
