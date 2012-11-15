using System;

namespace ButtonManagerAPISample
{
    public static class Message
    {
        private static Exception lstException;

        public static Exception LastException
        {
            get
            {
                return lstException;
            }
            set
            {
                if (value != lstException)
                {
                    lstException = value;
                }
            }
        }
    }
}
