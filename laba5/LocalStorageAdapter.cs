using System;
using System.Collections.Generic;
using System.Text;

namespace laba5
{
    public class LocalStorageAdapter : IStorageAdapter
    {
        public void Write(string path, string data) => Console.WriteLine($"[Локальный диск] Запись данных в {path}");
        public string Read(string path) => $"данные из файла {path}";
        public void Delete(string path) => Console.WriteLine($"[Локальный диск] Удаление {path}");
        public List<string> ListContents(string path) => new List<string> { "file.txt" };
    }
}
