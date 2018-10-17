using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo.MainMenu
{
    public partial class MainForm : Form
    {
        string fileName;
        string fileExtention; 
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Загрузка файлов разных форматов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            openFileDialog.DefaultExt = "txt";
            openFileDialog.Filter = "All Files (*.*)|*.*|Text files (*.txt)|*.txt |RTF (*.rtf) |*.rtf";
            openFileDialog.FilterIndex = 3;
           

            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                fileName = openFileDialog.FileName;
                fileExtention = GetFileExtention(fileName);
                RichTextBoxStreamType textType = RichTextBoxStreamType.PlainText;

                switch (openFileDialog.FilterIndex)
                {

                    case 0:
                    case 1:

                        if (GetFileExtention(openFileDialog.FileName) == "rtf")
                        {
                            textType = RichTextBoxStreamType.RichText;
                        }
                        break;
                    case 2:
                        break;
                    case 3:
                        textType = RichTextBoxStreamType.RichText;
                        break;
                }
                richTextBox1.LoadFile(openFileDialog.FileName, textType);
                
            }
        }
        
        /// <summary>
        /// Сохранить текущие изменения в файле
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
           if (String.IsNullOrEmpty(fileName))
            {
                saveAsToolStripMenuItem_Click(sender, e);
                return;
            }

            RichTextBoxStreamType textType = RichTextBoxStreamType.PlainText;

            if (GetFileExtention(fileName) == "rtf")
            {
                textType = RichTextBoxStreamType.RichText;
            }

         richTextBox1.SaveFile(fileName, textType);


        }
        /// <summary>
        /// Сохранить текст как...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.DefaultExt = "txt";
            saveFileDialog.Filter = "All Files (*.*)|*.*|Text files (*.txt)|*.txt |RTF (*.rtf) |*.rtf";
            saveFileDialog.FilterIndex = 3;

            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                
                RichTextBoxStreamType textType = RichTextBoxStreamType.PlainText;

                switch (saveFileDialog.FilterIndex)
                {

                    case 0:
                    case 1:
                        
                        if (GetFileExtention(openFileDialog.FileName) == "rtf")
                        {
                            textType = RichTextBoxStreamType.RichText;
                        }
                        break;
                    case 2:
                        break;
                    case 3:
                        textType = RichTextBoxStreamType.RichText;
                        break;
                }
                richTextBox1.SaveFile(saveFileDialog.FileName, textType);
            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog.Font = richTextBox1.Font;
            if (fontDialog.ShowDialog(this) == DialogResult.OK)
            {
                richTextBox1.Font = fontDialog.Font;
            }
        }
        /// <summary>
        /// Метод выделяющий расширение файла
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private static string GetFileExtention(string fileName)
        {
            string format = "";
            for (int i = fileName.Length - 1; i > 0; --i)
            {
                if (fileName[i] == '.')
                {
                    break;
                }
                format = fileName[i] + format;
            }
            format = format.ToLower();

            return format;
        }
        /// <summary>
        /// Выбор полужирного шрифта для вделенного текста
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Font of = richTextBox1.SelectionFont;

            richTextBox1.SelectionFont = new Font(of, of.Style ^ FontStyle.Bold);
            
        }

        private void fontDialog_Apply(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Выбор курсива для вделенного текста
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Font of = richTextBox1.SelectionFont;

            richTextBox1.SelectionFont = new Font(of, of.Style ^ FontStyle.Italic);
        }
        /// <summary>
        /// Выбор подчеркнутого шрифта для вделенного текста
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Font of = richTextBox1.SelectionFont;

            richTextBox1.SelectionFont = new Font(of, of.Style ^ FontStyle.Underline);
        }
        /// <summary>
        /// Вызов редактора изменения параметров шрифта
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (fontDialog.ShowDialog(this) == DialogResult.OK)
            {
                richTextBox1.SelectionFont = fontDialog.Font;
            }
        }
        /// <summary>
        /// Изменение цвета текста
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog(this) == DialogResult.OK)
            {
                richTextBox1.SelectionColor = colorDialog1.Color;
            }
        }

        private void toolStripContainer1_TopToolStripPanel_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Смещение текста влево
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
        }
        /// <summary>
        /// Размещение текста по центру
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
        }
        /// <summary>
        /// Смещение текста вправо
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
        }
        /// <summary>
        /// Изменение цвета фона текста
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog(this) == DialogResult.OK)
            {
                richTextBox1.SelectionBackColor = colorDialog1.Color;
            }
        }
    }
}
