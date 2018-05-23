using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kantin.Entity;

namespace Kantin.Crud
{
   public class MealCrud :BaseCRUD
    {
       public int GetCountMealBy(string Nik, string Status)
        {
            string sql = string.Format(@"
                SELECT COUNT([Id])
                FROM [dbo].[KM_MEAL]
                WHERE [Nik] = @0
                AND [Dates] =CONVERT(date, GETDATE())
                AND [Status] = @1");
            return db.ExecuteScalar<int>(sql, Nik, Status);
        }

       public void InsertMeal(Meal oMeal)
       {
           string sql = string.Format(@"
                INSERT INTO [dbo].[KM_MEAL]
                ([Nik]
                ,[Dates]
                ,[ScanIn]
                ,[IdCatering]
                ,[Status])
                VALUES
                (@0
                ,CONVERT(date, GETDATE())
                ,CONVERT(datetime,GETDATE())
                ,@1
                ,@2)");
           db.Execute(sql, oMeal.Nik, oMeal.IdCatering,oMeal.Status);
       }
    }
}
