using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kantin.Entity
{

    [PetaPoco.TableName("KM_EMPLOYEE")]
    [PetaPoco.PrimaryKey("Nik")]
    [PetaPoco.ExplicitColumns]
    [Serializable]

    public class Employee
    {
        [PetaPoco.Column]
        public Int32 Id { get; set; }

        [PetaPoco.Column]
        public string Nik { get; set; }

        [PetaPoco.Column]
        public string NameEmployee { get; set; }

        [PetaPoco.Column]
        public string DepartmentEmployee { get; set; }

        [PetaPoco.Column]
        public string PhotoEmployee { get; set; }

    }
}
