using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace coursework_GUI
{
    public partial class Form1 : Form
    {
        int iterationCount;
        public Form1()
        {
            InitializeComponent();

        }
        //Method for linear search through list box
        private int linearSearch(int n)
        {
            iterationCount = 0;
            string number = n.ToString();
            for (int i = 0; i < lstIntVals.Items.Count; i++)
            {
                iterationCount = iterationCount + 1;
                txtIterations.Text = iterationCount.ToString();
                string currentNum = lstIntVals.Items[i].ToString();
                if (number == currentNum)
                {
                    int numFound = int.Parse(currentNum);
                    lstIntVals.SelectedIndex = i;
                    return numFound;
                }
            }
            txtIterations.Text = iterationCount.ToString();
            return -1;
        }
        //Method for linear search through list box to find index placement
        private int linearPlacementSearch(int n)
        {
            iterationCount = 0;
            for (int i = 0; i < lstIntVals.Items.Count; i++)
            {
                iterationCount = iterationCount + 1;
                string currentNumString = lstIntVals.Items[i].ToString();
                int currentNumInt = int.Parse(currentNumString);
                if (currentNumInt > n)
                {
                    return i;
                }
            }
            txtIterations.Text = iterationCount.ToString();
            return lstIntVals.Items.Count;
        }
        //Method for inserting at a particular position (sorted listbox)
        private int insertAtPosition(int insertPlacement)
        {
            string newEntry = txtInp.Text;
            lstIntVals.Items.Add("");
            for (int i = lstIntVals.Items.Count-1; i >= insertPlacement; i--)
            {
                iterationCount = iterationCount + 1;
                if (i != insertPlacement)
                {
                lstIntVals.Items[i] = lstIntVals.Items[i - 1];
                }
                else
                {
                    lstIntVals.Items[i] = newEntry;
                }

            }
            txtIterations.Text = iterationCount.ToString();
            return 1;
        }
        //Method for binary searching the listbox
        private int binarySearch(int n)
        {
            iterationCount = 0;
            int lowerBound = 0;
            int upperBound = lstIntVals.Items.Count - 1;
            while (lowerBound <= upperBound)
            {
                iterationCount = iterationCount + 1;
                txtIterations.Text = iterationCount.ToString();
             int mid = (lowerBound + upperBound) / 2;
              if (lstIntVals.Items[mid].ToString() == n.ToString())
                {
                    lstIntVals.SelectedIndex = mid;
                    return n;
                }
                string midPointValue = lstIntVals.Items[mid].ToString();
               if (int.Parse(midPointValue) > n)
                {
                    upperBound = (mid-1);
                }
                else
                {
                    lowerBound = (mid+1);
                }
            }
            txtIterations.Text = iterationCount.ToString();
            return -1;
        }
        //Method for bubbleSorting the listbox
        private void bubbleSort()
        {
            iterationCount = 0;
            int n = Convert.ToInt32(lstIntVals.Items.Count);
            int temp = Convert.ToInt32(lstIntVals.Items.Count);
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    iterationCount = iterationCount + 1;
                    if (Convert.ToInt32(lstIntVals.Items[i]) > Convert.ToInt32(lstIntVals.Items[j]))
                    {
                        temp = Convert.ToInt32(lstIntVals.Items[i]);
                        (lstIntVals.Items[i]) = Convert.ToInt32(lstIntVals.Items[j]);
                        (lstIntVals.Items[j]) = temp;

                    }
                }
            }
            radBinary.Enabled = true;
            radUnsorted.Enabled = false;
            txtIterations.Text = iterationCount.ToString();
        }
        //Method for loading the form and allowing drag drop features
        private void Form1_Load(object sender, EventArgs e)
        {
            lstIntVals.AllowDrop = true;
            pctBxBin.AllowDrop = true;

        }
        //Method for insert button being clicked
        private void btnIns_Click(object sender, EventArgs e)
        {
         int numIns;
            if(int.TryParse(txtInp.Text, out numIns))
            {
                if (lstIntVals.Items.Count < 30)
                {
                    if (numIns > 100 || numIns < 1)
                    {
                        string BoundsError = "The number inserted does not fit the bounds of 1<>100";
                        MessageBox.Show(BoundsError);
                    }

                    else if (radUnsorted.Checked)
                     {
                    if (linearSearch(numIns) == numIns)
                    {
                        txtInp.Text = "";
                        string duplicateError = "Number already exists in list box, please choose another!";
                        MessageBox.Show(duplicateError);
                    }
                        else
                        {
                            lstIntVals.Items.Add(numIns);
                            txtCountNum.Text = lstIntVals.Items.Count.ToString();
                        }
                   }
                    else
                    {
                       int insertPlacement = linearPlacementSearch(int.Parse(txtInp.Text));
                        insertAtPosition(insertPlacement);
                        txtCountNum.Text = lstIntVals.Items.Count.ToString();
                    }
                }
                else
                {
                    string txtTooManyIntsMessage = "No more than 30 entries please.";
                    MessageBox.Show(txtTooManyIntsMessage);
                }
            }
            else
            {
                txtInp.Text = "";
                string onlyIntsMessage = "Please only enter Integers.";
                MessageBox.Show(onlyIntsMessage);
            }
        }
        //Method for search button being clicked
        private void btnSearch_Click(object sender, EventArgs e)
        {
            int numInpSearch;
            if (int.TryParse(txtInpNumS.Text, out numInpSearch))
            {
                if (int.Parse(txtInpNumS.Text) > 100 || int.Parse(txtInpNumS.Text) < 1)
                {
                    string errorMessage = "The number searched for does not fit the parameters of being 1<>100";
                    MessageBox.Show(errorMessage);
                }
                if (radBinary.Checked)
                {
                    if(binarySearch(numInpSearch) == -1)
                    {
                        string errorMessage = "The number searched for does not exist in the list box";
                        MessageBox.Show(errorMessage);
                    }
                }
                else
                {
                    if(linearSearch(numInpSearch) == -1)
                    {
                    string errorMessage = "The number searched for does not exist in the list box";
                    MessageBox.Show(errorMessage);
                    }
                }
            }
            else
            {
                txtInpNumS.Text = "";
                string message = "Please only Search for Integers.";
                MessageBox.Show(message);
            }
        }
        //Method for initialise button beign clicked
        private void btnInit_Click(object sender, EventArgs e)
        {
            clearList();
            Random rnd = new Random();
            for (int i = 0; i < 30; i++)
            {
                bool uniqueNum = false;
                while (uniqueNum == false)
                {
                    string newItem = Convert.ToString(rnd.Next(1, 101));
                    if (linearSearch(int.Parse(newItem)) == -1)
                    {
                        uniqueNum = true;
                        lstIntVals.Items.Add(newItem);
                    }
                }
            }
            radUnsorted.Enabled = true;
            radUnsorted.Checked = true;
            radSorted.Checked = false;
            radBinary.Enabled = false;
            radBinary.Checked = false;
            txtCountNum.Text = lstIntVals.Items.Count.ToString();
            txtFirstNum.Text = lstIntVals.Items[0].ToString();
            txtIterations.Text = iterationCount.ToString();
        }
        //Method for delete button being clicked
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (lstIntVals.SelectedIndex > -1)
            {
            int indexToDelete = lstIntVals.SelectedIndex;
            deleteNumber(indexToDelete);
            }
        }
        //Method for value of count text box changing
        private void txtCountNum_TextChanged(object sender, EventArgs e)
        {
            if (lstIntVals.Items.Count > 0)
            {
                btnDel.Enabled = true;
            }
            else
            {
                btnDel.Enabled = false;
            }

            if (lstIntVals.Items.Count > 0)
            {
                btnSearch.Enabled = true;
            }
            else
            {
                btnSearch.Enabled = false;
            }

            if (lstIntVals.Items.Count > 0)
            {
                btnClear.Enabled = true;
            }
            else
            {
                btnClear.Enabled = false;
            }
            if (lstIntVals.Items.Count > 0)
            {
                txtInpNumS.Enabled = true;
            }
            else
            {
                txtInpNumS.Enabled = false;
            }
            if (lstIntVals.Items.Count > 0)
            {
                btnShufffle.Enabled = true;
            }
            else
            {
                btnShufffle.Enabled = false;
            }
            if (lstIntVals.Items.Count != 0)
            {
                txtFirstNum.Text = lstIntVals.Items[0].ToString();
            }
            else txtFirstNum.Text = "";
        }
        //Method for what happens when item is dropped onto picture box
        private void pctBxBin_DragDrop(object sender, DragEventArgs e)
        {
            int indexToDelete = lstIntVals.SelectedIndex;
            deleteNumber(indexToDelete);
        }
        //Method for what happens when mouse down of list box
        private void lstIntVals_MouseDown(object sender, MouseEventArgs e)
        {
            if (lstIntVals.Items.Count > 0)
            {
                lstIntVals.DoDragDrop(lstIntVals.Text, DragDropEffects.Move);
            }
        }
        //Method for when clear button is clicked
        private void btnClear_Click(object sender, EventArgs e)
        {
            clearList();
        }
        //Method for clearing the list
        private void clearList()
        {
            for (int i = lstIntVals.Items.Count - 1; i >= 0; i--)
            {
                deleteNumber(i);
            }
        }
        //Method for setting the list to sorted
        private void radSorted_CheckedChanged(object sender, EventArgs e)
        {
            if (radSorted.Checked)
            {
                bubbleSort();
            }
        }
        //Method for shuffling the list
        private void btnShufffle_Click(object sender, EventArgs e)
        {
            iterationCount = 0;
            Random rnd = new Random();
            for (int i = 0; i < 50; i++)
            {
                iterationCount = iterationCount + 1;
                string temp;
                int index1 = rnd.Next(0, (lstIntVals.Items.Count));
                int index2 = rnd.Next(0, (lstIntVals.Items.Count));
                temp = lstIntVals.Items[index1].ToString();
                lstIntVals.Items[index1] = lstIntVals.Items[index2];
                lstIntVals.Items[index2] = temp;
            }
            radUnsorted.Checked = true;
            radBinary.Enabled = false;
            radLinear.Checked = true;
            radUnsorted.Enabled = true;
            txtIterations.Text = iterationCount.ToString();
        }
        //Method for Exiting the program
        private void btnExit_Click(object sender, EventArgs e)
        {
            string doYouWantToLeaveMessage = "Are you sure that you would like to close the form?";
           DialogResult decision = MessageBox.Show(doYouWantToLeaveMessage, "Closing Form", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (decision == DialogResult.Yes)
            {
            System.Windows.Forms.Application.Exit();
            }
        }
        //Method for Hovering over the picture box with an item
        private void pctBxBin_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }
        //Method for Deleting a number
        private void deleteNumber (int indexToDelete)
        {
            iterationCount = 0;
            for (int i = indexToDelete; i < (lstIntVals.Items.Count - 1); i++)
            {
                iterationCount = iterationCount + 1;
                lstIntVals.Items[i] = lstIntVals.Items[i + 1];
            }
            lstIntVals.Items.RemoveAt(lstIntVals.Items.Count - 1);
            txtCountNum.Text = lstIntVals.Items.Count.ToString();
            if (lstIntVals.Items.Count == 0)
            {
                btnDel.Enabled = false;
                return;
            }
            txtIterations.Text = iterationCount.ToString();
        }
    }
}
