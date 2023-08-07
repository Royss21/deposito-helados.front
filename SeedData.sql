
--COMPANIA
INSERT [dbo].[Company] ([Id], [Name], [BusinessName], [Ruc], [FiscalAddress], [ArchiveId], [CreateUser], [CreateDate], [ModifyUser], [ModifyDate], [DeleteUser], [DeleteDate], [IsDeleted], [IsActive]) VALUES (N'65c3c91f-9dc0-44eb-895d-e573170e24a6', N'Krovelsa', N'Krovelsa SAC', N'102020302012', N'', NULL, N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'', NULL, N'', NULL, 0, 0)
GO

--MAESTRO
INSERT [dbo].[Master] ([Id], [Code], [Name], [Description], [CreateUser], [CreateDate], [ModifyUser], [ModifyDate], [DeleteUser], [DeleteDate], [IsDeleted], [IsActive], [CompanyId]) VALUES (N'155e00d0-400e-4ecf-99d9-010957292df2', N'UM', N'Unit Measurement', N'Tabla para guardar las unidades de medida', N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'', NULL, N'', NULL, 0, 0, N'65c3c91f-9dc0-44eb-895d-e573170e24a6')
INSERT [dbo].[Master] ([Id], [Code], [Name], [Description], [CreateUser], [CreateDate], [ModifyUser], [ModifyDate], [DeleteUser], [DeleteDate], [IsDeleted], [IsActive], [CompanyId]) VALUES (N'6e1b3ca6-cee4-42ae-a9c2-42143da2df8e', N'DOCIDENT', N'Type Document Identity', N'Tabla para guardar los tipos de documento de identidad', N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'', NULL, N'', NULL, 0, 0, N'65c3c91f-9dc0-44eb-895d-e573170e24a6')
INSERT [dbo].[Master] ([Id], [Code], [Name], [Description], [CreateUser], [CreateDate], [ModifyUser], [ModifyDate], [DeleteUser], [DeleteDate], [IsDeleted], [IsActive], [CompanyId]) VALUES (N'84fc9e1b-1fe9-4090-aef1-934e452699c0', N'BRAND', N'Brand', N'Tabla para guardar las marcas', N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'', NULL, N'', NULL, 0, 0, N'65c3c91f-9dc0-44eb-895d-e573170e24a6')
INSERT [dbo].[Master] ([Id], [Code], [Name], [Description], [CreateUser], [CreateDate], [ModifyUser], [ModifyDate], [DeleteUser], [DeleteDate], [IsDeleted], [IsActive], [CompanyId]) VALUES (N'94e36fa2-f0a9-4f43-b140-e10c0a9b013d', N'UBI', N'Ubigeous', N'Tabla para guardar los ubigeos', N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'', NULL, N'', NULL, 0, 0, N'65c3c91f-9dc0-44eb-895d-e573170e24a6')
INSERT [dbo].[Master] ([Id], [Code], [Name], [Description], [CreateUser], [CreateDate], [ModifyUser], [ModifyDate], [DeleteUser], [DeleteDate], [IsDeleted], [IsActive], [CompanyId]) VALUES (N'19cdc88f-70e5-4af3-8df9-ea95bfa30938', N'FILE', N'Type File', N'Tabla para guardar los tipos de archivos', N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'', NULL, N'', NULL, 0, 0, N'65c3c91f-9dc0-44eb-895d-e573170e24a6')
GO

--MAETRO DETALLE
SET IDENTITY_INSERT [dbo].[MasterDetail] ON 

