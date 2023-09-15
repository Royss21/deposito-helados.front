IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Archive] (
    [Id] uniqueidentifier NOT NULL,
    [Name] nvarchar(100) NOT NULL,
    [FileName] nvarchar(250) NOT NULL,
    [PathName] nvarchar(100) NOT NULL,
    [MdTypeArchiveId] int NOT NULL,
    [CreateUser] nvarchar(50) NOT NULL DEFAULT N'system',
    [CreateDate] datetime2 NOT NULL,
    [ModifyUser] nvarchar(50) NULL DEFAULT N'system',
    [ModifyDate] datetime2 NULL,
    [DeleteUser] nvarchar(50) NULL DEFAULT N'system',
    [DeleteDate] datetime2 NULL,
    [IsDeleted] bit NOT NULL DEFAULT CAST(0 AS bit),
    [IsActive] bit NOT NULL DEFAULT CAST(1 AS bit),
    [CompanyId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Archive] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Company] (
    [Id] uniqueidentifier NOT NULL,
    [Name] nvarchar(100) NOT NULL,
    [BusinessName] nvarchar(250) NOT NULL,
    [Ruc] nvarchar(12) NOT NULL,
    [FiscalAddress] nvarchar(250) NOT NULL,
    [ArchiveId] uniqueidentifier NULL,
    [CreateUser] nvarchar(50) NOT NULL DEFAULT N'system',
    [CreateDate] datetime2 NOT NULL,
    [ModifyUser] nvarchar(50) NULL DEFAULT N'system',
    [ModifyDate] datetime2 NULL,
    [DeleteUser] nvarchar(50) NULL DEFAULT N'system',
    [DeleteDate] datetime2 NULL,
    [IsDeleted] bit NOT NULL DEFAULT CAST(0 AS bit),
    [IsActive] bit NOT NULL DEFAULT CAST(1 AS bit),
    CONSTRAINT [PK_Company] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Company_Archive_ArchiveId] FOREIGN KEY ([ArchiveId]) REFERENCES [Archive] ([Id])
);
GO

