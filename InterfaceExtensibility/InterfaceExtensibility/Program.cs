using System;

namespace InterfaceExtensibility
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // Using the Console Logger
            var dbMigrator = new DbMigrator(new ConsoleLogger());
            dbMigrator.Migrate();

            var dbMigrator2 = new DbMigrator(new FileLogger("/tmp/log.txt"));
            dbMigrator2.Migrate();
        }
    }
}
