using log4net;
using MppProjectCSharp.repository.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemaC.domain;

namespace MppProjectCSharp.repository
{
    internal class UsersRepository : IUsersRepository
    {
        private static readonly ILog log = LogManager.GetLogger("UsersRepository");

        IDictionary<String, string> props;

        public UsersRepository(IDictionary<String, string> props)
        {
            this.props = props;
        }
        public bool ExistsUser(string username, string password)
        {
            log.InfoFormat("Entering ExistsUser with {0} {1}", username, password);
            using (var conn = DBUtils.DBUtils.getConnection(props))
            {
                using (var comm = conn.CreateCommand())
                {
                    comm.CommandText = "select count(*) from users where username=@username and password=@password";
                    var paramUsername = comm.CreateParameter();
                    paramUsername.ParameterName = "@username";
                    paramUsername.Value = username;
                    comm.Parameters.Add(paramUsername);
                    var paramPassword = comm.CreateParameter();
                    paramPassword.ParameterName = "@password";
                    paramPassword.Value = password;
                    comm.Parameters.Add(paramPassword);

                    var result = comm.ExecuteScalar();
                    log.InfoFormat("Exiting ExistsUser with {0}", result);
                    return (Convert.ToInt32(result) != 0);
                }
            }
        }

        public User? GetOne(string username)
        {
            log.InfoFormat("Entering GetOne with username {0}", username);
            using(var connection = DBUtils.DBUtils.getConnection(props))
            {
                var command = connection.CreateCommand();
                command.CommandText = "select * from users where username=@username";

                var param = command.CreateParameter();
                param.ParameterName = "@username";
                param.Value = username;
                command.Parameters.Add(param);

                var result = command.ExecuteReader();

                if (result.Read())
                {
                    int id = result.GetInt32(0);
                    string password = result.GetString(2);
                    User user = new User(username,password);
                    user.Id = id;
                    return user;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
