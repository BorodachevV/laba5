namespace laba5
{
    internal class Program
    {
        static void Main()
        {
            var root = new FolderItem("Root"); 
            var docs = new FolderItem("Documents"); 
            var system = new FolderItem("System");
            docs.Add(new FileItem("report.pdf", 2500)); 
            docs.Add(new FileItem("budget.xlsx", 1200)); 
            system.Add(new FileItem("config.ini", 300)); 
            system.Add(new FileItem("temp.tmp", 5000));
            root.Add(docs); root.Add(system);
            Console.WriteLine("--- Исходная структура файловой системы ---"); 
            root.Display();
            IFileSystem fileSystemAdapter = new FileSystemAdapter(root);
            var facade = new FileSystemFacade(fileSystemAdapter);


            var configs = new List<string>{        
                "Root/System/config.ini",        
                "Root/Documents/report.pdf",        
                "Root/System/missing_file.txt"             
            };            
            facade.ReadSystemConfigs(configs);


            var trashFiles = new List<string> {       
                "Root/System/temp.tmp",        
                "Root/Documents/budget.xlsx"      
            };      
            facade.BatchCleanup(trashFiles);
            Console.WriteLine("--- Структура файловой системы после работы Фасада ---");     
            root.Display();    
        }
    }
}

