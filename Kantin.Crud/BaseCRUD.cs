
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kantin.Crud
{
    public class BaseCRUD : IDisposable
    {
        public PetaPoco.Database db = null;
        public string Username { get; set; }
        public string HostAddress { get; set; }
        public string URLPath { get; set; }

        public BaseCRUD()
        {
            db = new PetaPoco.Database("KantinCon");
        }

        public static PetaPoco.Database dbStatic
        {
            get
            {
                return new PetaPoco.Database("KantinCon");
            }
        }


        public void Dispose()
        {
            
        }
    }
}
