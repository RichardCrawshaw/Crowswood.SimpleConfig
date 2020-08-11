namespace Crowswood.SimpleConfig
{
    public interface ISimpleConfig
    {
        bool IsLoaded { get; }

        string Path { get; }
    }
}
