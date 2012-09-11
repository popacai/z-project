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
    class Tree_root
    {
        public string name = "";
        public List<Tree_item> item = new List<Tree_item>();
    }
    class Tree_item
    {
        public string name = "";
        public string description = "";
    }
    class C_Logon
    {
        public List<Tree_root> list1 = new List<Tree_root>();
        public int Logon_check() 
        {
            check1();
            check2();
            check3();
            check4();
            check5();
            check8();
         //   check6();
           // check7();
            
            return 0;
        }
        private int check8() //start folder
        {
            string str;
            Tree_root root = new Tree_root();
            root.name = @"C:\ProgramData\Microsoft\Windows\Start Menu\Programs\Startup";
            string[] name;
            Tree_item item;
            name = REdit.get_file_name(root.name);
            for (int i = 0; i < name.Length; i++) 
            {
                item = new Tree_item();
                item.name = name[i];

                item.description = "";
                root.item.Add(item);
            }
            list1.Add(root);
            return 0;
        }
        private int check7() 
        {
            string str;
            Tree_root root = new Tree_root();
            root.name = @"HKLM/SOFTWARE\Classes\Protocols\Handler";
            string[] name;
            Tree_item item;
            //string str;
            
            name = REdit.get_sub_key(root.name);

            for (int i = 0; i < name.Length; i++)
            {
                item = new Tree_item();
                item.name = name[i];
                str = root.name + @"\" + name[i];
                item.description = REdit.get_value("CLSID", str);

                str = "name=" + CLSID_Contorller.find_name(item.name);
                str += "\nimagepath=" + CLSID_Contorller.find_imagepath(item.name);
                item.description = str;

                root.item.Add(item);
            }
            list1.Add(root);
            return 0;
        }
        private int check6()
        {
            Tree_root root = new Tree_root();
            root.name = @"HKLM/SOFTWARE\Classes\Protocols\Filter";
            string[] name;
            Tree_item item;
            string str;
            name = REdit.get_sub_key(root.name);

            for (int i = 0; i < name.Length; i++)
            {
                item = new Tree_item();
                item.name = name[i];
                str = root.name+@"\" + name[i];
                item.description = REdit.get_value("CLSID", str);
                root.item.Add(item);
            }
            list1.Add(root);
            return 0;
        }
        private int check5() 
        {
            Tree_root root = new Tree_root();
            root.name = @"HKCU/Software\Microsoft\Windows\CurrentVersion\Run";
            string[] name;
            Tree_item item;
            name = REdit.get_name(root.name);

            for (int i = 0; i < name.Length; i++)
            {
                item = new Tree_item();
                item.name = name[i];
                item.description = REdit.get_value(item.name, root.name);
                root.item.Add(item);
            }
            list1.Add(root);
            return 0;
        }
        private int check4() 
        {
            Tree_root root = new Tree_root();
            root.name = @"HKLM/SOFTWARE\Microsoft\Windows\CurrentVersion\Run";
            string[] name;
            Tree_item item;
            name = REdit.get_name(root.name);
            
            for (int i = 0; i < name.Length; i++)
            {
                item = new Tree_item();
                item.name = name[i];
                item.description = REdit.get_value(item.name, root.name);
                root.item.Add(item);
            }
            list1.Add(root);
            return 0;
        }
        private int check3() 
        {
            Tree_root root = new Tree_root();
            root.name = @"HKLM/SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon\";
            Tree_item item = new Tree_item();
            item.name = "Shell";
            item.description = REdit.get_value(item.name, root.name);
            root.item.Add(item);
            list1.Add(root);
            return 0;
        }
        private int check2() 
        {
            Tree_root root = new Tree_root();
            root.name = @"HKLM/SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon\";
            Tree_item item = new Tree_item();
            item.name = "Userinit";
            item.description = REdit.get_value(item.name, root.name);
            root.item.Add(item);
            list1.Add(root);
            return 0;
        }
        private int check1() 
        {
            Tree_root root = new Tree_root();
            root.name = @"HKLM/System\CurrentControlSet\Control\Terminal Server\Wds\rdpwd";
            Tree_item item = new Tree_item();
            item.name = "StartupPrograms";
            item.description = REdit.get_value(item.name, root.name);
            root.item.Add(item);
            list1.Add(root);
            return 0;
        }
    }
}
