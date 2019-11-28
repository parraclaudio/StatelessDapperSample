namespace StatelessDapperSample.Domain.Data
{
    public sealed class ConnectionString
    {
        /// <summary>
        /// Host address
        /// </summary>
        public string ServerName { get; set; }

        /// <summary>
        /// Database name
        /// </summary>
        public string Database { get; set; }

        /// <summary>
        /// User name
        /// </summary>
        public string User { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Constructor method
        /// </summary>
        /// <param name="serverName">host address</param>
        /// <param name="database">database name</param>
        /// <param name="user">user name</param>
        /// <param name="password">password</param>
        public ConnectionString(string serverName, string database, string user, string password)
        {
            ServerName = serverName;
            Database = database;
            User = user;
            Password = password;
        }

        ///// <summary>
        ///// Constructor method
        ///// </summary>
        public ConnectionString()
        {
        }

        ///// <summary>
        ///// Getting connection String
        ///// </summary>
        public string GetConnectionString => $"server={ServerName};database={Database};uid={User};password={Password}";
    }
}