INSERT [dbo].[MasterDetail] ([Id], [MasterId], [Code], [Name], [Description], [AdditionalOne], [AdditionalTwo], [Sort], [CreateUser], [CreateDate], [ModifyUser], [ModifyDate], [DeleteUser], [DeleteDate], [IsDeleted], [IsActive]) VALUES (1, N'94e36fa2-f0a9-4f43-b140-e10c0a9b013d', N'15', N'Lima', N'', N'UBI', N'', 1, N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'', NULL, N'', NULL, 0, 0)
INSERT [dbo].[MasterDetail] ([Id], [MasterId], [Code], [Name], [Description], [AdditionalOne], [AdditionalTwo], [Sort], [CreateUser], [CreateDate], [ModifyUser], [ModifyDate], [DeleteUser], [DeleteDate], [IsDeleted], [IsActive]) VALUES (2, N'94e36fa2-f0a9-4f43-b140-e10c0a9b013d', N'1501', N'Lima', N'', N'UBI', N'', 2, N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'', NULL, N'', NULL, 0, 0)
INSERT [dbo].[MasterDetail] ([Id], [MasterId], [Code], [Name], [Description], [AdditionalOne], [AdditionalTwo], [Sort], [CreateUser], [CreateDate], [ModifyUser], [ModifyDate], [DeleteUser], [DeleteDate], [IsDeleted], [IsActive]) VALUES (3, N'94e36fa2-f0a9-4f43-b140-e10c0a9b013d', N'150101', N'Lima', N'', N'UBI', N'', 3, N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'', NULL, N'', NULL, 0, 0)
INSERT [dbo].[MasterDetail] ([Id], [MasterId], [Code], [Name], [Description], [AdditionalOne], [AdditionalTwo], [Sort], [CreateUser], [CreateDate], [ModifyUser], [ModifyDate], [DeleteUser], [DeleteDate], [IsDeleted], [IsActive]) VALUES (4, N'94e36fa2-f0a9-4f43-b140-e10c0a9b013d', N'150102', N'Ancón', N'', N'UBI', N'', 4, N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'', NULL, N'', NULL, 0, 0)
INSERT [dbo].[MasterDetail] ([Id], [MasterId], [Code], [Name], [Description], [AdditionalOne], [AdditionalTwo], [Sort], [CreateUser], [CreateDate], [ModifyUser], [ModifyDate], [DeleteUser], [DeleteDate], [IsDeleted], [IsActive]) VALUES (5, N'94e36fa2-f0a9-4f43-b140-e10c0a9b013d', N'150103', N'Ate', N'', N'UBI', N'', 5, N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'', NULL, N'', NULL, 0, 0)
INSERT [dbo].[MasterDetail] ([Id], [MasterId], [Code], [Name], [Description], [AdditionalOne], [AdditionalTwo], [Sort], [CreateUser], [CreateDate], [ModifyUser], [ModifyDate], [DeleteUser], [DeleteDate], [IsDeleted], [IsActive]) VALUES (6, N'94e36fa2-f0a9-4f43-b140-e10c0a9b013d', N'150104', N'Barranco', N'', N'UBI', N'', 6, N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'', NULL, N'', NULL, 0, 0)
INSERT [dbo].[MasterDetail] ([Id], [MasterId], [Code], [Name], [Description], [AdditionalOne], [AdditionalTwo], [Sort], [CreateUser], [CreateDate], [ModifyUser], [ModifyDate], [DeleteUser], [DeleteDate], [IsDeleted], [IsActive]) VALUES (7, N'94e36fa2-f0a9-4f43-b140-e10c0a9b013d', N'150105', N'Breña', N'', N'UBI', N'', 7, N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'', NULL, N'', NULL, 0, 0)
INSERT [dbo].[MasterDetail] ([Id], [MasterId], [Code], [Name], [Description], [AdditionalOne], [AdditionalTwo], [Sort], [CreateUser], [CreateDate], [ModifyUser], [ModifyDate], [DeleteUser], [DeleteDate], [IsDeleted], [IsActive]) VALUES (8, N'94e36fa2-f0a9-4f43-b140-e10c0a9b013d', N'150106', N'Carabayllo', N'', N'UBI', N'', 8, N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'', NULL, N'', NULL, 0, 0)
INSERT [dbo].[MasterDetail] ([Id], [MasterId], [Code], [Name], [Description], [AdditionalOne], [AdditionalTwo], [Sort], [CreateUser], [CreateDate], [ModifyUser], [ModifyDate], [DeleteUser], [DeleteDate], [IsDeleted], [IsActive]) VALUES (9, N'94e36fa2-f0a9-4f43-b140-e10c0a9b013d', N'150107', N'Chaclacayo', N'', N'UBI', N'', 9, N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'', NULL, N'', NULL, 0, 0)
INSERT [dbo].[MasterDetail] ([Id], [MasterId], [Code], [Name], [Description], [AdditionalOne], [AdditionalTwo], [Sort], [CreateUser], [CreateDate], [ModifyUser], [ModifyDate], [DeleteUser], [DeleteDate], [IsDeleted], [IsActive]) VALUES (10, N'94e36fa2-f0a9-4f43-b140-e10c0a9b013d', N'150108', N'Chorrillos', N'', N'UBI', N'', 10, N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'', NULL, N'', NULL, 0, 0)
INSERT [dbo].[MasterDetail] ([Id], [MasterId], [Code], [Name], [Description], [AdditionalOne], [AdditionalTwo], [Sort], [CreateUser], [CreateDate], [ModifyUser], [ModifyDate], [DeleteUser], [DeleteDate], [IsDeleted], [IsActive]) VALUES (11, N'94e36fa2-f0a9-4f43-b140-e10c0a9b013d', N'150109', N'Cieneguilla', N'', N'UBI', N'', 11, N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'', NULL, N'', NULL, 0, 0)
INSERT [dbo].[MasterDetail] ([Id], [MasterId], [Code], [Name], [Description], [AdditionalOne], [AdditionalTwo], [Sort], [CreateUser], [CreateDate], [ModifyUser], [ModifyDate], [DeleteUser], [DeleteDate], [IsDeleted], [IsActive]) VALUES (12, N'94e36fa2-f0a9-4f43-b140-e10c0a9b013d', N'150110', N'Comas', N'', N'UBI', N'', 12, N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'', NULL, N'', NULL, 0, 0)
INSERT [dbo].[MasterDetail] ([Id], [MasterId], [Code], [Name], [Description], [AdditionalOne], [AdditionalTwo], [Sort], [CreateUser], [CreateDate], [ModifyUser], [ModifyDate], [DeleteUser], [DeleteDate], [IsDeleted], [IsActive]) VALUES (13, N'94e36fa2-f0a9-4f43-b140-e10c0a9b013d', N'150111', N'El Agustino', N'', N'UBI', N'', 13, N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'', NULL, N'', NULL, 0, 0)
INSERT [dbo].[MasterDetail] ([Id], [MasterId], [Code], [Name], [Description], [AdditionalOne], [AdditionalTwo], [Sort], [CreateUser], [CreateDate], [ModifyUser], [ModifyDate], [DeleteUser], [DeleteDate], [IsDeleted], [IsActive]) VALUES (14, N'94e36fa2-f0a9-4f43-b140-e10c0a9b013d', N'150112', N'Independencia', N'', N'UBI', N'', 14, N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'', NULL, N'', NULL, 0, 0)
INSERT [dbo].[MasterDetail] ([Id], [MasterId], [Code], [Name], [Description], [AdditionalOne], [AdditionalTwo], [Sort], [CreateUser], [CreateDate], [ModifyUser], [ModifyDate], [DeleteUser], [DeleteDate], [IsDeleted], [IsActive]) VALUES (15, N'94e36fa2-f0a9-4f43-b140-e10c0a9b013d', N'150113', N'Jesús María', N'', N'UBI', N'', 15, N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'', NULL, N'', NULL, 0, 0)
INSERT [dbo].[MasterDetail] ([Id], [MasterId], [Code], [Name], [Description], [AdditionalOne], [AdditionalTwo], [Sort], [CreateUser], [CreateDate], [ModifyUser], [ModifyDate], [DeleteUser], [DeleteDate], [IsDeleted], [IsActive]) VALUES (16, N'94e36fa2-f0a9-4f43-b140-e10c0a9b013d', N'150114', N'La Molina', N'', N'UBI', N'', 16, N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'', NULL, N'', NULL, 0, 0)
INSERT [dbo].[MasterDetail] ([Id], [MasterId], [Code], [Name], [Description], [AdditionalOne], [AdditionalTwo], [Sort], [CreateUser], [CreateDate], [ModifyUser], [ModifyDate], [DeleteUser], [DeleteDate], [IsDeleted], [IsActive]) VALUES (17, N'94e36fa2-f0a9-4f43-b140-e10c0a9b013d', N'150115', N'La Victoria', N'', N'UBI', N'', 17, N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'', NULL, N'', NULL, 0, 0)
INSERT [dbo].[MasterDetail] ([Id], [MasterId], [Code], [Name], [Description], [AdditionalOne], [AdditionalTwo], [Sort], [CreateUser], [CreateDate], [ModifyUser], [ModifyDate], [DeleteUser], [DeleteDate], [IsDeleted], [IsActive]) VALUES (18, N'94e36fa2-f0a9-4f43-b140-e10c0a9b013d', N'150116', N'Lince', N'', N'UBI', N'', 18, N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'', NULL, N'', NULL, 0, 0)
INSERT [dbo].[MasterDetail] ([Id], [MasterId], [Code], [Name], [Description], [AdditionalOne], [AdditionalTwo], [Sort], [CreateUser], [CreateDate], [ModifyUser], [ModifyDate], [DeleteUser], [DeleteDate], [IsDeleted], [IsActive]) VALUES (19, N'94e36fa2-f0a9-4f43-b140-e10c0a9b013d', N'150117', N'Los Olivos', N'', N'UBI', N'', 19, N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'', NULL, N'', NULL, 0, 0)
INSERT [dbo].[MasterDetail] ([Id], [MasterId], [Code], [Name], [Description], [AdditionalOne], [AdditionalTwo], [Sort], [CreateUser], [CreateDate], [ModifyUser], [ModifyDate], [DeleteUser], [DeleteDate], [IsDeleted], [IsActive]) VALUES (20, N'94e36fa2-f0a9-4f43-b140-e10c0a9b013d', N'150118', N'Lurigancho', N'', N'UBI', N'', 20, N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'', NULL, N'', NULL, 0, 0)
INSERT [dbo].[MasterDetail] ([Id], [MasterId], [Code], [Name], [Description], [AdditionalOne], [AdditionalTwo], [Sort], [CreateUser], [CreateDate], [ModifyUser], [ModifyDate], [DeleteUser], [DeleteDate], [IsDeleted], [IsActive]) VALUES (21, N'94e36fa2-f0a9-4f43-b140-e10c0a9b013d', N'150119', N'Lurin', N'', N'UBI', N'', 21, N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'', NULL, N'', NULL, 0, 0)
INSERT [dbo].[MasterDetail] ([Id], [MasterId], [Code], [Name], [Description], [AdditionalOne], [AdditionalTwo], [Sort], [CreateUser], [CreateDate], [ModifyUser], [ModifyDate], [DeleteUser], [DeleteDate], [IsDeleted], [IsActive]) VALUES (22, N'94e36fa2-f0a9-4f43-b140-e10c0a9b013d', N'150120', N'Magdalena del Mar', N'', N'UBI', N'', 22, N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'', NULL, N'', NULL, 0, 0)
INSERT [dbo].[MasterDetail] ([Id], [MasterId], [Code], [Name], [Description], [AdditionalOne], [AdditionalTwo], [Sort], [CreateUser], [CreateDate], [ModifyUser], [ModifyDate], [DeleteUser], [DeleteDate], [IsDeleted], [IsActive]) VALUES (23, N'94e36fa2-f0a9-4f43-b140-e10c0a9b013d', N'150121', N'Pueblo Libre', N'', N'UBI', N'', 23, N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'', NULL, N'', NULL, 0, 0)
INSERT [dbo].[MasterDetail] ([Id], [MasterId], [Code], [Name], [Description], [AdditionalOne], [AdditionalTwo], [Sort], [CreateUser], [CreateDate], [ModifyUser], [ModifyDate], [DeleteUser], [DeleteDate], [IsDeleted], [IsActive]) VALUES (24, N'94e36fa2-f0a9-4f43-b140-e10c0a9b013d', N'150122', N'Miraflores', N'', N'UBI', N'', 24, N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'', NULL, N'', NULL, 0, 0)
INSERT [dbo].[MasterDetail] ([Id], [MasterId], [Code], [Name], [Description], [AdditionalOne], [AdditionalTwo], [Sort], [CreateUser], [CreateDate], [ModifyUser], [ModifyDate], [DeleteUser], [DeleteDate], [IsDeleted], [IsActive]) VALUES (25, N'94e36fa2-f0a9-4f43-b140-e10c0a9b013d', N'150123', N'Pachacamac', N'', N'UBI', N'', 25, N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'', NULL, N'', NULL, 0, 0)
INSERT [dbo].[MasterDetail] ([Id], [MasterId], [Code], [Name], [Description], [AdditionalOne], [AdditionalTwo], [Sort], [CreateUser], [CreateDate], [ModifyUser], [ModifyDate], [DeleteUser], [DeleteDate], [IsDeleted], [IsActive]) VALUES (26, N'94e36fa2-f0a9-4f43-b140-e10c0a9b013d', N'150124', N'Pucusana', N'', N'UBI', N'', 26, N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'', NULL, N'', NULL, 0, 0)
INSERT [dbo].[MasterDetail] ([Id], [MasterId], [Code], [Name], [Description], [AdditionalOne], [AdditionalTwo], [Sort], [CreateUser], [CreateDate], [ModifyUser], [ModifyDate], [DeleteUser], [DeleteDate], [IsDeleted], [IsActive]) VALUES (27, N'94e36fa2-f0a9-4f43-b140-e10c0a9b013d', N'150125', N'Puente Piedra', N'', N'UBI', N'', 27, N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'', NULL, N'', NULL, 0, 0)
INSERT [dbo].[MasterDetail] ([Id], [MasterId], [Code], [Name], [Description], [AdditionalOne], [AdditionalTwo], [Sort], [CreateUser], [CreateDate], [ModifyUser], [ModifyDate], [DeleteUser], [DeleteDate], [IsDeleted], [IsActive]) VALUES (28, N'94e36fa2-f0a9-4f43-b140-e10c0a9b013d', N'150126', N'Punta Hermosa', N'', N'UBI', N'', 28, N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'', NULL, N'', NULL, 0, 0)
INSERT [dbo].[MasterDetail] ([Id], [MasterId], [Code], [Name], [Description], [AdditionalOne], [AdditionalTwo], [Sort], [CreateUser], [CreateDate], [ModifyUser], [ModifyDate], [DeleteUser], [DeleteDate], [IsDeleted], [IsActive]) VALUES (29, N'94e36fa2-f0a9-4f43-b140-e10c0a9b013d', N'150127', N'Punta Negra', N'', N'UBI', N'', 29, N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'', NULL, N'', NULL, 0, 0)
INSERT [dbo].[MasterDetail] ([Id], [MasterId], [Code], [Name], [Description], [AdditionalOne], [AdditionalTwo], [Sort], [CreateUser], [CreateDate], [ModifyUser], [ModifyDate], [DeleteUser], [DeleteDate], [IsDeleted], [IsActive]) VALUES (30, N'94e36fa2-f0a9-4f43-b140-e10c0a9b013d', N'150128', N'Rímac', N'', N'UBI', N'', 30, N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'', NULL, N'', NULL, 0, 0)
INSERT [dbo].[MasterDetail] ([Id], [MasterId], [Code], [Name], [Description], [AdditionalOne], [AdditionalTwo], [Sort], [CreateUser], [CreateDate], [ModifyUser], [ModifyDate], [DeleteUser], [DeleteDate], [IsDeleted], [IsActive]) VALUES (31, N'94e36fa2-f0a9-4f43-b140-e10c0a9b013d', N'150129', N'San Bartolo', N'', N'UBI', N'', 31, N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'', NULL, N'', NULL, 0, 0)
INSERT [dbo].[MasterDetail] ([Id], [MasterId], [Code], [Name], [Description], [AdditionalOne], [AdditionalTwo], [Sort], [CreateUser], [CreateDate], [ModifyUser], [ModifyDate], [DeleteUser], [DeleteDate], [IsDeleted], [IsActive]) VALUES (32, N'94e36fa2-f0a9-4f43-b140-e10c0a9b013d', N'150130', N'San Borja', N'', N'UBI', N'', 32, N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'', NULL, N'', NULL, 0, 0)
INSERT [dbo].[MasterDetail] ([Id], [MasterId], [Code], [Name], [Description], [AdditionalOne], [AdditionalTwo], [Sort], [CreateUser], [CreateDate], [ModifyUser], [ModifyDate], [DeleteUser], [DeleteDate], [IsDeleted], [IsActive]) VALUES (33, N'94e36fa2-f0a9-4f43-b140-e10c0a9b013d', N'150131', N'San Isidro', N'', N'UBI', N'', 33, N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'', NULL, N'', NULL, 0, 0)
INSERT [dbo].[MasterDetail] ([Id], [MasterId], [Code], [Name], [Description], [AdditionalOne], [AdditionalTwo], [Sort], [CreateUser], [CreateDate], [ModifyUser], [ModifyDate], [DeleteUser], [DeleteDate], [IsDeleted], [IsActive]) VALUES (34, N'94e36fa2-f0a9-4f43-b140-e10c0a9b013d', N'150132', N'San Juan de Lurigancho', N'', N'UBI', N'', 34, N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'', NULL, N'', NULL, 0, 0)
INSERT [dbo].[MasterDetail] ([Id], [MasterId], [Code], [Name], [Description], [AdditionalOne], [AdditionalTwo], [Sort], [CreateUser], [CreateDate], [ModifyUser], [ModifyDate], [DeleteUser], [DeleteDate], [IsDeleted], [IsActive]) VALUES (35, N'94e36fa2-f0a9-4f43-b140-e10c0a9b013d', N'150133', N'San Juan de Miraflores', N'', N'UBI', N'', 35, N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'', NULL, N'', NULL, 0, 0)
INSERT [dbo].[MasterDetail] ([Id], [MasterId], [Code], [Name], [Description], [AdditionalOne], [AdditionalTwo], [Sort], [CreateUser], [CreateDate], [ModifyUser], [ModifyDate], [DeleteUser], [DeleteDate], [IsDeleted], [IsActive]) VALUES (36, N'94e36fa2-f0a9-4f43-b140-e10c0a9b013d', N'150134', N'San Luis', N'', N'UBI', N'', 36, N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'', NULL, N'', NULL, 0, 0)
INSERT [dbo].[MasterDetail] ([Id], [MasterId], [Code], [Name], [Description], [AdditionalOne], [AdditionalTwo], [Sort], [CreateUser], [CreateDate], [ModifyUser], [ModifyDate], [DeleteUser], [DeleteDate], [IsDeleted], [IsActive]) VALUES (37, N'94e36fa2-f0a9-4f43-b140-e10c0a9b013d', N'150135', N'San Martín de Porres', N'', N'UBI', N'', 37, N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'', NULL, N'', NULL, 0, 0)
INSERT [dbo].[MasterDetail] ([Id], [MasterId], [Code], [Name], [Description], [AdditionalOne], [AdditionalTwo], [Sort], [CreateUser], [CreateDate], [ModifyUser], [ModifyDate], [DeleteUser], [DeleteDate], [IsDeleted], [IsActive]) VALUES (38, N'94e36fa2-f0a9-4f43-b140-e10c0a9b013d', N'150136', N'San Miguel', N'', N'UBI', N'', 38, N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'', NULL, N'', NULL, 0, 0)
INSERT [dbo].[MasterDetail] ([Id], [MasterId], [Code], [Name], [Description], [AdditionalOne], [AdditionalTwo], [Sort], [CreateUser], [CreateDate], [ModifyUser], [ModifyDate], [DeleteUser], [DeleteDate], [IsDeleted], [IsActive]) VALUES (39, N'94e36fa2-f0a9-4f43-b140-e10c0a9b013d', N'150137', N'Santa Anita', N'', N'UBI', N'', 39, N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'', NULL, N'', NULL, 0, 0)
INSERT [dbo].[MasterDetail] ([Id], [MasterId], [Code], [Name], [Description], [AdditionalOne], [AdditionalTwo], [Sort], [CreateUser], [CreateDate], [ModifyUser], [ModifyDate], [DeleteUser], [DeleteDate], [IsDeleted], [IsActive]) VALUES (40, N'94e36fa2-f0a9-4f43-b140-e10c0a9b013d', N'150138', N'Santa María del Mar', N'', N'UBI', N'', 40, N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'', NULL, N'', NULL, 0, 0)
INSERT [dbo].[MasterDetail] ([Id], [MasterId], [Code], [Name], [Description], [AdditionalOne], [AdditionalTwo], [Sort], [CreateUser], [CreateDate], [ModifyUser], [ModifyDate], [DeleteUser], [DeleteDate], [IsDeleted], [IsActive]) VALUES (41, N'94e36fa2-f0a9-4f43-b140-e10c0a9b013d', N'150139', N'Santa Rosa', N'', N'UBI', N'', 41, N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'', NULL, N'', NULL, 0, 0)
INSERT [dbo].[MasterDetail] ([Id], [MasterId], [Code], [Name], [Description], [AdditionalOne], [AdditionalTwo], [Sort], [CreateUser], [CreateDate], [ModifyUser], [ModifyDate], [DeleteUser], [DeleteDate], [IsDeleted], [IsActive]) VALUES (42, N'94e36fa2-f0a9-4f43-b140-e10c0a9b013d', N'150140', N'Santiago de Surco', N'', N'UBI', N'', 42, N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'', NULL, N'', NULL, 0, 0)
INSERT [dbo].[MasterDetail] ([Id], [MasterId], [Code], [Name], [Description], [AdditionalOne], [AdditionalTwo], [Sort], [CreateUser], [CreateDate], [ModifyUser], [ModifyDate], [DeleteUser], [DeleteDate], [IsDeleted], [IsActive]) VALUES (43, N'94e36fa2-f0a9-4f43-b140-e10c0a9b013d', N'150141', N'Surquillo', N'', N'UBI', N'', 43, N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'', NULL, N'', NULL, 0, 0)
INSERT [dbo].[MasterDetail] ([Id], [MasterId], [Code], [Name], [Description], [AdditionalOne], [AdditionalTwo], [Sort], [CreateUser], [CreateDate], [ModifyUser], [ModifyDate], [DeleteUser], [DeleteDate], [IsDeleted], [IsActive]) VALUES (44, N'94e36fa2-f0a9-4f43-b140-e10c0a9b013d', N'150142', N'Villa El Salvador', N'', N'UBI', N'', 44, N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'', NULL, N'', NULL, 0, 0)
INSERT [dbo].[MasterDetail] ([Id], [MasterId], [Code], [Name], [Description], [AdditionalOne], [AdditionalTwo], [Sort], [CreateUser], [CreateDate], [ModifyUser], [ModifyDate], [DeleteUser], [DeleteDate], [IsDeleted], [IsActive]) VALUES (45, N'94e36fa2-f0a9-4f43-b140-e10c0a9b013d', N'150143', N'Villa María del Triunfo', N'', N'UBI', N'', 45, N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'', NULL, N'', NULL, 0, 0)
INSERT [dbo].[MasterDetail] ([Id], [MasterId], [Code], [Name], [Description], [AdditionalOne], [AdditionalTwo], [Sort], [CreateUser], [CreateDate], [ModifyUser], [ModifyDate], [DeleteUser], [DeleteDate], [IsDeleted], [IsActive]) VALUES (46, N'155e00d0-400e-4ecf-99d9-010957292df2', N'UM01', N'Unidad', N'', N'UM', N'', 1, N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'', NULL, N'', NULL, 0, 0)
INSERT [dbo].[MasterDetail] ([Id], [MasterId], [Code], [Name], [Description], [AdditionalOne], [AdditionalTwo], [Sort], [CreateUser], [CreateDate], [ModifyUser], [ModifyDate], [DeleteUser], [DeleteDate], [IsDeleted], [IsActive]) VALUES (47, N'155e00d0-400e-4ecf-99d9-010957292df2', N'UM02', N'Caja', N'', N'UM', N'', 2, N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'', NULL, N'', NULL, 0, 0)
INSERT [dbo].[MasterDetail] ([Id], [MasterId], [Code], [Name], [Description], [AdditionalOne], [AdditionalTwo], [Sort], [CreateUser], [CreateDate], [ModifyUser], [ModifyDate], [DeleteUser], [DeleteDate], [IsDeleted], [IsActive]) VALUES (48, N'155e00d0-400e-4ecf-99d9-010957292df2', N'UM03', N'Cubeta', N'', N'UM', N'', 3, N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'', NULL, N'', NULL, 0, 0)
INSERT [dbo].[MasterDetail] ([Id], [MasterId], [Code], [Name], [Description], [AdditionalOne], [AdditionalTwo], [Sort], [CreateUser], [CreateDate], [ModifyUser], [ModifyDate], [DeleteUser], [DeleteDate], [IsDeleted], [IsActive]) VALUES (49, N'155e00d0-400e-4ecf-99d9-010957292df2', N'UM04', N'Media Cubeta 1/2', N'', N'UM', N'', 4, N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'', NULL, N'', NULL, 0, 0)
INSERT [dbo].[MasterDetail] ([Id], [MasterId], [Code], [Name], [Description], [AdditionalOne], [AdditionalTwo], [Sort], [CreateUser], [CreateDate], [ModifyUser], [ModifyDate], [DeleteUser], [DeleteDate], [IsDeleted], [IsActive]) VALUES (50, N'84fc9e1b-1fe9-4090-aef1-934e452699c0', N'BRAND01', N'Donofrio', N'', N'BRAND', N'', 1, N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'', NULL, N'', NULL, 0, 0)
INSERT [dbo].[MasterDetail] ([Id], [MasterId], [Code], [Name], [Description], [AdditionalOne], [AdditionalTwo], [Sort], [CreateUser], [CreateDate], [ModifyUser], [ModifyDate], [DeleteUser], [DeleteDate], [IsDeleted], [IsActive]) VALUES (51, N'84fc9e1b-1fe9-4090-aef1-934e452699c0', N'BRAND02', N'Yamboly', N'', N'BRAND', N'', 2, N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'', NULL, N'', NULL, 0, 0)
INSERT [dbo].[MasterDetail] ([Id], [MasterId], [Code], [Name], [Description], [AdditionalOne], [AdditionalTwo], [Sort], [CreateUser], [CreateDate], [ModifyUser], [ModifyDate], [DeleteUser], [DeleteDate], [IsDeleted], [IsActive]) VALUES (52, N'6e1b3ca6-cee4-42ae-a9c2-42143da2df8e', N'DOCIDENT01', N'DNI', N'Documento de Identidad', N'DOCIDENT', N'', 1, N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'', NULL, N'', NULL, 0, 0)
INSERT [dbo].[MasterDetail] ([Id], [MasterId], [Code], [Name], [Description], [AdditionalOne], [AdditionalTwo], [Sort], [CreateUser], [CreateDate], [ModifyUser], [ModifyDate], [DeleteUser], [DeleteDate], [IsDeleted], [IsActive]) VALUES (53, N'6e1b3ca6-cee4-42ae-a9c2-42143da2df8e', N'DOCIDENT02', N'PASS', N'Pasaporte', N'DOCIDENT', N'', 2, N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'', NULL, N'', NULL, 0, 0)
INSERT [dbo].[MasterDetail] ([Id], [MasterId], [Code], [Name], [Description], [AdditionalOne], [AdditionalTwo], [Sort], [CreateUser], [CreateDate], [ModifyUser], [ModifyDate], [DeleteUser], [DeleteDate], [IsDeleted], [IsActive]) VALUES (54, N'6e1b3ca6-cee4-42ae-a9c2-42143da2df8e', N'DOCIDENT03', N'CEX', N'Carnet de Extranjeria', N'DOCIDENT', N'', 3, N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'', NULL, N'', NULL, 0, 0)
INSERT [dbo].[MasterDetail] ([Id], [MasterId], [Code], [Name], [Description], [AdditionalOne], [AdditionalTwo], [Sort], [CreateUser], [CreateDate], [ModifyUser], [ModifyDate], [DeleteUser], [DeleteDate], [IsDeleted], [IsActive]) VALUES (55, N'19cdc88f-70e5-4af3-8df9-ea95bfa30938', N'FILE01', N'Imagen', N'', N'FILE', N'', 1, N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'', NULL, N'', NULL, 0, 0)
INSERT [dbo].[MasterDetail] ([Id], [MasterId], [Code], [Name], [Description], [AdditionalOne], [AdditionalTwo], [Sort], [CreateUser], [CreateDate], [ModifyUser], [ModifyDate], [DeleteUser], [DeleteDate], [IsDeleted], [IsActive]) VALUES (56, N'19cdc88f-70e5-4af3-8df9-ea95bfa30938', N'FILE02', N'Documento Word', N'', N'FILE', N'', 2, N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'', NULL, N'', NULL, 0, 0)
INSERT [dbo].[MasterDetail] ([Id], [MasterId], [Code], [Name], [Description], [AdditionalOne], [AdditionalTwo], [Sort], [CreateUser], [CreateDate], [ModifyUser], [ModifyDate], [DeleteUser], [DeleteDate], [IsDeleted], [IsActive]) VALUES (57, N'19cdc88f-70e5-4af3-8df9-ea95bfa30938', N'FILE03', N'Documento Excel', N'', N'FILE', N'', 3, N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'', NULL, N'', NULL, 0, 0)
INSERT [dbo].[MasterDetail] ([Id], [MasterId], [Code], [Name], [Description], [AdditionalOne], [AdditionalTwo], [Sort], [CreateUser], [CreateDate], [ModifyUser], [ModifyDate], [DeleteUser], [DeleteDate], [IsDeleted], [IsActive]) VALUES (58, N'19cdc88f-70e5-4af3-8df9-ea95bfa30938', N'FILE04', N'Documento Pdf', N'', N'FILE', N'', 4, N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'', NULL, N'', NULL, 0, 0)


