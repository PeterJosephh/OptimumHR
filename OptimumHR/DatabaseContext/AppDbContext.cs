using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OptimumHR.Models;

namespace OptimumHR.DatabaseContext
{
    public class AppDbContext : IdentityDbContext<Account>
    {

        //Employee

        public DbSet<Employee> Employees { get; set; }
        public DbSet<TaskRequest> Tasks { get; set; }
        public DbSet<Department> Departments { get; set; }

        public DbSet<SocialStatus> SocialStatuses { get; set; }
        public DbSet<JobTitle> JobTitles { get; set; }

        //Documents
        public DbSet<DocumentCopy> DocumentCopies { get; set; }

        public DbSet<DocuType> DocuTypes { get; set; }

        //JobRecruitments
        public DbSet<JobRecruitment> JobRecruitments { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Guest> Guests { get; set; }

        //DaysOff

        public DbSet<DayOffType> DayOffTypes { get; set; }
        public DbSet<DayOffRequest> DayOffRequests { get; set; }


        public DbSet<PermissionReq> PermissionReqs { get; set; }
        public DbSet<RequestStatus> RequestStatuses { get; set; }
        public DbSet<VacationBalance> VacationBalances { get; set; }
        public DbSet<VacRule> VacRules { get; set; }

        //shift
        public DbSet<Shift> Shift { get; set; }
        public DbSet<ShiftRule> ShiftRules { get; set; }
        public DbSet<WeeklyDayOff> WeeklyDayOffs { get; set; }



        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public AppDbContext()
        {

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=HROptimimDb;Integrated Security=True;TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);

        }



    }
}
