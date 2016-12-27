using System.IO;
using Android.App;
using MobileTemplate.Core.Services;

namespace MobileTemplate.Droid.Service
{
    public class AssetServiceDroid : AssetService
    {
        public override string ReadAssetText(string path)
        {
            string text;
            using (var stream = GetAssetStream(path))
            {
                using (var streamReader = new StreamReader(stream))
                {
                    text = streamReader.ReadToEnd();
                }
            }
            return text;
        }

        private Stream GetAssetStream(string path)
        {
            return Application.Context.Assets.Open(path);
        }
    }
}