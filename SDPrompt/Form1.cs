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
using System.Text.RegularExpressions;

namespace SDPrompt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ReadPicture();
            ReadTxtList();
        }

        List<string> _group_box = new List<string>();
        void ReadTxtList()
        {
            ReadClothes();
            ReadMaterial();
            ReadChest();
            ReadScarf();
            ReadMouth();
            ReadHairStyle();
            ReadEye();
            ReadHairAccessories();
            ReadSocks();
            ReadShoes();
            ReadBodyShape();
            ReadPosture();
            ReadPhotoQuality();
            ReadSkin();
            ReadLight();
            ReadAngle();
            ReadBackGround();
            groupBox16.Text = "Prompt";
        }


        void ReadBackGround()
        {
            string path = "背景建築.txt";
            ReadFile(listBox18, path);
            groupBox18.Text = "背景建築";
        }
        void ReadAngle()
        {
            string path = "角度.txt";
            ReadFile(listBox17, path);
            groupBox17.Text = "角度";
        }

        void ReadLight()
        {
            string path = "光源描述.txt";
            ReadFile(listBox15, path);
            groupBox15.Text = "光源描述";
        }
        void ReadSkin()
        {
            string path = "皮膚.txt";
            ReadFile(listBox14, path);
            groupBox14.Text = "皮膚";
        }
        void ReadPhotoQuality()
        {
            string path = "照片品質.txt";
            ReadFile(listBox13, path);
            groupBox13.Text = "照片品質";
        }
        void ReadPosture()
        {
            string path = "姿勢.txt";
            ReadFile(listBox12, path);
            groupBox12.Text = "姿勢";
        }
        void ReadBodyShape()
        {
            string path = "身材.txt";
            ReadFile(listBox11, path);
            groupBox11.Text = "身材";
        }

        void ReadShoes()
        {
            string path = "鞋子.txt";
            ReadFile(listBox10, path);
            groupBox10.Text = "鞋子";
        }
        void ReadSocks()
        {
            string path = "襪子.txt";
            ReadFile(listBox9, path);
            groupBox9.Text = "襪子";
        }
        void ReadHairAccessories()
        {
            string path = "髮飾帽子.txt";
            ReadFile(listBox8, path);
            groupBox8.Text = "髮飾帽子";
        }
        void ReadEye()
        {
            string path = "眼睛.txt";
            ReadFile(listBox7, path);
            groupBox7.Text = "眼睛";
        }
        void ReadHairStyle()
        {
            string path = "髮型.txt";
            ReadFile(listBox6, path);
            groupBox6.Text = "髮型";
        }
        void ReadMouth()
        {
            string path = "嘴.txt";
            ReadFile(listBox5, path);
            groupBox5.Text = "嘴";
        }

        void ReadScarf()
        {
            string path = "領巾項鍊.txt";
            ReadFile(listBox4, path);
            groupBox4.Text = "領巾項鍊";
        }
        void ReadClothes()
        {
            string path = "衣服描述.txt";
            ReadFile(listBox1, path);
            groupBox1.Text = "衣服描述";
        }

        void ReadChest()
        {
            string path = "胸部.txt";
            ReadFile(listBox3, path);
            groupBox3.Text = "胸部";
        }
        void ReadMaterial()
        {
            string path = "衣服材質.txt";
            ReadFile(listBox2, path);
            groupBox2.Text = "衣服材質";
        }

        void ReadPicture()
        {
            string path = "image.png";
            pictureBox1.Image = Image.FromFile(path);
        }

        private void ListBox9_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            AddPrompt(listBox9);
        }

        private void ListBox13_DoubleClick(object sender, EventArgs e)
        {
            AddPrompt(listBox13);
        }

        private void ListBox15_DoubleClick(object sender, EventArgs e)
        {
            AddPrompt(listBox15);
        }

        private void ListBox17_DoubleClick(object sender, EventArgs e)
        {
            AddPrompt(listBox17);
        }

        private void ListBox11_DoubleClick(object sender, EventArgs e)
        {
            AddPrompt(listBox11);
        }

        private void ListBox12_DoubleClick(object sender, EventArgs e)
        {
            AddPrompt(listBox12);
        }

        private void ListBox7_DoubleClick(object sender, EventArgs e)
        {
            AddPrompt(listBox7);
        }

        private void ListBox5_DoubleClick(object sender, EventArgs e)
        {
            AddPrompt(listBox5);
        }

        private void ListBox4_DoubleClick(object sender, EventArgs e)
        {
            AddPrompt(listBox4);
        }

        private void ListBox3_DoubleClick(object sender, EventArgs e)
        {
            AddPrompt(listBox3);
        }

        private void ListBox1_DoubleClick(object sender, EventArgs e)
        {
            AddPrompt(listBox1);
        }

        private void ListBox10_DoubleClick(object sender, EventArgs e)
        {
            AddPrompt(listBox10);
        }

        private void ListBox2_DoubleClick(object sender, EventArgs e)
        {
            AddPrompt(listBox2);
        }

        private void ListBox14_DoubleClick(object sender, EventArgs e)
        {
            AddPrompt(listBox14);
        }

        private void ListBox6_DoubleClick(object sender, EventArgs e)
        {
            AddPrompt(listBox6);
        }

        private void ListBox8_DoubleClick(object sender, EventArgs e)
        {
            AddPrompt(listBox8);
        }

        private void ListBox18_DoubleClick(object sender, EventArgs e)
        {
            AddPrompt(listBox18);
        }

        void ReadFile(ListBox listBox, string path)
        {
            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string str = sr.ReadLine();
                        listBox.Items.Add(str);
                    }
                }
            }
        }
        private void AddPrompt(ListBox listBox)
        {
            if (listBox.SelectedItem != null)
            {
                string selectedText = listBox.SelectedItem.ToString();
                string[] separators = new string[] { ":", "：" };
                string[] selectedTextParts = selectedText.Split(separators, StringSplitOptions.None);
                string englishText = "";

                if (selectedTextParts.Count() == 2)
                {
                    englishText += selectedTextParts[1];
                }
                else if (selectedTextParts.Count() == 1)
                {
                    englishText += selectedTextParts[0];
                }

                englishText = englishText.Trim();

                if (!listBox16.Items.Contains(englishText))
                {
                    listBox16.Items.Add(englishText);
                }

                listBox16.Show();
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            Parallel.For(0, listBox16.Items.Count, i =>
            {
                sb.Append(listBox16.Items[i].ToString());
                sb.Append(",");
            });

            if (sb.Length > 0)
            {
                Clipboard.SetText(sb.ToString());
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            foreach (var selectedItem in listBox16.SelectedItems.Cast<object>().ToList())
            {
                listBox16.Items.Remove(selectedItem);
            }
        }

        private void AddText2File(string path, string new_str)
        {
            using (StreamWriter sw = new StreamWriter(path+".txt", true))
            {
                sw.WriteLine(new_str);
            }
        }

        private void DeleteTextFromFile(string path, string old_str)
        {
            List<string> lines = new List<string>();
            foreach (string line in File.ReadAllLines(path+".txt"))
            {
                if (!line.Contains(old_str))
                {
                    lines.Add(line);
                }
            }

            File.WriteAllLines(path+".txt", lines);
        }
        private void Button3_Click(object sender, EventArgs e)
        {
            foreach (var control in this.Controls)
            {
                if (control is GroupBox groupBox && groupBox.Text == label1.Text)
                {
                    var listBox = groupBox.Controls.OfType<ListBox>().FirstOrDefault();
                    if (listBox != null)
                    {
                        if (!listBox.Items.Contains(textBox1.Text))
                        {
                            AddText2File(groupBox.Text, textBox1.Text);
                            listBox.Items.Add(textBox1.Text);
                            break;
                        }
                    }
                }
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            foreach (var control in this.Controls)
            {
                if (control is GroupBox groupBox && groupBox.Text == label1.Text)
                {
                    var listBox = groupBox.Controls.OfType<ListBox>().FirstOrDefault();
                    if (listBox != null)
                    {

                        DeleteTextFromFile(groupBox.Text, textBox1.Text);
                        listBox.Items.Remove(textBox1.Text);
                        break;
                    }
                }
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            listBox16.Items.Clear();
            Clipboard.Clear();
        }

        private void ListBox13_Click(object sender, EventArgs e)
        {
            label1.Text = groupBox13.Text;
        }

        private void ListBox15_Click(object sender, EventArgs e)
        {
            label1.Text = groupBox15.Text;
        }

        private void ListBox17_Click(object sender, EventArgs e)
        {
            label1.Text = groupBox17.Text;
        }

        private void ListBox11_Click(object sender, EventArgs e)
        {
            label1.Text = groupBox11.Text;
        }

        private void ListBox12_Click(object sender, EventArgs e)
        {
            label1.Text = groupBox12.Text;
        }

        private void ListBox7_Click(object sender, EventArgs e)
        {
            label1.Text = groupBox7.Text;
        }

        private void ListBox5_Click(object sender, EventArgs e)
        {
            label1.Text = groupBox5.Text;
        }

        private void ListBox4_Click(object sender, EventArgs e)
        {
            label1.Text = groupBox4.Text;
        }

        private void ListBox3_Click(object sender, EventArgs e)
        {
            label1.Text = groupBox3.Text;
        }

        private void ListBox1_Click(object sender, EventArgs e)
        {
            label1.Text = groupBox1.Text;
        }

        private void ListBox9_Click(object sender, EventArgs e)
        {
            label1.Text = groupBox9.Text;
        }

        private void ListBox10_Click(object sender, EventArgs e)
        {
            label1.Text = groupBox10.Text;
        }

        private void ListBox6_Click(object sender, EventArgs e)
        {
            label1.Text = groupBox6.Text;
        }

        private void ListBox14_Click(object sender, EventArgs e)
        {
            label1.Text = groupBox14.Text;
        }

        private void ListBox2_Click(object sender, EventArgs e)
        {
            label1.Text = groupBox2.Text;
        }

        private void ListBox18_Click(object sender, EventArgs e)
        {
            label1.Text = groupBox18.Text;
        }

        private void ListBox8_Click(object sender, EventArgs e)
        {
            label1.Text = groupBox8.Text;
        }
    }
}
