using System;
using System.Collections.Generic;
using System.Text;

namespace laba5
{
    public class CloudStorageAdapter : IStorageAdapter
    {
        private ThirdPartyCloudAPI _cloudApi = new ThirdPartyCloudAPI();
        private string _bucketName = "my-backup-bucket";

        public void Write(string path, string data) => _cloudApi.UploadObject(_bucketName, path, data);
        public string Read(string path) => _cloudApi.DownloadObject(_bucketName, path);
        public void Delete(string path) => _cloudApi.RemoveObject(_bucketName, path);
        public List<string> ListContents(string path) => new List<string> { "cloud_file.txt" };
    }
}
