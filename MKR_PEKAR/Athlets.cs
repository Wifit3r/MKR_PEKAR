using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MKR_PEKAR
{
    public class Athlet
    {
        
        public string FisrtNAme { get; set; }
        public string Sport { get; set; }
        public int Result { get; set; }
        public string Medal { get; set; }

        public Athlet()
        { }
        public Athlet(string name, string sport, int result, string medal)
        {
            this.FisrtNAme = name;
            this.Sport = sport;
            this.Result = result;
            this.Medal = medal;
        }
    }
    public class SolutionContext: DbContext
    {
        public DbSet<Athlet> Athlets { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            optionsBuilder.UseNpgsql(@"Server=ASUSVIVOBOOK\SQLEXPRESS; Database=AthletsDB; ");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Athlet>().HasNoKey();
        }
        public static void GetAthletsBySport(string sport)
        {
            using (var context = new SolutionContext())
            {
                var Athlets = context.Athlets.FirstOrDefault(athlet => athlet.Sport == sport && athlet.Medal != null);
                if (Athlets != null)
                {
                    Console.WriteLine($"Athlets name = {Athlets.FisrtNAme}, medal = {Athlets.Medal}, result = {Athlets.Result}");

                }
                else
                {
                    Console.WriteLine("Athlets could not be found");
                }
            }

        }
    }
    
}
