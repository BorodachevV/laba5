using System;
using System.Collections.Generic;
using System.Text;

namespace laba5
{
    public class FolderItem : IFileSystemComponent
    {
        public string Name { get; }
        private List<IFileSystemComponent> _children = new List<IFileSystemComponent>();

        public IReadOnlyList<IFileSystemComponent> Children => _children.AsReadOnly();

        public FolderItem(string name)
        {
            Name = name;
        }

        public void Add(IFileSystemComponent component) => _children.Add(component);
        public void Remove(IFileSystemComponent component) => _children.Remove(component);

        public int GetSize()
        {
            int totalSize = 0;
            foreach (var child in _children)
            {
                totalSize += child.GetSize();
            }
            return totalSize;
        }

        public void Display(int depth = 0)
        {
            Console.WriteLine(new string(' ', depth * 2) + $"📁 Папка: {Name}");
            foreach (var child in _children)
            {
                child.Display(depth + 1);
            }
        }

        public void Delete()
        {
            Console.WriteLine($"[Удаление] Очистка содержимого папки: {Name}...");
            foreach (var child in _children)
            {
                child.Delete();
            }
            _children.Clear();
            Console.WriteLine($"[Удаление] Папка {Name} удалена.");
        }

        public IFileSystemComponent Copy()
        {
            Console.WriteLine($"[Копирование] Создание копии папки: {Name}");
            var newFolder = new FolderItem(Name + "_copy");
            foreach (var child in _children)
            {
                newFolder.Add(child.Copy());
            }
            return newFolder;
        }
    }
}
