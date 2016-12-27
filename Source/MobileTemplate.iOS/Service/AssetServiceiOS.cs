using System;
using System.IO;
using Foundation;
using MobileTemplate.Core.Services;

namespace MobileTemplate.iOS.Service
{
    public class AssetServiceiOS : AssetService
    {
        public override string ReadAssetText(string path)
        {
            using (var data = GetAssetData(path))
            {
                using (var text = new NSString(data, NSStringEncoding.UTF8))
                {
                    return text.ToString();
                }
            }
        }

        private NSData GetAssetData(string path)
        {
            var resourcePath = GetResourcePath(path);
            return NSData.FromFile(resourcePath);
        }

        private string GetResourcePath(string path)
        {
            var extension = Path.GetExtension(path) ?? "";
            var filePath = path.Replace(extension, "");
            extension = extension.Replace(".", "");
            return NSBundle.MainBundle.PathForResource(filePath, extension);
        }
    }
}