CREATE TABLE [Campus] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(100) NOT NULL,
    [FiscalAddress] nvarchar(250) NOT NULL,
    [CreateUser] nvarchar(50) NOT NULL DEFAULT N'system',
    [CreateDate] datetime2 NOT NULL,
    [ModifyUser] nvarchar(50) NULL DEFAULT N'system',
    [ModifyDate] datetime2 NULL,
    [DeleteUser] nvarchar(50) NULL DEFAULT N'system',
    [DeleteDate] datetime2 NULL,
    [IsDeleted] bit NOT NULL DEFAULT CAST(0 AS bit),
    [IsActive] bit NOT NULL DEFAULT CAST(1 AS bit),
    [CompanyId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Campus] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Campus_Company_CompanyId] FOREIGN KEY ([CompanyId]) REFERENCES [Company] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Category] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(100) NOT NULL,
    [Description] nvarchar(250) NOT NULL,
    [Icon] nvarchar(100) NOT NULL,
    [Sort] int NOT NULL,
    [CategoryParentId] int NULL,
    [CreateUser] nvarchar(50) NOT NULL DEFAULT N'system',
    [CreateDate] datetime2 NOT NULL,
    [ModifyUser] nvarchar(50) NULL DEFAULT N'system',
    [ModifyDate] datetime2 NULL,
    [DeleteUser] nvarchar(50) NULL DEFAULT N'system',
    [DeleteDate] datetime2 NULL,
    [IsDeleted] bit NOT NULL DEFAULT CAST(0 AS bit),
    [IsActive] bit NOT NULL DEFAULT CAST(1 AS bit),
    [CompanyId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Category] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Category_Category_CategoryParentId] FOREIGN KEY ([CategoryParentId]) REFERENCES [Category] ([Id]),
    CONSTRAINT [FK_Category_Company_CompanyId] FOREIGN KEY ([CompanyId]) REFERENCES [Company] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Master] (
    [Id] uniqueidentifier NOT NULL,
    [Code] nvarchar(12) NOT NULL,
    [Name] nvarchar(250) NOT NULL,
    [Description] nvarchar(400) NOT NULL,
    [CreateUser] nvarchar(50) NOT NULL DEFAULT N'system',
    [CreateDate] datetime2 NOT NULL,
    [ModifyUser] nvarchar(50) NULL DEFAULT N'system',
    [ModifyDate] datetime2 NULL,
    [DeleteUser] nvarchar(50) NULL DEFAULT N'system',
    [DeleteDate] datetime2 NULL,
    [IsDeleted] bit NOT NULL DEFAULT CAST(0 AS bit),
    [IsActive] bit NOT NULL DEFAULT CAST(1 AS bit),
    [CompanyId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Master] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Master_Company_CompanyId] FOREIGN KEY ([CompanyId]) REFERENCES [Company] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Menu] (
    [Id] uniqueidentifier NOT NULL,
    [Icon] nvarchar(500) NOT NULL,
    [Name] nvarchar(100) NOT NULL,
    [Url] nvarchar(250) NOT NULL,
    [Sort] int NOT NULL,
    [CompanyId] uniqueidentifier NOT NULL,
    [CreateUser] nvarchar(50) NOT NULL DEFAULT N'system',
    [CreateDate] datetime2 NOT NULL,
    [ModifyUser] nvarchar(50) NULL DEFAULT N'system',
    [ModifyDate] datetime2 NULL,
    [DeleteUser] nvarchar(50) NULL DEFAULT N'system',
    [DeleteDate] datetime2 NULL,
    [IsDeleted] bit NOT NULL DEFAULT CAST(0 AS bit),
    [IsActive] bit NOT NULL DEFAULT CAST(1 AS bit),
    CONSTRAINT [PK_Menu] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Menu_Company_CompanyId] FOREIGN KEY ([CompanyId]) REFERENCES [Company] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Role] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(20) NOT NULL,
    [Code] nvarchar(12) NOT NULL,
    [CreateUser] nvarchar(50) NOT NULL DEFAULT N'system',
    [CreateDate] datetime2 NOT NULL,
    [ModifyUser] nvarchar(50) NULL DEFAULT N'system',
    [ModifyDate] datetime2 NULL,
    [DeleteUser] nvarchar(50) NULL DEFAULT N'system',
    [DeleteDate] datetime2 NULL,
    [IsDeleted] bit NOT NULL DEFAULT CAST(0 AS bit),
    [IsActive] bit NOT NULL DEFAULT CAST(1 AS bit),
    [CompanyId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Role] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Role_Company_CompanyId] FOREIGN KEY ([CompanyId]) REFERENCES [Company] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [User] (
    [Id] uniqueidentifier NOT NULL,
    [PersonRoleId] int NOT NULL,
    [UserName] nvarchar(20) NOT NULL,
    [Password] nvarchar(20) NOT NULL,
    [HashType] int NOT NULL,
    [CreateUser] nvarchar(50) NOT NULL DEFAULT N'system',
    [CreateDate] datetime2 NOT NULL,
    [ModifyUser] nvarchar(50) NULL DEFAULT N'system',
    [ModifyDate] datetime2 NULL,
    [DeleteUser] nvarchar(50) NULL DEFAULT N'system',
    [DeleteDate] datetime2 NULL,
    [IsDeleted] bit NOT NULL DEFAULT CAST(0 AS bit),
    [IsActive] bit NOT NULL DEFAULT CAST(1 AS bit),
    [CompanyId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_User_Company_CompanyId] FOREIGN KEY ([CompanyId]) REFERENCES [Company] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [MasterDetail] (
    [Id] int NOT NULL IDENTITY,
    [MasterId] uniqueidentifier NOT NULL,
    [Code] nvarchar(20) NOT NULL,
    [Name] nvarchar(50) NOT NULL,
    [Description] nvarchar(200) NOT NULL,
    [AdditionalOne] nvarchar(100) NOT NULL,
    [AdditionalTwo] nvarchar(100) NOT NULL,
    [Sort] int NOT NULL,
    [CreateUser] nvarchar(50) NOT NULL DEFAULT N'system',
    [CreateDate] datetime2 NOT NULL,
    [ModifyUser] nvarchar(50) NULL DEFAULT N'system',
    [ModifyDate] datetime2 NULL,
    [DeleteUser] nvarchar(50) NULL DEFAULT N'system',
    [DeleteDate] datetime2 NULL,
    [IsDeleted] bit NOT NULL DEFAULT CAST(0 AS bit),
    [IsActive] bit NOT NULL DEFAULT CAST(1 AS bit),
    CONSTRAINT [PK_MasterDetail] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_MasterDetail_Master_MasterId] FOREIGN KEY ([MasterId]) REFERENCES [Master] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [MenuRole] (
    [Id] int NOT NULL IDENTITY,
    [RoleId] int NOT NULL,
    [MenuId] uniqueidentifier NOT NULL,
    [CreateUser] nvarchar(50) NOT NULL DEFAULT N'system',
    [CreateDate] datetime2 NOT NULL,
    [ModifyUser] nvarchar(50) NULL DEFAULT N'system',
    [ModifyDate] datetime2 NULL,
    [DeleteUser] nvarchar(50) NULL DEFAULT N'system',
    [DeleteDate] datetime2 NULL,
    [IsDeleted] bit NOT NULL DEFAULT CAST(0 AS bit),
    [IsActive] bit NOT NULL DEFAULT CAST(1 AS bit),
    CONSTRAINT [PK_MenuRole] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_MenuRole_Menu_MenuId] FOREIGN KEY ([MenuId]) REFERENCES [Menu] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_MenuRole_Role_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [Role] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [UserRole] (
    [Id] int NOT NULL IDENTITY,
    [UserId] uniqueidentifier NOT NULL,
    [RoleId] int NOT NULL,
    [CampusId] int NOT NULL,
    [CreateUser] nvarchar(50) NOT NULL DEFAULT N'system',
    [CreateDate] datetime2 NOT NULL,
    [ModifyUser] nvarchar(50) NULL DEFAULT N'system',
    [ModifyDate] datetime2 NULL,
    [DeleteUser] nvarchar(50) NULL DEFAULT N'system',
    [DeleteDate] datetime2 NULL,
    [IsDeleted] bit NOT NULL DEFAULT CAST(0 AS bit),
    [IsActive] bit NOT NULL DEFAULT CAST(1 AS bit),
    CONSTRAINT [PK_UserRole] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_UserRole_Campus_CampusId] FOREIGN KEY ([CampusId]) REFERENCES [Campus] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_UserRole_Role_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [Role] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_UserRole_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [User] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Person] (
    [Id] uniqueidentifier NOT NULL,
    [FirstName] nvarchar(50) NOT NULL,
    [SecondName] nvarchar(50) NOT NULL,
    [LastName] nvarchar(50) NOT NULL,
    [MiddleName] nvarchar(50) NOT NULL,
    [IdentityDocument] nvarchar(20) NOT NULL,
    [Email] nvarchar(50) NOT NULL,
    [PhoneNumber] nvarchar(50) NOT NULL,
    [MdIdentityDocumentTypeId] int NOT NULL,
    [CreateUser] nvarchar(50) NOT NULL DEFAULT N'system',
    [CreateDate] datetime2 NOT NULL,
    [ModifyUser] nvarchar(50) NULL DEFAULT N'system',
    [ModifyDate] datetime2 NULL,
    [DeleteUser] nvarchar(50) NULL DEFAULT N'system',
    [DeleteDate] datetime2 NULL,
    [IsDeleted] bit NOT NULL DEFAULT CAST(0 AS bit),
    [IsActive] bit NOT NULL DEFAULT CAST(1 AS bit),
    [CompanyId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Person] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Person_Company_CompanyId] FOREIGN KEY ([CompanyId]) REFERENCES [Company] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Person_MasterDetail_MdIdentityDocumentTypeId] FOREIGN KEY ([MdIdentityDocumentTypeId]) REFERENCES [MasterDetail] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Product] (
    [Id] uniqueidentifier NOT NULL,
    [MdBrandId] int NOT NULL,
    [Name] nvarchar(100) NOT NULL,
    [Description] nvarchar(200) NOT NULL,
    [CreateUser] nvarchar(50) NOT NULL DEFAULT N'system',
    [CreateDate] datetime2 NOT NULL,
    [ModifyUser] nvarchar(50) NULL DEFAULT N'system',
    [ModifyDate] datetime2 NULL,
    [DeleteUser] nvarchar(50) NULL DEFAULT N'system',
    [DeleteDate] datetime2 NULL,
    [IsDeleted] bit NOT NULL DEFAULT CAST(0 AS bit),
    [IsActive] bit NOT NULL DEFAULT CAST(1 AS bit),
    [CompanyId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Product] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Product_Company_CompanyId] FOREIGN KEY ([CompanyId]) REFERENCES [Company] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Product_MasterDetail_MdBrandId] FOREIGN KEY ([MdBrandId]) REFERENCES [MasterDetail] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [UserToken] (
    [Id] uniqueidentifier NOT NULL,
    [UserRoleId] int NOT NULL,
    [Token] nvarchar(400) NOT NULL,
    [TokenExpiredDate] datetime2 NOT NULL,
    [RefreshToken] nvarchar(250) NOT NULL,
    [RefreshTokenExpiredDate] datetime2 NOT NULL,
    [CreateUser] nvarchar(50) NOT NULL DEFAULT N'system',
    [CreateDate] datetime2 NOT NULL,
    [ModifyUser] nvarchar(50) NULL DEFAULT N'system',
    [ModifyDate] datetime2 NULL,
    [DeleteUser] nvarchar(50) NULL DEFAULT N'system',
    [DeleteDate] datetime2 NULL,
    [IsDeleted] bit NOT NULL DEFAULT CAST(0 AS bit),
    [IsActive] bit NOT NULL DEFAULT CAST(1 AS bit),
    CONSTRAINT [PK_UserToken] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_UserToken_UserRole_UserRoleId] FOREIGN KEY ([UserRoleId]) REFERENCES [UserRole] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [PersonAddress] (
    [Id] int NOT NULL IDENTITY,
    [PersonId] uniqueidentifier NOT NULL,
    [MdPostalCodeId] int NOT NULL,
    [Address] nvarchar(150) NOT NULL,
    [ReferenceAddress] nvarchar(150) NOT NULL,
    [CreateUser] nvarchar(50) NOT NULL DEFAULT N'system',
    [CreateDate] datetime2 NOT NULL,
    [ModifyUser] nvarchar(50) NULL DEFAULT N'system',
    [ModifyDate] datetime2 NULL,
    [DeleteUser] nvarchar(50) NULL DEFAULT N'system',
    [DeleteDate] datetime2 NULL,
    [IsDeleted] bit NOT NULL DEFAULT CAST(0 AS bit),
    [IsActive] bit NOT NULL DEFAULT CAST(1 AS bit),
    CONSTRAINT [PK_PersonAddress] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_PersonAddress_MasterDetail_MdPostalCodeId] FOREIGN KEY ([MdPostalCodeId]) REFERENCES [MasterDetail] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_PersonAddress_Person_PersonId] FOREIGN KEY ([PersonId]) REFERENCES [Person] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [PersonRole] (
    [Id] int NOT NULL IDENTITY,
    [PersonId] uniqueidentifier NOT NULL,
    [RoleId] int NOT NULL,
    [CampusId] int NOT NULL,
    [UniqueCode] nvarchar(20) NOT NULL,
    [CreateUser] nvarchar(50) NOT NULL DEFAULT N'system',
    [CreateDate] datetime2 NOT NULL,
    [ModifyUser] nvarchar(50) NULL DEFAULT N'system',
    [ModifyDate] datetime2 NULL,
    [DeleteUser] nvarchar(50) NULL DEFAULT N'system',
    [DeleteDate] datetime2 NULL,
    [IsDeleted] bit NOT NULL DEFAULT CAST(0 AS bit),
    [IsActive] bit NOT NULL DEFAULT CAST(1 AS bit),
    CONSTRAINT [PK_PersonRole] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_PersonRole_Campus_CampusId] FOREIGN KEY ([CampusId]) REFERENCES [Campus] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_PersonRole_Person_PersonId] FOREIGN KEY ([PersonId]) REFERENCES [Person] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_PersonRole_Role_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [Role] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [ProductArchive] (
    [Id] int NOT NULL IDENTITY,
    [ArchiveId] uniqueidentifier NOT NULL,
    [ProductId] uniqueidentifier NOT NULL,
    [Sort] int NOT NULL,
    [CreateUser] nvarchar(50) NOT NULL DEFAULT N'system',
    [CreateDate] datetime2 NOT NULL,
    [ModifyUser] nvarchar(50) NULL DEFAULT N'system',
    [ModifyDate] datetime2 NULL,
    [DeleteUser] nvarchar(50) NULL DEFAULT N'system',
    [DeleteDate] datetime2 NULL,
    [IsDeleted] bit NOT NULL DEFAULT CAST(0 AS bit),
    [IsActive] bit NOT NULL DEFAULT CAST(1 AS bit),
    CONSTRAINT [PK_ProductArchive] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ProductArchive_Archive_ArchiveId] FOREIGN KEY ([ArchiveId]) REFERENCES [Archive] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_ProductArchive_Product_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Product] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [ProductCategory] (
    [Id] int NOT NULL IDENTITY,
    [CategoryId] int NOT NULL,
    [ProductId] uniqueidentifier NOT NULL,
    [Sort] int NOT NULL,
    [CreateUser] nvarchar(50) NOT NULL DEFAULT N'system',
    [CreateDate] datetime2 NOT NULL,
    [ModifyUser] nvarchar(50) NULL DEFAULT N'system',
    [ModifyDate] datetime2 NULL,
    [DeleteUser] nvarchar(50) NULL DEFAULT N'system',
    [DeleteDate] datetime2 NULL,
    [IsDeleted] bit NOT NULL DEFAULT CAST(0 AS bit),
    [IsActive] bit NOT NULL DEFAULT CAST(1 AS bit),
    CONSTRAINT [PK_ProductCategory] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ProductCategory_Category_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Category] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_ProductCategory_Product_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Product] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [ProductFlavor] (
    [Id] int NOT NULL IDENTITY,
    [MdFlavorId] int NOT NULL,
    [ProductId] uniqueidentifier NOT NULL,
    [ArchiveId] uniqueidentifier NULL,
    [Sort] int NOT NULL,
    [CreateUser] nvarchar(50) NOT NULL DEFAULT N'system',
    [CreateDate] datetime2 NOT NULL,
    [ModifyUser] nvarchar(50) NULL DEFAULT N'system',
    [ModifyDate] datetime2 NULL,
    [DeleteUser] nvarchar(50) NULL DEFAULT N'system',
    [DeleteDate] datetime2 NULL,
    [IsDeleted] bit NOT NULL DEFAULT CAST(0 AS bit),
    [IsActive] bit NOT NULL DEFAULT CAST(1 AS bit),
    CONSTRAINT [PK_ProductFlavor] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ProductFlavor_Archive_ArchiveId] FOREIGN KEY ([ArchiveId]) REFERENCES [Archive] ([Id]),
    CONSTRAINT [FK_ProductFlavor_MasterDetail_MdFlavorId] FOREIGN KEY ([MdFlavorId]) REFERENCES [MasterDetail] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_ProductFlavor_Product_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Product] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [ProductPrice] (
    [Id] int NOT NULL IDENTITY,
    [ProductId] uniqueidentifier NOT NULL,
    [MdUnitMeasurementId] int NOT NULL,
    [PurchasePrice] money NOT NULL,
    [SalePrice] money NOT NULL,
    [PublicPrice] money NOT NULL,
    [EmployeePrice] money NOT NULL,
    [OtherPriceOne] money NOT NULL,
    [OtherPriceTwo] money NOT NULL,
    [CreateUser] nvarchar(50) NOT NULL DEFAULT N'system',
    [CreateDate] datetime2 NOT NULL,
    [ModifyUser] nvarchar(50) NULL DEFAULT N'system',
    [ModifyDate] datetime2 NULL,
    [DeleteUser] nvarchar(50) NULL DEFAULT N'system',
    [DeleteDate] datetime2 NULL,
    [IsDeleted] bit NOT NULL DEFAULT CAST(0 AS bit),
    [IsActive] bit NOT NULL DEFAULT CAST(1 AS bit),
    CONSTRAINT [PK_ProductPrice] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ProductPrice_MasterDetail_MdUnitMeasurementId] FOREIGN KEY ([MdUnitMeasurementId]) REFERENCES [MasterDetail] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_ProductPrice_Product_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Product] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [EmployeeOrderProduct] (
    [Id] int NOT NULL IDENTITY,
    [PersonRoleId] int NOT NULL,
    [DateProductOrder] datetime2 NOT NULL,
    [CampusId] int NOT NULL,
    [CreateUser] nvarchar(50) NOT NULL DEFAULT N'system',
    [CreateDate] datetime2 NOT NULL,
    [ModifyUser] nvarchar(50) NULL DEFAULT N'system',
    [ModifyDate] datetime2 NULL,
    [DeleteUser] nvarchar(50) NULL DEFAULT N'system',
    [DeleteDate] datetime2 NULL,
    [IsDeleted] bit NOT NULL DEFAULT CAST(0 AS bit),
    [IsActive] bit NOT NULL DEFAULT CAST(1 AS bit),
    CONSTRAINT [PK_EmployeeOrderProduct] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_EmployeeOrderProduct_Campus_CampusId] FOREIGN KEY ([CampusId]) REFERENCES [Campus] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_EmployeeOrderProduct_PersonRole_PersonRoleId] FOREIGN KEY ([PersonRoleId]) REFERENCES [PersonRole] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Order] (
    [Id] uniqueidentifier NOT NULL,
    [PersonRoleId] int NOT NULL,
    [MdOrderTypeId] int NOT NULL,
    [Code] nvarchar(12) NOT NULL,
    [MdStatusId] int NOT NULL,
    [CampusId] int NOT NULL,
    [CreateUser] nvarchar(50) NOT NULL DEFAULT N'system',
    [CreateDate] datetime2 NOT NULL,
    [ModifyUser] nvarchar(50) NULL DEFAULT N'system',
    [ModifyDate] datetime2 NULL,
    [DeleteUser] nvarchar(50) NULL DEFAULT N'system',
    [DeleteDate] datetime2 NULL,
    [IsDeleted] bit NOT NULL DEFAULT CAST(0 AS bit),
    [IsActive] bit NOT NULL DEFAULT CAST(1 AS bit),
    CONSTRAINT [PK_Order] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Order_Campus_CampusId] FOREIGN KEY ([CampusId]) REFERENCES [Campus] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Order_MasterDetail_MdOrderTypeId] FOREIGN KEY ([MdOrderTypeId]) REFERENCES [MasterDetail] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Order_MasterDetail_MdStatusId] FOREIGN KEY ([MdStatusId]) REFERENCES [MasterDetail] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Order_PersonRole_PersonRoleId] FOREIGN KEY ([PersonRoleId]) REFERENCES [PersonRole] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [EmployeeOrderProductDetail] (
    [Id] int NOT NULL IDENTITY,
    [EmployeeProductOrderId] int NOT NULL,
    [ProductId] uniqueidentifier NOT NULL,
    [MdUnitMeasurementId] int NOT NULL,
    [Quantity] int NOT NULL,
    [CreateUser] nvarchar(50) NOT NULL DEFAULT N'system',
    [CreateDate] datetime2 NOT NULL,
    [ModifyUser] nvarchar(50) NULL DEFAULT N'system',
    [ModifyDate] datetime2 NULL,
    [DeleteUser] nvarchar(50) NULL DEFAULT N'system',
    [DeleteDate] datetime2 NULL,
    [IsDeleted] bit NOT NULL DEFAULT CAST(0 AS bit),
    [IsActive] bit NOT NULL DEFAULT CAST(1 AS bit),
    CONSTRAINT [PK_EmployeeOrderProductDetail] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_EmployeeOrderProductDetail_EmployeeOrderProduct_EmployeeProductOrderId] FOREIGN KEY ([EmployeeProductOrderId]) REFERENCES [EmployeeOrderProduct] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_EmployeeOrderProductDetail_MasterDetail_MdUnitMeasurementId] FOREIGN KEY ([MdUnitMeasurementId]) REFERENCES [MasterDetail] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_EmployeeOrderProductDetail_Product_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Product] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [OrderAdvanceAmount] (
    [Id] int NOT NULL IDENTITY,
    [OrderId] uniqueidentifier NOT NULL,
    [Amount] money NOT NULL,
    [CreateUser] nvarchar(50) NOT NULL DEFAULT N'system',
    [CreateDate] datetime2 NOT NULL,
    [ModifyUser] nvarchar(50) NULL DEFAULT N'system',
    [ModifyDate] datetime2 NULL,
    [DeleteUser] nvarchar(50) NULL DEFAULT N'system',
    [DeleteDate] datetime2 NULL,
    [IsDeleted] bit NOT NULL DEFAULT CAST(0 AS bit),
    [IsActive] bit NOT NULL DEFAULT CAST(1 AS bit),
    CONSTRAINT [PK_OrderAdvanceAmount] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_OrderAdvanceAmount_Order_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [Order] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [OrderDetail] (
    [Id] int NOT NULL IDENTITY,
    [OrderId] uniqueidentifier NOT NULL,
    [ProductId] uniqueidentifier NOT NULL,
    [MdUnitMeasurementId] int NOT NULL,
    [TotalQuantity] money NOT NULL,
    [DevolutionQuantity] money NOT NULL,
    [ProductPrice] money NOT NULL,
    [OrderDate] datetime2 NOT NULL,
    [CreateUser] nvarchar(50) NOT NULL DEFAULT N'system',
    [CreateDate] datetime2 NOT NULL,
    [ModifyUser] nvarchar(50) NULL DEFAULT N'system',
    [ModifyDate] datetime2 NULL,
    [DeleteUser] nvarchar(50) NULL DEFAULT N'system',
    [DeleteDate] datetime2 NULL,
    [IsDeleted] bit NOT NULL DEFAULT CAST(0 AS bit),
    [IsActive] bit NOT NULL DEFAULT CAST(1 AS bit),
    CONSTRAINT [PK_OrderDetail] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_OrderDetail_MasterDetail_MdUnitMeasurementId] FOREIGN KEY ([MdUnitMeasurementId]) REFERENCES [MasterDetail] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_OrderDetail_Order_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [Order] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_OrderDetail_Product_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Product] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [PersonAmountAccount] (
    [Id] int NOT NULL IDENTITY,
    [PersonRoleId] int NOT NULL,
    [Amount] money NOT NULL,
    [CancellationDate] datetime2 NULL,
    [OrderId] uniqueidentifier NULL,
    [MdStatusId] int NOT NULL,
    [CreateUser] nvarchar(max) NOT NULL,
    [CreateDate] datetime2 NOT NULL,
    [ModifyUser] nvarchar(max) NOT NULL,
    [ModifyDate] datetime2 NULL,
    [DeleteUser] nvarchar(max) NOT NULL,
    [DeleteDate] datetime2 NULL,
    [IsDeleted] bit NOT NULL,
    [IsActive] bit NOT NULL,
    CONSTRAINT [PK_PersonAmountAccount] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_PersonAmountAccount_MasterDetail_MdStatusId] FOREIGN KEY ([MdStatusId]) REFERENCES [MasterDetail] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_PersonAmountAccount_Order_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [Order] ([Id]),
    CONSTRAINT [FK_PersonAmountAccount_PersonRole_PersonRoleId] FOREIGN KEY ([PersonRoleId]) REFERENCES [PersonRole] ([Id]) ON DELETE NO ACTION
);
GO

