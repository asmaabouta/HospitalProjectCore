using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PatientWebApp.Models;

namespace PatientWebApp.Data
{
    public class PatientDbContext : DbContext
    {
        public PatientDbContext (DbContextOptions<PatientDbContext> options)
            : base(options)
        {
        }

        public DbSet<PatientWebApp.Models.Medecin> Medecin { get; set; }

        public DbSet<PatientWebApp.Models.RendezVous> RendezVous { get; set; }

        public DbSet<PatientWebApp.Models.Patient> Patient { get; set; }
    }
}
