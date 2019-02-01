using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackupCopy
{
    class Program
    {
        static void Main(string[] args)
        {
            FlashMemory flashMemory = new FlashMemory();
            DiskDVD unilateralDiskDVD = new DiskDVD("Односторонний", TypeDVD.unilateral);
            DiskDVD bilateralDiskDVD = new DiskDVD("Двухсторонний", TypeDVD.bilateral);
            RemovableHDD removableHDD = new RemovableHDD("Samsung", 3, 400);

            Console.WriteLine(flashMemory.DeviceInfo());
            Console.WriteLine(unilateralDiskDVD.DeviceInfo());
            Console.WriteLine(bilateralDiskDVD.DeviceInfo());
            Console.WriteLine(removableHDD.DeviceInfo());

            File firstFile = new File();         // 100 Mb
            File secondFile = new File(512);     // 512 Mb
            File thirdFile = new File(1024);     // 1 Gb
            File fourthFile = new File(10240);   // 10 Gb
            File fifthfFle = new File(10240000); // 10 Tb

            Console.WriteLine();

            Console.WriteLine(flashMemory.CopyTime(firstFile));
            Console.WriteLine(flashMemory.CopyTime(secondFile));
            Console.WriteLine(flashMemory.CopyTime(thirdFile));
            Console.WriteLine(flashMemory.CopyTime(fourthFile));
            Console.WriteLine(flashMemory.CopyTime(fifthfFle));

            flashMemory.CopyData(firstFile);
            unilateralDiskDVD.CopyData(thirdFile);
            bilateralDiskDVD.CopyData(fourthFile);
            removableHDD.CopyData(fourthFile);
            removableHDD.CopyData(fifthfFle);

            Console.WriteLine();

            Console.WriteLine(flashMemory.DeviceInfo());
            Console.WriteLine(unilateralDiskDVD.DeviceInfo());
            Console.WriteLine(bilateralDiskDVD.DeviceInfo());
            Console.WriteLine(removableHDD.DeviceInfo());


            Console.ReadLine();
        }
    }
}
