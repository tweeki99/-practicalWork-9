using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackupCopy
{
    public class File
    {
        public int Size { get; set; }

        public File()
        {
            Size = 100; // Mb
        }

        public File(int size)
        {
            Size = size;
        }


    }
}