CREATE INDEX [IX_Archive_CompanyId] ON [Archive] ([CompanyId]);
GO

CREATE INDEX [IX_Archive_MdTypeArchiveId] ON [Archive] ([MdTypeArchiveId]);
GO

CREATE INDEX [IX_Campus_CompanyId] ON [Campus] ([CompanyId]);
GO

CREATE INDEX [IX_Category_CategoryParentId] ON [Category] ([CategoryParentId]);
GO

CREATE INDEX [IX_Category_CompanyId] ON [Category] ([CompanyId]);
GO

CREATE INDEX [IX_Company_ArchiveId] ON [Company] ([ArchiveId]);
GO

CREATE INDEX [IX_EmployeeOrderProduct_CampusId] ON [EmployeeOrderProduct] ([CampusId]);
GO

CREATE INDEX [IX_EmployeeOrderProduct_PersonRoleId] ON [EmployeeOrderProduct] ([PersonRoleId]);
GO

CREATE INDEX [IX_EmployeeOrderProductDetail_EmployeeProductOrderId] ON [EmployeeOrderProductDetail] ([EmployeeProductOrderId]);
GO

CREATE INDEX [IX_EmployeeOrderProductDetail_MdUnitMeasurementId] ON [EmployeeOrderProductDetail] ([MdUnitMeasurementId]);
GO

