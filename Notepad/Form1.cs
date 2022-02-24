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
        public Form1()
        {
            InitializeComponent();
            fontDialog1.ShowColor = true;
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(textBox1.TextLength != 0)
            {
              DialogResult res = MessageBox.Show("Найден текст.Сохранить?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(res == DialogResult.Yes)
                {
                    
                    SaveFileDialog save = new SaveFileDialog();
                    save.FileName = "Новый файл";
                    save.Filter = "Тесктовый файл|*.txt";
                    if(save.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(save.FileName, textBox1.Text);
                    }

                }
                if (res == DialogResult.No)
                {
                    textBox1.Clear();
                }
            }
            
        }

        private void шрифтToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.Cancel)
                return;

            textBox1.Font = fontDialog1.Font;
            textBox1.ForeColor = fontDialog1.Color;
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;

            string filename = openFileDialog1.FileName;

            string fileText = System.IO.File.ReadAllText(filename);
            textBox1.Text = fileText;
            MessageBox.Show("Файл открыт");
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = saveFileDialog1.FileName;
            File.WriteAllText(filename, textBox1.Text);
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Хорошая программа");
        }

        private void переносСтрокиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (переносСтрокиToolStripMenuItem.Checked)
            {
                textBox1.WordWrap = true;
                textBox1.ScrollBars = ScrollBars.Vertical;

            }
            else
            {
                textBox1.WordWrap = false;
                textBox1.ScrollBars = ScrollBars.Both;
            }
        }
    }
}
