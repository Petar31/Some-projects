USE [Database1]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 15-May-18 8:03:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[EmployeeID] [int] IDENTITY(1,1) NOT NULL,
	[LastName] [nvarchar](20) NOT NULL,
	[FirstName] [nvarchar](10) NOT NULL,
	[BirthDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Employees] ON 

INSERT [dbo].[Employees] ([EmployeeID], [LastName], [FirstName], [BirthDate]) VALUES (1, N'Jordan', N'Michael', CAST(N'1960-07-22T00:00:00.000' AS DateTime))
INSERT [dbo].[Employees] ([EmployeeID], [LastName], [FirstName], [BirthDate]) VALUES (2, N'Johnson', N'Earvin', CAST(N'1959-08-14T00:00:00.000' AS DateTime))
INSERT [dbo].[Employees] ([EmployeeID], [LastName], [FirstName], [BirthDate]) VALUES (3, N'Stockton', N'John', CAST(N'1962-03-26T00:00:00.000' AS DateTime))
INSERT [dbo].[Employees] ([EmployeeID], [LastName], [FirstName], [BirthDate]) VALUES (4, N'Russell', N'Bill', CAST(N'1934-02-12T00:00:00.000' AS DateTime))
INSERT [dbo].[Employees] ([EmployeeID], [LastName], [FirstName], [BirthDate]) VALUES (5, N'Bryant', N'Kobe ', CAST(N'1978-08-23T00:00:00.000' AS DateTime))
INSERT [dbo].[Employees] ([EmployeeID], [LastName], [FirstName], [BirthDate]) VALUES (6, N'Duncan', N'Tim ', CAST(N'1976-04-25T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Employees] OFF
