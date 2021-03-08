using lean.UI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace lean.UI.Context
{
    public class LeanDbContext : DbContext
    {
        public LeanDbContext()
        {

        }
        public static LeanDbContext Create()
        {
            return new LeanDbContext();
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<PropertyType> PropertyTypes { get; set; }
        public virtual DbSet<UnitType> UnitTypes { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<ProjectType> ProjectTypes { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<ProjectAmenitie> ProjectAmenities { get; set; }
        public virtual DbSet<ProjectPlane> ProjectPlanes { get; set; }
        public virtual DbSet<ProjectGallery> ProjectGalleries { get; set; }
        public virtual DbSet<StaticContent> StaticContent { get; set; }
        public virtual DbSet<Managment> Managments { get; set; }
        public virtual DbSet<WhatWeDelivered> WhatWeDelivereds { get; set; }
        public virtual DbSet<Gallery> Gallery { get; set; }
        public virtual DbSet<NewsAndEvents> NewsAndEvents { get; set; }
        public virtual DbSet<NewsAndEventsGallery> NewsAndEventsGallery { get; set; }
        public virtual DbSet<ContactUsReason> ContactUsReasons { get; set; }
        public virtual DbSet<ContactUsRequest> ContactUsRequests { get; set; }
        public virtual DbSet<AvilableJob> AvilableJobs { get; set; }
        public virtual DbSet<JobRequest> JobRequests { get; set; }
        public virtual DbSet<HeaderFooterPages> HeaderFooterPages { get; set; }
        public virtual DbSet<Slider> Slider { get; set; }
        public virtual DbSet<ConstructionUpdates> ConstructionUpdates { get; set; }
        public virtual DbSet<ConstructionUpdatesGallery> ConstructionUpdatesGallery { get; set; }
        public virtual DbSet<WhatWeDeliveredGallery> WhatWeDeliveredGallery { get; set; }
        public virtual DbSet<WhyUS> WhyUs { get; set; }
        public virtual DbSet<WhyUSGalleries> WhyUsGalleries { get; set; }
        public virtual DbSet<Clients> Client{ get; set; }
        public virtual DbSet<AboutUs> AboutUs { get; set; }
        public virtual DbSet<Product> Product{ get; set; }
        
       
        }
}