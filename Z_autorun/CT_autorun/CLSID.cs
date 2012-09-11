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
    class CLSID 
    {
        public string name = "";
        public string image_path = "";
        public string description = "";
    }
    static class CLSID_Contorller
    {
        public static List<CLSID> list_clsid = new List<CLSID>();
        public static int build_list()
        {
            string root_str = @"HKLM/Software\Classes\CLSID";
            string[] name;
            string path;
            string path2;
            CLSID clsid;
            name = REdit.get_sub_key(root_str);

            for (int i = 0; i < name.Length; i++)
            {
                clsid = new CLSID();
                path = root_str + @"\" + name[i];
                clsid.name = name[i];
                try
                {
                    path2 = path + @"\InProcServer32";
                    clsid.image_path = REdit.get_value("", path2);
                    clsid.description = REdit.get_value("", path);
                    
                }
                catch (Exception ex) 
                {
                    //MessageBox.Show(path);
                }
                list_clsid.Add(clsid);
            }
            return 0;
        }
        public static string find_imagepath(string str) 
        {
            for (int i = 0; i < list_clsid.Count; i++) 
            {
                if (list_clsid[i].name == str) 
                {
                    return list_clsid[i].image_path;
                }
            }
            return "";
        }
        public static string find_name(string str)
        {
            for (int i = 0; i < list_clsid.Count; i++)
            {
                if (list_clsid[i].name == str)
                {
                    return list_clsid[i].description;
                }
            }
            return "";
        }
    }
}
