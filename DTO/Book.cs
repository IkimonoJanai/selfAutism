using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DemoQuanLyThuVien.DTO
{
    public class Book
    {
        public int id { get; set; }
        public string name { get; set; }
        public int idCategory { get; set; }
        public int quantity { get; set; }
        public int releaseYear { get; set; }
        public string nameAuthor { get; set; }
        public string nameNXB { get; set; }
        public float price { get; set; }
        public string Pic { get; set; }

        public Book(int id, string name, int idCategory, int quantity, int releaseYear, string nameAuthor, string nameNXB, float price, string Pic)
        {
            this.id = id;
            this.name = name;
            this.idCategory = idCategory;
            this.quantity = quantity;
            this.releaseYear = releaseYear;
            this.nameAuthor = nameAuthor;
            this.nameNXB = nameNXB;
            this.price = price;
            this.Pic = Pic;
        }

        public Book(DataRow row)
        {
            this.id = (int)row["id"];
            this.name = row["name"].ToString();
            this.idCategory = (int)row["idCategory"];
            this.quantity = (int)row["quantity"];
            this.releaseYear = (int)row["releaseYear"];
            this.nameAuthor = row["nameAuthor"].ToString();
            this.nameNXB = row["nameNXB"].ToString();
            this.price = (float)Convert.ToDouble(row["price"].ToString());
            this.Pic = row["bookPic"].ToString();
        }



    }
}