CREATE INDEX [IX_EmployeeOrderProductDetail_ProductId] ON [EmployeeOrderProductDetail] ([ProductId]);
GO

CREATE INDEX [IX_Master_CompanyId] ON [Master] ([CompanyId]);
GO

CREATE INDEX [IX_MasterDetail_MasterId] ON [MasterDetail] ([MasterId]);
GO

CREATE INDEX [IX_Menu_CompanyId] ON [Menu] ([CompanyId]);
GO

CREATE INDEX [IX_MenuRole_MenuId] ON [MenuRole] ([MenuId]);
GO

CREATE INDEX [IX_MenuRole_RoleId] ON [MenuRole] ([RoleId]);
GO

CREATE INDEX [IX_Order_CampusId] ON [Order] ([CampusId]);
GO

CREATE INDEX [IX_Order_MdOrderTypeId] ON [Order] ([MdOrderTypeId]);
GO

CREATE INDEX [IX_Order_MdStatusId] ON [Order] ([MdStatusId]);
GO

CREATE INDEX [IX_Order_PersonRoleId] ON [Order] ([PersonRoleId]);
GO

CREATE INDEX [IX_OrderAdvanceAmount_OrderId] ON [OrderAdvanceAmount] ([OrderId]);
GO

CREATE INDEX [IX_OrderDetail_MdUnitMeasurementId] ON [OrderDetail] ([MdUnitMeasurementId]);
GO

