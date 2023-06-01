using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public static string GetConnectionString ()
        {
            return ConfigurationManager.ConnectionStrings["ConnectionToDatabase"]?.ConnectionString;
        }
    }
}
