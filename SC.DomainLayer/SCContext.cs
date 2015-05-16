using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using SC.DomainLayer.Model;

namespace SC.DomainLayer
{
    public class SCContext : DbContext
    {
        public IDbSet<Student> Student { get; set; }
        public IDbSet<Course> Course { get; set; }
        public IDbSet<Department> Department { get; set; }
        public IDbSet<Enrollment> Enrollment { get; set; }
        public IDbSet<EnrollmentDetails> EnrollmentDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public SCContext()
            : base("name=SCContext")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;

            //Database.SetInitializer<SCContext>(new CreateDatabaseIfNotExists<SCContext>());

            Database.SetInitializer<SCContext>(new DropCreateDatabaseIfModelChanges<SCContext>());
            //Database.SetInitializer<SCContext>(new DropCreateDatabaseAlways<SCContext>());
            //Database.SetInitializer<SCContext>(new SchoolDBInitializer());
        }
        public SCContext(string contextName)
            : base(string.Format("name={0}", contextName))
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;

            //Database.SetInitializer<SCContext>(new CreateDatabaseIfNotExists<SCContext>());

            Database.SetInitializer<SCContext>(new DropCreateDatabaseIfModelChanges<SCContext>());
            //Database.SetInitializer<SCContext>(new DropCreateDatabaseAlways<SCContext>());
            //Database.SetInitializer<SCContext>(new SchoolDBInitializer());

        }
    }
}
