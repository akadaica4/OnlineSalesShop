using OnlineSelling.Models;
using OnlineSelling.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineSelling.MenuService
{
    class MenuService1
    {
        private const int exitCode = 9;
        private const int min = 1;
        private const int max = 9;
        private const int hienthi = 1;
        private const int themsanpham = 2;
        private const int xemgiohang = 3;
        private const int suagiohang = 4;
        private const int xoa = 5;
        private const int timkiem = 6;
        private const int thanhtoan = 7;
        private const int dangxuat = 8;
        public MenuUser menu = new MenuUser();
        private ADShopService adShopService = new ADShopService();

        private void BuildMenu1(out int selected)
        {
            do
            {

                Console.WriteLine("========== Menu Service ==========");
                Console.WriteLine("1. Hiển thị danh sách sản phẩm");
                Console.WriteLine("2. Thêm sản phẩm vào giỏ hàng");
                Console.WriteLine("3. Xem giỏ hàng");
                Console.WriteLine("4. Sửa giỏ hàng");
                Console.WriteLine("5. Xóa sản phẩm trong giỏ hàng");
                Console.WriteLine("6. Tìm kiếm sản phẩm");
                Console.WriteLine("7. Thanh toán");
                Console.WriteLine("8. Đăng xuất");
                Console.WriteLine("9. Thoát");
                Console.WriteLine("================================");
                Console.Write($"Vui lòng chọn một số ({min},{max}):");
                int.TryParse(Console.ReadLine(), out selected);
            }
            while (selected < min || selected > max);
        }

        public void Process1()
        {
            int selected = 0;
            do
            {
                BuildMenu1(out selected);
                Console.Clear();
                switch (selected)
                {
                    case hienthi:
                        {
                            Console.WriteLine("ProductID\tProductName\tQuantity\tPrice");
                            adShopService.ShowProduct();
                            break;
                        }
                    case themsanpham:
                        {
                            string choice = "";
                            do
                            {
                                Console.WriteLine("ProductID\tProductName\tQuantity\tPrice");
                                adShopService.ShowProduct();
                                Console.WriteLine("Nhập ID sản phẩm muốn thêm");
                                var idproduct = int.Parse(Console.ReadLine());
                                Console.WriteLine("Nhập số lượng muốn mua");
                                var quantity = int.Parse(Console.ReadLine());
                                adShopService.AddCart(idproduct, quantity);
                                Console.WriteLine("Bạn có muốn tiếp tục mua hàng?(Y/N)");
                                Console.Write("Nhập Y để tiếp tục, N để thoát: ");
                                choice = Console.ReadLine();
                            } while (choice != "n");
                            break;
                        }
                    case xemgiohang:
                        {
                            adShopService.ShowCart();
                            break;
                        }
                    case suagiohang:
                        {
                            adShopService.ShowCart();
                            Console.WriteLine("Nhập ID sản phẩm muốm chỉnh sửa");
                            var idProduct = int.Parse(Console.ReadLine());
                            Console.WriteLine("Nhập lại số lượng muốn thay đổi");
                            var Quantity = int.Parse(Console.ReadLine());
                            adShopService.Edit(idProduct, Quantity);
                            break;
                        }
                    case xoa:
                        {
                            adShopService.ShowCart();
                            Console.WriteLine("Nhập ID sản phẩm muốn xóa");
                            var id = int.Parse(Console.ReadLine());
                            adShopService.RemoveCart(id);
                            Console.WriteLine("Đã xóa sản phẩm thành công");
                            break;
                        }
                    case timkiem:
                        {
                            Console.WriteLine("ProductID\tProductName\tQuantity\tPrice");
                            adShopService.ShowProduct();
                            Console.WriteLine("Nhập tên sản phẩm bạn muốn tìm");
                            var Keyword = Console.ReadLine();
                            adShopService.FindProduct(Keyword);
                            break;
                        }
                    case thanhtoan:
                        {
                            adShopService.Pay();
                            Console.WriteLine("Đã đạt hàng thành công");
                            break;
                        }
                    case dangxuat:
                        {
                            menu.Process();
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
