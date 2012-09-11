using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CT_autorun
{
    public partial class Main : Form
    {
        C_Logon c_logon;
        C_IEBHO c_iebho;
        C_service c_service;
        C_driver c_driver;
        C_Tasks c_tasks;
        C_Boot_Exec c_boot_exec;
        C_Known_DLL c_known_dll;
        List<Tree_item> list2;
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }

        private void logon_Click(object sender, EventArgs e)
        {

            listBox1.Items.Clear();
            c_logon = new C_Logon();
            c_logon.Logon_check();
            for (int i = 0; i < c_logon.list1.Count; i++) 
            {
                listBox1.Items.Add(c_logon.list1[i].name);
            }

        }



        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex != -1)
            {
                richTextBox1.Text = list2[listBox2.SelectedIndex].description;
            }
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            //listBox1_SelectedIndexChanged(sender, e);
        }

        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void IE_BHO_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            c_iebho = new C_IEBHO();
            c_iebho.iebho_check();
            for (int i = 0; i < c_iebho.list1.Count; i++)
            {
                listBox1.Items.Add(c_iebho.list1[i].name);
            }
        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                listBox2.Items.Clear();
                if (TabControl.SelectedIndex == 0)
                    list2 = c_logon.list1[listBox1.SelectedIndex].item;
                if (TabControl.SelectedIndex == 1)
                    list2 = c_iebho.list1[listBox1.SelectedIndex].item;
                if (TabControl.SelectedIndex == 2)
                    list2 = c_service.list1[listBox1.SelectedIndex].item;
                if (TabControl.SelectedIndex == 3)
                    list2 = c_driver.list1[listBox1.SelectedIndex].item;
                if (TabControl.SelectedIndex == 4)
                    list2 = c_tasks.list1[listBox1.SelectedIndex].item;
                if (TabControl.SelectedIndex == 5)
                    list2 = c_boot_exec.list1[listBox1.SelectedIndex].item;
                if (TabControl.SelectedIndex == 6)
                    list2 = c_known_dll.list1[listBox1.SelectedIndex].item;
                for (int i = 0; i < list2.Count; i++)
                {
                    listBox2.Items.Add(list2[i].name);
                }
                listBox2.SelectedIndex = 0;
            }
        }

        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TabControl.SelectedIndex == 0)
                logon_Click(sender, e);
            if (TabControl.SelectedIndex == 1)
                IE_BHO_Click(sender, e);
            if (TabControl.SelectedIndex == 2)
                services_Click(sender, e);
            if (TabControl.SelectedIndex == 3)
                drivers_Click(sender, e);
            if (TabControl.SelectedIndex == 4)
                tasks_Click(sender, e);
            if (TabControl.SelectedIndex == 5)
                boot_Click(sender, e);
            if (TabControl.SelectedIndex == 6)
                DLLs_Click(sender, e);
            listBox1.SelectedIndex = 0;
        }

        private void tasks_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            c_tasks = new C_Tasks();
            c_tasks.check();
            for (int i = 0; i < c_tasks.list1.Count; i++)
            {
                listBox1.Items.Add(c_tasks.list1[i].name);
            }
        }

        private void listBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex != -1)
            {
                richTextBox1.Text = list2[listBox2.SelectedIndex].description;
            }
        }

        private void services_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            c_service = new C_service();
            c_service.service_check();
            for (int i = 0; i < c_service.list1.Count; i++)
            {
                listBox1.Items.Add(c_service.list1[i].name);
            }
        }

        private void drivers_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            c_driver = new C_driver();
            c_driver.check();
            for (int i = 0; i < c_driver.list1.Count; i++)
            {
                listBox1.Items.Add(c_driver.list1[i].name);
            }
        }

        private void boot_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            c_boot_exec = new C_Boot_Exec();
            c_boot_exec.check();
            for (int i = 0; i < c_boot_exec.list1.Count; i++)
            {
                listBox1.Items.Add(c_boot_exec.list1[i].name);
            }
        }

        private void DLLs_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            c_known_dll = new C_Known_DLL();
            c_known_dll.check();
            for (int i = 0; i < c_known_dll.list1.Count; i++)
            {
                listBox1.Items.Add(c_known_dll.list1[i].name);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CLSID_Contorller.build_list();
            //progressBar1.Invoke();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            about a = new about();
            a.Show();
        }


    }
}
