using System;
using System.ComponentModel;

namespace CustomExports.Data
{
    public class Account
    {
        public int Id { get; set; }
        public int ClientId { get; set; }

        [DisplayName("Account Num")]
        public string AccountNumber { get; set; }
        [DisplayName("Message")]
        public double Balance { get; set; }
        public int FacilityId { get; set; }

        [DisplayName("Admit Date")]
        public DateTime AdmitDate { get; set; }

        [DisplayName("Discharge Date")]
        public DateTime DischargeDate { get; set; }

        [DisplayName("Patient ID")]
        public int PatientId { get; set; }
        public Client Client { get; set; }
    }
}