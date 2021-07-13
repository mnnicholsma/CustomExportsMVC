using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomExports.Models
{
    public class AppLog
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserId { get; set; }
        public string LogType { get; set; }
        public DateTime? LogTime { get; set; }
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public int NumberOfAccounts { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public Decimal TotalAmount { get; set; }

    }
}