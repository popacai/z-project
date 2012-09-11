using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CT_autorun
{
    class C_driver
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
            root.name = @"HKLM/System\CurrentControlSet\Services";
            string[] name;
            Tree_item item;
            string str;
            string type;
            name = REdit.get_sub_key(root.name);

            for (int i = 0; i < name.Length; i++)
            {
                item = new Tree_item();
                item.name = name[i];

                str = root.name + @"\" + name[i];
                //MessageBox.Show(str);
                try
                {
                    type = REdit.get_value("Type", str);
                    if (type == "1") // it's a service
                    {
                        try
                        {
                            item.description = "name=" + REdit.get_value("DisplayName", str);
                        }
                        catch (Exception ex)
                        {
                            item.description = "name=?";
                            
                            
                            Console.WriteLine(ex.ToString());
                            
                        }
                        item.description += "\npacketid=" + REdit.get_value("DriverPackageId", str);
                        item.description += "\n";
                        item.description += "imagepath=" + REdit.get_value("ImagePath", str);
                        
                        root.item.Add(item);
                    }
                    else
                    {
                        //skip;
                    }
                }
                catch (Exception ex)
                {
                    //not type element founded
                    //  MessageBox.Show(ex.ToString() + "\n\n" + str);
                }
                //MessageBox.Show(item.description);

            }
            list1.Add(root);
            return 0;

        }
    }
}
