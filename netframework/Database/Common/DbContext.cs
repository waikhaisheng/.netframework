using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Common
{
    /// <summary>
    /// Creater: Wai Khai Sheng
    /// Created: 20211222
    /// UpdatedBy:
    /// Updated:
    /// </summary>
    public class DbContext
    {
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211222
        /// UpdatedBy:
        /// Updated:
        /// </summary>
        protected string _dbConnectString;
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211222
        /// UpdatedBy:
        /// Updated:
        /// </summary>
        /// <param name="dbConnectionString"></param>
        public DbContext(string dbConnectionString)
        {
            _dbConnectString = dbConnectionString;
        }
    }
}
