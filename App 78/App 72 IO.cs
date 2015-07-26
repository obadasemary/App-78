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

namespace App_78
{
    public partial class App_72_IO : Form
    {

        static string fName = "D:\\t.txt";
        FileInfo myFile = new FileInfo(fName);
        public App_72_IO()
        {
            InitializeComponent();

           
            //Directory
            foreach (string file in Directory.GetFiles("D:\\Photo\\\\خطوبتي انا وسارة"))
            {
                listBox1.Items.Add(file);
            }
            //DirectoryInfo
            DirectoryInfo DI = new DirectoryInfo("D:\\Photo\\\\خطوبتي انا وسارة");
            foreach (FileInfo file in DI.GetFiles())
            {
                listBox2.Items.Add(file.Name);
            }

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DriveInfo dI = new DriveInfo("C:");
            double Total = dI.TotalSize;
            double FreeSpace = dI.AvailableFreeSpace;

            double Result = FreeSpace / Total * 100;
            MessageBox.Show("Free Space in C: Drive is : " + Result + "%");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DriveInfo dI = new DriveInfo("D:");
            double Total = dI.TotalSize;
            double FreeSpace = dI.AvailableFreeSpace;

            double Result = FreeSpace / Total * 100;
            MessageBox.Show("Free Space in D: Drive is : " + Result + "%");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string fn = "D:\\t.txt";
            if (File.Exists(fn))
            {
                //richTextBox1.Lines = File.ReadAllLines(fn);
                richTextBox1.Text = File.ReadAllText(fn);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string fn = "D:\\t.txt";
            File.WriteAllText(fn, richTextBox1.Text);
            File.WriteAllLines(fn, richTextBox1.Lines);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            myFile.MoveTo("D:\\t2.txt");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            myFile.CopyTo("D:\\t3.txt",true);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            myFile.Delete();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("D:\\test.txt", FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(fs);
            sw.Write(richTextBox2.Text);
            sw.Close();
            richTextBox2.Clear();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //Stream:
            //FileStream
            //NetworkStream
            //MemoryStream

            FileStream fs = new FileStream("D:\\test.txt", FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fs);
            richTextBox2.Text = sr.ReadToEnd();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string file1 = "D:\\OK.JPG";

            string file2 = "D:\\OK3.JPG";

            FileStream fs1 = new FileStream(file1, FileMode.Open);
            FileStream fs2 = new FileStream(file2, FileMode.Create);

            BinaryReader br = new BinaryReader(fs1);
            BinaryWriter bw = new BinaryWriter(fs2);

            for (int i = 0; i <= br.BaseStream.Length - 1; i++)
            {
                bw.Write(br.ReadByte());
            }
            MessageBox.Show("Done");
            br.Close();
            bw.Close();

        }
    }
}
