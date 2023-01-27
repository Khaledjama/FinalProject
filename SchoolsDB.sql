USE [SchoolsDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 1/27/2023 9:12:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 1/27/2023 9:12:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 1/27/2023 9:12:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 1/27/2023 9:12:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 1/27/2023 9:12:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 1/27/2023 9:12:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 1/27/2023 9:12:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[Comment] [nvarchar](max) NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 1/27/2023 9:12:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[parents]    Script Date: 1/27/2023 9:12:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[parents](
	[FirstName] [nvarchar](max) NULL,
	[MiddleName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[DB] [datetime2](7) NOT NULL,
	[Phone] [nvarchar](max) NULL,
	[Image] [nvarchar](max) NULL,
	[User_Id] [nvarchar](450) NULL,
	[ParentSSN] [bigint] NOT NULL,
 CONSTRAINT [PK_parents] PRIMARY KEY CLUSTERED 
(
	[ParentSSN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentAdress]    Script Date: 1/27/2023 9:12:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentAdress](
	[StudentSSN] [bigint] NOT NULL,
	[State] [nvarchar](max) NULL,
	[Government] [nvarchar](max) NULL,
	[street] [nvarchar](max) NULL,
	[ZipCode] [nvarchar](max) NULL,
 CONSTRAINT [PK_StudentAdress] PRIMARY KEY CLUSTERED 
(
	[StudentSSN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 1/27/2023 9:12:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[StudenntSSN] [bigint] NOT NULL,
	[User_Id] [nvarchar](450) NULL,
	[FirstName] [nvarchar](max) NULL,
	[MiddleName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[DB] [datetime2](7) NOT NULL,
	[Phone] [nvarchar](max) NULL,
	[Image] [nvarchar](max) NULL,
	[ParentId] [bigint] NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[StudenntSSN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentsSubjects]    Script Date: 1/27/2023 9:12:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentsSubjects](
	[SubjectId] [nvarchar](450) NOT NULL,
	[StudentId] [bigint] NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_StudentsSubjects] PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC,
	[SubjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subjects]    Script Date: 1/27/2023 9:12:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subjects](
	[CodeId] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[TeacherId] [bigint] NOT NULL,
	[SubjectDuration] [float] NOT NULL,
 CONSTRAINT [PK_Subjects] PRIMARY KEY CLUSTERED 
(
	[CodeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TeacherAdresses]    Script Date: 1/27/2023 9:12:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TeacherAdresses](
	[TeacherSSN] [bigint] NOT NULL,
	[State] [nvarchar](max) NULL,
	[Government] [nvarchar](max) NULL,
	[street] [nvarchar](max) NULL,
	[ZipCode] [nvarchar](max) NULL,
 CONSTRAINT [PK_TeacherAdresses] PRIMARY KEY CLUSTERED 
(
	[TeacherSSN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teachers]    Script Date: 1/27/2023 9:12:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teachers](
	[FirstName] [nvarchar](max) NULL,
	[MiddleName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[DB] [datetime2](7) NOT NULL,
	[Phone] [nvarchar](max) NULL,
	[Image] [nvarchar](max) NULL,
	[TeacherSSN] [bigint] NOT NULL,
	[User_Id] [nvarchar](450) NULL,
 CONSTRAINT [PK_Teachers] PRIMARY KEY CLUSTERED 
(
	[TeacherSSN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Test]    Script Date: 1/27/2023 9:12:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Test](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Test] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221113043643_intialization', N'5.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221113225606_intialization2', N'5.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221113230812_intialization3', N'5.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221114181547_Intailization4', N'5.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221114181834_Intailization5', N'5.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221114220835_intialization5', N'5.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221114235708_intialization6', N'5.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221215213525_Adding_StudentSubject', N'5.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221215214910_Adding_StudentSubject2', N'5.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221216105400_Adding_StudentSubject3', N'5.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221216105744_Adding_StudentSubject4', N'5.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230123193900_AM', N'5.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230123193951_AM2', N'5.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230126145754_Add_R_S_P', N'5.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230126163548_Add_R_S_P2', N'5.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230126182814_Add_R_S_P3', N'5.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230127005008_Add_R_S_P4', N'5.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230127010110_Add_R_S_P5', N'5.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230127170202_UpdateT', N'5.0.0')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'1', N'Teacher', N'TEACHER', N'TEACHER')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'2', N'Student', N'STUDENT', N'STUDENT')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'3', N'Secrtaria', N'SECRTARIA', N'SECRTARIA')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'4', N'Admin', N'ADMIN', N'ADMIN')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'5', N'Parent', N'PARENT', N'PARENT')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'90a12e0b-2a7f-4fe0-aee0-bc168d16bef3', N'1')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'da023ad9-426c-459a-bc15-68eaac0b5b74', N'2')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'0b9a443e-e87f-43d3-92fc-3951a9ae6ff2', N'5')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'838ddc43-1dba-4d35-ad1c-4b09635c8881', N'5')
GO
INSERT [dbo].[AspNetUsers] ([Id], [Comment], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'0b9a443e-e87f-43d3-92fc-3951a9ae6ff2', NULL, N'P', N'P', N'P@Gmail.com', N'P@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEEhTRXNlvYZNzv81TI0LAJ6HbCTZeO5fn9izgY66mP3fWFTuorv4jcfPGCUPh5elKA==', N'HFVEMYXK3WMQV7R4R265MTX24KWUNCTY', N'4f23df9e-93c7-4d4f-ae8d-08be76e27933', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [Comment], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'65014912-873c-40c9-9bce-9ed00e4a6f40', NULL, N'Mohamed', N'MOHAMED', N'Mo@Gmail.com', N'MO@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEC83czMxVZp0Pf617His3BFQdRqZTmVvNkm1cPuPpzLHGN+jFBkhhRYnPVPaCG4FpA==', N'R6V4I6PTA2V42HXRQ6KB2IFYE67KDG7V', N'4d042651-b6e1-4b99-aab6-bf20cfe10f87', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [Comment], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'838ddc43-1dba-4d35-ad1c-4b09635c8881', NULL, N'klk', N'KLK', N'lk@Gmail.com', N'LK@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEMFTEU4mxS91eHFMsgKRZYKCtm8Pp8G6+BETzr2Qh1/up+hEG/bvC0VozN3Uw4H89g==', N'4VJIG6F6YN2URNFTRTSXJSJ6RBKNZZAI', N'f0fe8ba4-d9ec-4010-b878-1de36f7f4ee5', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [Comment], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'90a12e0b-2a7f-4fe0-aee0-bc168d16bef3', NULL, N'Khaled', N'KHALED', N'kh@gmail.com', N'KH@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAENT/E6yAgvcSOggH7rnlVkFc7bgwW4ZeIioKEIkJv+GNb9Q9ewN8FwN+I90nWhgufA==', N'JV4NCM5S5RAKROT4CNM6BYP4NMZC3HNP', N'c1f9c475-60a3-4f03-ae6f-9c0d3529e0e9', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [Comment], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'da023ad9-426c-459a-bc15-68eaac0b5b74', NULL, N'kk', N'KK', N'kkkk@Gmail.com', N'KKKK@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAENkecs1CB5O2KJksY3KFmPPH8kVFHR575CyIh35ZbVYTDb12buDKCSNYm9QlLZSngw==', N'74BDK46ATK4KI53YJ6OL3IVHEMM6HEZM', N'be9019d9-4f2f-421a-a42c-6ad85581444a', NULL, 0, 0, NULL, 1, 0)
GO
INSERT [dbo].[parents] ([FirstName], [MiddleName], [LastName], [DB], [Phone], [Image], [User_Id], [ParentSSN]) VALUES (N'g', N'g', N'g', CAST(N'2000-10-05T00:00:00.0000000' AS DateTime2), N'22222222222', NULL, N'838ddc43-1dba-4d35-ad1c-4b09635c8881', 30011132200288)
INSERT [dbo].[parents] ([FirstName], [MiddleName], [LastName], [DB], [Phone], [Image], [User_Id], [ParentSSN]) VALUES (N'f', N'f', N'f', CAST(N'2000-10-05T00:00:00.0000000' AS DateTime2), N'11111111111', NULL, N'0b9a443e-e87f-43d3-92fc-3951a9ae6ff2', 30011132200299)
GO
INSERT [dbo].[StudentAdress] ([StudentSSN], [State], [Government], [street], [ZipCode]) VALUES (30011132200255, N'Egypt', N'BaniSuaf', N'Somosta', N'#3gn')
GO
INSERT [dbo].[Students] ([StudenntSSN], [User_Id], [FirstName], [MiddleName], [LastName], [DB], [Phone], [Image], [ParentId]) VALUES (30011132200255, NULL, N'd', N'd', N'd', CAST(N'2000-10-05T00:00:00.0000000' AS DateTime2), N'33333333333', NULL, 30011132200288)
INSERT [dbo].[Students] ([StudenntSSN], [User_Id], [FirstName], [MiddleName], [LastName], [DB], [Phone], [Image], [ParentId]) VALUES (30011132200277, N'da023ad9-426c-459a-bc15-68eaac0b5b74', N'g', N'g', N'g', CAST(N'2000-10-05T00:00:00.0000000' AS DateTime2), N'01118168853', NULL, 30011132200299)
GO
INSERT [dbo].[Subjects] ([CodeId], [Name], [TeacherId], [SubjectDuration]) VALUES (N'Ch23', N'khk', 30011132200278, 5)
INSERT [dbo].[Subjects] ([CodeId], [Name], [TeacherId], [SubjectDuration]) VALUES (N'Ph123', N'Chemistry', 30011132200278, 4)
GO
INSERT [dbo].[TeacherAdresses] ([TeacherSSN], [State], [Government], [street], [ZipCode]) VALUES (30011132200278, N'kk', N'j', N'k', N'o')
GO
INSERT [dbo].[Teachers] ([FirstName], [MiddleName], [LastName], [DB], [Phone], [Image], [TeacherSSN], [User_Id]) VALUES (N'jJ', N'j', N'j', CAST(N'2000-10-05T00:00:00.0000000' AS DateTime2), N'01118168853', N'13b17465-1a82-4488-a0ed-5cad6f0fc584DataBase System.jpg', 30011132200278, N'90a12e0b-2a7f-4fe0-aee0-bc168d16bef3')
GO
SET IDENTITY_INSERT [dbo].[Test] ON 

INSERT [dbo].[Test] ([Id], [Name]) VALUES (1, N'ffff')
INSERT [dbo].[Test] ([Id], [Name]) VALUES (2, N'r')
SET IDENTITY_INSERT [dbo].[Test] OFF
GO
ALTER TABLE [dbo].[parents] ADD  DEFAULT (CONVERT([bigint],(0))) FOR [ParentSSN]
GO
ALTER TABLE [dbo].[Subjects] ADD  DEFAULT (CONVERT([bigint],(0))) FOR [TeacherId]
GO
ALTER TABLE [dbo].[Subjects] ADD  DEFAULT ((0.0000000000000000e+000)) FOR [SubjectDuration]
GO
ALTER TABLE [dbo].[Teachers] ADD  DEFAULT (CONVERT([bigint],(0))) FOR [TeacherSSN]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[parents]  WITH CHECK ADD  CONSTRAINT [FK_parents_AspNetUsers_User_Id] FOREIGN KEY([User_Id])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[parents] CHECK CONSTRAINT [FK_parents_AspNetUsers_User_Id]
GO
ALTER TABLE [dbo].[StudentAdress]  WITH CHECK ADD  CONSTRAINT [FK_StudentAdress_Students_StudentSSN] FOREIGN KEY([StudentSSN])
REFERENCES [dbo].[Students] ([StudenntSSN])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[StudentAdress] CHECK CONSTRAINT [FK_StudentAdress_Students_StudentSSN]
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Students_AspNetUsers_User_Id] FOREIGN KEY([User_Id])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Students_AspNetUsers_User_Id]
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Students_parents_ParentId] FOREIGN KEY([ParentId])
REFERENCES [dbo].[parents] ([ParentSSN])
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Students_parents_ParentId]
GO
ALTER TABLE [dbo].[StudentsSubjects]  WITH CHECK ADD  CONSTRAINT [FK_StudentsSubjects_Students_StudentId] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Students] ([StudenntSSN])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[StudentsSubjects] CHECK CONSTRAINT [FK_StudentsSubjects_Students_StudentId]
GO
ALTER TABLE [dbo].[StudentsSubjects]  WITH CHECK ADD  CONSTRAINT [FK_StudentsSubjects_Subjects_SubjectId] FOREIGN KEY([SubjectId])
REFERENCES [dbo].[Subjects] ([CodeId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[StudentsSubjects] CHECK CONSTRAINT [FK_StudentsSubjects_Subjects_SubjectId]
GO
ALTER TABLE [dbo].[Subjects]  WITH CHECK ADD  CONSTRAINT [FK_Subjects_Teachers_TeacherId] FOREIGN KEY([TeacherId])
REFERENCES [dbo].[Teachers] ([TeacherSSN])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Subjects] CHECK CONSTRAINT [FK_Subjects_Teachers_TeacherId]
GO
ALTER TABLE [dbo].[TeacherAdresses]  WITH CHECK ADD  CONSTRAINT [FK_TeacherAdresses_Teachers_TeacherSSN] FOREIGN KEY([TeacherSSN])
REFERENCES [dbo].[Teachers] ([TeacherSSN])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TeacherAdresses] CHECK CONSTRAINT [FK_TeacherAdresses_Teachers_TeacherSSN]
GO
ALTER TABLE [dbo].[Teachers]  WITH CHECK ADD  CONSTRAINT [FK_Teachers_AspNetUsers_User_Id] FOREIGN KEY([User_Id])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Teachers] CHECK CONSTRAINT [FK_Teachers_AspNetUsers_User_Id]
GO