CREATE INDEX [IX_OrderDetail_OrderId] ON [OrderDetail] ([OrderId]);
GO

CREATE INDEX [IX_OrderDetail_ProductId] ON [OrderDetail] ([ProductId]);
GO

CREATE INDEX [IX_Person_CompanyId] ON [Person] ([CompanyId]);
GO

CREATE INDEX [IX_Person_MdIdentityDocumentTypeId] ON [Person] ([MdIdentityDocumentTypeId]);
GO

CREATE INDEX [IX_PersonAddress_MdPostalCodeId] ON [PersonAddress] ([MdPostalCodeId]);
GO

CREATE INDEX [IX_PersonAddress_PersonId] ON [PersonAddress] ([PersonId]);
GO

CREATE INDEX [IX_PersonAmountAccount_MdStatusId] ON [PersonAmountAccount] ([MdStatusId]);
GO

CREATE INDEX [IX_PersonAmountAccount_OrderId] ON [PersonAmountAccount] ([OrderId]);
GO

CREATE INDEX [IX_PersonAmountAccount_PersonRoleId] ON [PersonAmountAccount] ([PersonRoleId]);
GO

CREATE INDEX [IX_PersonRole_CampusId] ON [PersonRole] ([CampusId]);
GO

CREATE INDEX [IX_PersonRole_PersonId] ON [PersonRole] ([PersonId]);
GO

