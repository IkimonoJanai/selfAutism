using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoQuanLyThuVien.DTO
{
    public class BookStorage
    {
        public int id { get; set; }
        public int idStorage { get; set; }

        public BookStorage(int id , int idStorage)
        {
            this.id = id;
            this.idStorage = idStorage;
        }

    }
}
