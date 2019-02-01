using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackupCopy
{
    class FlashMemory : Storage
    {        
        public int AllMemory { get; set; } // Mb
        public int Speed { get; set; }  // Mбайт/с
        public int FilledMemory { get; set; } // Mb

        public FlashMemory(): base("Флешка","\"ПУСТО\"")
        {
            Speed = 500; // Mбайт/с
            AllMemory = 32 * MbInGb;
        }

        public FlashMemory( string model, int allMemory): base("Флешка", model)
        {
            Speed = 500;
            AllMemory = allMemory * MbInGb;
        }     

        public override string DeviceInfo()
        {
            return $"{Name} {Model} объемом {AllMemory} МБ и скоростью {Speed} Мбайт/с заполнена на {FilledMemory} МБ";
        }

        public override int FreeMemory()
        {
            int freeMemory = AllMemory - FilledMemory;

            return freeMemory;
        }    

        public override void CopyData(File file)
        {
            if(FilledMemory + file.Size <= AllMemory)
            {
                FilledMemory += file.Size;
            }
        }

        public override int CopyTime(File file)
        {
            return file.Size / Speed;
        }
    }
}
