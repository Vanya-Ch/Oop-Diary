using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ООП_курсова
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        DataTable diary = new DataTable();
        bool isEditing = false;

        private void Form1_Load(object sender, EventArgs e)
        {
            // Create columns
            diary.Columns.Add("Title");
            diary.Columns.Add("Description");

            // point our datagridview to our datasource
            diaryView.DataSource = diary;
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            titleTextBox.Text = "";
            descriptionTextBox.Text = "";
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            isEditing = true;
            // fill text fields with data from table
            titleTextBox.Text = diary.Rows[diaryView.CurrentCell.RowIndex].ItemArray[0].ToString();
            descriptionTextBox.Text = diary.Rows[diaryView.CurrentCell.RowIndex].ItemArray[1].ToString();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                diary.Rows[diaryView.CurrentCell.RowIndex].Delete();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error :" + ex);
            }
        }

        private void saveButtoon_Click(object sender, EventArgs e)
        {
            if (isEditing)
            {
                diary.Rows[diaryView.CurrentCell.RowIndex]["Title"] = titleTextBox.Text;
                diary.Rows[diaryView.CurrentCell.RowIndex]["Description"] = descriptionTextBox.Text;
            }
            else
            {
                diary.Rows.Add(titleTextBox.Text, descriptionTextBox.Text);
            }
            // Clear fields
            titleTextBox.Text = "";
            descriptionTextBox.Text = "";
            isEditing = false;
        }
    }
}
