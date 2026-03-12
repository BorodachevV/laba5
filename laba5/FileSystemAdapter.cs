using System;
using System.Collections.Generic;
using System.Text;

namespace laba5
{
    public class FileSystemAdapter : IFileSystem
    {
        private readonly IFileSystemComponent _root;


        public FileSystemAdapter(IFileSystemComponent root)
        {
            _root = root;
        }


        private IFileSystemComponent FindComponent(IFileSystemComponent current, string[] pathParts, int depth)
        {

            if (current.Name == pathParts[depth])
            {

                if (depth == pathParts.Length - 1)
                {
                    return current;
                }


                if (current is FolderItem folder)
                {
                    foreach (var child in folder.Children)
                    {
                        var found = FindComponent(child, pathParts, depth + 1);
                        if (found != null) return found; 
                    }
                }
            }
            return null;
        }


        private IFileSystemComponent GetElementByPath(string absolutePath)
        {

            string[] parts = absolutePath.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 0) return null;

            return FindComponent(_root, parts, 0);
        }


        public void Read(string absolutePath)
        {
            var component = GetElementByPath(absolutePath);
            if (component != null && component is FileItem)
            {
                Console.WriteLine($"[Адаптер] Чтение файла по пути '{absolutePath}' выполнено успешно.");
            }
            else
            {
                Console.WriteLine($"[Адаптер] Ошибка: Файл '{absolutePath}' не найден.");
            }
        }

        public void Delete(string absolutePath)
        {
            var component = GetElementByPath(absolutePath);
            if (component != null)
            {
                component.Delete();
                Console.WriteLine($"[Адаптер] Элемент по пути '{absolutePath}' удален.");

            }
            else
            {
                Console.WriteLine($"[Адаптер] Ошибка: Элемент '{absolutePath}' не найден.");
            }
        }
    }

}
