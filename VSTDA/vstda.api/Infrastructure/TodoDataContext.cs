using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace vstda.api.Infrastructure
{
    public class TodoDataContext: DbContext
    {
        public TodoDataContext(): base("vstda")
        {

        }

        public System.Data.Entity.DbSet<vstda.api.Models.VstdoModel> ToDoes { get; set; }
    }
}