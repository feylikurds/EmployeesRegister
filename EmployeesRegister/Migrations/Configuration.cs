namespace EmployeesRegister.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EmployeesRegister.DataAccessLayer.EmployeesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EmployeesRegister.DataAccessLayer.EmployeesContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var employees = new List<Models.Employee>();

            var positions = new string[]
            {
                "Worker",
                "Teamleader",
                "Manager",
            };

            var departments = new string[]
            {
                "Factory",
                "Sales",
                "Corporate",
            };

            var rnd = new Random(new System.DateTime().Millisecond);

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    var fn = RandomString(rnd, 10);
                    var ln = RandomString(rnd, 10);
                    var sl = rnd.Next(1, 10) * 1000;
                    var ps = positions[rnd.Next(0, positions.Length)];
                    var dp = departments[rnd.Next(0, departments.Length)];

                    var employee = new Models.Employee
                    {
                        FirstName = fn,
                        LastName = ln,
                        Salary = sl,
                        Position = ps,
                        Department = dp,
                    };

                    employees.Add(employee);
                }
            }


            context.Employees.AddOrUpdate(p => p.LastName, employees.ToArray());
        }

        private static string RandomString(Random random, int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
