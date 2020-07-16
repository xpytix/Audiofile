using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Audiofile.Infrastructure
{
    public static class UrlHelpers
    {
        public static string UrzadzeniaIkonySciezka(this UrlHelper helper, string nazwaIkonyUrzadzen)
        {
            var IkonyUrzadzeniaFolder = AppConfig.IkonyUrzadzenFolderWzgledny;
            var sciezka = Path.Combine(IkonyUrzadzeniaFolder, nazwaIkonyUrzadzen);
            var sciezkaBezwglendna = helper.Content(sciezka);
            return sciezkaBezwglendna;
        }
    }
}