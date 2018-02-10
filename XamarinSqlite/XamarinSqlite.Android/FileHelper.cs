using System;
using System.IO;
using Xamarin.Forms;
using XamarinSqlite.Droid;
using XamarinSqlite.Helpers;

[assembly: Dependency(typeof(FileHelper))]
namespace XamarinSqlite.Droid
{

    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }
    }
}
    
