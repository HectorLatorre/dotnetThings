using System;
namespace firstapp.Data
{
    public class DbInitializer
    {
        public static void Initialize(UniContext context)
        {
            context.Database.EnsureCreated();
            context.SaveChanges();
        }
    }
}
