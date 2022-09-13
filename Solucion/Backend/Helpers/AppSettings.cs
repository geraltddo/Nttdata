using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Helpers
{
    public class AppSettings
    {
        /// <summary>
        /// 
        /// </summary>
        public string OriginCors { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Secret { get; set; }
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
        public string HmacSecretKey { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int ExpiryDays { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool UseRsa { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string RsaPrivateKeyXML { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string RsaPublicKeyXML { get; set; }
    }
}
