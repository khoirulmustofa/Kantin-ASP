using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kantin.Entity
{
    [PetaPoco.TableName("KM_USER")]
    [PetaPoco.PrimaryKey("UserID")]
    [PetaPoco.ExplicitColumns]
    [Serializable]

    public class Users
    {
        [PetaPoco.Column]
        public string UserID { get; set; }

        [PetaPoco.Column]
        public string UserName { get; set; }

        [PetaPoco.Column]
        public string Email { get; set; }

        [PetaPoco.Column]
        public string Passwords { get; set; }

        [PetaPoco.Column]
        public bool? Status { get; set; }

        [PetaPoco.Column]
        public string CreatedBy { get; set; }

        [PetaPoco.Column]
        public DateTime CreatedDate { get; set; }

        [PetaPoco.Column]
        public string UpdatedBy { get; set; }

        [PetaPoco.Column]
        public DateTime UpdatedDate { get; set; }
    }
}