insert into [Master]
(id, Code, Name, Description, CompanyId, CreateDate)
values
('EACC34D4-4C32-470A-A427-A3D4684C1841', 'TYPEORDER', 'TypeOrder', 'Tabla donde se guarda los tipos de pedidos', '65C3C91F-9DC0-44EB-895D-E573170E24A6', GETDATE()),
('DAB0BDA8-D8CE-479C-A11A-83E18B73E4F7', 'STATUS', 'Status', 'Tabla para guardar los estados', '65C3C91F-9DC0-44EB-895D-E573170E24A6', GETDATE())



insert into MasterDetail
(MasterId, Code, Name, Description, AdditionalOne, AdditionalTwo, CreateDate, Sort)
values
('EACC34D4-4C32-470A-A427-A3D4684C1841', 'TYPEORDER01', 'Pedidos de Empleado', '','TYPEORDER', '', getdate(), 1),
('EACC34D4-4C32-470A-A427-A3D4684C1841', 'TYPEORDER02', 'Pedidos de Cliente', '','TYPEORDER', '', getdate(), 2),
('DAB0BDA8-D8CE-479C-A11A-83E18B73E4F7', 'STATUS01', 'Registrado', '','STATUS', '', getdate(), 1),
('DAB0BDA8-D8CE-479C-A11A-83E18B73E4F7', 'STATUS02', 'Pagado', '','STATUS', '', getdate(), 2),
('DAB0BDA8-D8CE-479C-A11A-83E18B73E4F7', 'STATUS03', 'Pendiente de Pago', '','STATUS', '', getdate(), 3),
('DAB0BDA8-D8CE-479C-A11A-83E18B73E4F7', 'STATUS04', 'Terminado', '','STATUS', '', getdate(), 4),
('DAB0BDA8-D8CE-479C-A11A-83E18B73E4F7', 'STATUS05', 'Cancelado', '','STATUS', '', getdate(), 5),
('DAB0BDA8-D8CE-479C-A11A-83E18B73E4F7', 'STATUS06', 'Anulado', '','STATUS', '', getdate(), 6)

