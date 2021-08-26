using OnlineSelling.MenuService;
using OnlineSelling.Services;
using System;
using System.Text;
namespace OnlineSelling
{
    class Program
    {
        private static ADShopService adShopService = new ADShopService();
        public static MenuUser menu = new MenuUser();
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            menu.Process();
        }
    }
}
