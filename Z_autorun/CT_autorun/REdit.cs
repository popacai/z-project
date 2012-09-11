using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.IO;
namespace CT_autorun
{
    static class REdit
    {
        public static string[] get_sub_key(string path, string root = "HKLM")
        {
            int pos = path.IndexOf('/');
            root = path.Substring(0, pos);
            path = path.Substring(pos+1);

            string[] name = null;
            RegistryKey rkey;
            rkey = Registry.LocalMachine;
            if (root == "HKLM")
                rkey = Registry.LocalMachine;
            if (root == "HKCU")
                rkey = Registry.CurrentUser;

            rkey = rkey.OpenSubKey(path);
            if (rkey == null)
                return null;
            
            name = rkey.GetSubKeyNames();
          //  MessageBox.Show(name[0]);
            return name;
        }
        public static string[] get_name(string path,string root = "HKLM")
        {
            int pos = path.IndexOf('/');
            root = path.Substring(0, pos);
            path = path.Substring(pos + 1);

            string[] name = new string[100];
            RegistryKey rkey;
            rkey = Registry.LocalMachine;
            if (root == "HKLM")
                rkey = Registry.LocalMachine;
            if (root == "HKCU")
                rkey = Registry.CurrentUser;

            rkey = rkey.OpenSubKey(path);
            if (rkey == null)
                return null;

            name = rkey.GetValueNames();
            
            
            return name;
        }
        public static string get_value(string name, string path)
        {
            string value;
            RegistryKey rkey = Registry.LocalMachine;
            //string [] s = path.Split('/');
            string root = "";
            int pos = path.IndexOf('/');
            root = path.Substring(0, pos);
            path = path.Substring(pos + 1);


            if (root == "HKLM")
                rkey = Registry.LocalMachine;
            if (root == "HKCU")
                rkey = Registry.CurrentUser;
            
            
            rkey = rkey.OpenSubKey(path);
            
            value = rkey.GetValue(name).ToString();

          // MessageBox.Show(value);
            return value;
        }
        public static string [] get_file_name(string path)
        {
            DirectoryInfo folder = new DirectoryInfo(path);
            string[] str = new string[folder.GetFiles().Length];
            int i = 0;
            foreach (FileInfo file in folder.GetFiles())
            {
                //if (file.Name != "desktop.ini")
                {
                    str[i++] = file.Name;
                }
            }
            return str;
        }
    }
}
