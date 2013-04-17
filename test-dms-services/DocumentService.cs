using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nest;

namespace Dms.Services
{
    public class DocumentService
    {
        private readonly string index = "test-user";

        private ElasticClient _client;
        protected ElasticClient GetClient()
        {
            if (_client == null)
            {

                var elasticSettings = new ConnectionSettings("127.0.0.1.", 9200);
                elasticSettings.SetDefaultIndex(index);
                _client = new ElasticClient(elasticSettings);
            }
            return _client;
        }

        public List<User> GetUsers(string criteria)
        {

            if (String.IsNullOrEmpty(criteria))
            {
                criteria = "*";
            }
            var response = GetClient().IndexExists(index);
            if (!response.Exists)
            {
                GetClient().CreateIndex(index, new IndexSettings());
                var user = new User { Id = "dsandron", city = "Bankok", name = "Danilo" };
                GetClient().Index(user, index, new IndexParameters() { Refresh = true });
                user = new User { Id = "rlouapre", city = "Jersey City", name = "Richard" };
                GetClient().Index(user, index, new IndexParameters() { Refresh = true });
            }

            var results = GetClient().Search<User>(body =>
                body.Query(query =>
                query.QueryString(qs => qs.Query(criteria))));

            Console.WriteLine("Query: {0} - results total: {1}", criteria, results.Total);
            return results.Documents.ToList();
        }

        public string CreateUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            if (String.IsNullOrEmpty(user.Id)) 
            {
                user.Id = GenerateUniqueId(user);
            }
            var response = GetClient().Index(user, index, new IndexParameters() { Refresh = true });
            return response.Id;
        }

        private string GenerateUniqueId(User user)
        {
            return Guid.NewGuid().ToString();
        }

        public User GetUser(string id)
        {
            if (String.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException("id");
            }
            var user = GetClient().Get<User>(id);
            return user;
        }
    }
}
