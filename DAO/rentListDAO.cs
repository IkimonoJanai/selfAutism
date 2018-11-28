using DemoQuanLyThuVien.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DemoQuanLyThuVien.DAO
{
    public class rentListDAO
    {
        private static rentListDAO instance;

        public static rentListDAO Instance
        {
            get { if (instance == null) instance = new rentListDAO(); return rentListDAO.instance; }
            private set { rentListDAO.instance = value; }
        }
        public rentListDAO() { }

        public List<rentList> loadUserlist()
        {
            List<rentList> list= new List<rentList>();


            DataTable data = new DataTable();
            string sql = "SELECT * FROM Rent";
            data = DataProvider.Instance.ExecuteQuery(sql);


            foreach (DataRow item in data.Rows)
            {
                rentList rent = new rentList(item);
                list.Add(rent);
            }
            return list;
        }
    }
}
