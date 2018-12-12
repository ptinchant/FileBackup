using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteProgrammers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Informe o caminho para realização do backup.");
            string path = Console.ReadLine();

            if (string.IsNullOrEmpty(path) || !FilesBackup.CheckPath(path))
            {
                Console.WriteLine("O caminho informado não pode ser localizado");
                
            }
            else
            {
                List<string> duplicateFiles = FilesBackup.CheckDuplicateFilesByContent(path);
                if (duplicateFiles.Any())
                {
                    Console.WriteLine("Os seguintes arquivos estão duplicados");
                    duplicateFiles.ForEach(f => Console.WriteLine(f));
                }
                else
                {
                    Console.WriteLine("Não existem arquivos duplicados");
                }
            }
            Console.ReadKey();
        }
    }
}
