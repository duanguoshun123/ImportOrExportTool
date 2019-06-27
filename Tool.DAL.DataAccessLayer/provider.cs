using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool.DAL.DataAccessLayer
{
    public class provider
    {
        public string connectionString = ConfigurationManager.ConnectionStrings["OperationSystem_HBMSEntities"].ConnectionString;
    }
}
