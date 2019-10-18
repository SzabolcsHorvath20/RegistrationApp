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
                        write.WriteLine(tbname.Text + ";" + tbdob.Text + ";male;" + hobbylist.SelectedItem + ";");
                    }
                    if (rbfemale.Checked)
                    {
                        write.WriteLine(tbname.Text + ";" + tbdob.Text + ";female;" + hobbylist.SelectedItem + ";");
                    }
                    foreach (var item in hobbylist.Items)
                    {
                        write.Write(item+",");
                    }
                    write.Close();

                }
                catch (Exception)
                {
                    MessageBox.Show("Error, the data could not be saved.");
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
            hobbylist.Items.Add(tbhobby.Text);
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void Savebtn_Click(object sender, EventArgs e)
        {
            fdSave.ShowDialog();
        }
    }
}
