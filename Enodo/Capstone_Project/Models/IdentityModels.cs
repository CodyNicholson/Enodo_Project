using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace Capstone_Project.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
         
       
        public  override string Id { get; set; }

        [Required]
        [StringLength(255)]
        public override string UserName { get; set; }

        public bool IsResearcher { get; set; }

        [Required]
        [Display(Name = "Date of Birth")]
        public DateTime? Birthdate { get; set; }

        public Demographic Demographic { get; set; }

        [Required]
        [Display(Name = "Ethnicity")]
        public int DemographicId { get; set; }

        public Gender Gender { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public int GenderId { get; set; }

        [Required]
        [Display(Name = "Country")]
        public string Country { get; set; }

        public List<string> SurveyIds { get; set; }

      /*  internal Task<ClaimsIdentity> GenerateUserIdentityAsync(ApplicationUserManager manager)
        {
            throw new NotImplementedException();
        }*/
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
       // public DbSet<ApplicationUser> Users { get; set; }
       
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Demographic> Demographics { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<SurveyResults> SurveyResultsSet { get; set; }

       /* protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();


          

        }*/

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}