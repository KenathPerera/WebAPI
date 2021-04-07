using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class TaskDetailsContext : DbContext
    {
        //information Db provide(mqsql/SQL),Connection String for DB
        public TaskDetailsContext(DbContextOptions<TaskDetailsContext> options) : base(options)
        {

        }

        public DbSet<TaskDetail> TaskDetails { get; set; }
    }
}
