namespace Docway.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Cpf = c.String(maxLength: 150),
                        UserBaseId = c.Guid(nullable: false),
                        Weight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Height = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DateOfBirth = c.DateTime(),
                        HealthProblems = c.String(maxLength: 150),
                        AllergiesAndReactions = c.String(maxLength: 150),
                        Medicines = c.String(maxLength: 150),
                        BloodType = c.String(maxLength: 150),
                        ClientGatewayPaymentId = c.Int(nullable: false),
                        Parent_Id = c.Guid(),
                        User_Id = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Patients", t => t.Parent_Id)
                .ForeignKey("dbo.ClientGatewayPayments", t => t.ClientGatewayPaymentId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.BloodType)
                .Index(t => t.ClientGatewayPaymentId)
                .Index(t => t.Parent_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Street = c.String(maxLength: 150),
                        Number = c.String(maxLength: 150),
                        Complement = c.String(maxLength: 150),
                        Neighborhood = c.String(maxLength: 150),
                        Cep = c.String(maxLength: 150),
                        City = c.String(maxLength: 150),
                        State = c.String(maxLength: 150),
                        Landmark = c.String(maxLength: 150),
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
                        IsPrimary = c.Boolean(nullable: false),
                        Patient_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Patients", t => t.Patient_Id)
                .Index(t => t.Cep)
                .Index(t => t.City)
                .Index(t => t.State)
                .Index(t => t.IsPrimary)
                .Index(t => t.Patient_Id);
            
            CreateTable(
                "dbo.CreditCards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CardHolder = c.String(maxLength: 150),
                        Brand = c.String(maxLength: 150),
                        Token = c.String(maxLength: 150),
                        FinalNumber = c.String(maxLength: 150),
                        IsPrimary = c.Boolean(nullable: false),
                        Provider = c.Int(nullable: false),
                        PaymentMethodId = c.String(maxLength: 150),
                        Owner_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Patients", t => t.Owner_Id)
                .Index(t => t.Owner_Id);
            
            CreateTable(
                "dbo.ClientGatewayPayments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClientId = c.String(maxLength: 150),
                        GatewayPaymentId = c.Int(nullable: false),
                        GatewayPayment = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.GatewayPaymentId);
            
            CreateTable(
                "dbo.ProductSchedulers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        Name = c.String(maxLength: 45),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 45),
                        ProductType = c.Int(nullable: false),
                        Appointment_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Appointments", t => t.Appointment_Id)
                .Index(t => t.Appointment_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 150),
                        Name = c.String(maxLength: 45),
                        Email = c.String(maxLength: 256),
                        PhoneNumber = c.String(maxLength: 150),
                        UserName = c.String(nullable: false, maxLength: 256),
                        DeviceToken = c.String(maxLength: 150),
                        MerchantReference = c.String(maxLength: 150),
                        TimeZone = c.String(maxLength: 150),
                        IsDeleted = c.Boolean(nullable: false),
                        IsSUSEnabled = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(),
                        MailChimpId = c.String(maxLength: 150),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(maxLength: 150),
                        SecurityStamp = c.String(maxLength: 150),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        Address_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.Address_Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => t.Address_Id);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 150),
                        ClaimType = c.String(maxLength: 150),
                        ClaimValue = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 150),
                        ProviderKey = c.String(nullable: false, maxLength: 150),
                        UserId = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 150),
                        RoleId = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 150),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Crm = c.String(maxLength: 150),
                        CrmUF = c.String(maxLength: 150),
                        Bio = c.String(maxLength: 150),
                        AppointmentPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AppointmentRadius = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsPaylevenActive = c.Boolean(nullable: false),
                        UrgencyEnable = c.Boolean(nullable: false),
                        IsIuguActive = c.Boolean(nullable: false),
                        ServiceProviderId = c.Guid(nullable: false),
                        Identification_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Documents", t => t.Identification_Id)
                .ForeignKey("dbo.ServiceProviders", t => t.ServiceProviderId, cascadeDelete: true)
                .Index(t => t.ServiceProviderId)
                .Index(t => t.Identification_Id);
            
            CreateTable(
                "dbo.Calendars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DayOfWeek = c.Int(nullable: false),
                        Hour = c.Int(nullable: false),
                        Date = c.DateTime(),
                        IsDisponible = c.Boolean(nullable: false),
                        Appointment_Id = c.Int(),
                        Owner_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Appointments", t => t.Appointment_Id)
                .ForeignKey("dbo.Doctors", t => t.Owner_Id)
                .Index(t => t.DayOfWeek)
                .Index(t => t.Date)
                .Index(t => t.IsDisponible)
                .Index(t => t.Appointment_Id)
                .Index(t => t.Owner_Id);
            
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PromotionalCode = c.String(maxLength: 150),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        HasHealthInsurance = c.Boolean(nullable: false),
                        IsUrgency = c.Boolean(nullable: false),
                        DateAppointment = c.DateTime(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        PaymentMethod = c.Int(nullable: false),
                        PaymentStatus = c.Int(nullable: false),
                        Type = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        Address_Id = c.Int(),
                        Buyer_Id = c.String(maxLength: 150),
                        CreditCard_Id = c.Int(),
                        MedicalRecord_Id = c.Int(),
                        Seller_Id = c.String(maxLength: 150),
                        Specialty_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.Address_Id)
                .ForeignKey("dbo.Users", t => t.Buyer_Id)
                .ForeignKey("dbo.CreditCards", t => t.CreditCard_Id)
                .ForeignKey("dbo.MedicalRecords", t => t.MedicalRecord_Id)
                .ForeignKey("dbo.Users", t => t.Seller_Id)
                .ForeignKey("dbo.Specialities", t => t.Specialty_Id)
                .Index(t => t.IsUrgency)
                .Index(t => t.Status)
                .Index(t => t.Address_Id)
                .Index(t => t.Buyer_Id)
                .Index(t => t.CreditCard_Id)
                .Index(t => t.MedicalRecord_Id)
                .Index(t => t.Seller_Id)
                .Index(t => t.Specialty_Id);
            
            CreateTable(
                "dbo.MedicalRecords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Diagnostic = c.String(maxLength: 150),
                        Prescription = c.String(maxLength: 150),
                        Opinion = c.String(maxLength: 150),
                        Medicines = c.String(maxLength: 150),
                        Doctor_Id = c.Guid(),
                        Patient_Id = c.Guid(),
                        Medicine_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Doctors", t => t.Doctor_Id)
                .ForeignKey("dbo.Patients", t => t.Patient_Id)
                .ForeignKey("dbo.Medicines", t => t.Medicine_Id)
                .Index(t => t.Doctor_Id)
                .Index(t => t.Patient_Id)
                .Index(t => t.Medicine_Id);
            
            CreateTable(
                "dbo.Specialities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 45),
                        Comments = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Symptoms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 45),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReferenceId = c.String(maxLength: 150),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SellerAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StartupAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FeeAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RawResponseData = c.String(maxLength: 150),
                        CreateDate = c.DateTime(nullable: false),
                        IsFinalized = c.Boolean(nullable: false),
                        Appointment_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Appointments", t => t.Appointment_Id)
                .Index(t => t.Appointment_Id);
            
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImageUrl = c.String(maxLength: 150),
                        Doctor_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Doctors", t => t.Doctor_Id)
                .Index(t => t.Doctor_Id);
            
            CreateTable(
                "dbo.Evaluations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rating = c.Int(nullable: false),
                        Comment = c.String(maxLength: 150),
                        Doctor_Id = c.Guid(),
                        Owner_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Doctors", t => t.Doctor_Id)
                .ForeignKey("dbo.Patients", t => t.Owner_Id)
                .Index(t => t.Doctor_Id)
                .Index(t => t.Owner_Id);
            
            CreateTable(
                "dbo.ServiceProviders",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserBaseId = c.Guid(nullable: false),
                        User_Id = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Colaborators",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Agenda",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDisponible = c.Boolean(nullable: false),
                        LastUpdate = c.DateTime(nullable: false),
                        Observacao = c.String(maxLength: 150),
                        Owner_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Doctors", t => t.Owner_Id)
                .Index(t => t.IsDisponible)
                .Index(t => t.Owner_Id);
            
            CreateTable(
                "dbo.CityAutoCompletes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 45),
                        State_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StateAutoCompletes", t => t.State_Id)
                .Index(t => t.State_Id);
            
            CreateTable(
                "dbo.StateAutoCompletes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(maxLength: 150),
                        Name = c.String(maxLength: 45),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 45),
                        StateAutoComplete_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StateAutoCompletes", t => t.StateAutoComplete_Id)
                .Index(t => t.StateAutoComplete_Id);
            
            CreateTable(
                "dbo.Clinics",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ServiceProviderId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceProviders", t => t.ServiceProviderId, cascadeDelete: true)
                .Index(t => t.ServiceProviderId);
            
            CreateTable(
                "dbo.Stocks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProductId = c.Int(nullable: false),
                        ClinicId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clinics", t => t.ClinicId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.ClinicId);
            
            CreateTable(
                "dbo.Medicines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 45),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MobileInformations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OperatingSystem = c.String(maxLength: 150),
                        VersionOperatingSystem = c.String(maxLength: 150),
                        AppVersion = c.String(maxLength: 150),
                        BuildVersion = c.String(maxLength: 150),
                        LastUseDate = c.DateTime(nullable: false),
                        Owner_Id = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Owner_Id)
                .Index(t => t.Owner_Id);
            
            CreateTable(
                "dbo.ProductSchedulerPatients",
                c => new
                    {
                        ProductScheduler_Id = c.Int(nullable: false),
                        Patient_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductScheduler_Id, t.Patient_Id })
                .ForeignKey("dbo.ProductSchedulers", t => t.ProductScheduler_Id, cascadeDelete: true)
                .ForeignKey("dbo.Patients", t => t.Patient_Id, cascadeDelete: true)
                .Index(t => t.ProductScheduler_Id)
                .Index(t => t.Patient_Id);
            
            CreateTable(
                "dbo.SpecialityDoctors",
                c => new
                    {
                        Speciality_Id = c.Int(nullable: false),
                        Doctor_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Speciality_Id, t.Doctor_Id })
                .ForeignKey("dbo.Specialities", t => t.Speciality_Id, cascadeDelete: true)
                .ForeignKey("dbo.Doctors", t => t.Doctor_Id, cascadeDelete: true)
                .Index(t => t.Speciality_Id)
                .Index(t => t.Doctor_Id);
            
            CreateTable(
                "dbo.SymptomAppointments",
                c => new
                    {
                        Symptom_Id = c.Int(nullable: false),
                        Appointment_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Symptom_Id, t.Appointment_Id })
                .ForeignKey("dbo.Symptoms", t => t.Symptom_Id, cascadeDelete: true)
                .ForeignKey("dbo.Appointments", t => t.Appointment_Id, cascadeDelete: true)
                .Index(t => t.Symptom_Id)
                .Index(t => t.Appointment_Id);
            
            CreateStoredProcedure(
                "dbo.Patient_Insert",
                p => new
                    {
                        Id = p.Guid(),
                        Cpf = p.String(maxLength: 150),
                        UserBaseId = p.Guid(),
                        Weight = p.Decimal(precision: 18, scale: 2),
                        Height = p.Decimal(precision: 18, scale: 2),
                        DateOfBirth = p.DateTime(),
                        HealthProblems = p.String(maxLength: 150),
                        AllergiesAndReactions = p.String(maxLength: 150),
                        Medicines = p.String(maxLength: 150),
                        BloodType = p.String(maxLength: 150),
                        ClientGatewayPaymentId = p.Int(),
                        Parent_Id = p.Guid(),
                        User_Id = p.String(maxLength: 150),
                    },
                body:
                    @"INSERT [dbo].[Patients]([Id], [Cpf], [UserBaseId], [Weight], [Height], [DateOfBirth], [HealthProblems], [AllergiesAndReactions], [Medicines], [BloodType], [ClientGatewayPaymentId], [Parent_Id], [User_Id])
                      VALUES (@Id, @Cpf, @UserBaseId, @Weight, @Height, @DateOfBirth, @HealthProblems, @AllergiesAndReactions, @Medicines, @BloodType, @ClientGatewayPaymentId, @Parent_Id, @User_Id)"
            );
            
            CreateStoredProcedure(
                "dbo.Patient_Update",
                p => new
                    {
                        Id = p.Guid(),
                        Cpf = p.String(maxLength: 150),
                        UserBaseId = p.Guid(),
                        Weight = p.Decimal(precision: 18, scale: 2),
                        Height = p.Decimal(precision: 18, scale: 2),
                        DateOfBirth = p.DateTime(),
                        HealthProblems = p.String(maxLength: 150),
                        AllergiesAndReactions = p.String(maxLength: 150),
                        Medicines = p.String(maxLength: 150),
                        BloodType = p.String(maxLength: 150),
                        ClientGatewayPaymentId = p.Int(),
                        Parent_Id = p.Guid(),
                        User_Id = p.String(maxLength: 150),
                    },
                body:
                    @"UPDATE [dbo].[Patients]
                      SET [Cpf] = @Cpf, [UserBaseId] = @UserBaseId, [Weight] = @Weight, [Height] = @Height, [DateOfBirth] = @DateOfBirth, [HealthProblems] = @HealthProblems, [AllergiesAndReactions] = @AllergiesAndReactions, [Medicines] = @Medicines, [BloodType] = @BloodType, [ClientGatewayPaymentId] = @ClientGatewayPaymentId, [Parent_Id] = @Parent_Id, [User_Id] = @User_Id
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.Patient_Delete",
                p => new
                    {
                        Id = p.Guid(),
                        Parent_Id = p.Guid(),
                        User_Id = p.String(maxLength: 150),
                    },
                body:
                    @"DELETE [dbo].[Patients]
                      WHERE ((([Id] = @Id) AND (([Parent_Id] = @Parent_Id) OR ([Parent_Id] IS NULL AND @Parent_Id IS NULL))) AND (([User_Id] = @User_Id) OR ([User_Id] IS NULL AND @User_Id IS NULL)))"
            );
            
            CreateStoredProcedure(
                "dbo.CreditCard_Insert",
                p => new
                    {
                        CardHolder = p.String(maxLength: 150),
                        Brand = p.String(maxLength: 150),
                        Token = p.String(maxLength: 150),
                        FinalNumber = p.String(maxLength: 150),
                        IsPrimary = p.Boolean(),
                        Provider = p.Int(),
                        PaymentMethodId = p.String(maxLength: 150),
                        Owner_Id = p.Guid(),
                    },
                body:
                    @"INSERT [dbo].[CreditCards]([CardHolder], [Brand], [Token], [FinalNumber], [IsPrimary], [Provider], [PaymentMethodId], [Owner_Id])
                      VALUES (@CardHolder, @Brand, @Token, @FinalNumber, @IsPrimary, @Provider, @PaymentMethodId, @Owner_Id)
                      
                      DECLARE @Id int
                      SELECT @Id = [Id]
                      FROM [dbo].[CreditCards]
                      WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()
                      
                      SELECT t0.[Id]
                      FROM [dbo].[CreditCards] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[Id] = @Id"
            );
            
            CreateStoredProcedure(
                "dbo.CreditCard_Update",
                p => new
                    {
                        Id = p.Int(),
                        CardHolder = p.String(maxLength: 150),
                        Brand = p.String(maxLength: 150),
                        Token = p.String(maxLength: 150),
                        FinalNumber = p.String(maxLength: 150),
                        IsPrimary = p.Boolean(),
                        Provider = p.Int(),
                        PaymentMethodId = p.String(maxLength: 150),
                        Owner_Id = p.Guid(),
                    },
                body:
                    @"UPDATE [dbo].[CreditCards]
                      SET [CardHolder] = @CardHolder, [Brand] = @Brand, [Token] = @Token, [FinalNumber] = @FinalNumber, [IsPrimary] = @IsPrimary, [Provider] = @Provider, [PaymentMethodId] = @PaymentMethodId, [Owner_Id] = @Owner_Id
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.CreditCard_Delete",
                p => new
                    {
                        Id = p.Int(),
                        Owner_Id = p.Guid(),
                    },
                body:
                    @"DELETE [dbo].[CreditCards]
                      WHERE (([Id] = @Id) AND (([Owner_Id] = @Owner_Id) OR ([Owner_Id] IS NULL AND @Owner_Id IS NULL)))"
            );
            
            CreateStoredProcedure(
                "dbo.Doctor_Insert",
                p => new
                    {
                        Id = p.Guid(),
                        Crm = p.String(maxLength: 150),
                        CrmUF = p.String(maxLength: 150),
                        Bio = p.String(maxLength: 150),
                        AppointmentPrice = p.Decimal(precision: 18, scale: 2),
                        AppointmentRadius = p.Int(),
                        IsActive = p.Boolean(),
                        IsPaylevenActive = p.Boolean(),
                        UrgencyEnable = p.Boolean(),
                        IsIuguActive = p.Boolean(),
                        ServiceProviderId = p.Guid(),
                        Identification_Id = p.Int(),
                    },
                body:
                    @"INSERT [dbo].[Doctors]([Id], [Crm], [CrmUF], [Bio], [AppointmentPrice], [AppointmentRadius], [IsActive], [IsPaylevenActive], [UrgencyEnable], [IsIuguActive], [ServiceProviderId], [Identification_Id])
                      VALUES (@Id, @Crm, @CrmUF, @Bio, @AppointmentPrice, @AppointmentRadius, @IsActive, @IsPaylevenActive, @UrgencyEnable, @IsIuguActive, @ServiceProviderId, @Identification_Id)"
            );
            
            CreateStoredProcedure(
                "dbo.Doctor_Update",
                p => new
                    {
                        Id = p.Guid(),
                        Crm = p.String(maxLength: 150),
                        CrmUF = p.String(maxLength: 150),
                        Bio = p.String(maxLength: 150),
                        AppointmentPrice = p.Decimal(precision: 18, scale: 2),
                        AppointmentRadius = p.Int(),
                        IsActive = p.Boolean(),
                        IsPaylevenActive = p.Boolean(),
                        UrgencyEnable = p.Boolean(),
                        IsIuguActive = p.Boolean(),
                        ServiceProviderId = p.Guid(),
                        Identification_Id = p.Int(),
                    },
                body:
                    @"UPDATE [dbo].[Doctors]
                      SET [Crm] = @Crm, [CrmUF] = @CrmUF, [Bio] = @Bio, [AppointmentPrice] = @AppointmentPrice, [AppointmentRadius] = @AppointmentRadius, [IsActive] = @IsActive, [IsPaylevenActive] = @IsPaylevenActive, [UrgencyEnable] = @UrgencyEnable, [IsIuguActive] = @IsIuguActive, [ServiceProviderId] = @ServiceProviderId, [Identification_Id] = @Identification_Id
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.Doctor_Delete",
                p => new
                    {
                        Id = p.Guid(),
                        Identification_Id = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[Doctors]
                      WHERE (([Id] = @Id) AND (([Identification_Id] = @Identification_Id) OR ([Identification_Id] IS NULL AND @Identification_Id IS NULL)))"
            );
            
            CreateStoredProcedure(
                "dbo.Appointment_Insert",
                p => new
                    {
                        PromotionalCode = p.String(maxLength: 150),
                        Price = p.Decimal(precision: 18, scale: 2),
                        HasHealthInsurance = p.Boolean(),
                        IsUrgency = p.Boolean(),
                        DateAppointment = p.DateTime(),
                        CreateDate = p.DateTime(),
                        PaymentMethod = p.Int(),
                        PaymentStatus = p.Int(),
                        Type = p.Int(),
                        Status = p.Int(),
                        Address_Id = p.Int(),
                        Buyer_Id = p.String(maxLength: 150),
                        CreditCard_Id = p.Int(),
                        MedicalRecord_Id = p.Int(),
                        Seller_Id = p.String(maxLength: 150),
                        Specialty_Id = p.Int(),
                    },
                body:
                    @"INSERT [dbo].[Appointments]([PromotionalCode], [Price], [HasHealthInsurance], [IsUrgency], [DateAppointment], [CreateDate], [PaymentMethod], [PaymentStatus], [Type], [Status], [Address_Id], [Buyer_Id], [CreditCard_Id], [MedicalRecord_Id], [Seller_Id], [Specialty_Id])
                      VALUES (@PromotionalCode, @Price, @HasHealthInsurance, @IsUrgency, @DateAppointment, @CreateDate, @PaymentMethod, @PaymentStatus, @Type, @Status, @Address_Id, @Buyer_Id, @CreditCard_Id, @MedicalRecord_Id, @Seller_Id, @Specialty_Id)
                      
                      DECLARE @Id int
                      SELECT @Id = [Id]
                      FROM [dbo].[Appointments]
                      WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()
                      
                      SELECT t0.[Id]
                      FROM [dbo].[Appointments] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[Id] = @Id"
            );
            
            CreateStoredProcedure(
                "dbo.Appointment_Update",
                p => new
                    {
                        Id = p.Int(),
                        PromotionalCode = p.String(maxLength: 150),
                        Price = p.Decimal(precision: 18, scale: 2),
                        HasHealthInsurance = p.Boolean(),
                        IsUrgency = p.Boolean(),
                        DateAppointment = p.DateTime(),
                        CreateDate = p.DateTime(),
                        PaymentMethod = p.Int(),
                        PaymentStatus = p.Int(),
                        Type = p.Int(),
                        Status = p.Int(),
                        Address_Id = p.Int(),
                        Buyer_Id = p.String(maxLength: 150),
                        CreditCard_Id = p.Int(),
                        MedicalRecord_Id = p.Int(),
                        Seller_Id = p.String(maxLength: 150),
                        Specialty_Id = p.Int(),
                    },
                body:
                    @"UPDATE [dbo].[Appointments]
                      SET [PromotionalCode] = @PromotionalCode, [Price] = @Price, [HasHealthInsurance] = @HasHealthInsurance, [IsUrgency] = @IsUrgency, [DateAppointment] = @DateAppointment, [CreateDate] = @CreateDate, [PaymentMethod] = @PaymentMethod, [PaymentStatus] = @PaymentStatus, [Type] = @Type, [Status] = @Status, [Address_Id] = @Address_Id, [Buyer_Id] = @Buyer_Id, [CreditCard_Id] = @CreditCard_Id, [MedicalRecord_Id] = @MedicalRecord_Id, [Seller_Id] = @Seller_Id, [Specialty_Id] = @Specialty_Id
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.Appointment_Delete",
                p => new
                    {
                        Id = p.Int(),
                        Address_Id = p.Int(),
                        Buyer_Id = p.String(maxLength: 150),
                        CreditCard_Id = p.Int(),
                        MedicalRecord_Id = p.Int(),
                        Seller_Id = p.String(maxLength: 150),
                        Specialty_Id = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[Appointments]
                      WHERE ((((((([Id] = @Id) AND (([Address_Id] = @Address_Id) OR ([Address_Id] IS NULL AND @Address_Id IS NULL))) AND (([Buyer_Id] = @Buyer_Id) OR ([Buyer_Id] IS NULL AND @Buyer_Id IS NULL))) AND (([CreditCard_Id] = @CreditCard_Id) OR ([CreditCard_Id] IS NULL AND @CreditCard_Id IS NULL))) AND (([MedicalRecord_Id] = @MedicalRecord_Id) OR ([MedicalRecord_Id] IS NULL AND @MedicalRecord_Id IS NULL))) AND (([Seller_Id] = @Seller_Id) OR ([Seller_Id] IS NULL AND @Seller_Id IS NULL))) AND (([Specialty_Id] = @Specialty_Id) OR ([Specialty_Id] IS NULL AND @Specialty_Id IS NULL)))"
            );
            
            CreateStoredProcedure(
                "dbo.MedicalRecord_Insert",
                p => new
                    {
                        Diagnostic = p.String(maxLength: 150),
                        Prescription = p.String(maxLength: 150),
                        Opinion = p.String(maxLength: 150),
                        Medicines = p.String(maxLength: 150),
                        Doctor_Id = p.Guid(),
                        Patient_Id = p.Guid(),
                        Medicine_Id = p.Int(),
                    },
                body:
                    @"INSERT [dbo].[MedicalRecords]([Diagnostic], [Prescription], [Opinion], [Medicines], [Doctor_Id], [Patient_Id], [Medicine_Id])
                      VALUES (@Diagnostic, @Prescription, @Opinion, @Medicines, @Doctor_Id, @Patient_Id, @Medicine_Id)
                      
                      DECLARE @Id int
                      SELECT @Id = [Id]
                      FROM [dbo].[MedicalRecords]
                      WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()
                      
                      SELECT t0.[Id]
                      FROM [dbo].[MedicalRecords] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[Id] = @Id"
            );
            
            CreateStoredProcedure(
                "dbo.MedicalRecord_Update",
                p => new
                    {
                        Id = p.Int(),
                        Diagnostic = p.String(maxLength: 150),
                        Prescription = p.String(maxLength: 150),
                        Opinion = p.String(maxLength: 150),
                        Medicines = p.String(maxLength: 150),
                        Doctor_Id = p.Guid(),
                        Patient_Id = p.Guid(),
                        Medicine_Id = p.Int(),
                    },
                body:
                    @"UPDATE [dbo].[MedicalRecords]
                      SET [Diagnostic] = @Diagnostic, [Prescription] = @Prescription, [Opinion] = @Opinion, [Medicines] = @Medicines, [Doctor_Id] = @Doctor_Id, [Patient_Id] = @Patient_Id, [Medicine_Id] = @Medicine_Id
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.MedicalRecord_Delete",
                p => new
                    {
                        Id = p.Int(),
                        Doctor_Id = p.Guid(),
                        Patient_Id = p.Guid(),
                        Medicine_Id = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[MedicalRecords]
                      WHERE (((([Id] = @Id) AND (([Doctor_Id] = @Doctor_Id) OR ([Doctor_Id] IS NULL AND @Doctor_Id IS NULL))) AND (([Patient_Id] = @Patient_Id) OR ([Patient_Id] IS NULL AND @Patient_Id IS NULL))) AND (([Medicine_Id] = @Medicine_Id) OR ([Medicine_Id] IS NULL AND @Medicine_Id IS NULL)))"
            );
            
            CreateStoredProcedure(
                "dbo.Transaction_Insert",
                p => new
                    {
                        ReferenceId = p.String(maxLength: 150),
                        TotalAmount = p.Decimal(precision: 18, scale: 2),
                        SellerAmount = p.Decimal(precision: 18, scale: 2),
                        StartupAmount = p.Decimal(precision: 18, scale: 2),
                        FeeAmount = p.Decimal(precision: 18, scale: 2),
                        RawResponseData = p.String(maxLength: 150),
                        CreateDate = p.DateTime(),
                        IsFinalized = p.Boolean(),
                        Appointment_Id = p.Int(),
                    },
                body:
                    @"INSERT [dbo].[Transactions]([ReferenceId], [TotalAmount], [SellerAmount], [StartupAmount], [FeeAmount], [RawResponseData], [CreateDate], [IsFinalized], [Appointment_Id])
                      VALUES (@ReferenceId, @TotalAmount, @SellerAmount, @StartupAmount, @FeeAmount, @RawResponseData, @CreateDate, @IsFinalized, @Appointment_Id)
                      
                      DECLARE @Id int
                      SELECT @Id = [Id]
                      FROM [dbo].[Transactions]
                      WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()
                      
                      SELECT t0.[Id]
                      FROM [dbo].[Transactions] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[Id] = @Id"
            );
            
            CreateStoredProcedure(
                "dbo.Transaction_Update",
                p => new
                    {
                        Id = p.Int(),
                        ReferenceId = p.String(maxLength: 150),
                        TotalAmount = p.Decimal(precision: 18, scale: 2),
                        SellerAmount = p.Decimal(precision: 18, scale: 2),
                        StartupAmount = p.Decimal(precision: 18, scale: 2),
                        FeeAmount = p.Decimal(precision: 18, scale: 2),
                        RawResponseData = p.String(maxLength: 150),
                        CreateDate = p.DateTime(),
                        IsFinalized = p.Boolean(),
                        Appointment_Id = p.Int(),
                    },
                body:
                    @"UPDATE [dbo].[Transactions]
                      SET [ReferenceId] = @ReferenceId, [TotalAmount] = @TotalAmount, [SellerAmount] = @SellerAmount, [StartupAmount] = @StartupAmount, [FeeAmount] = @FeeAmount, [RawResponseData] = @RawResponseData, [CreateDate] = @CreateDate, [IsFinalized] = @IsFinalized, [Appointment_Id] = @Appointment_Id
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.Transaction_Delete",
                p => new
                    {
                        Id = p.Int(),
                        Appointment_Id = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[Transactions]
                      WHERE (([Id] = @Id) AND (([Appointment_Id] = @Appointment_Id) OR ([Appointment_Id] IS NULL AND @Appointment_Id IS NULL)))"
            );
            
            CreateStoredProcedure(
                "dbo.Document_Insert",
                p => new
                    {
                        ImageUrl = p.String(maxLength: 150),
                        Doctor_Id = p.Guid(),
                    },
                body:
                    @"INSERT [dbo].[Documents]([ImageUrl], [Doctor_Id])
                      VALUES (@ImageUrl, @Doctor_Id)
                      
                      DECLARE @Id int
                      SELECT @Id = [Id]
                      FROM [dbo].[Documents]
                      WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()
                      
                      SELECT t0.[Id]
                      FROM [dbo].[Documents] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[Id] = @Id"
            );
            
            CreateStoredProcedure(
                "dbo.Document_Update",
                p => new
                    {
                        Id = p.Int(),
                        ImageUrl = p.String(maxLength: 150),
                        Doctor_Id = p.Guid(),
                    },
                body:
                    @"UPDATE [dbo].[Documents]
                      SET [ImageUrl] = @ImageUrl, [Doctor_Id] = @Doctor_Id
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.Document_Delete",
                p => new
                    {
                        Id = p.Int(),
                        Doctor_Id = p.Guid(),
                    },
                body:
                    @"DELETE [dbo].[Documents]
                      WHERE (([Id] = @Id) AND (([Doctor_Id] = @Doctor_Id) OR ([Doctor_Id] IS NULL AND @Doctor_Id IS NULL)))"
            );
            
            CreateStoredProcedure(
                "dbo.Colaborator_Insert",
                p => new
                    {
                        Id = p.Guid(),
                    },
                body:
                    @"INSERT [dbo].[Colaborators]([Id])
                      VALUES (@Id)"
            );
            
            CreateStoredProcedure(
                "dbo.Colaborator_Update",
                p => new
                    {
                        Id = p.Guid(),
                    },
                body:
                    @"RETURN"
            );
            
            CreateStoredProcedure(
                "dbo.Colaborator_Delete",
                p => new
                    {
                        Id = p.Guid(),
                    },
                body:
                    @"DELETE [dbo].[Colaborators]
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.Agenda_Insert",
                p => new
                    {
                        IsDisponible = p.Boolean(),
                        LastUpdate = p.DateTime(),
                        Observacao = p.String(maxLength: 150),
                        Owner_Id = p.Guid(),
                    },
                body:
                    @"INSERT [dbo].[Agenda]([IsDisponible], [LastUpdate], [Observacao], [Owner_Id])
                      VALUES (@IsDisponible, @LastUpdate, @Observacao, @Owner_Id)
                      
                      DECLARE @Id int
                      SELECT @Id = [Id]
                      FROM [dbo].[Agenda]
                      WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()
                      
                      SELECT t0.[Id]
                      FROM [dbo].[Agenda] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[Id] = @Id"
            );
            
            CreateStoredProcedure(
                "dbo.Agenda_Update",
                p => new
                    {
                        Id = p.Int(),
                        IsDisponible = p.Boolean(),
                        LastUpdate = p.DateTime(),
                        Observacao = p.String(maxLength: 150),
                        Owner_Id = p.Guid(),
                    },
                body:
                    @"UPDATE [dbo].[Agenda]
                      SET [IsDisponible] = @IsDisponible, [LastUpdate] = @LastUpdate, [Observacao] = @Observacao, [Owner_Id] = @Owner_Id
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.Agenda_Delete",
                p => new
                    {
                        Id = p.Int(),
                        Owner_Id = p.Guid(),
                    },
                body:
                    @"DELETE [dbo].[Agenda]
                      WHERE (([Id] = @Id) AND (([Owner_Id] = @Owner_Id) OR ([Owner_Id] IS NULL AND @Owner_Id IS NULL)))"
            );
            
            CreateStoredProcedure(
                "dbo.CityAutoComplete_Insert",
                p => new
                    {
                        Name = p.String(maxLength: 45),
                        State_Id = p.Int(),
                    },
                body:
                    @"INSERT [dbo].[CityAutoCompletes]([Name], [State_Id])
                      VALUES (@Name, @State_Id)
                      
                      DECLARE @Id int
                      SELECT @Id = [Id]
                      FROM [dbo].[CityAutoCompletes]
                      WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()
                      
                      SELECT t0.[Id]
                      FROM [dbo].[CityAutoCompletes] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[Id] = @Id"
            );
            
            CreateStoredProcedure(
                "dbo.CityAutoComplete_Update",
                p => new
                    {
                        Id = p.Int(),
                        Name = p.String(maxLength: 45),
                        State_Id = p.Int(),
                    },
                body:
                    @"UPDATE [dbo].[CityAutoCompletes]
                      SET [Name] = @Name, [State_Id] = @State_Id
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.CityAutoComplete_Delete",
                p => new
                    {
                        Id = p.Int(),
                        State_Id = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[CityAutoCompletes]
                      WHERE (([Id] = @Id) AND (([State_Id] = @State_Id) OR ([State_Id] IS NULL AND @State_Id IS NULL)))"
            );
            
            CreateStoredProcedure(
                "dbo.Clinic_Insert",
                p => new
                    {
                        Id = p.Guid(),
                        ServiceProviderId = p.Guid(),
                    },
                body:
                    @"INSERT [dbo].[Clinics]([Id], [ServiceProviderId])
                      VALUES (@Id, @ServiceProviderId)"
            );
            
            CreateStoredProcedure(
                "dbo.Clinic_Update",
                p => new
                    {
                        Id = p.Guid(),
                        ServiceProviderId = p.Guid(),
                    },
                body:
                    @"UPDATE [dbo].[Clinics]
                      SET [ServiceProviderId] = @ServiceProviderId
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.Clinic_Delete",
                p => new
                    {
                        Id = p.Guid(),
                    },
                body:
                    @"DELETE [dbo].[Clinics]
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.Medicine_Insert",
                p => new
                    {
                        Name = p.String(maxLength: 45),
                    },
                body:
                    @"INSERT [dbo].[Medicines]([Name])
                      VALUES (@Name)
                      
                      DECLARE @Id int
                      SELECT @Id = [Id]
                      FROM [dbo].[Medicines]
                      WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()
                      
                      SELECT t0.[Id]
                      FROM [dbo].[Medicines] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[Id] = @Id"
            );
            
            CreateStoredProcedure(
                "dbo.Medicine_Update",
                p => new
                    {
                        Id = p.Int(),
                        Name = p.String(maxLength: 45),
                    },
                body:
                    @"UPDATE [dbo].[Medicines]
                      SET [Name] = @Name
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.Medicine_Delete",
                p => new
                    {
                        Id = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[Medicines]
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.MobileInformation_Insert",
                p => new
                    {
                        OperatingSystem = p.String(maxLength: 150),
                        VersionOperatingSystem = p.String(maxLength: 150),
                        AppVersion = p.String(maxLength: 150),
                        BuildVersion = p.String(maxLength: 150),
                        LastUseDate = p.DateTime(),
                        Owner_Id = p.String(maxLength: 150),
                    },
                body:
                    @"INSERT [dbo].[MobileInformations]([OperatingSystem], [VersionOperatingSystem], [AppVersion], [BuildVersion], [LastUseDate], [Owner_Id])
                      VALUES (@OperatingSystem, @VersionOperatingSystem, @AppVersion, @BuildVersion, @LastUseDate, @Owner_Id)
                      
                      DECLARE @Id int
                      SELECT @Id = [Id]
                      FROM [dbo].[MobileInformations]
                      WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()
                      
                      SELECT t0.[Id]
                      FROM [dbo].[MobileInformations] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[Id] = @Id"
            );
            
            CreateStoredProcedure(
                "dbo.MobileInformation_Update",
                p => new
                    {
                        Id = p.Int(),
                        OperatingSystem = p.String(maxLength: 150),
                        VersionOperatingSystem = p.String(maxLength: 150),
                        AppVersion = p.String(maxLength: 150),
                        BuildVersion = p.String(maxLength: 150),
                        LastUseDate = p.DateTime(),
                        Owner_Id = p.String(maxLength: 150),
                    },
                body:
                    @"UPDATE [dbo].[MobileInformations]
                      SET [OperatingSystem] = @OperatingSystem, [VersionOperatingSystem] = @VersionOperatingSystem, [AppVersion] = @AppVersion, [BuildVersion] = @BuildVersion, [LastUseDate] = @LastUseDate, [Owner_Id] = @Owner_Id
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.MobileInformation_Delete",
                p => new
                    {
                        Id = p.Int(),
                        Owner_Id = p.String(maxLength: 150),
                    },
                body:
                    @"DELETE [dbo].[MobileInformations]
                      WHERE (([Id] = @Id) AND (([Owner_Id] = @Owner_Id) OR ([Owner_Id] IS NULL AND @Owner_Id IS NULL)))"
            );
            
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.MobileInformation_Delete");
            DropStoredProcedure("dbo.MobileInformation_Update");
            DropStoredProcedure("dbo.MobileInformation_Insert");
            DropStoredProcedure("dbo.Medicine_Delete");
            DropStoredProcedure("dbo.Medicine_Update");
            DropStoredProcedure("dbo.Medicine_Insert");
            DropStoredProcedure("dbo.Clinic_Delete");
            DropStoredProcedure("dbo.Clinic_Update");
            DropStoredProcedure("dbo.Clinic_Insert");
            DropStoredProcedure("dbo.CityAutoComplete_Delete");
            DropStoredProcedure("dbo.CityAutoComplete_Update");
            DropStoredProcedure("dbo.CityAutoComplete_Insert");
            DropStoredProcedure("dbo.Agenda_Delete");
            DropStoredProcedure("dbo.Agenda_Update");
            DropStoredProcedure("dbo.Agenda_Insert");
            DropStoredProcedure("dbo.Colaborator_Delete");
            DropStoredProcedure("dbo.Colaborator_Update");
            DropStoredProcedure("dbo.Colaborator_Insert");
            DropStoredProcedure("dbo.Document_Delete");
            DropStoredProcedure("dbo.Document_Update");
            DropStoredProcedure("dbo.Document_Insert");
            DropStoredProcedure("dbo.Transaction_Delete");
            DropStoredProcedure("dbo.Transaction_Update");
            DropStoredProcedure("dbo.Transaction_Insert");
            DropStoredProcedure("dbo.MedicalRecord_Delete");
            DropStoredProcedure("dbo.MedicalRecord_Update");
            DropStoredProcedure("dbo.MedicalRecord_Insert");
            DropStoredProcedure("dbo.Appointment_Delete");
            DropStoredProcedure("dbo.Appointment_Update");
            DropStoredProcedure("dbo.Appointment_Insert");
            DropStoredProcedure("dbo.Doctor_Delete");
            DropStoredProcedure("dbo.Doctor_Update");
            DropStoredProcedure("dbo.Doctor_Insert");
            DropStoredProcedure("dbo.CreditCard_Delete");
            DropStoredProcedure("dbo.CreditCard_Update");
            DropStoredProcedure("dbo.CreditCard_Insert");
            DropStoredProcedure("dbo.Patient_Delete");
            DropStoredProcedure("dbo.Patient_Update");
            DropStoredProcedure("dbo.Patient_Insert");
            DropForeignKey("dbo.MobileInformations", "Owner_Id", "dbo.Users");
            DropForeignKey("dbo.MedicalRecords", "Medicine_Id", "dbo.Medicines");
            DropForeignKey("dbo.Stocks", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Stocks", "ClinicId", "dbo.Clinics");
            DropForeignKey("dbo.Clinics", "ServiceProviderId", "dbo.ServiceProviders");
            DropForeignKey("dbo.CityAutoCompletes", "State_Id", "dbo.StateAutoCompletes");
            DropForeignKey("dbo.Cities", "StateAutoComplete_Id", "dbo.StateAutoCompletes");
            DropForeignKey("dbo.Agenda", "Owner_Id", "dbo.Doctors");
            DropForeignKey("dbo.Doctors", "ServiceProviderId", "dbo.ServiceProviders");
            DropForeignKey("dbo.ServiceProviders", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Doctors", "Identification_Id", "dbo.Documents");
            DropForeignKey("dbo.Evaluations", "Owner_Id", "dbo.Patients");
            DropForeignKey("dbo.Evaluations", "Doctor_Id", "dbo.Doctors");
            DropForeignKey("dbo.Documents", "Doctor_Id", "dbo.Doctors");
            DropForeignKey("dbo.Calendars", "Owner_Id", "dbo.Doctors");
            DropForeignKey("dbo.Calendars", "Appointment_Id", "dbo.Appointments");
            DropForeignKey("dbo.Transactions", "Appointment_Id", "dbo.Appointments");
            DropForeignKey("dbo.SymptomAppointments", "Appointment_Id", "dbo.Appointments");
            DropForeignKey("dbo.SymptomAppointments", "Symptom_Id", "dbo.Symptoms");
            DropForeignKey("dbo.SpecialityDoctors", "Doctor_Id", "dbo.Doctors");
            DropForeignKey("dbo.SpecialityDoctors", "Speciality_Id", "dbo.Specialities");
            DropForeignKey("dbo.Appointments", "Specialty_Id", "dbo.Specialities");
            DropForeignKey("dbo.Appointments", "Seller_Id", "dbo.Users");
            DropForeignKey("dbo.Products", "Appointment_Id", "dbo.Appointments");
            DropForeignKey("dbo.Appointments", "MedicalRecord_Id", "dbo.MedicalRecords");
            DropForeignKey("dbo.MedicalRecords", "Patient_Id", "dbo.Patients");
            DropForeignKey("dbo.MedicalRecords", "Doctor_Id", "dbo.Doctors");
            DropForeignKey("dbo.Appointments", "CreditCard_Id", "dbo.CreditCards");
            DropForeignKey("dbo.Appointments", "Buyer_Id", "dbo.Users");
            DropForeignKey("dbo.Appointments", "Address_Id", "dbo.Addresses");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Patients", "User_Id", "dbo.Users");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.Users");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.Users");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "Address_Id", "dbo.Addresses");
            DropForeignKey("dbo.ProductSchedulers", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductSchedulerPatients", "Patient_Id", "dbo.Patients");
            DropForeignKey("dbo.ProductSchedulerPatients", "ProductScheduler_Id", "dbo.ProductSchedulers");
            DropForeignKey("dbo.Patients", "ClientGatewayPaymentId", "dbo.ClientGatewayPayments");
            DropForeignKey("dbo.Patients", "Parent_Id", "dbo.Patients");
            DropForeignKey("dbo.CreditCards", "Owner_Id", "dbo.Patients");
            DropForeignKey("dbo.Addresses", "Patient_Id", "dbo.Patients");
            DropIndex("dbo.SymptomAppointments", new[] { "Appointment_Id" });
            DropIndex("dbo.SymptomAppointments", new[] { "Symptom_Id" });
            DropIndex("dbo.SpecialityDoctors", new[] { "Doctor_Id" });
            DropIndex("dbo.SpecialityDoctors", new[] { "Speciality_Id" });
            DropIndex("dbo.ProductSchedulerPatients", new[] { "Patient_Id" });
            DropIndex("dbo.ProductSchedulerPatients", new[] { "ProductScheduler_Id" });
            DropIndex("dbo.MobileInformations", new[] { "Owner_Id" });
            DropIndex("dbo.Stocks", new[] { "ClinicId" });
            DropIndex("dbo.Stocks", new[] { "ProductId" });
            DropIndex("dbo.Clinics", new[] { "ServiceProviderId" });
            DropIndex("dbo.Cities", new[] { "StateAutoComplete_Id" });
            DropIndex("dbo.CityAutoCompletes", new[] { "State_Id" });
            DropIndex("dbo.Agenda", new[] { "Owner_Id" });
            DropIndex("dbo.Agenda", new[] { "IsDisponible" });
            DropIndex("dbo.ServiceProviders", new[] { "User_Id" });
            DropIndex("dbo.Evaluations", new[] { "Owner_Id" });
            DropIndex("dbo.Evaluations", new[] { "Doctor_Id" });
            DropIndex("dbo.Documents", new[] { "Doctor_Id" });
            DropIndex("dbo.Transactions", new[] { "Appointment_Id" });
            DropIndex("dbo.MedicalRecords", new[] { "Medicine_Id" });
            DropIndex("dbo.MedicalRecords", new[] { "Patient_Id" });
            DropIndex("dbo.MedicalRecords", new[] { "Doctor_Id" });
            DropIndex("dbo.Appointments", new[] { "Specialty_Id" });
            DropIndex("dbo.Appointments", new[] { "Seller_Id" });
            DropIndex("dbo.Appointments", new[] { "MedicalRecord_Id" });
            DropIndex("dbo.Appointments", new[] { "CreditCard_Id" });
            DropIndex("dbo.Appointments", new[] { "Buyer_Id" });
            DropIndex("dbo.Appointments", new[] { "Address_Id" });
            DropIndex("dbo.Appointments", new[] { "Status" });
            DropIndex("dbo.Appointments", new[] { "IsUrgency" });
            DropIndex("dbo.Calendars", new[] { "Owner_Id" });
            DropIndex("dbo.Calendars", new[] { "Appointment_Id" });
            DropIndex("dbo.Calendars", new[] { "IsDisponible" });
            DropIndex("dbo.Calendars", new[] { "Date" });
            DropIndex("dbo.Calendars", new[] { "DayOfWeek" });
            DropIndex("dbo.Doctors", new[] { "Identification_Id" });
            DropIndex("dbo.Doctors", new[] { "ServiceProviderId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.Users", new[] { "Address_Id" });
            DropIndex("dbo.Users", "UserNameIndex");
            DropIndex("dbo.Products", new[] { "Appointment_Id" });
            DropIndex("dbo.ProductSchedulers", new[] { "ProductId" });
            DropIndex("dbo.ClientGatewayPayments", new[] { "GatewayPaymentId" });
            DropIndex("dbo.CreditCards", new[] { "Owner_Id" });
            DropIndex("dbo.Addresses", new[] { "Patient_Id" });
            DropIndex("dbo.Addresses", new[] { "IsPrimary" });
            DropIndex("dbo.Addresses", new[] { "State" });
            DropIndex("dbo.Addresses", new[] { "City" });
            DropIndex("dbo.Addresses", new[] { "Cep" });
            DropIndex("dbo.Patients", new[] { "User_Id" });
            DropIndex("dbo.Patients", new[] { "Parent_Id" });
            DropIndex("dbo.Patients", new[] { "ClientGatewayPaymentId" });
            DropIndex("dbo.Patients", new[] { "BloodType" });
            DropTable("dbo.SymptomAppointments");
            DropTable("dbo.SpecialityDoctors");
            DropTable("dbo.ProductSchedulerPatients");
            DropTable("dbo.MobileInformations");
            DropTable("dbo.Medicines");
            DropTable("dbo.Stocks");
            DropTable("dbo.Clinics");
            DropTable("dbo.Cities");
            DropTable("dbo.StateAutoCompletes");
            DropTable("dbo.CityAutoCompletes");
            DropTable("dbo.Agenda");
            DropTable("dbo.Colaborators");
            DropTable("dbo.ServiceProviders");
            DropTable("dbo.Evaluations");
            DropTable("dbo.Documents");
            DropTable("dbo.Transactions");
            DropTable("dbo.Symptoms");
            DropTable("dbo.Specialities");
            DropTable("dbo.MedicalRecords");
            DropTable("dbo.Appointments");
            DropTable("dbo.Calendars");
            DropTable("dbo.Doctors");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.Users");
            DropTable("dbo.Products");
            DropTable("dbo.ProductSchedulers");
            DropTable("dbo.ClientGatewayPayments");
            DropTable("dbo.CreditCards");
            DropTable("dbo.Addresses");
            DropTable("dbo.Patients");
        }
    }
}
