using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PatientWebApp.Models
{
    public class Medecin
    {
        [Key]
        public int ID { get; set; }

        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Specialite { get; set; }
        public float PrixVisite { get; set; }

        public Medecin()
        {
        }
    }
}
