﻿using EmailMarketing.Data;
using EmailMarketing.Membership.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailMarketing.Framework.Entities
{
    public class SMTPConfig : IAuditableEntity<Guid>
    {
        public string Server { get; set; }
        public int Port { get; set; }
        public string SenderName { get; set; }
        public string SenderEmail { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Guid UserId { get; set; }
        public bool EnableSSL { get; set; }
    }
}