GO

--ROLES

insert into [Role]
(name, Code, CreateUser, CreateDate, CompanyId)
values
('Empleado', 'EMPLOYEE', 'system', getdate(), '65C3C91F-9DC0-44EB-895D-E573170E24A6'),
('Cliente', 'CUSTOMER', 'system', getdate(), '65C3C91F-9DC0-44EB-895D-E573170E24A6')

GO

--CATEGORIAS
insert into Category
(Name, Description, Icon, Sort, CategoryParentId, CompanyId, CreateDate)
values
('Helados de Crema', '','', 1, null, '65C3C91F-9DC0-44EB-895D-E573170E24A6', getdate()),
('Cubeta de 5L', '','', 2, null, '65C3C91F-9DC0-44EB-895D-E573170E24A6', getdate()),
('Helados de Hielo', '','', 3, null, '65C3C91F-9DC0-44EB-895D-E573170E24A6', getdate()),
('Helados en vaso', '','', 3, null, '65C3C91F-9DC0-44EB-895D-E573170E24A6', getdate())

GO

--PRODUCTOS
insert into Product
(id, MdBrandId, Name, Description, CreateUser, CreateDate, CompanyId)
values
('D8EA2F78-705C-4C36-9C47-27DBD460C8C6', 50, 'Turbo', 'Helado de turbo', 'system', getdate(), '65C3C91F-9DC0-44EB-895D-E573170E24A6'),
('EDEFFADC-13E1-450E-8943-9E9D413F811C', 50, 'Sin parar de Lucuma chip', '', 'system', getdate(), '65C3C91F-9DC0-44EB-895D-E573170E24A6'),
('0C88D3FA-FFB1-4284-B1C5-5FF4E0B3B6A5', 51, 'Cubeta', '', 'system', getdate(), '65C3C91F-9DC0-44EB-895D-E573170E24A6'),
('8F17669E-6869-476C-941E-EEA5BCAF28ED', 51, 'Crema de Lucuma', 'Helado de turbo', 'system', getdate(), '65C3C91F-9DC0-44EB-895D-E573170E24A6')

