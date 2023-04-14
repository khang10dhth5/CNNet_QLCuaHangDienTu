using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_Nhom16
{
    class App_Tools
    {
        public string MaHoaMatKhau(string chuoi)
        {
            string str_md5 = "";
            byte[] mang = System.Text.Encoding.UTF8.GetBytes(chuoi);

            MD5CryptoServiceProvider my_md5 = new MD5CryptoServiceProvider();
            mang = my_md5.ComputeHash(mang);

            foreach (byte b in mang)
            {
                str_md5 += b.ToString("X2");
            }

            return str_md5;
        }
        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }
        public bool  timVaXoaFile(string tenFile_VaMoRong, string rootFolder)  
        {
            try    
            {    
                // Check if file exists with its full path    
                if (File.Exists(Path.Combine(rootFolder, tenFile_VaMoRong)))
                {
                    // If file found, delete it    
                    File.Delete(Path.Combine(rootFolder, tenFile_VaMoRong));
                    return true;
                }
                else return false;   
            }    
            catch (IOException ioExp)    
            {
                return false;      
            } 

        }  
    
           

    }
}
