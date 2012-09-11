using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CT_autorun
{
    class C_Tasks
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
            root.name = @"C:\Windows\Tasks";
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
    }
}
