using System;
using System.Collections.Generic;
using System.Text;

namespace laba5
{
    public class ThirdPartyCloudAPI
    {
        public void UploadObject(string bucket, string key, string content) =>
            Console.WriteLine($"[Облако S3] Загрузка '{key}' в бакет '{bucket}'");
        public string DownloadObject(string bucket, string key) => "облачные данные";
        public void RemoveObject(string bucket, string key) =>
            Console.WriteLine($"[Облако S3] Удаление '{key}' из '{bucket}'");
    }
}
