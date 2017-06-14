namespace Docway.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Spatial;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "Address_Id", "dbo.Addresses");
            DropForeignKey("dbo.Patients", "ClientGatewayPaymentId", "dbo.ClientGatewayPayments");
            DropForeignKey("dbo.Appointments", "Buyer_Id", "dbo.Users");
            DropForeignKey("dbo.Appointments", "Seller_Id", "dbo.Users");
            DropIndex("dbo.Patients", new[] { "ClientGatewayPaymentId" });
            DropIndex("dbo.Users", new[] { "Address_Id" });
            DropIndex("dbo.Appointments", new[] { "Buyer_Id" });
            DropIndex("dbo.Appointments", new[] { "Seller_Id" });
            RenameColumn(table: "dbo.Patients", name: "ClientGatewayPaymentId", newName: "GatewayPayment_Id");
            RenameColumn(table: "dbo.Appointments", name: "Buyer_Id", newName: "BuyerId");
            RenameColumn(table: "dbo.Appointments", name: "Seller_Id", newName: "SellerId");
            AddColumn("dbo.Addresses", "Location", c => c.Geography());
            AddColumn("dbo.Doctors", "DateOfBirth", c => c.DateTime(nullable: false));
            AddColumn("dbo.Doctors", "Cpf", c => c.String(maxLength: 150));
            AddColumn("dbo.Doctors", "UserBaseId", c => c.Guid(nullable: false));
            AddColumn("dbo.Doctors", "Address_Id", c => c.Int());
            AddColumn("dbo.Doctors", "User_Id", c => c.String(maxLength: 150));
            AlterColumn("dbo.Patients", "GatewayPayment_Id", c => c.Int());
            AlterColumn("dbo.Appointments", "BuyerId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Appointments", "SellerId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Appointments", "SellerId");
            CreateIndex("dbo.Appointments", "BuyerId");
            CreateIndex("dbo.Patients", "GatewayPayment_Id");
            CreateIndex("dbo.Doctors", "Address_Id");
            CreateIndex("dbo.Doctors", "User_Id");
            AddForeignKey("dbo.Doctors", "Address_Id", "dbo.Addresses", "Id");
            AddForeignKey("dbo.Doctors", "User_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Patients", "GatewayPayment_Id", "dbo.ClientGatewayPayments", "Id");
            AddForeignKey("dbo.Appointments", "BuyerId", "dbo.Patients", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Appointments", "SellerId", "dbo.ServiceProviders", "Id", cascadeDelete: true);
            DropColumn("dbo.Users", "Address_Id");
            CreateStoredProcedure(
                "dbo.ServiceProvider_Insert",
                p => new
                    {
                        Id = p.Guid(),
                        UserBaseId = p.Guid(),
                        User_Id = p.String(maxLength: 150),
                    },
                body:
                    @"INSERT [dbo].[ServiceProviders]([Id], [UserBaseId], [User_Id])
                      VALUES (@Id, @UserBaseId, @User_Id)"
            );
            
            CreateStoredProcedure(
                "dbo.ServiceProvider_Update",
                p => new
                    {
                        Id = p.Guid(),
                        UserBaseId = p.Guid(),
                        User_Id = p.String(maxLength: 150),
                    },
                body:
                    @"UPDATE [dbo].[ServiceProviders]
                      SET [UserBaseId] = @UserBaseId, [User_Id] = @User_Id
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.ServiceProvider_Delete",
                p => new
                    {
                        Id = p.Guid(),
                        User_Id = p.String(maxLength: 150),
                    },
                body:
                    @"DELETE [dbo].[ServiceProviders]
                      WHERE (([Id] = @Id) AND (([User_Id] = @User_Id) OR ([User_Id] IS NULL AND @User_Id IS NULL)))"
            );
            
            AlterStoredProcedure(
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
                        Parent_Id = p.Guid(),
                        GatewayPayment_Id = p.Int(),
                        User_Id = p.String(maxLength: 150),
                    },
                body:
                    @"INSERT [dbo].[Patients]([Id], [Cpf], [UserBaseId], [Weight], [Height], [DateOfBirth], [HealthProblems], [AllergiesAndReactions], [Medicines], [BloodType], [Parent_Id], [GatewayPayment_Id], [User_Id])
                      VALUES (@Id, @Cpf, @UserBaseId, @Weight, @Height, @DateOfBirth, @HealthProblems, @AllergiesAndReactions, @Medicines, @BloodType, @Parent_Id, @GatewayPayment_Id, @User_Id)"
            );
            
            AlterStoredProcedure(
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
                        Parent_Id = p.Guid(),
                        GatewayPayment_Id = p.Int(),
                        User_Id = p.String(maxLength: 150),
                    },
                body:
                    @"UPDATE [dbo].[Patients]
                      SET [Cpf] = @Cpf, [UserBaseId] = @UserBaseId, [Weight] = @Weight, [Height] = @Height, [DateOfBirth] = @DateOfBirth, [HealthProblems] = @HealthProblems, [AllergiesAndReactions] = @AllergiesAndReactions, [Medicines] = @Medicines, [BloodType] = @BloodType, [Parent_Id] = @Parent_Id, [GatewayPayment_Id] = @GatewayPayment_Id, [User_Id] = @User_Id
                      WHERE ([Id] = @Id)"
            );
            
            AlterStoredProcedure(
                "dbo.Patient_Delete",
                p => new
                    {
                        Id = p.Guid(),
                        Parent_Id = p.Guid(),
                        GatewayPayment_Id = p.Int(),
                        User_Id = p.String(maxLength: 150),
                    },
                body:
                    @"DELETE [dbo].[Patients]
                      WHERE (((([Id] = @Id) AND (([Parent_Id] = @Parent_Id) OR ([Parent_Id] IS NULL AND @Parent_Id IS NULL))) AND (([GatewayPayment_Id] = @GatewayPayment_Id) OR ([GatewayPayment_Id] IS NULL AND @GatewayPayment_Id IS NULL))) AND (([User_Id] = @User_Id) OR ([User_Id] IS NULL AND @User_Id IS NULL)))"
            );
            
            AlterStoredProcedure(
                "dbo.Doctor_Insert",
                p => new
                    {
                        Id = p.Guid(),
                        DateOfBirth = p.DateTime(),
                        Crm = p.String(maxLength: 150),
                        CrmUF = p.String(maxLength: 150),
                        Bio = p.String(maxLength: 150),
                        Cpf = p.String(maxLength: 150),
                        AppointmentPrice = p.Decimal(precision: 18, scale: 2),
                        AppointmentRadius = p.Int(),
                        IsActive = p.Boolean(),
                        IsPaylevenActive = p.Boolean(),
                        UrgencyEnable = p.Boolean(),
                        IsIuguActive = p.Boolean(),
                        ServiceProviderId = p.Guid(),
                        UserBaseId = p.Guid(),
                        Address_Id = p.Int(),
                        Identification_Id = p.Int(),
                        User_Id = p.String(maxLength: 150),
                    },
                body:
                    @"INSERT [dbo].[Doctors]([Id], [DateOfBirth], [Crm], [CrmUF], [Bio], [Cpf], [AppointmentPrice], [AppointmentRadius], [IsActive], [IsPaylevenActive], [UrgencyEnable], [IsIuguActive], [ServiceProviderId], [UserBaseId], [Address_Id], [Identification_Id], [User_Id])
                      VALUES (@Id, @DateOfBirth, @Crm, @CrmUF, @Bio, @Cpf, @AppointmentPrice, @AppointmentRadius, @IsActive, @IsPaylevenActive, @UrgencyEnable, @IsIuguActive, @ServiceProviderId, @UserBaseId, @Address_Id, @Identification_Id, @User_Id)"
            );
            
            AlterStoredProcedure(
                "dbo.Doctor_Update",
                p => new
                    {
                        Id = p.Guid(),
                        DateOfBirth = p.DateTime(),
                        Crm = p.String(maxLength: 150),
                        CrmUF = p.String(maxLength: 150),
                        Bio = p.String(maxLength: 150),
                        Cpf = p.String(maxLength: 150),
                        AppointmentPrice = p.Decimal(precision: 18, scale: 2),
                        AppointmentRadius = p.Int(),
                        IsActive = p.Boolean(),
                        IsPaylevenActive = p.Boolean(),
                        UrgencyEnable = p.Boolean(),
                        IsIuguActive = p.Boolean(),
                        ServiceProviderId = p.Guid(),
                        UserBaseId = p.Guid(),
                        Address_Id = p.Int(),
                        Identification_Id = p.Int(),
                        User_Id = p.String(maxLength: 150),
                    },
                body:
                    @"UPDATE [dbo].[Doctors]
                      SET [DateOfBirth] = @DateOfBirth, [Crm] = @Crm, [CrmUF] = @CrmUF, [Bio] = @Bio, [Cpf] = @Cpf, [AppointmentPrice] = @AppointmentPrice, [AppointmentRadius] = @AppointmentRadius, [IsActive] = @IsActive, [IsPaylevenActive] = @IsPaylevenActive, [UrgencyEnable] = @UrgencyEnable, [IsIuguActive] = @IsIuguActive, [ServiceProviderId] = @ServiceProviderId, [UserBaseId] = @UserBaseId, [Address_Id] = @Address_Id, [Identification_Id] = @Identification_Id, [User_Id] = @User_Id
                      WHERE ([Id] = @Id)"
            );
            
            AlterStoredProcedure(
                "dbo.Doctor_Delete",
                p => new
                    {
                        Id = p.Guid(),
                        Address_Id = p.Int(),
                        Identification_Id = p.Int(),
                        User_Id = p.String(maxLength: 150),
                    },
                body:
                    @"DELETE [dbo].[Doctors]
                      WHERE (((([Id] = @Id) AND (([Address_Id] = @Address_Id) OR ([Address_Id] IS NULL AND @Address_Id IS NULL))) AND (([Identification_Id] = @Identification_Id) OR ([Identification_Id] IS NULL AND @Identification_Id IS NULL))) AND (([User_Id] = @User_Id) OR ([User_Id] IS NULL AND @User_Id IS NULL)))"
            );
            
            AlterStoredProcedure(
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
                        SellerId = p.Guid(),
                        BuyerId = p.Guid(),
                        Address_Id = p.Int(),
                        Specialty_Id = p.Int(),
                        CreditCard_Id = p.Int(),
                        MedicalRecord_Id = p.Int(),
                    },
                body:
                    @"INSERT [dbo].[Appointments]([PromotionalCode], [Price], [HasHealthInsurance], [IsUrgency], [DateAppointment], [CreateDate], [PaymentMethod], [PaymentStatus], [Type], [Status], [SellerId], [BuyerId], [Address_Id], [Specialty_Id], [CreditCard_Id], [MedicalRecord_Id])
                      VALUES (@PromotionalCode, @Price, @HasHealthInsurance, @IsUrgency, @DateAppointment, @CreateDate, @PaymentMethod, @PaymentStatus, @Type, @Status, @SellerId, @BuyerId, @Address_Id, @Specialty_Id, @CreditCard_Id, @MedicalRecord_Id)
                      
                      DECLARE @Id int
                      SELECT @Id = [Id]
                      FROM [dbo].[Appointments]
                      WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()
                      
                      SELECT t0.[Id]
                      FROM [dbo].[Appointments] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[Id] = @Id"
            );
            
            AlterStoredProcedure(
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
                        SellerId = p.Guid(),
                        BuyerId = p.Guid(),
                        Address_Id = p.Int(),
                        Specialty_Id = p.Int(),
                        CreditCard_Id = p.Int(),
                        MedicalRecord_Id = p.Int(),
                    },
                body:
                    @"UPDATE [dbo].[Appointments]
                      SET [PromotionalCode] = @PromotionalCode, [Price] = @Price, [HasHealthInsurance] = @HasHealthInsurance, [IsUrgency] = @IsUrgency, [DateAppointment] = @DateAppointment, [CreateDate] = @CreateDate, [PaymentMethod] = @PaymentMethod, [PaymentStatus] = @PaymentStatus, [Type] = @Type, [Status] = @Status, [SellerId] = @SellerId, [BuyerId] = @BuyerId, [Address_Id] = @Address_Id, [Specialty_Id] = @Specialty_Id, [CreditCard_Id] = @CreditCard_Id, [MedicalRecord_Id] = @MedicalRecord_Id
                      WHERE ([Id] = @Id)"
            );
            
            AlterStoredProcedure(
                "dbo.Appointment_Delete",
                p => new
                    {
                        Id = p.Int(),
                        Address_Id = p.Int(),
                        Specialty_Id = p.Int(),
                        CreditCard_Id = p.Int(),
                        MedicalRecord_Id = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[Appointments]
                      WHERE ((((([Id] = @Id) AND (([Address_Id] = @Address_Id) OR ([Address_Id] IS NULL AND @Address_Id IS NULL))) AND (([Specialty_Id] = @Specialty_Id) OR ([Specialty_Id] IS NULL AND @Specialty_Id IS NULL))) AND (([CreditCard_Id] = @CreditCard_Id) OR ([CreditCard_Id] IS NULL AND @CreditCard_Id IS NULL))) AND (([MedicalRecord_Id] = @MedicalRecord_Id) OR ([MedicalRecord_Id] IS NULL AND @MedicalRecord_Id IS NULL)))"
            );
            
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.ServiceProvider_Delete");
            DropStoredProcedure("dbo.ServiceProvider_Update");
            DropStoredProcedure("dbo.ServiceProvider_Insert");
            AddColumn("dbo.Users", "Address_Id", c => c.Int());
            DropForeignKey("dbo.Appointments", "SellerId", "dbo.ServiceProviders");
            DropForeignKey("dbo.Appointments", "BuyerId", "dbo.Patients");
            DropForeignKey("dbo.Patients", "GatewayPayment_Id", "dbo.ClientGatewayPayments");
            DropForeignKey("dbo.Doctors", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Doctors", "Address_Id", "dbo.Addresses");
            DropIndex("dbo.Doctors", new[] { "User_Id" });
            DropIndex("dbo.Doctors", new[] { "Address_Id" });
            DropIndex("dbo.Patients", new[] { "GatewayPayment_Id" });
            DropIndex("dbo.Appointments", new[] { "BuyerId" });
            DropIndex("dbo.Appointments", new[] { "SellerId" });
            AlterColumn("dbo.Appointments", "SellerId", c => c.String(maxLength: 150));
            AlterColumn("dbo.Appointments", "BuyerId", c => c.String(maxLength: 150));
            AlterColumn("dbo.Patients", "GatewayPayment_Id", c => c.Int(nullable: false));
            DropColumn("dbo.Doctors", "User_Id");
            DropColumn("dbo.Doctors", "Address_Id");
            DropColumn("dbo.Doctors", "UserBaseId");
            DropColumn("dbo.Doctors", "Cpf");
            DropColumn("dbo.Doctors", "DateOfBirth");
            DropColumn("dbo.Addresses", "Location");
            RenameColumn(table: "dbo.Appointments", name: "SellerId", newName: "Seller_Id");
            RenameColumn(table: "dbo.Appointments", name: "BuyerId", newName: "Buyer_Id");
            RenameColumn(table: "dbo.Patients", name: "GatewayPayment_Id", newName: "ClientGatewayPaymentId");
            CreateIndex("dbo.Appointments", "Seller_Id");
            CreateIndex("dbo.Appointments", "Buyer_Id");
            CreateIndex("dbo.Users", "Address_Id");
            CreateIndex("dbo.Patients", "ClientGatewayPaymentId");
            AddForeignKey("dbo.Appointments", "Seller_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Appointments", "Buyer_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Patients", "ClientGatewayPaymentId", "dbo.ClientGatewayPayments", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Users", "Address_Id", "dbo.Addresses", "Id");
            throw new NotSupportedException("Scaffolding create or alter procedure operations is not supported in down methods.");
        }
    }
}
