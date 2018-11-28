using DemoQuanLyThuVien.DAO;
using DemoQuanLyThuVien.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DemoQuanLyThuVien
{
    public partial class fBookList : Form
    {
        BindingSource loadBook = new BindingSource();
        public fBookList()
        {
            InitializeComponent();
            load();
            AddBookBinding();
        }

        void load()
        {
            dtgvfBookList.DataSource = loadBook;
            LoadBookList();
            LoadCategoryBookIntoCombobox(cbBookListIdCategory);
        }
        void LoadBookList()
        {
            loadBook.DataSource = BookDAO.Instance.getBook();
        }
        void AddBookBinding()
        {
            //cbBookListIdCategory.DataBindings.Add();

            txtBookListId.DataBindings.Add(new Binding("Text", dtgvfBookList.DataSource, "id", true , DataSourceUpdateMode.Never));
            txtBookListName.DataBindings.Add(new Binding("Text", dtgvfBookList.DataSource, "name", true, DataSourceUpdateMode.Never));
            txtBookListYear.DataBindings.Add(new Binding("Text", dtgvfBookList.DataSource, "releaseYear", true, DataSourceUpdateMode.Never));
            txtSl.DataBindings.Add(new Binding("Text", dtgvfBookList.DataSource, "quantity", true, DataSourceUpdateMode.Never));
            txtBookListAuthor.DataBindings.Add(new Binding("Text", dtgvfBookList.DataSource, "nameAuthor", true, DataSourceUpdateMode.Never));
            txtBookListNameNXB.DataBindings.Add(new Binding("Text", dtgvfBookList.DataSource, "nameNXB", true, DataSourceUpdateMode.Never));
            nbfBookListPrice.DataBindings.Add(new Binding("Value", dtgvfBookList.DataSource, "price", true, DataSourceUpdateMode.Never));
            txtPic.DataBindings.Add(new Binding("Text", dtgvfBookList.DataSource, "Pic", true, DataSourceUpdateMode.Never));
        }
        void  LoadCategoryBookIntoCombobox(ComboBox cb)
        {
            cb.DataSource = CategoryDAO.Instance.GetListCategory();
            cb.DisplayMember = "name";
        }

        private void txtBookListId_TextChanged(object sender, EventArgs e)
        {

            if (dtgvfBookList.SelectedCells.Count > 0)
            {
                int id = (int)dtgvfBookList.SelectedCells[0].OwningRow.Cells["idCategory"].Value;

                Category category = CategoryDAO.Instance.GetListCategoryId(id);

                cbBookListIdCategory.SelectedItem = category;

                int index = -1;
                int i = 0;

                foreach (Category item in cbBookListIdCategory.Items)
                {
                    if (item.id == category.id)
                    {
                        index = i;
                        break;
                    }
                    i++;
                }
                cbBookListIdCategory.SelectedIndex = index;
            }
        }

        private void btfBookListRefresh_Click(object sender, EventArgs e)
        {
            loadBook.DataSource = BookDAO.Instance.getBook();
        }

        private void btfBookListAdd_Click(object sender, EventArgs e)
        {
            string name = txtBookListName.Text;
            int cateId = (cbBookListIdCategory.SelectedItem as Category).id;
            int yearrl = int.Parse(txtBookListYear.Text);
            int SL = int.Parse(txtSl.Text);
            string nameAuthor = txtBookListAuthor.Text;
            string nameNXB = txtBookListNameNXB.Text;
            float price = (float)nbfBookListPrice.Value;
            string Pic = txtPic.Text;
            //int cateId, string name, int SL , int yearrl, string nameAuthor, string nameNXB, float price , string Pic
            if (BookDAO.Instance.InsertBook(cateId, name, SL, yearrl, nameAuthor, nameNXB, price, Pic))
            {
                MessageBox.Show("Đã thêm");
                load();
            }
            else
            {
                MessageBox.Show("Không thành công", "Thông báo");
            }
        }

        private void btfBookListChange_Click(object sender, EventArgs e)
        {
            string name = txtBookListName.Text;
            int cateId = /*Convert.ToInt32( txtBookListId.Text)*/(cbBookListIdCategory.SelectedItem as Category).id;
            int yearrl = int.Parse(txtBookListYear.Text);
            int SL = int.Parse(txtSl.Text);
            string nameAuthor = txtBookListAuthor.Text;
            string nameNXB = txtBookListNameNXB.Text;
            float price = (float)nbfBookListPrice.Value;
            int idBook = int.Parse(txtBookListId.Text);// convert.toint32(a.text)
            string Pic = txtPic.Text;
            //MessageBox.Show(idBook.ToString());
            //int idBook, int cateId, string name, int SL, int yearrl, string nameAuthor, string nameNXB, float price, string Pic
            if (BookDAO.Instance.UpdateBook(idBook, cateId, name, SL, yearrl, nameAuthor, nameNXB, price, Pic))
            {
                MessageBox.Show("Đã sửa");
                load();
            }
            else
            {
                MessageBox.Show("Không thành công", "Thông báo");
            }
        }

        private void btfBookListDelete_Click(object sender, EventArgs e)
        {
            int idBook = int.Parse(txtBookListId.Text);

            if (BookDAO.Instance.DeleteBookById(idBook))
            {
                /*if(*/MessageBox.Show("OK", "asd", MessageBoxButtons.OKCancel); /*!= System.Windows.Forms.DialogResult.OK)*/
                /*{
                    
                }*/
                load();
            }
            else
            {
                MessageBox.Show("RIP", "Thông báo");
            }
        }

        private void mnfRentList_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //private event EventHandler updateBook;
        //public event EventHandler UpdateBook
        //{
        //    add { updateBook += value; }
        //    remove { updateBook -= value; }
        //}
    }
}
