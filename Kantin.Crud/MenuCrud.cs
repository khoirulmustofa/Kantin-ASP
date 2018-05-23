using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Kantin.Crud
{
    public class MenuCrud : BaseCRUD
    {
        /// <summary>
        /// CETAK SEMUA MENU
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public DataTable GetListMenuByUserIDAsDataTable(string userID)
        {
            string sql = @"SELECT DISTINCT([MENUID]),[MENUNAME],[MENUPATH],[MENUPARENT],[MENUICONSTRING]
                        FROM KM_MENU M INNER JOIN KM_ROLE_MENU RM ON RM.ROLEMENU=M.MENUID
                        AND [ROLE] IN (SELECT ROLEID FROM KM_ROLE_USER WHERE USERID= @0)";
            DataTable dt = db.ExecuteReader(sql, new object[] { userID });
            return dt;
        }
        /// <summary>
        /// CETAK MENU PARENT
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public DataTable GetRootMenuByUserID(string userID)
        {
            string sql = @"SELECT * FROM [DBO].[KM_MENU] WHERE MENUNAME='Dashboard'
                            UNION
                            SELECT DISTINCT C.* FROM [DBO].[KM_ROLE_MENU] A
                            INNER JOIN [DBO].[KM_MENU] B ON B.MENUID = A.ROLEMENU
                            INNER JOIN [DBO].[KM_MENU] C ON C.MENUID = B.MENUPARENT
                            WHERE [ROLE] IN (SELECT ROLEID FROM [DBO].[KM_ROLE_USER] WHERE USERID = @0) AND C.MENUPARENT = 0";
            return db.ExecuteReader(sql, userID);
        }       
    }
}
