using System;
using System.Collections.Generic;
using System.Text;

namespace laba5
{
    public class FileSystemFacade
    {
        private readonly IStorageAdapter _localDb;
        private readonly IStorageAdapter _cloudDb;

        public FileSystemFacade(IStorageAdapter localDb, IStorageAdapter cloudDb)
        {
            _localDb = localDb;
            _cloudDb = cloudDb;
        }

        public void BackupLocalToCloud(IFileSystemComponent rootNode)
        {
            Console.WriteLine("\n=== ЗАПУСК РЕЗЕРВНОГО КОПИРОВАНИЯ В ОБЛАКО ===");
            Console.WriteLine($"Подсчет требуемого места: {rootNode.GetSize()} байт");

            SyncRecursive(rootNode, "");

            Console.WriteLine("=== РЕЗЕРВНОЕ КОПИРОВАНИЕ ЗАВЕРШЕНО ===\n");
        }

        private void SyncRecursive(IFileSystemComponent node, string currentPath)
        {
            string path = string.IsNullOrEmpty(currentPath) ? node.Name : $"{currentPath}/{node.Name}";

            if (node is FileItem file)
            {
                string data = _localDb.Read(path);
                _cloudDb.Write(path, data);
            }
            else if (node is FolderItem folder)
            {
                Console.WriteLine($"[Фасад] Синхронизация директории: {path}");
                foreach (var child in folder.Children)
                {
                    SyncRecursive(child, path);
                }
            }
        }
    }
}