CREATE INDEX [IX_PersonRole_RoleId] ON [PersonRole] ([RoleId]);
GO

CREATE INDEX [IX_Product_CompanyId] ON [Product] ([CompanyId]);
GO

CREATE INDEX [IX_Product_MdBrandId] ON [Product] ([MdBrandId]);
GO

CREATE INDEX [IX_ProductArchive_ArchiveId] ON [ProductArchive] ([ArchiveId]);
GO

CREATE INDEX [IX_ProductArchive_ProductId] ON [ProductArchive] ([ProductId]);
GO

CREATE INDEX [IX_ProductCategory_CategoryId] ON [ProductCategory] ([CategoryId]);
GO

CREATE INDEX [IX_ProductCategory_ProductId] ON [ProductCategory] ([ProductId]);
GO

CREATE INDEX [IX_ProductFlavor_ArchiveId] ON [ProductFlavor] ([ArchiveId]);
GO

CREATE INDEX [IX_ProductFlavor_MdFlavorId] ON [ProductFlavor] ([MdFlavorId]);
GO

CREATE INDEX [IX_ProductFlavor_ProductId] ON [ProductFlavor] ([ProductId]);
GO

CREATE INDEX [IX_ProductPrice_MdUnitMeasurementId] ON [ProductPrice] ([MdUnitMeasurementId]);
GO

