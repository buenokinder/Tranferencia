namespace Docway.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Spatial;
    
    public partial class SecondMigrations : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "Address_Id", "dbo.Addresses");
            DropIndex("dbo.Users", new[] { "Address_Id" });
            AddColumn("dbo.Addresses", "Location", c => c.Geography());
            AddColumn("dbo.Doctors", "DateOfBirth", c => c.DateTime(nullable: false));
            AddColumn("dbo.Doctors", "Cpf", c => c.String(maxLength: 150));
            AddColumn("dbo.Doctors", "UserBaseId", c => c.Guid(nullable: false));
            AddColumn("dbo.Doctors", "Address_Id", c => c.Int());
            AddColumn("dbo.Doctors", "User_Id", c => c.String(maxLength: 150));
            CreateIndex("dbo.Doctors", "Address_Id");
            CreateIndex("dbo.Doctors", "User_Id");
            AddForeignKey("dbo.Doctors", "Address_Id", "dbo.Addresses", "Id");
            AddForeignKey("dbo.Doctors", "User_Id", "dbo.Users", "Id");
            DropColumn("dbo.Users", "Address_Id");
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
                        Address_Id = p.Int(),
                        Specialty_Id = p.Int(),
                        Buyer_Id = p.String(maxLength: 150),
                        CreditCard_Id = p.Int(),
                        MedicalRecord_Id = p.Int(),
                        Seller_Id = p.String(maxLength: 150),
                    },
                body:
                    @"INSERT [dbo].[Appointments]([PromotionalCode], [Price], [HasHealthInsurance], [IsUrgency], [DateAppointment], [CreateDate], [PaymentMethod], [PaymentStatus], [Type], [Status], [Address_Id], [Specialty_Id], [Buyer_Id], [CreditCard_Id], [MedicalRecord_Id], [Seller_Id])
                      VALUES (@PromotionalCode, @Price, @HasHealthInsurance, @IsUrgency, @DateAppointment, @CreateDate, @PaymentMethod, @PaymentStatus, @Type, @Status, @Address_Id, @Specialty_Id, @Buyer_Id, @CreditCard_Id, @MedicalRecord_Id, @Seller_Id)
                      
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
                        Address_Id = p.Int(),
                        Specialty_Id = p.Int(),
                        Buyer_Id = p.String(maxLength: 150),
                        CreditCard_Id = p.Int(),
                        MedicalRecord_Id = p.Int(),
                        Seller_Id = p.String(maxLength: 150),
                    },
                body:
                    @"UPDATE [dbo].[Appointments]
                      SET [PromotionalCode] = @PromotionalCode, [Price] = @Price, [HasHealthInsurance] = @HasHealthInsurance, [IsUrgency] = @IsUrgency, [DateAppointment] = @DateAppointment, [CreateDate] = @CreateDate, [PaymentMethod] = @PaymentMethod, [PaymentStatus] = @PaymentStatus, [Type] = @Type, [Status] = @Status, [Address_Id] = @Address_Id, [Specialty_Id] = @Specialty_Id, [Buyer_Id] = @Buyer_Id, [CreditCard_Id] = @CreditCard_Id, [MedicalRecord_Id] = @MedicalRecord_Id, [Seller_Id] = @Seller_Id
                      WHERE ([Id] = @Id)"
            );
            
            AlterStoredProcedure(
                "dbo.Appointment_Delete",
                p => new
                    {
                        Id = p.Int(),
                        Address_Id = p.Int(),
                        Specialty_Id = p.Int(),
                        Buyer_Id = p.String(maxLength: 150),
                        CreditCard_Id = p.Int(),
                        MedicalRecord_Id = p.Int(),
                        Seller_Id = p.String(maxLength: 150),
                    },
                body:
                    @"DELETE [dbo].[Appointments]
                      WHERE ((((((([Id] = @Id) AND (([Address_Id] = @Address_Id) OR ([Address_Id] IS NULL AND @Address_Id IS NULL))) AND (([Specialty_Id] = @Specialty_Id) OR ([Specialty_Id] IS NULL AND @Specialty_Id IS NULL))) AND (([Buyer_Id] = @Buyer_Id) OR ([Buyer_Id] IS NULL AND @Buyer_Id IS NULL))) AND (([CreditCard_Id] = @CreditCard_Id) OR ([CreditCard_Id] IS NULL AND @CreditCard_Id IS NULL))) AND (([MedicalRecord_Id] = @MedicalRecord_Id) OR ([MedicalRecord_Id] IS NULL AND @MedicalRecord_Id IS NULL))) AND (([Seller_Id] = @Seller_Id) OR ([Seller_Id] IS NULL AND @Seller_Id IS NULL)))"
            );
            
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Address_Id", c => c.Int());
            DropForeignKey("dbo.Doctors", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Doctors", "Address_Id", "dbo.Addresses");
            DropIndex("dbo.Doctors", new[] { "User_Id" });
            DropIndex("dbo.Doctors", new[] { "Address_Id" });
            DropColumn("dbo.Doctors", "User_Id");
            DropColumn("dbo.Doctors", "Address_Id");
            DropColumn("dbo.Doctors", "UserBaseId");
            DropColumn("dbo.Doctors", "Cpf");
            DropColumn("dbo.Doctors", "DateOfBirth");
            DropColumn("dbo.Addresses", "Location");
            CreateIndex("dbo.Users", "Address_Id");
            AddForeignKey("dbo.Users", "Address_Id", "dbo.Addresses", "Id");
            throw new NotSupportedException("Scaffolding create or alter procedure operations is not supported in down methods.");
        }
    }
}
