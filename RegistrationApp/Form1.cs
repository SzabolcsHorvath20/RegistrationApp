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

namespace RegistrationApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            hobbylist.Items.Add("Cook");
            hobbylist.Items.Add("Gardener");
            hobbylist.Items.Add("Gamer");
            fdSave.FileOk += (senderFile, efile) =>
            {
                try
                {
                    string fileName = fdSave.FileName;
                    StreamWriter write = new StreamWriter(fileName);
                    if (rbmale.Checked)
                    {
                        write.Write(tbname.Text + ";" + tbdob.Text + ";male;" + hobbylist.SelectedItem + ";");
                    }
                    if (rbfemale.Checked)
                    {
                        write.Write(tbname.Text + ";" + tbdob.Text + ";female;" + hobbylist.SelectedItem + ";");
                    }
                    foreach (var item in hobbylist.Items)
                    {
                        write.Write(item + ",");
                    }
                    write.Close();

                }
                catch (Exception)
                {
                    MessageBox.Show("Error, the data could not be saved.");
                }
            };
            fdOpen.FileOk += (sender, e) =>
            {
                try
                {
                    hobbylist.Items.Clear();
                    StreamReader read = new StreamReader(fdOpen.FileName);
                    string line = read.ReadLine();
                    string[] split = line.Split(';');
                    tbname.Text = split[0];
                    tbdob.Text = split[1];
                    if (split[2] == "male")
                    {
                        rbmale.Checked = true;
                    }
                    if (split[2] == "female")
                    {
                        rbfemale.Checked = true;
                    }
                    string[] splithobby = split[4].Split(',');
                    for (int i = 0; i < splithobby.Length-1; i++)
                    {
                        hobbylist.Items.Add(splithobby[i]);
                        if (split[3] == splithobby[i])
                        {
                            hobbylist.SelectedItem = split[3];
                        }
                    }
                    read.Close();

                }
                catch (Exception)
                {
                    MessageBox.Show("Error, the data could not be loaded.");
                }
            };
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void hobbylist_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void Addbtn_Click(object sender, EventArgs e)
        {
            if (!hobbylist.Items.Contains(tbhobby.Text) && (tbhobby.Text != ""))
            {
                hobbylist.Items.Add(tbhobby.Text);
            }
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void Savebtn_Click(object sender, EventArgs e)
        {
            if (tbdob.Text.Trim() != "" && tbname.Text.Trim() != "" && !hobbylist.SelectedItem.Equals("") && (rbmale.Checked == true || rbfemale.Checked == true))
            {
                fdSave.ShowDialog();
            }
            else
            {
                MessageBox.Show("There are some information missing,\n please fill out the from in order to save", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Loadbtn_Click(object sender, EventArgs e)
        {
            fdOpen.ShowDialog();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
