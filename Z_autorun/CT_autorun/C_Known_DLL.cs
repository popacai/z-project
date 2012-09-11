using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CT_autorun
{
    class C_Known_DLL
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
            root.name = @"HKLM/System\CurrentControlSet\Control\Session Manager\KnownDlls";
            string[] name;
            Tree_item item;
            string str;
            
            name = REdit.get_name(root.name);

            for (int i = 0; i < name.Length; i++)
            {
                item = new Tree_item();
                item.name = name[i];

                str = root.name;
                //MessageBox.Show(str);
                    //type = REdit.get_value("Type", str);
                item.description = REdit.get_value(name[i], root.name);
                root.item.Add(item);
                //MessageBox.Show(item.description);

            }
            list1.Add(root);
            return 0;

        }
    }
}
