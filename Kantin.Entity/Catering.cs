using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kantin.Entity
{

    [PetaPoco.TableName("KM_CATERING")]
    [PetaPoco.PrimaryKey("IdCatering")]
    [PetaPoco.ExplicitColumns]
    [Serializable]

    public class Catering
    {
        [PetaPoco.Column]
        public string IdCatering { get; set; }

        [PetaPoco.Column]
        public string NameCatering { get; set; }

        [PetaPoco.Column]
        public string TelpCatering { get; set; }

        [PetaPoco.Column]
        public string AddressCatering { get; set; }

        [PetaPoco.Column]
        public string EmailCatering { get; set; }

    }
}
