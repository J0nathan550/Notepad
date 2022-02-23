using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Notepad
{
    public partial class Form1 : Form
    {
        //Dialogs
        private OpenFileDialog openFileDialog;
        private SaveFileDialog savefileDialog;
        private FontDialog fontDialog;
        private ColorDialog colorDialog;

        public Form1()
        {
            InitializeComponent();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        // create new file
        private void NewFile()
        {
            if (string.IsNullOrEmpty(this.richTextBox1.Text))
            {
                MessageBox.Show("You need save file first.");
            }
            else
            {
                this.richTextBox1.Text = string.Empty;
                this.Text = "Simple Notepad - Untitled";
            }
        }

        private void SaveFile()
        {
            savefileDialog.Filter = "Untitled File Text (*.txt) | *.txt";
            if (savefileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(savefileDialog.FileName, this.richTextBox1.Text);
                this.Text = savefileDialog.FileName;
            }
        }

        private void OpenFile()
        {
            OpenFileDialog openfileDialog = new OpenFileDialog();
            if (openfileDialog.ShowDialog() == DialogResult.OK)
            {
                this.richTextBox1.Text = File.ReadAllText(openfileDialog.FileName);
                this.Text = openfileDialog.FileName;
            }

        }

        private void SaveFileAs()
        {
            if (!string.IsNullOrEmpty(this.richTextBox1.Text))
            {
                savefileDialog = new SaveFileDialog();
                savefileDialog.Filter = "All Files (*.*)| *.*";
                if (savefileDialog.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(savefileDialog.FileName, this.richTextBox1.Text);
                    this.Text = savefileDialog.FileName;
                }
            }
            else
            {
                MessageBox.Show("The File is empty!");
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e) // new
        {
            NewFile();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e) // open
        {
            OpenFile();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e) // save
        {
            SaveFile();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e) // save as
        {
            SaveFileAs();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) // exit
        {
            DialogResult dialog = MessageBox.Show("Are you sure that you want exit from application? \nAll progress will lost.", "Warning", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                return;
            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e) // font
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            fontDialog = new FontDialog();
            colorDialog = new ColorDialog();
            savefileDialog = new SaveFileDialog();
            openFileDialog = new OpenFileDialog();
        }

        private void unitedProgrammingServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://discord.gg/zymVckwshh");
        }

        private void themeToolStripMenuItem_Click(object sender, EventArgs e) // theme
        {
        }

        private void fontToolStripMenuItem1_Click(object sender, EventArgs e) // main font
        {
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                this.richTextBox1.Font = fontDialog.Font;
            }
        }

        private void foregroundColorToolStripMenuItem_Click(object sender, EventArgs e) // foreground color
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                this.richTextBox1.ForeColor = colorDialog.Color;
            }
        }

        private void backgroundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                this.richTextBox1.BackColor = colorDialog.Color;
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e) // copy
        {
            this.richTextBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e) // paste
        {
            this.richTextBox1.Paste();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e) // select all
        {
            this.richTextBox1.SelectAll();
        }

        private void findToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            textBox1.Visible = true;
            button1.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.richTextBox1.Find(textBox1.Text);
            textBox1.Visible = false;
            button1.Visible = false;
        }
    }
}