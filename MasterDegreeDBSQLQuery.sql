USE [master]
GO
/****** Object:  Database [MasterDegree]    Script Date: 04/02/2023 21:21:14 ******/
CREATE DATABASE [MasterDegre]
GO
ALTER DATABASE [MasterDegree] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MasterDegree].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MasterDegree] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MasterDegree] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MasterDegree] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MasterDegree] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MasterDegree] SET ARITHABORT OFF 
GO
ALTER DATABASE [MasterDegree] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MasterDegree] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MasterDegree] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MasterDegree] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MasterDegree] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MasterDegree] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MasterDegree] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MasterDegree] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MasterDegree] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MasterDegree] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MasterDegree] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MasterDegree] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MasterDegree] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MasterDegree] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MasterDegree] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MasterDegree] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MasterDegree] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MasterDegree] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MasterDegree] SET  MULTI_USER 
GO
ALTER DATABASE [MasterDegree] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MasterDegree] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MasterDegree] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MasterDegree] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MasterDegree] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MasterDegree] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [MasterDegree] SET QUERY_STORE = OFF
GO
USE [MasterDegree]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 04/02/2023 21:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 04/02/2023 21:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 04/02/2023 21:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 04/02/2023 21:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 04/02/2023 21:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 04/02/2023 21:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[DepartmentCode] [nvarchar](128) NULL,
	[ResearchSpeciality] [nvarchar](max) NULL,
	[Degree] [nvarchar](max) NULL,
	[Birthdate] [date] NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Department]    Script Date: 04/02/2023 21:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[DepartmentCode] [nvarchar](128) NOT NULL,
	[DepartmentName] [nvarchar](max) NULL,
	[MainOffice] [nvarchar](max) NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[DepartmentCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DepartmentsMangment]    Script Date: 04/02/2023 21:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DepartmentsMangment](
	[DepartmentsMangmentID] [int] IDENTITY(1,1) NOT NULL,
	[ChairmanID] [nvarchar](128) NOT NULL,
	[DepartmentCode] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_DepartmentsMangment_1] PRIMARY KEY CLUSTERED 
(
	[DepartmentsMangmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Report]    Script Date: 04/02/2023 21:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Report](
	[ReportCode] [int] IDENTITY(1,1) NOT NULL,
	[Evaluation] [float] NULL,
	[StartDate] [date] NULL,
 CONSTRAINT [PK_Report] PRIMARY KEY CLUSTERED 
(
	[ReportCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReportMaker]    Script Date: 04/02/2023 21:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReportMaker](
	[ReportMakerID] [int] IDENTITY(1,1) NOT NULL,
	[ReportCode] [int] NULL,
	[ProfessorID] [nvarchar](128) NULL,
 CONSTRAINT [PK_ReportMaker] PRIMARY KEY CLUSTERED 
(
	[ReportMakerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReportOwnership]    Script Date: 04/02/2023 21:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReportOwnership](
	[ReportOwnershipID] [int] IDENTITY(1,1) NOT NULL,
	[ReportCode] [int] NOT NULL,
	[StudentID] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_ReportOwnership] PRIMARY KEY CLUSTERED 
(
	[ReportOwnershipID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentThesis]    Script Date: 04/02/2023 21:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentThesis](
	[StudentID] [nvarchar](128) NOT NULL,
	[ThesisCode] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_MasterThesis] PRIMARY KEY CLUSTERED 
(
	[StudentID] ASC,
	[ThesisCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Thesis]    Script Date: 04/02/2023 21:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Thesis](
	[ThesisCode] [nvarchar](128) NOT NULL,
	[StartDate] [date] NULL,
	[EndDate] [date] NULL,
	[ThesisName] [nvarchar](max) NULL,
 CONSTRAINT [PK_Thesis] PRIMARY KEY CLUSTERED 
(
	[ThesisCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ThesisSupervision]    Script Date: 04/02/2023 21:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThesisSupervision](
	[ThesisSupervisionID] [int] IDENTITY(1,1) NOT NULL,
	[ThesisCode] [nvarchar](128) NOT NULL,
	[ProfessorID] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_ThesisSupervision] PRIMARY KEY CLUSTERED 
(
	[ThesisSupervisionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 04/02/2023 21:21:15 ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserId]    Script Date: 04/02/2023 21:21:15 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserId]    Script Date: 04/02/2023 21:21:15 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_RoleId]    Script Date: 04/02/2023 21:21:15 ******/
CREATE NONCLUSTERED INDEX [IX_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserId]    Script Date: 04/02/2023 21:21:15 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserRoles]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 04/02/2023 21:21:15 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[DepartmentsMangment]  WITH CHECK ADD  CONSTRAINT [FK_DepartmentsMangment_AspNetUsers] FOREIGN KEY([ChairmanID])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DepartmentsMangment] CHECK CONSTRAINT [FK_DepartmentsMangment_AspNetUsers]
GO
ALTER TABLE [dbo].[DepartmentsMangment]  WITH CHECK ADD  CONSTRAINT [FK_DepartmentsMangment_Department] FOREIGN KEY([DepartmentCode])
REFERENCES [dbo].[Department] ([DepartmentCode])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DepartmentsMangment] CHECK CONSTRAINT [FK_DepartmentsMangment_Department]
GO
ALTER TABLE [dbo].[ReportMaker]  WITH CHECK ADD  CONSTRAINT [FK_ReportMaker_AspNetUsers] FOREIGN KEY([ProfessorID])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ReportMaker] CHECK CONSTRAINT [FK_ReportMaker_AspNetUsers]
GO
ALTER TABLE [dbo].[ReportMaker]  WITH CHECK ADD  CONSTRAINT [FK_ReportMaker_Report] FOREIGN KEY([ReportCode])
REFERENCES [dbo].[Report] ([ReportCode])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ReportMaker] CHECK CONSTRAINT [FK_ReportMaker_Report]
GO
ALTER TABLE [dbo].[ReportOwnership]  WITH CHECK ADD  CONSTRAINT [FK_ReportOwnership_AspNetUsers] FOREIGN KEY([StudentID])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ReportOwnership] CHECK CONSTRAINT [FK_ReportOwnership_AspNetUsers]
GO
ALTER TABLE [dbo].[ReportOwnership]  WITH CHECK ADD  CONSTRAINT [FK_ReportOwnership_Report] FOREIGN KEY([ReportCode])
REFERENCES [dbo].[Report] ([ReportCode])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ReportOwnership] CHECK CONSTRAINT [FK_ReportOwnership_Report]
GO
ALTER TABLE [dbo].[StudentThesis]  WITH CHECK ADD  CONSTRAINT [FK_Student_Thesis] FOREIGN KEY([ThesisCode])
REFERENCES [dbo].[Thesis] ([ThesisCode])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[StudentThesis] CHECK CONSTRAINT [FK_Student_Thesis]
GO
ALTER TABLE [dbo].[ThesisSupervision]  WITH CHECK ADD  CONSTRAINT [FK_ThesisSupervision_AspNetUsers] FOREIGN KEY([ProfessorID])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ThesisSupervision] CHECK CONSTRAINT [FK_ThesisSupervision_AspNetUsers]
GO
ALTER TABLE [dbo].[ThesisSupervision]  WITH CHECK ADD  CONSTRAINT [FK_ThesisSupervision_Thesis] FOREIGN KEY([ThesisCode])
REFERENCES [dbo].[Thesis] ([ThesisCode])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ThesisSupervision] CHECK CONSTRAINT [FK_ThesisSupervision_Thesis]
GO
USE [master]
GO
ALTER DATABASE [MasterDegree] SET  READ_WRITE 
GO
