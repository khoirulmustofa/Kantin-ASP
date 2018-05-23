using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Kantin.Common
{
    public class Commons
    {
        /// <summary>
        /// Mengambil data sesion user ID
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentLoginUser()
        {
            HttpContext.Current.Session["UserId"] = @"KHOIRUL-MUSTOFA/123";
            if (HttpContext.Current.Session != null && HttpContext.Current.Session["UserID"] != null)
                return HttpContext.Current.Session["UserID"].ToString();
            else
                return null;

        }
    }
}
