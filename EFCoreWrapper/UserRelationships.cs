using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Interface;
using Newtonsoft.Json;

namespace EFCoreWrapper
{
    public partial class UserRelationships
    {
        public string GetRelationships()
        {
            using (var db = new ModelContext())
            {
                var result = db.UserRelationships;
                if (result == null)
                {
                    return "Nothing found";
                }
                else
                {
                    return JsonConvert.SerializeObject(result);
                }

            }
        }

        public string GetRelationship(int userId)
        {
            using (var db = new ModelContext())
            {
                var result = db.UserRelationships.Where( r => r.UserId == userId );
                if (result == null)
                {
                    return "-1";
                }
                else
                {
                    return JsonConvert.SerializeObject(result);
                }
            }
        }

        public void WriteDBValues(int id, string value)
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
    }
}
