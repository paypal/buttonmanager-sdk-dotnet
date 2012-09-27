using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Text;


namespace PayPal.OAuth
{
    
    public class PayPalURLEncoder
    {
        public const string digits = "0123456789abcdef";

        public static string Encode(string s, string enc)
        {
            if (s == null || enc == null)
            {
                throw new NullReferenceException();
            }
            StringBuilder buf = new StringBuilder(s.Length + 16);
            int start = -1;

            for (int i = 0; i < s.Length; i++) {
                char ch = s[i];
                if ((ch >= 'a' && ch <= 'z') || (ch >= 'A' && ch <= 'Z')
                    || (ch >= '0' && ch <= '9') || " _".IndexOf(ch) > -1) //removed "." and "-" and "*"
                { 

                    if (start >= 0) 
                    {
                        Convert(s.Substring(start, (i-start)), buf, enc);
                        start = -1;
                    }
                    if (ch != ' ') 
                    {
                        buf.Append(ch);
                    }
                    else 
                    {
                        buf.Append('+');
                    }
                } 
                else 
                {
                    if (start < 0) 
                    {
                        start = i;
                    }
                }
            }
            if (start >= 0) 
            {
                Convert(s.Substring(start, (s.Length-start)), buf, enc);
            }

            return buf.ToString(0,buf.Length);
        }


        private static void Convert(string s, StringBuilder buf, string enc)
        {
            Encoding encoding = System.Text.Encoding.GetEncoding(enc);
            byte[] bytes = encoding.GetBytes(s);

            for (int j = 0; j < bytes.Length; j++)
            {
                buf.Append('%');
                buf.Append(digits[((bytes[j] & 0xf0) >> 4)]);
                buf.Append(digits[(bytes[j] & 0xf)]);
            }
        }

    }

}
