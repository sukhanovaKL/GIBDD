﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GIBDD
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CarColors> CarColors { get; set; }
        public virtual DbSet<Drivers> Drivers { get; set; }
        public virtual DbSet<DTP> DTP { get; set; }
        public virtual DbSet<DTP_Driver> DTP_Driver { get; set; }
        public virtual DbSet<Fine> Fine { get; set; }
        public virtual DbSet<FineStatuses> FineStatuses { get; set; }
        public virtual DbSet<Licences> Licences { get; set; }
        public virtual DbSet<LicenceStatus> LicenceStatus { get; set; }
        public virtual DbSet<Photo_DTPDriver> Photo_DTPDriver { get; set; }
        public virtual DbSet<Regions> Regions { get; set; }
        public virtual DbSet<StatusHistory> StatusHistory { get; set; }
        public virtual DbSet<Users> Users { get; set; }
    }
}
