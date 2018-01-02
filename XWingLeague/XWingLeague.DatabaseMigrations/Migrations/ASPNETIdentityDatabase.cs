using FluentMigrator;

namespace XWingLeague.DatabaseMigrations.Migrations
{
    [Migration(1)]
    public class ASPNETIdentityDatabase : ForwardOnlyMigration
    {
        public override void Up()
        {
            CreateUsersTable();

            CreateLoginsTable();

            CreateRolesTable();

            CreateUserRolesTable();

            CreateUserClaimsTable();
        }

        private void CreateUserClaimsTable()
        {
            Create.Table("AspNetUserClaims")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey()
                .WithColumn("UserId")
                .AsString(128)
                .NotNullable()
                .ForeignKey("FK_AspNetUserClaims_AspNetUsers", "AspNetUsers", "Id")
                .WithColumn("ClaimType").AsString(int.MaxValue).Nullable()
                .WithColumn("ClaimValue").AsString(int.MaxValue).Nullable();

            Create.Index("IX_UserId")
                .OnTable("AspNetUserClaims")
                .OnColumn("UserId")
                .Ascending()
                .WithOptions()
                .NonClustered();
        }

        private void CreateUserRolesTable()
        {
            Create.Table("AspNetUserRoles")
                .WithColumn("UserId")
                .AsString(128)
                .NotNullable()
                .ForeignKey("FK_AspNetUserRoles_AspNetUsers", "AspNetUsers", "Id")
                .WithColumn("RoleId")
                .AsString(128)
                .NotNullable()
                .ForeignKey("FK_AspNetUserRoles_AspNetRoles", "AspNetRoles", "Id");

            Create.PrimaryKey("PK_AspNetUserRoles").OnTable("AspNetUserRoles").Columns("UserId", "RoleId");

            Create.Index("IX_RoleId").OnTable("AspNetUserRoles").OnColumn("RoleId").Ascending().WithOptions().NonClustered();
            Create.Index("IX_UserId").OnTable("AspNetUserRoles").OnColumn("UserId").Ascending().WithOptions().NonClustered();
        }

        private void CreateRolesTable()
        {
            Create.Table("AspNetRoles")
                .WithColumn("Id").AsString(128).PrimaryKey().NotNullable()
                .WithColumn("Name").AsString(256).NotNullable();

            Create.Index("RoleNameIndex").OnTable("AspNetRoles").OnColumn("Name").Unique().WithOptions().NonClustered();
        }

        private void CreateLoginsTable()
        {
            Create.Table("AspNetUserLogins")
                .WithColumn("LoginProvider").AsString(128).NotNullable()
                .WithColumn("ProviderKey").AsString(128).NotNullable()
                .WithColumn("UserId").AsString(128).NotNullable();

            Create.Index("IX_UserId")
                .OnTable("AspNetUserLogins")
                .OnColumn("UserId")
                .Ascending()
                .WithOptions()
                .NonClustered();

            Create.PrimaryKey("PK_AspNetUserLogins")
                .OnTable("AspNetUserLogins")
                .Columns("LoginProvider", "ProviderKey", "UserId");
        }

        private void CreateUsersTable()
        {
            Create.Table("AspNetUsers")
                .WithColumn("Id").AsString(128).PrimaryKey()
                .WithColumn("Email").AsString(256).Nullable()
                .WithColumn("EmailConfirmed").AsBoolean().NotNullable()
                .WithColumn("PasswordHash").AsString(int.MaxValue).Nullable()
                .WithColumn("SecurityStamp").AsString(int.MaxValue).Nullable()
                .WithColumn("PhoneNumber").AsString(int.MaxValue).Nullable()
                .WithColumn("PhoneNumberConfirmed").AsBoolean().NotNullable()
                .WithColumn("TwoFactorEnabled").AsBoolean().NotNullable()
                .WithColumn("LockoutEndDateUtc").AsDateTime().Nullable()
                .WithColumn("LockoutEnabled").AsBoolean().NotNullable()
                .WithColumn("AccessFailedCount").AsInt32().NotNullable()
                .WithColumn("Username").AsString(256).NotNullable();

            Create.Index("UserNameIndex")
                .OnTable("AspNetUsers")
                .OnColumn("Username")
                .Unique()
                .WithOptions()
                .NonClustered();
        }
    }
}