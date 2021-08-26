using OnlineSelling.Helper;
using OnlineSelling.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace OnlineSelling.Services
{
    class BillService : BaseService, IBillService
    {
        private string billFileName = "Bills.json";
        private BillList billList = new BillList();
        public BillService()
        {
            billList = FileHelper.ReadFile<BillList>(Path.Combine(path, billFileName));
        }
        public bool CreateBill(List<BillDetail> BillDetails)
        {
            var billId = billList.Bills.Max(b => b.BillId) + 1;
            Bill bill = new Bill();
            bill.BillId = billId;
            bill.Date = DateTime.Now;
            bill.IsPaid = false;
            bill.BillDetails = BillDetails;

            billList.Bills.Add(bill);
            FileHelper.WriteFile<BillList>(Path.Combine(path, billFileName), billList);
            return true;
        }
    }
}
