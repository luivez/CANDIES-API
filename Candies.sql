USE [Candies]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 13/04/2020 14:32:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[idClient] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[address] [nvarchar](200) NULL,
	[coordinate] [nvarchar](200) NULL,
	[nit] [nvarchar](10) NULL,
	[wholesaler] [bit] NOT NULL,
	[email] [nvarchar](100) NULL,
	[idPerson] [int] NOT NULL,
	[urlPage] [nvarchar](500) NULL,
	[state] [bit] NOT NULL,
 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
	[idClient] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ClientMachine]    Script Date: 13/04/2020 14:32:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClientMachine](
	[idClientMachine] [int] IDENTITY(1,1) NOT NULL,
	[idClient] [int] NOT NULL,
	[idMachine] [int] NOT NULL,
	[dateAssignment] [datetime2](7) NOT NULL,
	[state] [bit] NOT NULL,
 CONSTRAINT [PK_ClientMachine] PRIMARY KEY CLUSTERED 
(
	[idClientMachine] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Machine]    Script Date: 13/04/2020 14:32:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Machine](
	[idMachine] [int] IDENTITY(1,1) NOT NULL,
	[idStatusMachine] [int] NOT NULL,
	[capacity] [int] NOT NULL,
 CONSTRAINT [PK_Machine] PRIMARY KEY CLUSTERED 
(
	[idMachine] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Notification]    Script Date: 13/04/2020 14:32:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notification](
	[idNotification] [int] IDENTITY(1,1) NOT NULL,
	[idClient] [int] NOT NULL,
	[idUser] [int] NOT NULL,
	[date] [datetime2](7) NOT NULL,
	[idStatusMachine] [int] NOT NULL,
	[totalSales] [real] NOT NULL,
 CONSTRAINT [PK_Notification] PRIMARY KEY CLUSTERED 
(
	[idNotification] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OperationProductEntry]    Script Date: 13/04/2020 14:32:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OperationProductEntry](
	[idOperationEntry] [int] IDENTITY(1,1) NOT NULL,
	[dateOperation] [datetime2](7) NOT NULL,
	[idProducto] [int] NOT NULL,
	[quantity] [int] NOT NULL,
	[unitValue] [real] NOT NULL,
	[idProvider] [int] NULL,
 CONSTRAINT [PK_OperationProductEntry] PRIMARY KEY CLUSTERED 
(
	[idOperationEntry] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OperationProductOutput]    Script Date: 13/04/2020 14:32:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OperationProductOutput](
	[idOperationOutput] [int] IDENTITY(1,1) NOT NULL,
	[dateOperation] [datetime2](7) NOT NULL,
	[idProducto] [int] NOT NULL,
	[quantity] [int] NOT NULL,
	[unitValue] [real] NOT NULL,
	[idClient] [int] NOT NULL,
	[idNotification] [int] NULL,
 CONSTRAINT [PK_OperationProductOutput] PRIMARY KEY CLUSTERED 
(
	[idOperationOutput] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Page]    Script Date: 13/04/2020 14:32:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Page](
	[idPage] [int] IDENTITY(1,1) NOT NULL,
	[description] [nvarchar](50) NULL,
	[state] [bit] NOT NULL,
 CONSTRAINT [PK_Page] PRIMARY KEY CLUSTERED 
(
	[idPage] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Person]    Script Date: 13/04/2020 14:32:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[idPerson] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NULL,
	[telephone] [nvarchar](10) NULL,
	[address] [nvarchar](200) NULL,
	[email] [nvarchar](100) NULL,
	[state] [bit] NOT NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[idPerson] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Product]    Script Date: 13/04/2020 14:32:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[idProduct] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[cost] [real] NOT NULL,
	[precio] [real] NOT NULL,
	[idProvider] [int] NOT NULL,
	[existence] [int] NOT NULL,
	[idProductType] [int] NOT NULL,
	[state] [bit] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[idProduct] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProductType]    Script Date: 13/04/2020 14:32:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductType](
	[idProductType] [int] IDENTITY(1,1) NOT NULL,
	[description] [nvarchar](50) NULL,
 CONSTRAINT [PK_ProductType] PRIMARY KEY CLUSTERED 
(
	[idProductType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Provider]    Script Date: 13/04/2020 14:32:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Provider](
	[idProvider] [int] IDENTITY(1,1) NOT NULL,
	[nameProvider] [nvarchar](100) NULL,
	[reason] [nvarchar](200) NULL,
	[nit] [nvarchar](10) NULL,
	[address] [nvarchar](200) NULL,
	[email] [nvarchar](100) NULL,
	[typeProvider] [int] NOT NULL,
	[state] [bit] NOT NULL,
 CONSTRAINT [PK_Provider] PRIMARY KEY CLUSTERED 
(
	[idProvider] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PurchaseDetail]    Script Date: 13/04/2020 14:32:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchaseDetail](
	[idPurchaseDetail] [int] IDENTITY(1,1) NOT NULL,
	[idProduct] [int] NOT NULL,
	[idPurchaseOrder] [int] NULL,
 CONSTRAINT [PK_PurchaseDetail] PRIMARY KEY CLUSTERED 
(
	[idPurchaseDetail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PurchaseOrder]    Script Date: 13/04/2020 14:32:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchaseOrder](
	[idPurchaseOrder] [int] IDENTITY(1,1) NOT NULL,
	[orderTitle] [nvarchar](50) NULL,
	[datePurchaseOrder] [datetime2](7) NOT NULL,
	[purchaseOrderAmount] [real] NOT NULL,
	[statusOrder] [bit] NOT NULL,
	[idProvider] [int] NOT NULL,
 CONSTRAINT [PK_PurchaseOrder] PRIMARY KEY CLUSTERED 
(
	[idPurchaseOrder] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Role]    Script Date: 13/04/2020 14:32:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[idRole] [int] IDENTITY(1,1) NOT NULL,
	[description] [nvarchar](50) NULL,
	[state] [bit] NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[idRole] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RolePage]    Script Date: 13/04/2020 14:32:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RolePage](
	[idRolePage] [int] IDENTITY(1,1) NOT NULL,
	[idRole] [int] NOT NULL,
	[idPage] [int] NOT NULL,
	[state] [bit] NOT NULL,
 CONSTRAINT [PK_RolePage] PRIMARY KEY CLUSTERED 
(
	[idRolePage] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StatusMachine]    Script Date: 13/04/2020 14:32:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StatusMachine](
	[idStatusMachine] [int] IDENTITY(1,1) NOT NULL,
	[description] [nvarchar](50) NULL,
 CONSTRAINT [PK_StatusMachine] PRIMARY KEY CLUSTERED 
(
	[idStatusMachine] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 13/04/2020 14:32:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[idUser] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[lastName] [nvarchar](50) NULL,
	[userName] [nvarchar](15) NULL,
	[passwordHash] [varbinary](max) NULL,
	[passwordSalt] [varbinary](max) NULL,
	[estado] [tinyint] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[idUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 13/04/2020 14:32:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRole](
	[idUserRole] [int] IDENTITY(1,1) NOT NULL,
	[idUser] [int] NOT NULL,
	[idRole] [int] NOT NULL,
	[state] [bit] NOT NULL,
 CONSTRAINT [PK_UserRole] PRIMARY KEY CLUSTERED 
(
	[idUserRole] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Client]  WITH CHECK ADD  CONSTRAINT [FK_Client_Person_idPerson] FOREIGN KEY([idPerson])
REFERENCES [dbo].[Person] ([idPerson])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Client] CHECK CONSTRAINT [FK_Client_Person_idPerson]
GO
ALTER TABLE [dbo].[ClientMachine]  WITH CHECK ADD  CONSTRAINT [FK_ClientMachine_Client_idClient] FOREIGN KEY([idClient])
REFERENCES [dbo].[Client] ([idClient])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ClientMachine] CHECK CONSTRAINT [FK_ClientMachine_Client_idClient]
GO
ALTER TABLE [dbo].[ClientMachine]  WITH CHECK ADD  CONSTRAINT [FK_ClientMachine_Machine_idMachine] FOREIGN KEY([idMachine])
REFERENCES [dbo].[Machine] ([idMachine])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ClientMachine] CHECK CONSTRAINT [FK_ClientMachine_Machine_idMachine]
GO
ALTER TABLE [dbo].[Machine]  WITH CHECK ADD  CONSTRAINT [FK_Machine_StatusMachine_idStatusMachine] FOREIGN KEY([idStatusMachine])
REFERENCES [dbo].[StatusMachine] ([idStatusMachine])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Machine] CHECK CONSTRAINT [FK_Machine_StatusMachine_idStatusMachine]
GO
ALTER TABLE [dbo].[Notification]  WITH CHECK ADD  CONSTRAINT [FK_Notification_Client_idClient] FOREIGN KEY([idClient])
REFERENCES [dbo].[Client] ([idClient])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Notification] CHECK CONSTRAINT [FK_Notification_Client_idClient]
GO
ALTER TABLE [dbo].[Notification]  WITH CHECK ADD  CONSTRAINT [FK_Notification_StatusMachine_idStatusMachine] FOREIGN KEY([idStatusMachine])
REFERENCES [dbo].[StatusMachine] ([idStatusMachine])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Notification] CHECK CONSTRAINT [FK_Notification_StatusMachine_idStatusMachine]
GO
ALTER TABLE [dbo].[Notification]  WITH CHECK ADD  CONSTRAINT [FK_Notification_User_idUser] FOREIGN KEY([idUser])
REFERENCES [dbo].[User] ([idUser])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Notification] CHECK CONSTRAINT [FK_Notification_User_idUser]
GO
ALTER TABLE [dbo].[OperationProductEntry]  WITH CHECK ADD  CONSTRAINT [FK_OperationProductEntry_Product_idProducto] FOREIGN KEY([idProducto])
REFERENCES [dbo].[Product] ([idProduct])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OperationProductEntry] CHECK CONSTRAINT [FK_OperationProductEntry_Product_idProducto]
GO
ALTER TABLE [dbo].[OperationProductEntry]  WITH CHECK ADD  CONSTRAINT [FK_OperationProductEntry_Provider_idProvider] FOREIGN KEY([idProvider])
REFERENCES [dbo].[Provider] ([idProvider])
GO
ALTER TABLE [dbo].[OperationProductEntry] CHECK CONSTRAINT [FK_OperationProductEntry_Provider_idProvider]
GO
ALTER TABLE [dbo].[OperationProductOutput]  WITH CHECK ADD  CONSTRAINT [FK_OperationProductOutput_Client_idClient] FOREIGN KEY([idClient])
REFERENCES [dbo].[Client] ([idClient])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OperationProductOutput] CHECK CONSTRAINT [FK_OperationProductOutput_Client_idClient]
GO
ALTER TABLE [dbo].[OperationProductOutput]  WITH CHECK ADD  CONSTRAINT [FK_OperationProductOutput_Notification_idNotification] FOREIGN KEY([idNotification])
REFERENCES [dbo].[Notification] ([idNotification])
GO
ALTER TABLE [dbo].[OperationProductOutput] CHECK CONSTRAINT [FK_OperationProductOutput_Notification_idNotification]
GO
ALTER TABLE [dbo].[OperationProductOutput]  WITH CHECK ADD  CONSTRAINT [FK_OperationProductOutput_Product_idProducto] FOREIGN KEY([idProducto])
REFERENCES [dbo].[Product] ([idProduct])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OperationProductOutput] CHECK CONSTRAINT [FK_OperationProductOutput_Product_idProducto]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_ProductType_idProductType] FOREIGN KEY([idProductType])
REFERENCES [dbo].[ProductType] ([idProductType])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_ProductType_idProductType]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Provider_idProvider] FOREIGN KEY([idProvider])
REFERENCES [dbo].[Provider] ([idProvider])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Provider_idProvider]
GO
ALTER TABLE [dbo].[PurchaseDetail]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseDetail_Product_idProduct] FOREIGN KEY([idProduct])
REFERENCES [dbo].[Product] ([idProduct])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PurchaseDetail] CHECK CONSTRAINT [FK_PurchaseDetail_Product_idProduct]
GO
ALTER TABLE [dbo].[PurchaseDetail]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseDetail_PurchaseOrder_idPurchaseOrder] FOREIGN KEY([idPurchaseOrder])
REFERENCES [dbo].[PurchaseOrder] ([idPurchaseOrder])
GO
ALTER TABLE [dbo].[PurchaseDetail] CHECK CONSTRAINT [FK_PurchaseDetail_PurchaseOrder_idPurchaseOrder]
GO
ALTER TABLE [dbo].[PurchaseOrder]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseOrder_Provider_idProvider] FOREIGN KEY([idProvider])
REFERENCES [dbo].[Provider] ([idProvider])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PurchaseOrder] CHECK CONSTRAINT [FK_PurchaseOrder_Provider_idProvider]
GO
ALTER TABLE [dbo].[RolePage]  WITH CHECK ADD  CONSTRAINT [FK_RolePage_Page_idPage] FOREIGN KEY([idPage])
REFERENCES [dbo].[Page] ([idPage])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RolePage] CHECK CONSTRAINT [FK_RolePage_Page_idPage]
GO
ALTER TABLE [dbo].[RolePage]  WITH CHECK ADD  CONSTRAINT [FK_RolePage_Role_idRole] FOREIGN KEY([idRole])
REFERENCES [dbo].[Role] ([idRole])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RolePage] CHECK CONSTRAINT [FK_RolePage_Role_idRole]
GO
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_Role_idRole] FOREIGN KEY([idRole])
REFERENCES [dbo].[Role] ([idRole])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_UserRole_Role_idRole]
GO
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_User_idUser] FOREIGN KEY([idUser])
REFERENCES [dbo].[User] ([idUser])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_UserRole_User_idUser]
GO
