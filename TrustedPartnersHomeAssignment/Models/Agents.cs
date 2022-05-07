using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrustedPartnersHomeAssignment.Models
{
    [Table("AGENTS")]
    public partial class Agents
    {
        [Key]
        [Column("AGENT_CODE")]
        [StringLength(6)]
        public string AgentCode { get; set; }
        [Column("AGENT_NAME")]
        [StringLength(40)]
        public string AgentName { get; set; }
        [Column("WORKING_AREA")]
        [StringLength(35)]
        public string WorkingArea { get; set; }
        [Column("COMMISSION")]
        public int? Commission { get; set; }
        [Column("PHONE_NO")]
        [StringLength(15)]
        public string PhoneNo { get; set; }
        [Column("COUNTRY")]
        [StringLength(25)]
        public string Country { get; set; }
    }
}
