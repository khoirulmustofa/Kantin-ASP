using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kantin.Entity
{

    [PetaPoco.TableName("KM_MEAL")]
    [PetaPoco.PrimaryKey("Id")]
    [PetaPoco.ExplicitColumns]
    [Serializable]

    public class Meal
    {
        [PetaPoco.Column]
        public Int32 Id { get; set; }

        [PetaPoco.Column]
        public string Nik { get; set; }

        [PetaPoco.Column]
        public string Dates { get; set; }

        [PetaPoco.Column]
        public DateTime? ScanIn { get; set; }

        [PetaPoco.Column]
        public string IdCatering { get; set; }

        [PetaPoco.Column]
        public string Status { get; set; }

    }
}
