

using Model.System;

using System.Data.Entity;

namespace Repository
{
    public partial class BaseDbContext : DbContext
    {
        public BaseDbContext()
            : base("name=BaseDbContext")
        {
            //Database.SetInitializer(new SystemInitializer());
        }

        public virtual DbSet<DictionaryEntity> Dictionaries { get; set; }
        public virtual DbSet<DictionarytypeEntity> Dictionarytypes { get; set; }
        public virtual DbSet<MenuEntity> Menus { get; set; }
        public virtual DbSet<RoleEntity> Roles { get; set; }
        public virtual DbSet<RolemenuEntity> Rolemenus { get; set; }
        public virtual DbSet<SystemfunctionEntity> Systemfunctions { get; set; }
        public virtual DbSet<SystemparameterEntity> Systemparameters { get; set; }
        public virtual DbSet<UserEntity> Users { get; set; }
        public virtual DbSet<UserroleEntity> Userroles { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
             modelBuilder.Entity<DictionaryEntity>()
                .Property(e => e.Coding)
                .IsUnicode(false);

            modelBuilder.Entity<DictionaryEntity>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<DictionaryEntity>()
                .Property(e => e.ExtensionDescription)
                .IsUnicode(false);

            modelBuilder.Entity<DictionarytypeEntity>()
                .Property(e => e.DicType)
                .IsUnicode(false);

            modelBuilder.Entity<DictionarytypeEntity>()
                .Property(e => e.DicName)
                .IsUnicode(false);

            modelBuilder.Entity<DictionarytypeEntity>()
                .Property(e => e.Illustrate)
                .IsUnicode(false);

            modelBuilder.Entity<DictionarytypeEntity>()
                .HasMany(e => e.dictionary)
                .WithRequired(e => e.dictionarytype)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MenuEntity>()
                .Property(e => e.MenuName)
                .IsUnicode(false);

            modelBuilder.Entity<MenuEntity>()
                .Property(e => e.Menulevel)
                .IsUnicode(false);

            modelBuilder.Entity<MenuEntity>()
                .Property(e => e.Icon)
                .IsUnicode(false);

            modelBuilder.Entity<MenuEntity>()
                .Property(e => e.State)
                .IsUnicode(false);

            modelBuilder.Entity<MenuEntity>()
                .HasMany(e => e.rolemenu)
                .WithRequired(e => e.menu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RoleEntity>()
                .Property(e => e.RoleName)
                .IsUnicode(false);

            modelBuilder.Entity<RoleEntity>()
                .Property(e => e.CreateUserName)
                .IsUnicode(false);

            modelBuilder.Entity<RoleEntity>()
                .Property(e => e.UpdateUserName)
                .IsUnicode(false);

            modelBuilder.Entity<RoleEntity>()
                .HasMany(e => e.rolemenu)
                .WithRequired(e => e.role)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RoleEntity>()
                .HasMany(e => e.userrole)
                .WithRequired(e => e.role)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RolemenuEntity>()
                .Property(e => e.CreateUserName)
                .IsUnicode(false);

            modelBuilder.Entity<SystemfunctionEntity>()
                .Property(e => e.SystemCoding)
                .IsUnicode(false);

            modelBuilder.Entity<SystemfunctionEntity>()
                .Property(e => e.SystemName)
                .IsUnicode(false);

            modelBuilder.Entity<SystemfunctionEntity>()
                .Property(e => e.CreateUserName)
                .IsUnicode(false);

            modelBuilder.Entity<SystemfunctionEntity>()
                .HasMany(e => e.dictionary)
                .WithRequired(e => e.systemfunction)
                .HasForeignKey(e => e.SystemCoding)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SystemfunctionEntity>()
                .HasMany(e => e.dictionarytype)
                .WithRequired(e => e.systemfunction)
                .HasForeignKey(e => e.SystemCoding)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SystemfunctionEntity>()
                .HasMany(e => e.menu)
                .WithRequired(e => e.systemfunction)
                .HasForeignKey(e => e.SystemCoding)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SystemfunctionEntity>()
                .HasMany(e => e.role)
                .WithRequired(e => e.systemfunction)
                .HasForeignKey(e => e.SystemCoding)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SystemfunctionEntity>()
                .HasMany(e => e.systemparameters)
                .WithRequired(e => e.systemfunction)
                .HasForeignKey(e => e.SystemCoding)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SystemparameterEntity>()
                .Property(e => e.Encode)
                .IsUnicode(false);

            modelBuilder.Entity<SystemparameterEntity>()
                .Property(e => e.EncodeName)
                .IsUnicode(false);

            modelBuilder.Entity<SystemparameterEntity>()
                .Property(e => e.EncodeValue)
                .IsUnicode(false);

            modelBuilder.Entity<SystemparameterEntity>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<SystemparameterEntity>()
                .Property(e => e.State)
                .IsUnicode(false);

            modelBuilder.Entity<UserroleEntity>()
                .Property(e => e.CreateUserName)
                .IsUnicode(false);

            modelBuilder.Entity<UserEntity>()
                .Property(e => e.Useraccount)
                .IsUnicode(false);

            modelBuilder.Entity<UserEntity>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<UserEntity>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<UserEntity>()
                .Property(e => e.State)
                .IsUnicode(false);

            modelBuilder.Entity<UserEntity>()
                .HasMany(e => e.userrole)
                .WithRequired(e => e.users)
                .WillCascadeOnDelete(false);
        }
    }
}
