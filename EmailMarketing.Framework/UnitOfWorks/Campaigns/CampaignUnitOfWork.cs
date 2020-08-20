﻿using EmailMarketing.Framework.Context;
using EmailMarketing.Framework.Repositories.Campaings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailMarketing.Framework.UnitOfWorks.Campaigns
{
    public class CampaignUnitOfWork : EmailMarketing.Data.UnitOfWork, ICampaignUnitOfWork
    {
        public ICampaignRepository CampaignRepository { get; set; }
        public IEmailTemplateRepository EmailTemplateRepository { get; set; }
        public CampaignUnitOfWork(FrameworkContext dbContext, ICampaignRepository campaignRepository,
            IEmailTemplateRepository emailTemplateRepository)
            : base(dbContext)
        {
            CampaignRepository = campaignRepository;
            EmailTemplateRepository = emailTemplateRepository;
        }
    }
}