﻿using System;
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
    public partial class frmLogin : Form
    {
        //StreamReader FileReader = new StreamReader(location + "argus-SMALL.txt");

        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            //READ FILE            
            //local variables          
            string[] productData;
            string[] branchData;
            string[] categoryData;
            
            //set up StreamReader
            StreamReader reader = new StreamReader("argus-BIG.txt");

            //make reader start at beginning of file
            reader.DiscardBufferedData();
            reader.BaseStream.Seek(0, SeekOrigin.Begin);
            reader.BaseStream.Position = 0;

            while (!reader.EndOfStream)
            {
                //create array to hold data values
                branchData = new string[11];
              
                //get 11 lines of branch data file
                for (int i = 0; i < 11; i++)
                {
                    branchData[i] = reader.ReadLine();
                }
                
                //new instance of Branch Class
                Branch tempBranch = new Branch(branchData[0], branchData[1], branchData[2], 
                                                branchData[3], branchData[4], branchData[5], 
                                                    branchData[6], branchData[7], branchData[8], 
                                                        branchData[9], Convert.ToInt32(branchData[10]));
               
                //add branch to main arrayList                
                tempBranch.addBranchToMainArgus(tempBranch);

                for (int i = 0; i < Convert.ToInt32(tempBranch.getNoCategories()); i++)
                {
                    //create array to hold data values
                    categoryData = new string[3];

                    //get 3 lines of category data file
                    for (int j = 0; j < 3; j++)
                    {
                        categoryData[j] = reader.ReadLine();
                    }

                    //new instance of Category Class
                    Category tempCategory = new Category(Convert.ToInt32(categoryData[0]), categoryData[1], 
                                                            Convert.ToInt32(categoryData[2]));

                    //add category to Categories in branch arrayList
                    tempBranch.addCategoryToBranch(tempCategory);

                    for (int j = 0; j < Convert.ToInt32(tempCategory.getNoProduct()); j++)
                    {
                        //create array to hold data values
                        productData = new string[6];

                        //get 6 lines of category data file
                        for (int k = 0; k < 6; k++)
                        {
                            productData[k] = reader.ReadLine();
                        }

                        //new instance of Product Class
                        Product tempProduct = new Product(Convert.ToInt32(productData[0]), productData[1], productData[2],
                                                            productData[3], Convert.ToSingle(productData[4]), Convert.ToInt32(productData[5]));

                        //add product to productsincategory arraylist
                        tempCategory.addProduct(tempProduct);
                    }
                }
            }            
        }

        public bool branchIDcheck(string inBranchID)
        {
            bool validID = false;

            //Branch branch = new Branch();
            MainBranch main = new MainBranch();

            if (inBranchID != "")
            {
                MessageBox.Show("branches: " + main.mainArgus.Count);
                do
                {                    
                    foreach (Branch b in main.mainArgus)
                    {
                        if (inBranchID == b.getBranchID())
                            validID = true;
                    }
                } while (validID == false);
            }
            
            MessageBox.Show("valid" + Convert.ToString(validID));

            return validID;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {            
            bool valid = false;
            MainBranch MainBranch = new MainBranch();

            //get input from text field and pass it to login validation            
            valid = branchIDcheck(txtBranchID.Text);

            if (valid == true)
            {
                MainBranch.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid branch ID - please try again");
            }
        }

        private void txtBranchID_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
