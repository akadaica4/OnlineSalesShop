using OnlineSelling.Helper;
using OnlineSelling.Models;
using OnlineSelling.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OnlineSelling.MenuService
{
    class MenuUser : BaseService
    {
        private const int exitCode = 3;
        private const int min = 1;
        private const int max = 3;
        private const int dangnhap = 1;
        private const int dangky = 2;
        static UserService userService = new UserService();
        private static void BuildMenu(out int selected)
        {
            do
            {
                Console.WriteLine("========== Đăng nhập ==========");
                Console.WriteLine("1. Đăng Nhập");
                Console.WriteLine("2. Đăng ký");
                Console.WriteLine("3. Thoát");
                Console.WriteLine("================================");
                Console.Write($"Vui lòng chọn một số ({min},{max}):");
                int.TryParse(Console.ReadLine(), out selected);
            }
            while (selected < min || selected > max);
        }

        public void Process()
        {
            MenuService1 menuService = new MenuService1();
            int selected = 0;
            do
            {
                BuildMenu(out selected);
                Console.Clear();
                switch (selected)
                {
                    case dangnhap:
                        {
                            bool check = userService.Dangnhap();
                            if (check)
                            {
                                menuService.Process1();
                                break;
                            }
                            break;
                        }
                    case dangky:
                        {
                            userService.Dangky();
                            menuService.Process1();
                            break;
                        }
                    case exitCode:
                        {
                            Environment.Exit(0);
                            break;
                        }
                }
            }
            while (selected != exitCode);
        }
    }
}
