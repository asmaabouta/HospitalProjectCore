using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PatientWebApp.Models
{
    public class RendezVous
    {
        [Key]
        public int ID { get; set; }

        public DateTime dateRendezVous { get; set; }
        public Boolean Valider { get; set; }

        public int PatientID { get; set; }
        public Patient Patient { get; set; }
        public int MedecinID { get; set; }
        public Medecin Medecin { get; set; }

        public RendezVous()
        {
        }
    }
}
