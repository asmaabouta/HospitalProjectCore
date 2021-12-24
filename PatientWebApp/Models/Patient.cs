using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PatientWebApp.Models
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }

        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime DateNaissance { get; set; }
       
        public ICollection<RendezVous> RendezVous { get; set; }
       
        public Patient()
        {

        }

    }
}
