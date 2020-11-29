﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMDbTrackerLibrary.Models;

namespace IMDbTrackerLibrary.EntityContexts {
    public class UserContext : DbContext {
        public UserContext() : base("name=Entity") { }
        public DbSet<User> Users { get; set; }
    }
}