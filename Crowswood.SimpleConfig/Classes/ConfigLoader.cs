using System;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Crowswood.SimpleConfig
{
    public class ConfigLoader :
        IConfigLoader
    {
        protected string ReadFile(FileInfo file)
        {
            using (var stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }

    public abstract class ConfigLoader<TIConfig> : ConfigLoader,
        IConfigLoader<TIConfig>
        where TIConfig : ISimpleConfig
    {
        public TIConfig Load<TConfig>(string path) 
            where TConfig : class, TIConfig
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentNullException(nameof(path));

            var file = new FileInfo(path);
            if (!file.Exists)
                throw new ArgumentException($"File does not exist: {path}");

            var text = ReadFile(file);

            var config = Deserialize<TConfig>(text);
            if (config is BaseConfig baseConfig)
            {
                baseConfig.IsLoaded = true;
                baseConfig.Path = file.FullName;
            }
            return config;
        }

        protected abstract TConfig Deserialize<TConfig>(string text)
            where TConfig : class, TIConfig;
    }

    public class XmlConfigLoader<TIConfig> : ConfigLoader<TIConfig>
        where TIConfig : ISimpleConfig
    {
        protected override TConfig Deserialize<TConfig>(string text)
        {
            var serializer = new XmlSerializer(typeof(TConfig));
            using (var reader = new StringReader(text))
            {
                return (TConfig)serializer.Deserialize(reader);
            }
        }
    }

    public class JsonConfigLoader<TIConfig> : ConfigLoader<TIConfig>
        where TIConfig : ISimpleConfig
    {
        protected override TConfig Deserialize<TConfig>(string text)
        {
            var serializer = new JsonSerializer();
            using (var textReader = new StringReader(text))
            {
                using (var reader = new JsonTextReader(textReader))
                {
                    return serializer.Deserialize<TConfig>(reader);
                }
            }
        }
    }
}
