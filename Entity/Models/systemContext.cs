using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MySqEntity.Models
{
    public partial class systemContext : DbContext
    {
        public systemContext()
        {
        }

        public systemContext(DbContextOptions<systemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Dictionary> Dictionaries { get; set; }
        public virtual DbSet<Dictionarytype> Dictionarytypes { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Rolemenu> Rolemenus { get; set; }
        public virtual DbSet<Systemfunction> Systemfunctions { get; set; }
        public virtual DbSet<Systemparameter> Systemparameters { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Userrole> Userroles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("server=localhost;userid=root;pwd=pzqllq;port=3306;database=system;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dictionary>(entity =>
            {
                entity.ToTable("dictionary");

                entity.HasIndex(e => e.Id, "Id")
                    .IsUnique();

                entity.Property(e => e.Coding)
                    .HasColumnType("longtext")
                    .HasComment("编码");

                entity.Property(e => e.CreationTime).HasComment("创建时间");

                entity.Property(e => e.DictionaryTypeId).HasComment("类型");

                entity.Property(e => e.ExtensionDescription)
                    .HasColumnType("longtext")
                    .HasComment("扩展描述");

                entity.Property(e => e.Name)
                    .HasColumnType("longtext")
                    .HasComment("名称");

                entity.Property(e => e.Sorting).HasComment("排序号");

                entity.Property(e => e.SystemCoding)
                    .HasColumnType("longtext")
                    .HasComment("系统编码");

                entity.Property(e => e.UpdateTime).HasComment("修改时间");
            });

            modelBuilder.Entity<Dictionarytype>(entity =>
            {
                entity.ToTable("dictionarytype");

                entity.HasIndex(e => e.Id, "Id")
                    .IsUnique();

                entity.Property(e => e.CreationTime).HasComment("创建时间");

                entity.Property(e => e.DicName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("字典名称");

                entity.Property(e => e.DicType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("字典类型");

                entity.Property(e => e.Illustrate)
                    .HasMaxLength(300)
                    .HasComment("说明");

                entity.Property(e => e.SystemCoding)
                    .IsRequired()
                    .HasMaxLength(4)
                    .HasComment("系统编码");

                entity.Property(e => e.UpdateTime).HasComment("修改时间");
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.ToTable("menu");

                entity.HasComment("菜单表");

                entity.HasIndex(e => e.Id, "Id")
                    .IsUnique();

                entity.HasIndex(e => e.SystemCoding, "SystemCoding");

                entity.Property(e => e.CreationTime).HasComment("创建时间");

                entity.Property(e => e.Icon)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("图标");

                entity.Property(e => e.MenuAddress)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasComment("菜单地址");

                entity.Property(e => e.MenuName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("菜单名称");

                entity.Property(e => e.Menulevel)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasComment("菜单级别\n\n");

                entity.Property(e => e.ParentMenu).HasComment("父菜单");

                entity.Property(e => e.Sorting).HasComment("排序");

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(2)
                    .HasDefaultValueSql("'1'")
                    .HasComment("状态 1 有效 0 无效");

                entity.Property(e => e.SystemCoding)
                    .IsRequired()
                    .HasMaxLength(4)
                    .HasComment("系统编码");

                entity.Property(e => e.UpdateTime).HasComment("修改时间");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("role");

                entity.HasComment("角色表");

                entity.HasIndex(e => e.RoleId, "RoleId")
                    .IsUnique();

                entity.Property(e => e.RoleId).HasComment("角色id");

                entity.Property(e => e.CreateUserName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("创建用户");

                entity.Property(e => e.CreationTime).HasComment("创建时间");

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasComment("角色名称");

                entity.Property(e => e.Sorting).HasComment("排序号");

                entity.Property(e => e.SystemCoding)
                    .IsRequired()
                    .HasMaxLength(4)
                    .HasComment("系统编码");

                entity.Property(e => e.UpdateTime).HasComment("修改时间");

                entity.Property(e => e.UpdateUserName)
                    .HasMaxLength(50)
                    .HasComment("修改用户");
            });

            modelBuilder.Entity<Rolemenu>(entity =>
            {
                entity.ToTable("rolemenu");

                entity.HasComment("角色与菜单表");

                entity.HasIndex(e => e.Id, "Id")
                    .IsUnique();

                entity.Property(e => e.CreateUserName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("创建用户");

                entity.Property(e => e.CreationTime).HasComment("创建时间");

                entity.Property(e => e.MenuId).HasComment("菜单id");

                entity.Property(e => e.RoleId).HasComment("角色id");
            });

            modelBuilder.Entity<Systemfunction>(entity =>
            {
                entity.ToTable("systemfunction");

                entity.HasComment("系统功能表");

                entity.HasIndex(e => e.Id, "Id")
                    .IsUnique();

                entity.HasIndex(e => e.SystemCoding, "SystemCoding");

                entity.Property(e => e.CreateUserName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'hnpzq'")
                    .HasComment("操作用户");

                entity.Property(e => e.SystemCoding)
                    .IsRequired()
                    .HasMaxLength(4)
                    .HasComment("系统编码");

                entity.Property(e => e.SystemName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasComment("系统名称");
            });

            modelBuilder.Entity<Systemparameter>(entity =>
            {
                entity.ToTable("systemparameters");

                entity.HasComment("系统参数表");

                entity.HasIndex(e => e.Id, "Id")
                    .IsUnique();

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasComment("描述");

                entity.Property(e => e.Encode)
                    .IsRequired()
                    .HasMaxLength(60)
                    .HasComment("编码");

                entity.Property(e => e.EncodeName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasComment("编码名称");

                entity.Property(e => e.EncodeValue)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasComment("编码值");

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(2)
                    .HasComment("状态 1有效 0 无效");

                entity.Property(e => e.SystemCoding)
                    .IsRequired()
                    .HasMaxLength(4)
                    .HasComment("系统编码");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.Id, "Id")
                    .IsUnique();

                entity.Property(e => e.CreationTime).HasComment("创建时间");

                entity.Property(e => e.PassUpdateTime).HasComment("密码修改时间");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("密码");

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(2)
                    .HasDefaultValueSql("'1'")
                    .HasComment("状态 1有效 0 无效");

                entity.Property(e => e.UpdateTime).HasComment("修改时间");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("姓名");

                entity.Property(e => e.Useraccount)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("用户账号");
            });

            modelBuilder.Entity<Userrole>(entity =>
            {
                entity.ToTable("userrole");

                entity.HasIndex(e => e.Id, "Id")
                    .IsUnique();

                entity.Property(e => e.CreateUserName)
                    .HasMaxLength(50)
                    .HasComment("创建用户");

                entity.Property(e => e.CreationTime).HasComment("创建时间");

                entity.Property(e => e.RoleId).HasComment("角色id");

                entity.Property(e => e.UsersId).HasComment("用户id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
