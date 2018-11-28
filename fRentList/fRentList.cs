using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DemoQuanLyThuVien.DAO;
namespace DemoQuanLyThuVien
{
    public partial class fRentList : Form
    {
        public fRentList()
        {
            InitializeComponent();
            loadRent();
        }

        private void mnfRentList_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void loadRent()
        {
            dataGridView1.DataSource = rentListDAO.Instance.loadUserlist();
        }
        
    }
}
