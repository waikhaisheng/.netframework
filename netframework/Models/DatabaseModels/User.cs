using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DatabaseModels
{
    /// <summary>
    /// Creater: Wai Khai Sheng
    /// Created: 20211222
    /// UpdatedBy:
    /// Updated:
    /// </summary>
    public class User
    {
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211222
        /// UpdatedBy:
        /// Updated:
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211222
        /// UpdatedBy:
        /// Updated:
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211222
        /// UpdatedBy:
        /// Updated:
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211222
        /// UpdatedBy:
        /// Updated:
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211222
        /// UpdatedBy:
        /// Updated:
        /// </summary>
        public DateTime Created { get; set; }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211222
        /// UpdatedBy:
        /// Updated:
        /// </summary>
        public DateTime Updated { get; set; }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211222
        /// UpdatedBy:
        /// Updated:
        /// </summary>
        public bool Deleted { get; set; }
    }
}
