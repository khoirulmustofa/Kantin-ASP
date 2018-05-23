using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Kantin.Crud
{
    public class RoleUserCrud : BaseCRUD
    {
        public DataTable GetRoleUserBy(string UserID)
        {
            string sql = string.Format(@"
                SELECT U.USERID,U.USERNAME,R.ROLEID,R.ROLENAME FROM [DBO].[KM_USER] AS U
                INNER JOIN [DBO].[KM_ROLE_USER] AS RU
                ON RU.USERID=U.USERID
                INNER JOIN [DBO].[KM_ROLE] AS R
                ON R.[ROLEID]=RU.[ROLEID]
                WHERE U.USERID = @0");
            return db.ExecuteReader(sql, UserID);
        }

        public DataTable GetMenuAccesBy(string RoleId, string FormName)
        {
            string sql = string.Format(@"
                SELECT RM.[READACCES],RM.[CREATEACCES],RM.[EDITACCES], RM.[DELETEACCES]FROM [DBO].[KM_ROLE_USER] AS RU
                INNER JOIN [DBO].[KM_ROLE_MENU] AS RM
                ON RM.[ROLE]=RU.ROLEID
                INNER JOIN [DBO].[KM_MENU] AS M
                ON M.MENUID=RM.ROLEMENU
                WHERE RU.ROLEID= @0 AND M.FORMNAME= @1");
            return db.ExecuteReader(sql, RoleId, FormName);
        }
    }
}
