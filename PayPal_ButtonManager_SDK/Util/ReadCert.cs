using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography.X509Certificates;
using System.IO;
namespace PayPal.Util
{
    class ReadCert
    {
        
        byte[] bCert = null;
        string filePath = string.Empty;
        FileStream fs = null;

        public ReadCert()
        { 
        }
        /// <summary>
        /// To read the certificate
        /// </summary>
        /// <param name="certpath"></param>
        /// <returns></returns>
        public byte[] ReadCertificate(string certpath)
        {

            ///loading the certificate file into profile.

            fs = new FileStream(certpath, FileMode.Open, FileAccess.Read);
            bCert = new byte[fs.Length];
            fs.Read(bCert, 0, int.Parse(fs.Length.ToString()));
            fs.Close();
            return bCert;

        }
        
    }
}
