using System.Data.Entity.Infrastructure;

[assembly: WebActivator.PreApplicationStartMethod(typeof(NoStressWedding.AppStart_SQLCEEntityFramework), "Start")]

namespace NoStressWedding {
    public static class AppStart_SQLCEEntityFramework {
        public static void Start() {
            Database.DefaultConnectionFactory = new SqlCeConnectionFactory("System.Data.SqlServerCe.4.0");
        }
    }
}