GO

--PRODUCT PRECIOS
insert into ProductPrice
(ProductId, MdUnitMeasurementId, PurchasePrice, SalePrice, PublicPrice, EmployeePrice, OtherPriceOne, OtherPriceTwo,  CreateUser, CreateDate)
values
('D8EA2F78-705C-4C36-9C47-27DBD460C8C6', 46,0 ,0 ,0 ,0 ,0,0 ,'system', getdate()),
('D8EA2F78-705C-4C36-9C47-27DBD460C8C6', 47,0 ,0 ,0 ,0 ,0,0 ,'system', getdate()),
('EDEFFADC-13E1-450E-8943-9E9D413F811C', 46,0 ,0 ,0 ,0 ,0,0 ,'system', getdate()),
('EDEFFADC-13E1-450E-8943-9E9D413F811C', 47,0 ,0 ,0 ,0 ,0,0 ,'system', getdate()),
('8F17669E-6869-476C-941E-EEA5BCAF28ED', 46,0 ,0 ,0 ,0 ,0,0 ,'system', getdate()),
('8F17669E-6869-476C-941E-EEA5BCAF28ED', 47,0 ,0 ,0 ,0 ,0,0 ,'system', getdate()),
('0C88D3FA-FFB1-4284-B1C5-5FF4E0B3B6A5', 48,0 ,0 ,0 ,0 ,0,0 ,'system', getdate()),
('0C88D3FA-FFB1-4284-B1C5-5FF4E0B3B6A5', 49,0 ,0 ,0 ,0 ,0,0 ,'system', getdate())

