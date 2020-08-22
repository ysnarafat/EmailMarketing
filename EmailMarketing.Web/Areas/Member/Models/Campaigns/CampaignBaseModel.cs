﻿using Autofac;
using EmailMarketing.Common.Services;
using EmailMarketing.Framework.Services.Campaigns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmailMarketing.Web.Areas.Member.Models.Campaigns
{
    public class CampaignBaseModel : MemberBaseModel 
    {
        protected readonly ICampaignService _campaignService;
        protected readonly ICurrentUserService _currentUserService;
        public CampaignBaseModel(ICampaignService campaignService,
            ICurrentUserService currentUserService)
        {
            _campaignService = campaignService;
            _currentUserService = currentUserService;
        }

        public CampaignBaseModel()
        {
            _campaignService = Startup.AutofacContainer.Resolve<ICampaignService>();
            _currentUserService = Startup.AutofacContainer.Resolve<ICurrentUserService>();
        }

       
    }
}
