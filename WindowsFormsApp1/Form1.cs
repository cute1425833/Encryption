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


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        
        }
        string zz;
        char[] a = { ' ' };
        FileInfo fileinfo;
        private void button2_Click(object sender, EventArgs e)
            
        {
            textBox5.Text = "";
           


            lock_p = "";

            if (textBox1.Text == "")
                MessageBox.Show("原始資料請勿空白");
            else
            {
                

                byte[] bytes = new byte[2];

                int f;
                string x;
                x = "";
                for (f = 0; f < textBox1.Text.Length; f++)
                {
                    bytes = Encoding.Unicode.GetBytes(textBox1.Text.Substring(f, 1));
                    if (String.Format("{0:X}", bytes[1]).Length < 2)
                    {
                        x = "0" + String.Format("{0:X}", bytes[1]);
                    }
                    else x = String.Format("{0:X}", bytes[1]);


                    if (String.Format("{0:X}", bytes[0]).Length < 2)
                    {
                        x += "0" + String.Format("{0:X}", bytes[0]);
                    }
                    else x += String.Format("{0:X}", bytes[0]);


                    lock_p += x + " ";
                    
                   

                }


            }
           
            string za="";
            if (textBox2.Text == "")
                MessageBox.Show("加密條件請勿空白!!");
            else
            {
                zz = "";
                
                string[] b = lock_p.Trim().Split(a);

                for (int i = 0; i < b.Length; i++)
                {
                    for (int j = 0; j < b[i].Length; j++)
                    {

                    
                            za = (Convert.ToInt32((ASC(b[i].Substring(j, 1)).ToString())) + Convert.ToInt32(textBox2.Text)).ToString();
                            zz += za + " ";
                  
                    
                    
                    
                    
                    }
                }
               textBox5.Text = zz;
                
            }
           



        }
       
        
        string lock_p ;
        string end;
        private void button3_Click(object sender, EventArgs e)
        {
            if(textBox3.Text=="")
            { MessageBox.Show("待解密資料請勿空白"); }
            else if ( textBox4.Text == "")
            {
                MessageBox.Show("解碼條件請勿空白");
            }
            else
            {
               textBox6.Text = "";
                string uni = "";
                char[] a = { ' ' };
                string[] b = textBox3.Text.Trim().Split(a);
                int g = 0;
                for (int i = 0; i < b.Length; i++)
                {
                    end = (Convert.ToInt32(b[i]) - Convert.ToInt32(textBox4.Text)).ToString();
                    uni += Chr(Convert.ToInt32(end));
                    g += 1;
                    if (g == 4)
                    {
                        uni += " ";
                        g = 0;
                    }
                }



                byte[] bytes = new byte[2];
                string[] c = uni.Trim().Split(a);


                for (int j = 0; j < c.Length; j++)
                {

                    bytes[1] = Convert.ToByte(c[j].Substring(0, 2), 16);
                    bytes[0] = Convert.ToByte(c[j].Substring(2, 2), 16);
                    string result = Encoding.Unicode.GetString(bytes);

                   textBox6.Text += result;
                }

            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            if(this.加密ToolStripMenuItem.Checked=true)
            {
                label8.Visible = false;
                textBox6.Visible = false;
                button3.Visible = false; 
                label1.Visible = false;
                textBox3.Visible = false;
                label5.Visible = false;
                textBox4.Visible = false;
                mod = 1;
            }
            else
            {
                label7.Visible = false;
                textBox5.Visible = false;
                label4.Visible = false;
                textBox1.Visible = false;
                label6.Visible = false;
                textBox2.Visible = false;
                button2.Visible = false;
                label8.Visible = true;
               textBox6.Visible = true;
                button3.Visible = true;
                label1.Visible = true;
                textBox3.Visible = true;
                label5.Visible = true;
                textBox4.Visible = true;
                mod = 2;
            }
        }


        public static char Chr(int Num)

        {

            char C = Convert.ToChar(Num);

            return C;

        }



        public static int ASC(string S)

        {

            int N = Convert.ToInt32(S[0]);

            return N;

        }



        public static int ASC(char C)

        {

            int N = Convert.ToInt32(C);

            return N;

        }
        int mod=0;
        private void 加密ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(this.加密ToolStripMenuItem.Checked=true)
            { this.解碼ToolStripMenuItem.Checked = false;
                label8.Visible = false;
                textBox6.Visible = false;
                button3.Visible = false;
                label1.Visible = false;
                textBox3.Visible = false;
                label7.Visible = true;
                textBox5.Visible = true;
                label4.Visible = true;
                textBox1.Visible = true;
                label6.Visible = true;
                textBox2.Visible = true;
                button2.Visible = true;
                label5.Visible = false;
                textBox4.Visible =false;
                mod = 1;
            }
            else
            { this.解碼ToolStripMenuItem.Checked = true; }
        }

        private void 解碼ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.解碼ToolStripMenuItem.Checked = true)
            { this.加密ToolStripMenuItem.Checked = false;
                label7.Visible = false;
               textBox5.Visible = false;
                label4.Visible = false;
                textBox1.Visible = false;
                label6.Visible = false;
                textBox2.Visible = false;
                button2.Visible = false;
                label8.Visible = true;
               textBox6.Visible = true;
                button3.Visible = true;
                label1.Visible = true;
                textBox3.Visible = true;
                label5.Visible = true;
                textBox4.Visible = true;
                mod = 2;
            }
            else
            { this.加密ToolStripMenuItem.Checked = true; }
        }

       private void 開啟檔案ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //不要寫在這裡
        }
        string path = "SECRET.txt";
        private void 開啟檔案ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (mod==1)
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    StreamReader sr = new StreamReader(openFileDialog1.FileName);
                    textBox1.Text = sr.ReadToEnd();
                    sr.Close();

                }
            }

            if (mod == 2)
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    StreamReader sr = new StreamReader(openFileDialog1.FileName);
                    textBox3.Text = sr.ReadToEnd();
                    sr.Close();

                }
            }

        }

        private void 儲存檔案ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string FileName = "SECRET.txt";
            if (mod == 1)
            {
                
                if (System.IO.File.Exists(FileName))
                {
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {


                        FileInfo fileinfo = new FileInfo(saveFileDialog1.FileName);
                        StreamWriter sw = fileinfo.CreateText();
                        sw.WriteLine(textBox5.Text);
                        sw.Flush();
                        sw.Close();
                        this.Text = path;

                    }
                }
                else
                {
                    MessageBox.Show(FileName + " 檔案不存在");
                    fileinfo = new FileInfo(path);
                    StreamWriter sw = fileinfo.CreateText();
                    sw.WriteLine(textBox5.Text);
                    sw.Flush();
                    sw.Close();
                    MessageBox.Show("已建立檔案" + path);

                }
            }
            if (mod == 2)
            {
                if (System.IO.File.Exists(FileName))
                {
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {


                        FileInfo fileinfo = new FileInfo(saveFileDialog1.FileName);
                        StreamWriter sw = fileinfo.CreateText();
                        sw.WriteLine(textBox6.Text);
                        sw.Flush();
                        sw.Close();
                        this.Text = path;

                    }
                }
                else
                {
                    MessageBox.Show(FileName + " 檔案不存在");
                    fileinfo = new FileInfo(path);
                    StreamWriter sw = fileinfo.CreateText();
                    sw.WriteLine(textBox6.Text);
                    sw.Flush();
                    sw.Close();
                    MessageBox.Show("已建立檔案" + path);
                }
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            int ch;
            ch = Convert.ToInt32(e.KeyChar);
            if (ch == 8 )
                return;
            if (e.KeyChar < '0' || e.KeyChar > '9')
                e.Handled = true;
           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {

        }
    }
}
