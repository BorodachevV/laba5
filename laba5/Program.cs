namespace laba5
{
    internal class Program
    {
        static void Main()
        {
            // 1. Строим иерархию 
            var root = new FolderItem("Root");
            var docs = new FolderItem("Documents");

            docs.Add(new FileItem("report.pdf", 2500));
            root.Add(docs);

            Console.WriteLine("--- Структура файловой системы ---");
            root.Display();

            // 2. Инициализируем подсистемы
            IStorageAdapter local = new LocalStorageAdapter();
            IStorageAdapter cloud = new CloudStorageAdapter();

            // 3. Выполняем сложные сценарии через Фасад
            var facade = new FileSystemFacade(local, cloud);
            facade.BackupLocalToCloud(root);
        }
    }
}
