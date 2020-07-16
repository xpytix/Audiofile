using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Audiofile.Infrastructure
{
    public class AppConfig
    {
        private static string _ikonyUrzadzenFolderWzgledny = ConfigurationManager.AppSettings["IkonyUrzadzenFolder"];
        public static string IkonyUrzadzenFolderWzgledny
        {
            get
            {
                return _ikonyUrzadzenFolderWzgledny;
            }
        }
    }
}