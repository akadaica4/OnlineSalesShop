using OnlineSelling.Helper;
using OnlineSelling.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace OnlineSelling.Services
{
    class UserService : BaseService,IUserService
    {
        private string fileName = "user.json";
        private UserList userList = new UserList();
        public UserService()
        {
            userList = FileHelper.ReadFile<UserList>(Path.Combine(path, fileName));
        }
        public static bool Checkusername(string name)
        {
            return Regex.IsMatch(name, "^[a-zA-Z0-9_]{6,16}$");
        }
        public static bool CheckPassword(string password)
        {
            return Regex.IsMatch(password, @"((?=.*\d)(?=.*[a-z]).*[A-Z])(?=.*[!@#$%^&]).{6,20}");
        }
        public static bool IsNameExist(List<User> user, string name)
        {
            foreach (var item in user)
            {
                if (item.tendangnhap.Contains(name))
                {
                    return true;
                }
            }
            return false;
        }
        public static bool IsPasswordExist(List<User> user, string password)
        {
            foreach (var item in user)
            {
                if (item.matkhau.Contains(password))
                {
                    return true;
                }
            }
            return false;
        }
        public static bool IsExistvalue(List<User> user)
        {
            foreach (var item in user)
            {
                if (item != null)
                {
                    return true;
                }
            }
            return false;
        }
        public  bool Dangnhap()
        {
            bool login = false;
            bool check = false;
            if (IsExistvalue(userList.users))
            {
                do
                {
                    Console.Write("Tên Đăng Nhập:");
                    string name = Console.ReadLine();
                    Console.Write("Mật Khẩu:");
                    string password = Console.ReadLine();
                    bool isNameExist = IsNameExist(userList.users, name);
                    bool isPasswordExist = IsPasswordExist(userList.users, password);
                    if (isNameExist)
                    {
                        if (isPasswordExist)
                        {
                            Console.WriteLine("Đăng Nhập Thành Công");
                            login = true;
                            check = true;
                        }
                        else
                        {
                            Console.WriteLine("Sai Mật Khẩu!! Vui Lòng Thử lại:");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Tên Đăng Nhập Không Tồn Tại!! Vui Lòng Đăng Nhập Lại");
                    }
                }
                while (check == false);
            }
            else
            {
                Console.WriteLine("Chưa Có Tài Khoản!!!");
            }
            return login;
        }
        public void Dangky()
        {
            Console.WriteLine("Thông Tin Đăng Nhập!");
            Console.Write("Tên đăng nhập: ");
            string name = Console.ReadLine();
            while (Checkusername(name) == false)
            {
                Console.WriteLine("Tên đăng nhập không hợp lệ ");
                Console.WriteLine("Tên đăng nhập không được dùng ký tự đặc biệt hoặc khoảng trắng và tối thiểu có 6 ký tự!");
                Console.Write("Tên đăng nhập: ");
                name = Console.ReadLine();
            }
            while (IsNameExist(userList.users, name))
            {
                Console.WriteLine("Tên đăng nhập đã tồi tại! Vui lòng chọc tên khác ");
                Console.Write("Tên đăng nhập: ");
                name = Console.ReadLine();
            }

            Console.WriteLine("Mật khẩu tối thiểu 6 ký tự bao gồm: Chữ hoa, chữ thường, số và ký tự đặc biệt");
            Console.Write("Mật khẩu: ");
            string matkhau = Console.ReadLine();
            while (CheckPassword(matkhau) == false)
            {
                Console.WriteLine("Mật khẩu chưa hợp lệ. Vui lòng nhập lại mật khẩu");
                Console.WriteLine("Mật khẩu tối thiểu 6 ký tự bao gồm: Chữ hoa, chữ thường, số và ký tự đặc biệt");
                Console.Write("Mật khẩu: ");
                matkhau = Console.ReadLine();
            }
            Console.Write("Nhập lại mật khẩu: ");
            string reMatkhau = Console.ReadLine();
            while (matkhau != reMatkhau)
            {
                Console.WriteLine("Mật khẩu không trùng khớp!");
                Console.Write("Vui lòng nhập lại: ");
                reMatkhau = Console.ReadLine();
            }

            User user1 = new User();
            user1.tendangnhap = name;
            user1.matkhau = matkhau;
            userList.users.Add(user1);
            FileHelper.WriteFile<UserList>(Path.Combine(path, fileName), userList);
        }

        public List<User> Get()
        {
            return userList.users;
        }
    } 
}
