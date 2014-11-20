﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack;
using TechStacks.ServiceModel.Types;

namespace TechStacks.ServiceModel
{
    [Route("/techs", Verbs = "GET, POST")]
    [Route("/techs/{Id}")]
    public class Tech : IReturn<TechResponse>
    {
        public long? Id { get; set; }

        public string Name { get; set; }
        public string VendorName { get; set; }
        public string VendorUrl { get; set; }
        public string ProductUrl { get; set; }
        public string LogoUrl { get; set; }
        public string Description { get; set; }

        public bool LogoApproved { get; set; }

        public List<TechnologyTier?> Tiers { get; set; }
    }

    [Route("/searchtech")]
    public class FindTechnologies : QueryBase<Technology>
    {

    }

    public class TechResponse
    {
        public List<Technology> Techs { get; set; }
        public Technology Tech { get; set; }
    }
}
