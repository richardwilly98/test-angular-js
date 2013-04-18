using System;
using System.Collections.Generic;
using Dms.Services;
using Nancy;
using Nancy.ModelBinding;

namespace Test.Nancy.Rest
{
    public class UserModule : NancyModule
    {
        public UserModule()
            : base("/api/users")
        {
            Get["/find/{name}"] = parameter =>
            {
                return GetUsers();
            };

            Post["/"] = parameter =>
            {
                try
                {
                    var user = this.Bind<User>();
                    Console.WriteLine(user);
                    CreateUser(ref user);
                    return Response.AsJson(user, HttpStatusCode.Created);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                    throw;
                }
            };
        }

        private List<User> GetUsers()
        {
            DocumentService service = new DocumentService();
            return service.GetUsers(String.Empty);
        //    return new List<User>(
        //new[] { 
        //                new User { name = "John Doe", city = "Los Angeles" }, 
        //                new User { name = "Richard Louapre", city = "New York" } 
        //            });
        }

        private void CreateUser(ref User user)
        {
            DocumentService service = new DocumentService();
            string id = service.CreateUser(user);
            user.Id = id;
        }
    }
}
