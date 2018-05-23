using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kantin.Entity;
using System.Data;

namespace Kantin.Crud
{
    public class CateringCrud : BaseCRUD
    {
        public Catering GetCateringByNik(string nik)
        {
            string sql = string.Format(@"
               SELECT [IdCatering]
                ,[NameCatering]
                ,[TelpCatering]
                ,[AddressCatering]
                ,[EmailCatering]
                FROM [dbo].[KM_CATERING]
                WHERE [IdCatering] = @0");

            return db.SingleOrDefault<Catering>(sql, nik);
        }


        public void InsertCatering(Catering oCatering)
        {
            string sql = string.Format(@"
                INSERT INTO [dbo].[KM_CATERING]
                ([IdCatering]
                ,[NameCatering]
                ,[TelpCatering]
                ,[AddressCatering]
                ,[EmailCatering])
                VALUES
                (@0
                ,@1
                ,@2
                ,@3
                ,@4)");
            db.Execute(sql, oCatering.IdCatering,
                oCatering.NameCatering,
                oCatering.TelpCatering,
                oCatering.AddressCatering,
                oCatering.EmailCatering);
        }

        public void UpdateCatering(Catering oCatering)
        {
            string sql = string.Format(@"
                UPDATE [dbo].[KM_CATERING]
                SET [NameCatering] = @1
                ,[TelpCatering] = @2
                ,[AddressCatering] = @3
                ,[EmailCatering] = @4
                WHERE [IdCatering] = @0");
            db.Execute(sql, oCatering.IdCatering,
                oCatering.NameCatering,
                oCatering.TelpCatering,
                oCatering.AddressCatering,
                oCatering.EmailCatering);
        }

        public void DeleteCateringByNik(string IdCatering)
        {
            string sql = string.Format(@"
                DELETE FROM [dbo].[KM_CATERING]
                WHERE [IdCatering] = @0");
            db.Execute(sql, IdCatering);
        }


        public DataTable GetCateringAsTable(string criteria, string value, int startPage, int endPage)
        {
            string sql = string.Format(@"
                WITH ORDERED AS (
                SELECT ROW_NUMBER() OVER (ORDER BY [IdCatering]) AS ROW_NUMBER,
                *
                FROM [dbo].[KM_CATERING]
                WHERE  {0} LIKE @0
                )
                SELECT
                *
                FROM ORDERED
                WHERE (ROW_NUMBER BETWEEN {1} AND {2})
                ORDER BY ROW_NUMBER", criteria, startPage, endPage);
            return db.ExecuteReader(sql, "%" + value + "%");
        }

        public int GetTotalPage(string criteria, string value, int listPerPage)
        {
            string sql = string.Format(@"
                SELECT COUNT(*) / {1}
                FROM [dbo].[KM_CATERING]
                WHERE  {0} LIKE @0", criteria, listPerPage);
            return db.ExecuteScalar<int>(sql, "%" + value + "%");
        }

        public int GetTotalRecord(string criteria, string value)
        {
            string sql = string.Format(@"
                SELECT COUNT(*) 
                FROM [dbo].[KM_CATERING]
                WHERE  {0} LIKE @0", criteria);
            return db.ExecuteScalar<int>(sql, "%" + value + "%");
        }


       
    }
}
