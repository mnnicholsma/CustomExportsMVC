using System;

namespace CustomExports.Models
{
    public class Account
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string AccountNumber { get; set; }
        public double Balance { get; set; }
        public int FacilityId { get; set; }
        public DateTime AdmitDate { get; set; }
        public DateTime DischargeDate { get; set; }
        public string ClientName { get; set; }
        public int PatientId { get; set; }

    }
}