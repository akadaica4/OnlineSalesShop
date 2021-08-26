using OnlineSelling.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineSelling.Services
{
    interface IUserService
    {
        void Dangky();
        List<User> Get();
    }
}