CREATE INDEX [IX_ProductPrice_ProductId] ON [ProductPrice] ([ProductId]);
GO

CREATE UNIQUE INDEX [IX_Role_Code] ON [Role] ([Code]);
GO

CREATE INDEX [IX_Role_CompanyId] ON [Role] ([CompanyId]);
GO

CREATE INDEX [IX_User_CompanyId] ON [User] ([CompanyId]);
GO

CREATE INDEX [IX_UserRole_CampusId] ON [UserRole] ([CampusId]);
GO

CREATE INDEX [IX_UserRole_RoleId] ON [UserRole] ([RoleId]);
GO

CREATE INDEX [IX_UserRole_UserId] ON [UserRole] ([UserId]);
GO

CREATE UNIQUE INDEX [IX_UserToken_UserRoleId] ON [UserToken] ([UserRoleId]);
GO

ALTER TABLE [Archive] ADD CONSTRAINT [FK_Archive_Company_CompanyId] FOREIGN KEY ([CompanyId]) REFERENCES [Company] ([Id]) ON DELETE NO ACTION;
GO

ALTER TABLE [Archive] ADD CONSTRAINT [FK_Archive_MasterDetail_MdTypeArchiveId] FOREIGN KEY ([MdTypeArchiveId]) REFERENCES [MasterDetail] ([Id]) ON DELETE NO ACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230730032357_first1', N'7.0.9');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [EmployeeOrderProduct] ADD [OrderId] uniqueidentifier NULL;
GO