GO

--CAMPUS
insert into Campus
(Name, FiscalAddress, CreateUser, CreateDate, CompanyId)
values
('Krovelsa', 'Alguna direccion', 'system', getdate(), '65C3C91F-9DC0-44EB-895D-E573170E24A6')

GO

--PERSONAS
insert into Person
(id, FirstName, SecondName, LastName, MiddleName, IdentityDocument, Email, PhoneNumber, MdIdentityDocumentTypeId, CreateUser, CreateDate, CompanyId)
values
('52739176-6178-4E39-8C5A-0C656103A04E','Royss', 'Hugo', 'Martel', 'Massi', '76602051', 'martel.royss21@gmail.com', '980444507',52, 'system', getdate(), '65C3C91F-9DC0-44EB-895D-E573170E24A6'),
('BB004C6A-C4F4-43BA-9846-17389732B9CD','Valois', 'Hugo', 'Martel', 'Duran', '12345678', 'valor@gmail.com', '980444507',52, 'system', getdate(), '65C3C91F-9DC0-44EB-895D-E573170E24A6'),
('26F1086A-0326-4972-A9E0-61F360C1AA31','Maria', 'Ivette', 'Ignacio', 'Diaz', '87654321', 'maria@gmail.com', '980444507',52, 'system', getdate(), '65C3C91F-9DC0-44EB-895D-E573170E24A6')

GO

--PERSONA DIRECCIONES
insert into PersonAddress
(PersonId, MdPostalCodeId, Address, ReferenceAddress, CreateUser, CreateDate)
values
('52739176-6178-4E39-8C5A-0C656103A04E',3, '---', '---', 'system', GETDATE() ),
('BB004C6A-C4F4-43BA-9846-17389732B9CD',3, '---', '---', 'system', GETDATE() ),
('26F1086A-0326-4972-A9E0-61F360C1AA31',3, '---', '---', 'system', GETDATE() )

GO

--PERSONA ROLES

insert into PersonRole
(PersonId, RoleId, CampusId, UniqueCode, CreateUser, CreateDate)
values
('52739176-6178-4E39-8C5A-0C656103A04E', 1, 1,'EMP00000001', 'system', getdate()),
('BB004C6A-C4F4-43BA-9846-17389732B9CD', 1, 1,'EMP00000002', 'system', getdate()),
('26F1086A-0326-4972-A9E0-61F360C1AA31', 1, 1,'EMP00000003', 'system', getdate())
