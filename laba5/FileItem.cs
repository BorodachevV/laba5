using System;
using System.Collections.Generic;
using System.Text;

namespace laba5
{
    public class FileItem : IFileSystemComponent
    {
        public string Name { get; }
        private int _size;

        public FileItem(string name, int size)
        {
            Name = name;
            _size = size;
        }

        public int GetSize() => _size;

        public void Display(int depth = 0)
        {
            Console.WriteLine(new string(' ', depth * 2) + $"📄 Файл: {Name} ({_size} байт)");
        }

        public void Delete()
        {
            Console.WriteLine($"[Удаление] Удален файл: {Name}");
        }

        public IFileSystemComponent Copy()
        {
            Console.WriteLine($"[Копирование] Скопирован файл: {Name}");
            return new FileItem(Name, _size);
        }
    }
}
