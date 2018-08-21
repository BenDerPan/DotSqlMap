using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotSqlMap.Api
{
    public class Utils
    {
        public static readonly string DumpDirectoryRoot = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"dump");
        
        public static void CheckDirecotryExist(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        public static string CheckTargetDBDirectoryExist(string target,string db)
        {
            var targetPath = Path.Combine(DumpDirectoryRoot, target);
            var dbPath = Path.Combine(targetPath, db);
            CheckDirecotryExist(targetPath);
            CheckDirecotryExist(dbPath);
            return dbPath;
        }
    }
}
