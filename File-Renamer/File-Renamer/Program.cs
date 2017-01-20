using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_Renamer
{ 
    class Program
    {
        private static List<FileInfo> fileList;

        static void Main(string[] args)
        {
            if (args.Count() == 1)
            {
                fileList = new List<FileInfo>();

                DirWalker(args[0]);

                foreach (FileInfo f in fileList)
                {
                    ModifyFile(f);
                }
            }
            else
            {
                Console.WriteLine("This program rename files in the supplied folder. (1. Somename --> 01 somename)");
                Console.WriteLine("To use the program supply folder path.");
                Console.WriteLine("example usage: File-Renamer c:\\Users\\Sezer\\Desktop\\CourseName");
            }
        }

        private static void DirWalker(string path)
        {
            string[] files = Directory.GetFiles(path);
            string[] dirs = Directory.GetDirectories(path);

            foreach (string f in files)
            {
                FileInfo fi = new FileInfo(f);

                if (fi.Extension == ".srt")
                    fileList.Add(fi);
            }

            foreach (string d in dirs)
                DirWalker(d);
        }

        private static void ModifyFile(FileInfo source_f)
        {
            try
            {
                if (source_f.Name.Substring(1, 1) == ".")
                {
                    source_f.MoveTo(source_f.Directory + "\\" + "0" + source_f.Name.Substring(0, 1) + " " + source_f.Name.Substring(3));
                }
                else
                {
                    source_f.MoveTo(source_f.Directory + "\\" + source_f.Name.Substring(0, 2) + " " + source_f.Name.Substring(4));
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Hata oldu");
            }
        }
    }
}
