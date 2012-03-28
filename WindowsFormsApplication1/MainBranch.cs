using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class MainBranch : Form
    {

        public ArrayList mainArgus = new ArrayList();
        
        public MainBranch()
        {
            InitializeComponent();
        }

        private void EditCatergoryBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Catergory ID, Name and Number of products displays in this popup");
        }

        private void BranchEditBtn_Click(object sender, EventArgs e)
        {
            frmBranchDetails BranchDetails = new frmBranchDetails();          
            BranchDetails.Show();
            this.Hide();
        }

        private void AddProduct_Click(object sender, EventArgs e)
        {
            ProductDetails ProductDetails = new ProductDetails();
            ProductDetails.Show();
            this.Hide();
            //need to find away to make the ID number become visible
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Product has been deleted from the file");
        }

        private void ProductInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ProductDetails ProductDetails = new ProductDetails();
            ProductDetails.Show();
            this.Hide();
        }

        private void AddCatergoryBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Catergory has been added to Branch");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Catergory has been removed from Branch");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This will search for product matches");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This will display the full catergory details in the message box.");
        }

        private void MainBranch_Load(object sender, EventArgs e)
        {

        }
    }
}
