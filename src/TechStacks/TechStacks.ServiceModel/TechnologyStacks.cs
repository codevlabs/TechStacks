﻿using System.Collections.Generic;
using System.Runtime.Serialization;
using ServiceStack;
using TechStacks.ServiceModel.Types;

namespace TechStacks.ServiceModel
{
    [Route("/techstack/{Slug}", Verbs = "GET")]
    public class TechnologyStacks : IReturn<TechStacksResponse>
    {
        public string Slug { get; set; }

        [IgnoreDataMember]
        public long Id
        {
            set { this.Slug = value.ToString(); }
        }
    }

    [Route("/techstack", Verbs = "POST")]
    public class CreateTechnologyStack : IReturn<CreateTechnologyStackResponse>
    {
        public string Name { get; set; }
        public string VendorName { get; set; }
        public string Description { get; set; }
        public string Details { get; set; }
    }

    public class CreateTechnologyStackResponse
    {
        public TechStackDetails TechStack { get; set; }
    }

    [Route("/techstack/{Id}", Verbs = "PUT")]
    public class UpdateTechnologyStack : IReturn<UpdateTechnologyStackResponse>
    {
        public long Id { get; set; }

        public string Name { get; set; }
        public string VendorName { get; set; }
        public string Description { get; set; }
        public string Details { get; set; }
    }

    public class UpdateTechnologyStackResponse
    {
        public TechStackDetails TechStack { get; set; }
    }

    [Route("/techstack/{Id}", Verbs = "DELETE")]
    public class DeleteTechnologyStack : IReturn<DeleteTechnologyStackResponse>
    {
        public long Id { get; set; }
    }

    public class DeleteTechnologyStackResponse
    {
        public TechStackDetails TechStack { get; set; }
    }

    [Route("/techstack", Verbs = "GET")]
    public class AllTechnologyStacks : IReturn<AllTechnologyStacksResponse>
    {
        
    }

    public class AllTechnologyStacksResponse
    {
        public List<TechnologyStack> TechStacks { get; set; }
    }

    [Route("/techstack/tiers")]
    [Route("/techstack/tiers/{Tier}")]
    public class TechStackByTier
    {
        public string Tier { get; set; }
    }

    public class TechStackByTierResponse
    {
        public List<TechnologyStack> TechStacks { get; set; }        
    }

    public class TechStacksResponse
    {
        public TechStackDetails TechStack { get; set; }

        public ResponseStatus ResponseStatus { get; set; }
    }

    [Query(QueryTerm.Or)]
    [Route("/techstack/search")]
    public class FindTechStacks : QueryBase<TechnologyStack> {}

    [Route("/techstack/latest")]
    public class RecentStackWithTechs : IReturn<RecentStackWithTechsResponse> {}

    public class RecentStackWithTechsResponse
    {
        public List<TechStackDetails> TechStacks { get; set; } 
    }

    public class TechStackDetails : TechnologyStack
    {
        public string DetailsHtml { get; set; }

        public List<TechnologyInStack> TechnologyChoices { get; set; }
    }

    public class TechnologyInStack : Technology
    {
        public long TechnologyId { get; set; }
        public long TechnologyStackId { get; set; }

        public string Justification { get; set; }
    }

    [Route("/techstack/trending")]
    public class TrendingTechStacks : IReturn<TrendingStacksResponse> { }

    public class TrendingStacksResponse
    {
        public List<UserInfo> TopUsers { get; set; }
        public List<TechnologyInfo> TopTechnologies { get; set; }

        public ResponseStatus ResponseStatus { get; set; }
    }

    public class UserInfo
    {
        public string UserName { get; set; }
        public string AvatarUrl { get; set; }
        public int StacksCount { get; set; }
    }

    public class TechnologyInfo
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int StacksCount { get; set; }
    }
}
