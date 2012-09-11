using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
namespace CT_autorun
{
    class C_Boot_Exec
    {
        public List<Tree_root> list1 = new List<Tree_root>();
        public int check()
        {
            check1();
            return 0;
        }
        private int check1() 
        {
            Tree_root root = new Tree_root();
            root.name = @"HKLM/System\CurrentControlSet\Control\Session Manager";
            Tree_item item = new Tree_item();
            item.name = "BootExecute";
            item.description = REdit.get_value("BootExecute", @"HKLM/System\CurrentControlSet\Control\Session Manager");
            
            root.item.Add(item);
            list1.Add(root);
            return 0;
            //return 0;
        }
    }
}
