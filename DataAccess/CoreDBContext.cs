using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    class CoreDBContext : DbContext
    {

        public CoreDBContext() : base()
        {

        }

        public CoreDBContext(DbContextOptions<DbContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<ClientType> ClientType { get; set; }
        public virtual DbSet<User> User { get; set; }

    }
}
