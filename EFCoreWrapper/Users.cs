using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Interface;
using Newtonsoft.Json;

namespace EFCoreWrapper
{
    public partial class Users
    {
        public object GetManagerName(int managerId)
        {
            using (var db = new ModelContext())
            {
                var result = db.Users.Where(u => u.UserId == managerId);
                if (result == null)
                {
                    return "Nothing found";
                }
                else
                {
                    return result;
                }

            }
        }

        public string GetUser(int managerId)
        {
            using (var db = new ModelContext())
            {
                //var result = db.Users.Where(u => u.Role == 1 && u.UserId == managerId);
                var result = db.Users.Where(u => u.Role == 1);
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

        public string GetUsers()
        {
            using (var db = new ModelContext())
            {
                var result = db.Users;
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

        public string GetClientsOfAllManagers()
        {
            using (var db = new ModelContext())
            {
                //GET Client IDs
                var clients = (from ur in db.UserRelationships
                               join u in db.Users
                               on ur.RelatedId equals u.UserId
                               select new
                               {
                                   ManagerId = ur.UserId ,
                                   ClientId = u.UserName,
                                   ClientAlias = u.Alias,
                                   ClientFirstName = u.FirstName,
                                   ClientLastName = u.LastName,
                                   ClientEmail = u.Email
                               });


                if (clients == null)
                {
                    return "Nothing found";
                }
                else
                {
                    return JsonConvert.SerializeObject(clients);
                }

            }
        }

        public string GetClientsOfManager(int managerId)
        {
            using (var db = new ModelContext())
            {
                List<User> lClients = new List<User>();
                var userRelationships = db.UserRelationships.Where(u => u.UserId == managerId);
                //var clientIds = db.UserRelationships.Join(db.Users, u => u.UserId, ur => ur.UserId,
                //    (u, ur) => ur );

                foreach (UserRelationship userRelationship in userRelationships)
                {
                    var client = db.Users.First(u => u.Role == 2 && u.UserId == userRelationship.RelatedId);
                    lClients.Add(client);
                }

                if (lClients == null || lClients.Count == 0)
                {
                    return "Nothing found";
                }
                else
                {
                    return JsonConvert.SerializeObject(lClients);
                }

            }
        }

        public string GetManagersOfAllClients()
        {
            using (var db = new ModelContext())
            {
                var clients = (from ur in db.UserRelationships
                               join u in db.Users
                               on ur.UserId equals u.UserId
                               select new
                               {
                                   ClientId = ur.RelatedId,
                                   ManagerId = u.UserName,
                                   ManagerAlias = u.Alias,
                                   ManagerFirstName = u.FirstName,
                                   ManagerLastName = u.LastName,
                                   ManagerEmail = u.Email
                               });


                if (clients == null)
                {
                    return "Nothing found";
                }
                else
                {
                    return JsonConvert.SerializeObject(clients);
                }

            }
        }

        public string GetManagersOfClient(int clientId)
        {
            using (var db = new ModelContext())
            {
                List<User> lManagers = new List<User>();
                var userRelationships = db.UserRelationships.Where(u => u.RelatedId == clientId);
                //var clientIds = db.UserRelationships.Join(db.Users, u => u.UserId, ur => ur.UserId,
                //    (u, ur) => ur );

                foreach (UserRelationship userRelationship in userRelationships)
                {
                    var manager = db.Users.First(u => u.Role == 2 && u.UserId == userRelationship.RelatedId);
                    lManagers.Add(manager);
                }

                if (lManagers == null || lManagers.Count == 0)
                {
                    return "Nothing found";
                }
                else
                {
                    return JsonConvert.SerializeObject(lManagers);
                }

            }
        }

        public string WriteDBValues(string userName, string email,
            string alias, string firstName, string lastName, string roleType)
        {
            try
            {
                using (var db = new ModelContext())
                {
                    var newUser = new User();
                    //newRole.Id = id;
                    newUser.UserName = userName;
                    newUser.Email = email;
                    newUser.Alias = alias;
                    newUser.FirstName = firstName;
                    newUser.LastName = lastName;
                    newUser.Role = roleType == "Manager" ? 1 : 2;
                    db.Users.Add(newUser);
                    var count = db.SaveChanges();
                }
                return "Write OK";
            }
            catch(Exception ex)
            {
                return ex.ToString();
            }
        }
    }
}
