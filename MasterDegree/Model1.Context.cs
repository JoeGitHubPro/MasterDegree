﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MasterDegree
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MasterDegreeEntities1 : DbContext
    {
        public MasterDegreeEntities1()
            : base("name=MasterDegreeEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<DepartmentsMangment> DepartmentsMangments { get; set; }
        public virtual DbSet<Report> Reports { get; set; }
        public virtual DbSet<ReportMaker> ReportMakers { get; set; }
        public virtual DbSet<ReportOwnership> ReportOwnerships { get; set; }
        public virtual DbSet<StudentThesi> StudentThesis { get; set; }
        public virtual DbSet<Thesis> Theses { get; set; }
        public virtual DbSet<ThesisSupervision> ThesisSupervisions { get; set; }
    }
}
