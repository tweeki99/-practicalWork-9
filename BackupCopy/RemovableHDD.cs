using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackupCopy
{
    class RemovableHDD : Storage
    {
        public int QuantitySections { get; set; }
        public int SectionsSize { get; set; } // Mb
        public int AllMemory { get; set; } // Mb
        public double Speed { get; set; }  // Mбайт/с
        public int FilledMemory { get; set; } // Mb

        public RemovableHDD() : base("Cъемный HDD", "\"ПУСТО\"")
        {
            Speed = 50; // Mбайт/с
            QuantitySections = 1;
            SectionsSize = 1000 * MbInGb;
            AllMemory = QuantitySections * SectionsSize;
            FilledMemory = 0;
        }
    
        public RemovableHDD(string model, int quantitySections, int sectionsSize) : base("Cъемный HDD", model)
        {
            Speed = 50; // Mбайт/с
            QuantitySections = quantitySections;
            SectionsSize = sectionsSize * MbInGb;
            AllMemory = QuantitySections * SectionsSize;
            FilledMemory = 0;
        }

        public override string DeviceInfo()
        {
            return $"{Name} {Model} объемом {AllMemory} МБ и скоростью {Speed} Мбайт/с заполнен на {FilledMemory} МБ";
        }

        public override int FreeMemory()
        {
            int freeMemory = AllMemory - FilledMemory;

            return freeMemory;
        }

        public override void CopyData(File file)
        {
            if (FilledMemory + file.Size <= AllMemory)
            {
                FilledMemory += file.Size;
            }
        }

        public override int CopyTime(File file)
        {
            return (int)(file.Size / Speed);
        }
    }
}
