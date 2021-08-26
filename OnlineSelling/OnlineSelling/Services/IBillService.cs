using OnlineSelling.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineSelling.Services
{
    interface IBillService
    {
        bool CreateBill(List<BillDetail> BillDetails);
    }
}
