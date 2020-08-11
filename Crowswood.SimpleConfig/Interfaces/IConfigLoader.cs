namespace Crowswood.SimpleConfig
{
    public interface IConfigLoader
    {
        
    }

    public interface IConfigLoader<TIConfig>
        where TIConfig : ISimpleConfig
    {
        TIConfig Load<TConfig>(string path)
            where TConfig : class, TIConfig;
    }
}
