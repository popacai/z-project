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
    class C_service
    {
        public List<Tree_root> list1 = new List<Tree_root>();
        public int service_check()
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
                    if (type != "1") // it's a service
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
                        try
                        {
                            item.description = "name=" + REdit.get_value("Display Name", str);
                        }
                        catch (Exception ex) { }
                        try
                        {
                            item.description += "\ndescription=" + REdit.get_value("Description", str);
                        }
                        catch (Exception ex) 
                        {
                            //pass;
                        }
                        item.description += "\n";
                        item.description += "imagepath=" + REdit.get_value("ImagePath", str);
                       // item.description = REdit.get_value("ImagePath",str);
                        root.item.Add(item);
                    }else
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
