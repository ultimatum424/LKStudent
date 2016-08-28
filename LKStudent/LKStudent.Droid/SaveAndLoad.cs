using System;
using System.IO;
using System.Runtime.CompilerServices;
using LKStudent.Droid;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(SaveAndLoad))]
namespace LKStudent.Droid
{
    public class SaveAndLoad : ISaveAndLoad
    {
        public void SaveText(string filename, string text)
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentsPath, filename);
            System.IO.File.WriteAllText(filePath, text);
        }

        public string LoadText(string filename)
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentsPath, filename);
            return System.IO.File.ReadAllText(filePath);
        }
    }
}