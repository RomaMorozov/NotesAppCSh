using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotesAppCSh
{
    public partial class NotesApp : Form
    {
        DataTable notes = new DataTable();
        bool editing = false;
        public NotesApp()
        {
            InitializeComponent();
        }

        private void NotesApp_Load(object sender, EventArgs e)
        {
            notes.Columns.Add("Title");
            notes.Columns.Add("Note");

            notesTable.DataSource = notes;
        }


        private void newButton_Click(object sender, EventArgs e)
        {
            titleBox.Text = "";
            noteBox.Text = "";
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            titleBox.Text = notes.Rows[notesTable.CurrentCell.RowIndex].ItemArray[0].ToString();
            noteBox.Text = notes.Rows[notesTable.CurrentCell.RowIndex].ItemArray[1].ToString();
            editing = true;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                notes.Rows[notesTable.CurrentCell.RowIndex].Delete();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (editing)
            {
                notes.Rows[notesTable.CurrentCell.RowIndex]["Title"] = titleBox;
                notes.Rows[notesTable.CurrentCell.RowIndex]["Note"] = noteBox;
            }
            else
            {
                notes.Rows.Add(titleBox.Text, noteBox.Text);
            }
            titleBox.Text = "";
            noteBox.Text = "";
            editing = false;
        }

        private void notesTable_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            titleBox.Text = notes.Rows[notesTable.CurrentCell.RowIndex].ItemArray[0].ToString();
            noteBox.Text = notes.Rows[notesTable.CurrentCell.RowIndex].ItemArray[1].ToString();
            editing = true;
        }

    }
}
