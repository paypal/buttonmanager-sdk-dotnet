using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Xml;

using PayPal.Exception;
using System.IO;

namespace PayPal.Manager
{    
    //TODO: Revert to package scope for ConfigManager
    public class ConfigManager
    {
        private SDKConfigHandler config;

        /// <summary>
        /// Singleton instance of the ConfigManager
        /// </summary>
        private static readonly ConfigManager instance = new ConfigManager();
        public static ConfigManager Instance
        {
            get
            {
                return instance;
            }
        }
        private ConfigManager()
        {
            config = (SDKConfigHandler) ConfigurationManager.GetSection("paypal");
            if (config == null)
            {
                throw new ConfigException("Cannot read config file");
            }
        }                
        
        public string GetProperty(string key)
        {
            return config.Setting(key);
        }

        public Account GetAccount(string apiUserName)
        {   
            return config.Accounts[apiUserName];
        }
        public Account GetAccount(int index)
        {
            return config.Accounts[index];
        }
        
    }
}
