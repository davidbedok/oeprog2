using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Store
{
    public class Program
    {
        public static void noVirtualPrint( NoVirtualItem item )
        {
            System.Console.WriteLine(item.play()); 
            System.Console.WriteLine(item.handle());
            System.Console.WriteLine();
        }

        public static void noVirtualDemo()
        {
            // minden metodus a NoVirtualItem osztalyban fut (egyertelmu)
            System.Console.WriteLine("\n### (1) NoVirtualItem iItem = new NoVirtualItem()");
            NoVirtualItem iItem = new NoVirtualItem("AlmaItem", 10, 1000);
            System.Console.WriteLine(iItem.play()); // Play NoVirtualItem
            System.Console.WriteLine(iItem.handle()); // Play NoVirtualItem            
                       
            // A play() egyertelmuen a NoVDVD-ben fut, de a handle() esete mar nem ennyire egyertelmu
            System.Console.WriteLine("\n### (2) NoVDVD iDVD = new NoVDVD()");
            NoVDVD iDVD = new NoVDVD("AlmaDVD", 20, 500.0, DVDType.LayerOne);
            System.Console.WriteLine(iDVD.play()); // Play NoVDVD --> DVD

            // Itt a Play a NoVirtualItem osztalyban fut! OK: a handle() altel hivott play() metodust eloszor a 
            // NoVirtualItem osztalyban talalja meg a fordito, mert a handle() metodus is ott van!
            System.Console.WriteLine(iDVD.handle()); // Play NoVirtualItem (es igy nem jelenik meg a DiskType..)
            
            // minden metodus a NoVirtualItem osztalyban fut --> ez a nem virtualis metodusok hasznlatanak egyik legnagyobb hatranya
            // egyetlen elonye: gyorsabb mint a virtualis metodusok hivasa (gyorsabb, mert kiszamithato, egyertelmu a forditonak. Embernek mar kevesbe..)
            System.Console.WriteLine("\n### (3) NoVirtualItem iItemDVD = new NoVDVD()");
            NoVirtualItem iItemDVD = new NoVDVD("AlmaDVD", 20, 500.0, DVDType.LayerOne);
            System.Console.WriteLine(iItemDVD.play()); // Play NoVirtualItem
            System.Console.WriteLine(iItemDVD.handle()); // Play NoVirtualItem

            System.Console.WriteLine("\n### (4) NoVDVD iDVD = new NoVDVD() --> NoVirtualItem");
            Program.noVirtualPrint(iDVD);
            // igy ugyanazt erjuk el, mint a 3. esetben
        }

        public static void noVirtualCast()
        {
            NoVirtualItem iItem = new NoVirtualItem("AlmaItem", 10, 1000);
            NoVDVD iDVD = new NoVDVD("AlmaDVD", 20, 500.0, DVDType.LayerOne);
            NoVirtualItem iItemDVD = new NoVDVD("AlmaDVD", 20, 500.0, DVDType.LayerOne);

            // DVD-bol Item-et (cast nelkul, mert mindig lehetseges)
            NoVirtualItem iItem2 = iDVD;
            System.Console.WriteLine(iItem2.play()); // Play NoVirtualItem

            // Item-bol DVD-t (cast szukseges, mert nem biztos, hogy lehetseges!)
            NoVDVD iDVD2 = (NoVDVD)iItemDVD;
            System.Console.WriteLine(iDVD2.play()); // Play NoVDVD

            NoVirtualItem iItemVHS = new NoVVHS("AlmaVHS", 20, 500.0, VHSType.Size240);
            // NoVDVD iDVD3 = (NoVDVD)iItemVHS; // InvalidCastException

            // biztonsagos megoldas
            if (iItemVHS is NoVDVD)
            {
                NoVDVD iDVD3 = (iItemVHS as NoVDVD);
                // vagy: NoVDVD iDVD3 = (NoVDVD)iItemVHS;
            }

            // tudjuk, hogy az iItemDVD-nek van DiskType-ja, de nem tudjuk kiirni:
            // System.Console.WriteLine(iItemDVD.DiskType);
            // de igy viszont mar igen
            System.Console.WriteLine((iItemDVD as NoVDVD).DiskType);
        }

        public static void virtualPrint(VirtualItem item)
        {
            System.Console.WriteLine(item.play());
            System.Console.WriteLine(item.handle());
            System.Console.WriteLine();
        }

        public static void virtualDemo()
        {
            // minden metodus a VirtualItem osztalyban fut (egyertelmu)
            System.Console.WriteLine("\n### (1) VirtualItem iItem = new VirtualItem()");
            VirtualItem iItem = new VirtualItem("AlmaItem", 10, 1000);
            System.Console.WriteLine(iItem.play()); // Play VirtualItem
            System.Console.WriteLine(iItem.handle()); // Play VirtualItem        

            // minden metodus a VDVD osztalyban fut
            System.Console.WriteLine("\n### (2) VDVD iDVD = new VDVD()");
            VDVD iDVD = new VDVD("AlmaDVD", 20, 500.0, DVDType.LayerOne);
            System.Console.WriteLine(iDVD.play()); // Play VDVD --> DVD
            // A VDVD osztalyban fut --> azert, mert Virtualis! (Virtualis Metodus Table keszul)
            System.Console.WriteLine(iDVD.handle()); // Play VDVD --> DVD

            // minden metodus a VDVD osztalyban fut!! A play() is és a handle() is
            System.Console.WriteLine("\n### (3) VirtualItem iItemDVD = new VDVD()");
            VirtualItem iItemDVD = new VDVD("AlmaDVD", 20, 500.0, DVDType.LayerOne);
            System.Console.WriteLine(iItemDVD.play()); // Play VDVD
            System.Console.WriteLine(iItemDVD.handle()); // Play VDVD

            System.Console.WriteLine("\n### (4) VDVD iDVD = new VDVD() --> VirtualItem");
            Program.virtualPrint(iDVD);
            // ezek utan ez is egyertelmu, hogy minden a VDVD osztalyban fut
        }

        public static void abstractPrint(AbstractItem item)
        {
            System.Console.WriteLine(item.play());
            System.Console.WriteLine(item.handle());
            System.Console.WriteLine();
        }

        public static void abstractDemo()
        {
            System.Console.WriteLine("\n### (1) AbstractItem iItem = new AbstractItem()");
            // AbstractItem iItem = new AbstractItem("AlmaItem", 10, 1000);
            System.Console.WriteLine("n/a");

            // ugyanaz a hatasa, mint a Virtual metodus hivas eseten. Ugyanugy VMT epul
            System.Console.WriteLine("\n### (2) DVD iDVD = new DVD()");
            DVD iDVD = new DVD("AlmaDVD", 20, 500.0, DVDType.LayerOne);
            System.Console.WriteLine(iDVD.play()); // Play VDVD --> DVD            
            System.Console.WriteLine(iDVD.handle()); // Play VDVD --> DVD

            // ugyanaz a hatasa, mint a Virtual metodus hivas eseten. Ugyanugy VMT epul
            System.Console.WriteLine("\n### (3) AbstractItem iItemDVD = new DVD()");
            AbstractItem iItemDVD = new DVD("AlmaDVD", 20, 500.0, DVDType.LayerOne);
            System.Console.WriteLine(iItemDVD.play()); // Play VDVD
            System.Console.WriteLine(iItemDVD.handle()); // Play VDVD

            System.Console.WriteLine("\n### (4) DVD iDVD = new DVD() --> AbstractItem");
            Program.abstractPrint(iDVD);
            // ezek utan ez is egyertelmu, hogy minden a DVD osztalyban fut           
        }

        public static void complexAbstractDemo()
        {
            System.Console.WriteLine("\n### complexAbstractDemo");

            AbstractItem[] items = new AbstractItem[5];
            items[0] = new VHS("StarWars", 130, 5043, VHSType.Size300);
            items[1] = new DVD("LoTR", 200, 20000, DVDType.LayerTwo);
            items[2] = new VHS("Matrix", 400, 432, VHSType.Size240);
            items[3] = new DVD("Bloff", 65, 55043, DVDType.LayerTwo);
            items[4] = new DVD("StarTrek", 2400, 20, DVDType.LayerOne);
            
            for (int i = 0; i < items.Length; i++)
            {
                System.Console.WriteLine(items[i].play());
            }

        }

        static void Main(string[] args)
        {
            // Program.noVirtualDemo();
            Program.virtualDemo();
            Program.abstractDemo();
            // Program.complexAbstractDemo();
            // Program.noVirtualCast();
            System.Console.ReadKey();
        }
    }
}
