using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace TesteProgrammers.Tests
{
    [TestClass]
    public class FindDuplicityTest
    {
        
        string _filesPath = @"d:\Arquivos";
        /// <summary>
        /// Verifica se o caminho do backup existe  
        /// </summary>
        [TestMethod]
        public void CheckPath()
        {
            Assert.IsTrue(FilesBackup.CheckPath(_filesPath), "Caminho especificado é inválido");
        }
        
        [TestMethod]
        public void CheckDuplicateFilesByContent()
        {
            Assert.IsFalse(FilesBackup.CheckDuplicateFilesByContent(_filesPath).Any(), "Existem arquivos duplicados na pasta");
        }
    }
}
