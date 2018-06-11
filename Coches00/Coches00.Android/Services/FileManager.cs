using System;
using System.IO;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(Coches00.FileManager))]

namespace Coches00
{
    public class FileManager : IFileManager
    {
        public string SaveFile(byte[] stream)
        {
            var dir = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDocuments);

            string filename = System.DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".jpg";
            string filePath = System.IO.Path.Combine(dir.ToString(), filename);

            try
            {
                System.IO.File.WriteAllBytes(filePath, stream);

                return filePath;
            }
            catch (Exception ex)
            {
                //System.Console.WriteLine(ex.ToString());
                return "Error";
            }
        }
    }
}