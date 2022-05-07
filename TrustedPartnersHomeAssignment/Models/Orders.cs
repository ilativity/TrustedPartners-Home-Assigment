using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrustedPartnersHomeAssignment.Models
{
    [Table("ORDERS")]
    public partial class Orders
    {
        [Key]
        [Column("ORD_NUM")]
        public int OrdNum { get; set; }
        [Column("ORD_AMOUNT")]
        public double OrdAmount { get; set; }
        [Column("ADVANCE_AMOUNT")]
        public double AdvanceAmount { get; set; }
        [Column("ORD_DATE", TypeName = "datetime")]
        public DateTime OrdDate { get; set; }
        [Required]
        [Column("CUST_CODE")]
        [StringLength(6)]
        public string CustCode { get; set; }
        [Required]
        [Column("AGENT_CODE")]
        [StringLength(6)]
        public string AgentCode { get; set; }
        [Required]
        [Column("ORD_DESCRIPTION")]
        [StringLength(60)]
        public string OrdDescription { get; set; }
    }
}