CREATE INDEX [IX_EmployeeOrderProduct_OrderId] ON [EmployeeOrderProduct] ([OrderId]);
GO

ALTER TABLE [EmployeeOrderProduct] ADD CONSTRAINT [FK_EmployeeOrderProduct_Order_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [Order] ([Id]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230731021512_second', N'7.0.9');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [PersonAmountAccount] DROP CONSTRAINT [FK_PersonAmountAccount_MasterDetail_MdStatusId];
GO

DROP INDEX [IX_PersonAmountAccount_MdStatusId] ON [PersonAmountAccount];
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[PersonAmountAccount]') AND [c].[name] = N'MdStatusId');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [PersonAmountAccount] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [PersonAmountAccount] DROP COLUMN [MdStatusId];
GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[OrderDetail]') AND [c].[name] = N'OrderDate');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [OrderDetail] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [OrderDetail] DROP COLUMN [OrderDate];
GO

ALTER TABLE [OrderDetail] ADD [IsAmountCalculate] bit NOT NULL DEFAULT CAST(0 AS bit);
GO

ALTER TABLE [Order] ADD [AmountReceived] money NOT NULL DEFAULT 0.0;
GO

CREATE TABLE [OrderTracking] (
    [Id] int NOT NULL IDENTITY,
    [OrderId] uniqueidentifier NOT NULL,
    [MdStatusId] int NOT NULL,
    [CreateUser] nvarchar(max) NOT NULL,
    [CreateDate] datetime2 NOT NULL,
    [ModifyUser] nvarchar(max) NOT NULL,
    [ModifyDate] datetime2 NULL,
    [DeleteUser] nvarchar(max) NOT NULL,
    [DeleteDate] datetime2 NULL,
    [IsDeleted] bit NOT NULL,
    [IsActive] bit NOT NULL,
    CONSTRAINT [PK_OrderTracking] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_OrderTracking_MasterDetail_MdStatusId] FOREIGN KEY ([MdStatusId]) REFERENCES [MasterDetail] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_OrderTracking_Order_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [Order] ([Id]) ON DELETE NO ACTION
);
GO

CREATE INDEX [IX_OrderTracking_MdStatusId] ON [OrderTracking] ([MdStatusId]);
GO

CREATE INDEX [IX_OrderTracking_OrderId] ON [OrderTracking] ([OrderId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230807002459_trhee', N'7.0.9');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[OrderTracking]') AND [c].[name] = N'ModifyUser');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [OrderTracking] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [OrderTracking] ALTER COLUMN [ModifyUser] nvarchar(50) NULL;
ALTER TABLE [OrderTracking] ADD DEFAULT N'system' FOR [ModifyUser];
GO

DECLARE @var3 sysname;
SELECT @var3 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[OrderTracking]') AND [c].[name] = N'IsDeleted');
IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [OrderTracking] DROP CONSTRAINT [' + @var3 + '];');
ALTER TABLE [OrderTracking] ADD DEFAULT CAST(0 AS bit) FOR [IsDeleted];
GO

DECLARE @var4 sysname;
SELECT @var4 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[OrderTracking]') AND [c].[name] = N'IsActive');
IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [OrderTracking] DROP CONSTRAINT [' + @var4 + '];');
ALTER TABLE [OrderTracking] ADD DEFAULT CAST(1 AS bit) FOR [IsActive];
GO

DECLARE @var5 sysname;
SELECT @var5 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[OrderTracking]') AND [c].[name] = N'DeleteUser');
IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [OrderTracking] DROP CONSTRAINT [' + @var5 + '];');
ALTER TABLE [OrderTracking] ALTER COLUMN [DeleteUser] nvarchar(50) NULL;
ALTER TABLE [OrderTracking] ADD DEFAULT N'system' FOR [DeleteUser];
GO

DECLARE @var6 sysname;
SELECT @var6 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[OrderTracking]') AND [c].[name] = N'CreateUser');
IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [OrderTracking] DROP CONSTRAINT [' + @var6 + '];');
ALTER TABLE [OrderTracking] ALTER COLUMN [CreateUser] nvarchar(50) NOT NULL;
ALTER TABLE [OrderTracking] ADD DEFAULT N'system' FOR [CreateUser];
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230807010031_four', N'7.0.9');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Person] ADD [DateBirthday] nvarchar(20) NOT NULL DEFAULT N'';
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230914204906_addColumnTbPerson', N'7.0.9');
GO

COMMIT;
GO

