using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class JwtSettings
    {
        /// <summary>
        /// 
        /// </summary>
        public string SecretKey { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Encryptkey { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Issuer { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Audience { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int NotBeforeMinutes { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int ExpirationMinutes { get; set; }
    }
}
