using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InterfaceStore.furniture;
using InterfaceStore.market;
using InterfaceStore.helper;
using InterfaceStore.core;

namespace InterfaceStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            System.Console.SetWindowSize(140, 40);
            Store store = new Store(10);
            store.addFurniture(new KitchenTable(RoomType.Kitchen, Material.CherryTree, new Size(200, 110, 180), 4, true));
            store.addFurniture(new Bed(RoomType.Bedroom, Material.Oak, new Size(200, 220, 40), 2, Mattress.Comfortable));
            store.addFurniture(new Wardrobe(RoomType.Hall, Material.Pine, new Size(100, 240, 80), 10, true));
            
            store.addMarketGoods(new DinnerwareSet(GoodsType.KitchenTool,true));
            store.addMarketGoods(new TableLamp(GoodsType.DeskTool,Efficiency.Watt60));

            System.Console.WriteLine(store);

            System.Console.WriteLine(store.simulationSalable());

        }
    }
}
