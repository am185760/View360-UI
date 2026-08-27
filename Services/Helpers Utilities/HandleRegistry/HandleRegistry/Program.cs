using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandleRegistry
{
    class Program
    {
        public static string DecodeString(string str)
        {
            String ascii = "";
            string hex = str;
            if (OnlyHexInString(hex))
            {
                for (int i = 0; i < hex.Length; i += 2)
                {
                    String part = hex.Substring(i, 2);
                    char ch = (char)Convert.ToInt32(part, 16); ;
                    ascii += ch;
                }
                return ascii;
            }
            else
                return "";
        }
        public static bool OnlyHexInString(string test)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(test, @"\A\b[0-9a-fA-F]+\b\Z");
        }
        static void Main(string[] args)
        {
            try
            {
                string regKey = @"SOFTWARE\NCR\CCMS";
                RegistryKey key = Registry.LocalMachine.CreateSubKey(regKey);
                key.SetValue("MasterZip", System.Configuration.ConfigurationManager.AppSettings["MasterZipPass"]);
                key.SetValue("ConnectionZip", System.Configuration.ConfigurationManager.AppSettings["ConnectionZipPass"]);
                key.SetValue("ZipDir", System.Configuration.ConfigurationManager.AppSettings["ZipDir"]);
                key.Close();

                string filePath = DecodeString(System.Configuration.ConfigurationManager.AppSettings["ZipDir"]);
                System.IO.Directory.CreateDirectory(filePath);
                Console.WriteLine("Successfully Done!");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
