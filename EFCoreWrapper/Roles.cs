using System;
using System.Collections.Generic;
using System.Text;
using Common.Interface;

namespace EFCoreWrapper
{
    public class Roles: IRoles
    {
        public string ReadDBValues(int value)
        {
            using (var db = new ModelContext())
            {
                var count = db.SaveChanges();
                Console.WriteLine("{0} records saved to database", count);

                // Retrieving and displaying data
                Console.WriteLine();
                Console.WriteLine("All departments in the database:");

                var result = db.Roles.Find(new object[] { value });
                if (result == null)
                {
                    return "Nothing found";
                }
                else
                {
                    return result.Name;
                }

            }
        }

        public string WriteDBValues(int id, string value)
        {
            try
            {
                using (var db = new ModelContext())
                {
                    var newRole = new Role();
                    newRole.Id = id;
                    newRole.Name = value;
                    db.Roles.Add(newRole);
                    var count = db.SaveChanges();
                }
            }
            catch(Exception Ex)
            {
                return Ex.ToString();
            }
            return "Write OK";
        }

        public string DeleteDBValues(int id)
        {
            try
            {
                using (var db = new ModelContext())
                {
                    var existingRole = new Role();
                    existingRole.Id = id;
                    db.Roles.Remove(existingRole);
                    var count = db.SaveChanges();
                }
            }
            catch (Exception Ex)
            {
                return Ex.ToString();
            }
            return "Write OK";
        }
    }
}
