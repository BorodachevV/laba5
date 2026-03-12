using System;
using System.Collections.Generic;
using System.Text;

namespace laba5
{
    public class FileSystemFacade
    {
        private readonly IFileSystem _fileSystem;
        public FileSystemFacade(IFileSystem fileSystem) { _fileSystem = fileSystem; }
        public void ReadSystemConfigs(List<string> configPaths) { 
            Console.WriteLine("\n=== [Фасад] Запуск чтения системных конфигураций ==="); 
            foreach (var path in configPaths) { 
                _fileSystem.Read(path); } 
            Console.WriteLine("=== [Фасад] Чтение завершено ===\n"); 
        }
        public void BatchCleanup(List<string> pathsToDelete) { 
            Console.WriteLine("\n=== [Фасад] Запуск пакетной очистки файлов ==="); 
            foreach (var path in pathsToDelete) { 
                _fileSystem.Delete(path); 
            } 
            Console.WriteLine("=== [Фасад] Пакетная очистка завершена ===\n"); 
        }
    }
}
