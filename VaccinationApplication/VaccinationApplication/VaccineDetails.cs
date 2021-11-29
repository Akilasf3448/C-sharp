using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccinationApplication
{
    class VaccineDetails
    {
        public VaccineType Vaccine { get; set; }
        public int Dosage { get; set; }
        public DateTime VaccinatedDate { get; set; }
        public VaccineDetails(int vaccine, DateTime date, int dose)
        {
            Vaccine = (VaccineType)vaccine;
            VaccinatedDate = date;
            Dosage = dose;
        }
    }
    public enum VaccineType
    {
        Covaxin = 1, Covishield, Sputnic
    }

}
