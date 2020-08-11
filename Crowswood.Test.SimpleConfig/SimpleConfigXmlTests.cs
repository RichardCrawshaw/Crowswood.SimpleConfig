using System;
using System.IO;
using Crowswood.SimpleConfig;
using Crowswood.SimpleConfig.Test;
using NUnit.Framework;

namespace Crowswood.Test.SimpleConfig
{
    [TestFixture]
    public class SimpleConfigXmlTests
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {

        }

        [Test]
        public void Loading_Config_Does_Not_Throw()
        {
            var path = Path.Combine(@"C:\Users\richa\source\repos\Crowswood.SimpleConfig\Crowswood.Test.SimpleConfig\bin\Debug", "Config.xml");
            var loader = new XmlConfigLoader<ITestConfig>();

            var exceptionThrown = false;
            try
            {
                var config = loader.Load<TestConfig>(path);
            }
            catch
            {
                exceptionThrown = true;
            }

            Assert.False(exceptionThrown, "Exception thrown when loading config from XML.");
        }

        [Test]
        public void Config_Is_Not_Null()
        {
            var path = Path.Combine(@"C:\Users\richa\source\repos\Crowswood.SimpleConfig\Crowswood.Test.SimpleConfig\bin\Debug", "Config.xml");
            var loader = new XmlConfigLoader<ITestConfig>();
            var config = loader.Load<TestConfig>(path);

            Assert.That(config, Is.Not.Null, "Loaded config is NULL");
        }

        [Test]
        public void Config_Loads_Correctly()
        {
            var path = Path.Combine(@"C:\Users\richa\source\repos\Crowswood.SimpleConfig\Crowswood.Test.SimpleConfig\bin\Debug", "Config.xml");
            var loader = new XmlConfigLoader<ITestConfig>();
            var config = loader.Load<TestConfig>(path);

            Assert.Multiple(() =>
            {
                Assert.True(config.IsLoaded, "Config reports that it has not been loaded.");
                Assert.AreEqual(config.Path, path, "Config reports different path");
            });
        }

        [Test]
        public void Config_Loads_Correct_Values()
        {
            var path = Path.Combine(@"C:\Users\richa\source\repos\Crowswood.SimpleConfig\Crowswood.Test.SimpleConfig\bin\Debug", "Config.xml");
            var loader = new XmlConfigLoader<ITestConfig>();
            var config = loader.Load<TestConfig>(path);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(config.TestBool, true, "TestBool is not True");
                Assert.AreEqual(config.TestDateTime, new DateTime(2020, 8, 9, 10, 11, 0), "TestDateTime is different");
                Assert.AreEqual(config.TestDecimal, 87.65, "TestDecimal is different");
                Assert.AreEqual(config.TestInt, 55, "TestInt is different");
                Assert.AreEqual(config.TestString, "This is a string", "TestString is different");
            });
        }
    }
}
