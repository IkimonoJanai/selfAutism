using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DemoQuanLyThuVien.DTO
{
    public class rentList // rentPay
    {
        public int id { get; set; }
        public int idBook { get; set; }
        public int idStudent { get; set; }
        public int idNhanVien { get; set; }
        public int SLbook { get; set; }
        public string DateRent { get; set; }
        public string DateRentPay { get; set; }
        public string status { get; set; }

        public rentList(int id, int idBook ,int idStudent ,int idNhanVien , int SLbook , string DateRent,string DateRentPay, string status )
        {
            this.id = id;
            this.idBook = idBook;
            this.idStudent = idStudent;
            this.idNhanVien = idNhanVien;
            this.SLbook = SLbook;
            this.DateRent = DateRent;
            this.DateRentPay = DateRentPay;
            this.status = status;
        }
        public rentList(DataRow row)
        {
            this.id = (int)row["id"];
            this.idBook = (int)row["idBook"];
            this.idStudent = (int)row["idStudent"];
            this.idNhanVien = (int)row["idNhanVien"];
            this.SLbook = (int)row["SLbook"];
            this.DateRent = row["DateRent"].ToString();
            this.DateRentPay = row["DateRentPay"].ToString();
            this.status = row["status"].ToString();
        }
    }
}
