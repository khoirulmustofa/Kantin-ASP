using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kantin.Entity;
using System.Data;

namespace Kantin.Crud
{
    public class EmployeeCrud : BaseCRUD
    {
        public Employee GetEmployeeByNik(string nik)
        {
            string sql = string.Format(@"
                SELECT [Id]
                ,[Nik]
                ,[NameEmployee]
                ,[DepartmentEmployee]
                ,[PhotoEmployee]
                FROM [dbo].[KM_EMPLOYEE]
                WHERE [Nik] = @0");

            return db.SingleOrDefault<Employee>(sql, nik);
        }


        public void InsertEmployee(Employee oEmployee)
        {
            string sql = string.Format(@"
                INSERT INTO [dbo].[KM_EMPLOYEE]
                ([Nik]
                ,[NameEmployee]
                ,[DepartmentEmployee]
                ,[PhotoEmployee])
                VALUES
                (@0
                ,@1
                ,@2
                ,@3)");
            db.Execute(sql, oEmployee.Nik,
                oEmployee.NameEmployee,
                oEmployee.DepartmentEmployee,
                oEmployee.PhotoEmployee);
        }

        public void UpdateEmployee(Employee oEmployee)
        {
            string sql = string.Format(@"
                UPDATE [dbo].[KM_EMPLOYEE]
                SET 
                [NameEmployee] = @1
                ,[DepartmentEmployee] = @2
                ,[PhotoEmployee] = @3
                WHERE [Nik] = @0");
            db.Execute(sql, oEmployee.Nik,
                oEmployee.NameEmployee,
                oEmployee.DepartmentEmployee,
                oEmployee.PhotoEmployee);
        }

        public void DeleteEmployeeByNik(string Nik)
        {
            string sql = string.Format(@"
                DELETE FROM [dbo].[KM_EMPLOYEE]
                WHERE [Nik] = @0");
            db.Execute(sql, Nik);
        }


        public DataTable GetEmployeeAsTable(string criteria, string value, int startPage, int endPage)
        {
            string sql = string.Format(@"
                WITH ORDERED AS (
                SELECT ROW_NUMBER() OVER (ORDER BY [Nik]) AS ROW_NUMBER,
                *
                FROM [dbo].[KM_EMPLOYEE]
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
                FROM [dbo].[KM_EMPLOYEE]
                WHERE  {0} LIKE @0", criteria, listPerPage);
            return db.ExecuteScalar<int>(sql, "%" + value + "%");
        }

        public int GetTotalRecord(string criteria, string value)
        {
            string sql = string.Format(@"
                SELECT COUNT(*) 
                FROM [dbo].[KM_EMPLOYEE]
                WHERE  {0} LIKE @0", criteria);
            return db.ExecuteScalar<int>(sql, "%" + value + "%");
        }




        public DataTable GetEmpleyeeNotDiscipline(string StartDate, string EndDate)
        {
            string sql = string.Format(@"
                SELECT
                M.Nik,E.NameEmployee,M.Dates,M.ScanIn,M.Status
                FROM [dbo].[KM_MEAL] M
                JOIN [dbo].[KM_EMPLOYEE] E
                ON E.Nik = M.Nik
                WHERE CAST([ScanIn] AS time)
                NOT BETWEEN (SELECT [StartRest] FROM [dbo].[KM_REST] WHERE [IdRest] = 1)
                AND (SELECT [EndRest] FROM [dbo].[KM_REST] WHERE [IdRest] = 1)
                AND
                CAST([ScanIn] AS time)
                NOT BETWEEN (SELECT [StartRest] FROM [dbo].[KM_REST] WHERE [IdRest] = 2)
                AND (SELECT [EndRest] FROM [dbo].[KM_REST] WHERE [IdRest] = 2)
                AND
                CAST([ScanIn] AS time)
                NOT BETWEEN (SELECT [StartRest] FROM [dbo].[KM_REST] WHERE [IdRest] = 3)
                AND (SELECT [EndRest] FROM [dbo].[KM_REST] WHERE [IdRest] = 3)
                AND [Dates] BETWEEN @0 AND @1
                ORDER BY [Dates]");
            return db.ExecuteReader(sql,StartDate,EndDate);
        }
    }
}
