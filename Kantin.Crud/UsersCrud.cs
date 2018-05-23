using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kantin.Entity;
using System.Security.Cryptography;

namespace Kantin.Crud
{
    public class UsersCrud : BaseCRUD
    {
        public Users GetUserBy(string userName)
        {
            string sql = string.Format(@"
                SELECT [UserID]
                ,[UserName]
                ,[Email]
                ,[Passwords]
                ,[Status]
                ,[CreatedBy]
                ,[CreatedDate]
                ,[UpdatedBy]
                ,[UpdatedDate]
                FROM [dbo].[KM_USER]
                WHERE [UserID] = @0");
            return db.SingleOrDefault<Users>(sql, userName);
        }

        public string GetUserVerifyPassword(string Password)
        {
            return GetSHA1Hash(Password) + GetMd5Hash(Password);
        }

        static string GetSHA1Hash(string Password)
        {
            SHA1 sha1Hash = SHA1.Create();
            // Convert the input string to a byte array and compute the hash. 
            byte[] data = sha1Hash.ComputeHash(Encoding.UTF8.GetBytes(Password));

            // Create a new Stringbuilder to collect the bytes 
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data  
            // and format each one as a hexadecimal string. 
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string. 
            return sBuilder.ToString().ToUpper();
        }

        static string GetMd5Hash(string Password)
        {
            Password = ReverseString(Password);
            MD5 md5Hash = MD5.Create();
            // Convert the input string to a byte array and compute the hash. 
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(Password));

            // Create a new Stringbuilder to collect the bytes 
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data  
            // and format each one as a hexadecimal string. 
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string. 
            return sBuilder.ToString().ToUpper();
        }

        public static string ReverseString(string Password)
        {
            char[] arr = Password.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
    }
}
