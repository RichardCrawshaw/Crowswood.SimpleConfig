using System;

namespace Crowswood.SimpleConfig.Test
{
    public interface ITestConfig : ISimpleConfig
    {
        string TestString { get; set; }

        int TestInt { get; set; }

        bool TestBool { get; set; }

        decimal TestDecimal { get; set; }

        DateTime TestDateTime { get; set; }
    }
}
