﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace CT_autorun
{
    class C_IEBHO
    {
        public List<Tree_root> list1 = new List<Tree_root>();
        public int iebho_check()
        {
            check1();
            check2();
            check3();
            check4();
            return 0;
        }
        private int check4()
        {
            Tree_root root = new Tree_root();
            root.name = @"HKLM/Software\Microsoft\Internet Explorer\Extensions";
            string[] name;
            Tree_item item;
            string itemname;
            string str;
            name = REdit.get_sub_key(root.name);

            for (int i = 0; i < name.Length; i++)
            {
                item = new Tree_item();
                item.name = name[i];

                str = root.name + @"\" + name[i];
                str = REdit.get_value("CLSID", str);
                item.name = str;
           //     MessageBox.Show(str);
                str = "name=" + CLSID_Contorller.find_name(item.name);
                str += "\nimagepath=" + CLSID_Contorller.find_imagepath(item.name);
                item.description = str;
                root.item.Add(item);
            }
            list1.Add(root);
            return 0;

        }
        private int check3()
        {
            Tree_root root = new Tree_root();
            root.name = @"HKLM/Software\Microsoft\Internet Explorer\Toolbar";
            string[] name;
            Tree_item item;
            string str;
            name = REdit.get_name(root.name);

            for (int i = 0; i < name.Length; i++)
            {
                item = new Tree_item();
                item.name = name[i];

                str = root.name + @"\" + name[i];

                str = "name=" + CLSID_Contorller.find_name(item.name);
                str += "\nimagepath=" + CLSID_Contorller.find_imagepath(item.name);
                item.description = str;
                root.item.Add(item);
            }
            list1.Add(root);
            return 0;

        }
        private int check2()
        {
            Tree_root root = new Tree_root();
            root.name = @"HKCU/Software\Microsoft\Internet Explorer\UrlSearchHooks";
            string[] name;
            Tree_item item;
            string str;
            name = REdit.get_name(root.name);

            for (int i = 0; i < name.Length; i++)
            {
                item = new Tree_item();
                item.name = name[i];
               
                str = root.name + @"\" + name[i];

                str = "name=" + CLSID_Contorller.find_name(item.name);
                str += "\nimagepath=" + CLSID_Contorller.find_imagepath(item.name);
                item.description = str;
                root.item.Add(item);
            }
            list1.Add(root);
            return 0;

        }
        private int check1() 
        {
            Tree_root root = new Tree_root();
            root.name = @"HKLM/Software\Microsoft\Windows\CurrentVersion\Explorer\Browser Helper Objects";
            string[] name;
            Tree_item item;
            string str;
            name = REdit.get_sub_key(root.name);

            for (int i = 0; i < name.Length; i++)
            {
                item = new Tree_item();
                item.name = name[i];
          //      MessageBox.Show(item.name);
                //str = root.name + @"\" + name[i];
                //item.description = REdit.get_value("CLSID", str);

                str = "name=" + CLSID_Contorller.find_name(item.name);
                str += "\nimagepath=" + CLSID_Contorller.find_imagepath(item.name);
                item.description = str;
                root.item.Add(item);
            }
            list1.Add(root);
            return 0;
           
        }
    }
}
