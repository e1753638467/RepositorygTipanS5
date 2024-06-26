using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gTipanS5.Utils
{
    internal class FileAccessHelper
    {
        public static string GetlocalfilePath(string filenname)
        {
            return System.IO.Path.Combine(FileSystem.AppDataDirectory, filenname);
        }

    }
}
