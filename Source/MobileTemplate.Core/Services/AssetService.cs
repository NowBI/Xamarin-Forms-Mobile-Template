namespace MobileTemplate.Core.Services
{
    public interface IAssetService
    {
        string ReadAssetText(string path);
    }

    public abstract class AssetService : IAssetService
    {
        public abstract string ReadAssetText(string path);
    }
}
