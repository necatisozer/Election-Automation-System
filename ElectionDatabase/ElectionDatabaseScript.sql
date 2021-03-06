USE [ElectionDatabase]
GO
/****** Object:  Table [dbo].[BallotBox]    Script Date: 31/05/2018 05:55:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BallotBox](
	[BallotBoxId] [int] IDENTITY(1,1) NOT NULL,
	[BallotBoxNumber] [int] NULL,
	[NeighbourhoodId] [int] NULL,
	[VoterCount] [int] NULL,
 CONSTRAINT [PK_BallotBox] PRIMARY KEY CLUSTERED 
(
	[BallotBoxId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Country]    Script Date: 31/05/2018 05:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country](
	[CountryId] [int] IDENTITY(1,1) NOT NULL,
	[CountryName] [nvarchar](max) NULL,
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[CountryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[District]    Script Date: 31/05/2018 05:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[District](
	[DistrictId] [int] IDENTITY(1,1) NOT NULL,
	[DistrictName] [nvarchar](max) NULL,
	[ProvinceId] [int] NULL,
 CONSTRAINT [PK_District] PRIMARY KEY CLUSTERED 
(
	[DistrictId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Election]    Script Date: 31/05/2018 05:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Election](
	[ElectionId] [int] IDENTITY(1,1) NOT NULL,
	[ElectionTitle] [nvarchar](max) NULL,
	[ElectionDate] [date] NULL,
	[CountryId] [int] NULL,
 CONSTRAINT [PK_Election] PRIMARY KEY CLUSTERED 
(
	[ElectionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Neighbourhood]    Script Date: 31/05/2018 05:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Neighbourhood](
	[NeighbourhoodId] [int] IDENTITY(1,1) NOT NULL,
	[NeighbourhoodName] [nvarchar](max) NULL,
	[DistrictId] [int] NULL,
 CONSTRAINT [PK_Neighbourhood] PRIMARY KEY CLUSTERED 
(
	[NeighbourhoodId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Party]    Script Date: 31/05/2018 05:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Party](
	[PartyId] [int] IDENTITY(1,1) NOT NULL,
	[PartyName] [nvarchar](max) NOT NULL,
	[PresidentId] [int] NULL,
	[Founder] [nvarchar](max) NULL,
	[FoundationDate] [date] NULL,
	[HeadquartersId] [int] NULL,
	[IsParty] [bit] NOT NULL,
 CONSTRAINT [PK_Party] PRIMARY KEY CLUSTERED 
(
	[PartyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[President]    Script Date: 31/05/2018 05:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[President](
	[PresidentId] [int] IDENTITY(1,1) NOT NULL,
	[PresidentName] [nvarchar](max) NULL,
	[Birthdate] [date] NULL,
	[BirthplaceId] [int] NULL,
	[Profession] [nvarchar](max) NULL,
 CONSTRAINT [PK_President] PRIMARY KEY CLUSTERED 
(
	[PresidentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Province]    Script Date: 31/05/2018 05:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Province](
	[ProvinceId] [int] IDENTITY(1,1) NOT NULL,
	[ProvinceName] [nvarchar](max) NULL,
	[ElectionId] [int] NULL,
 CONSTRAINT [PK_Province] PRIMARY KEY CLUSTERED 
(
	[ProvinceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vote]    Script Date: 31/05/2018 05:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vote](
	[VoteId] [int] IDENTITY(1,1) NOT NULL,
	[BallotBoxId] [int] NULL,
	[PartyId] [int] NULL,
	[VoteCount] [int] NOT NULL,
 CONSTRAINT [PK_Vote] PRIMARY KEY CLUSTERED 
(
	[VoteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[BallotBox]  WITH CHECK ADD  CONSTRAINT [FK_BallotBox_Neighbourhood] FOREIGN KEY([NeighbourhoodId])
REFERENCES [dbo].[Neighbourhood] ([NeighbourhoodId])
GO
ALTER TABLE [dbo].[BallotBox] CHECK CONSTRAINT [FK_BallotBox_Neighbourhood]
GO
ALTER TABLE [dbo].[District]  WITH CHECK ADD  CONSTRAINT [FK_District_Province] FOREIGN KEY([ProvinceId])
REFERENCES [dbo].[Province] ([ProvinceId])
GO
ALTER TABLE [dbo].[District] CHECK CONSTRAINT [FK_District_Province]
GO
ALTER TABLE [dbo].[Election]  WITH CHECK ADD  CONSTRAINT [FK_Election_Country] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Country] ([CountryId])
GO
ALTER TABLE [dbo].[Election] CHECK CONSTRAINT [FK_Election_Country]
GO
ALTER TABLE [dbo].[Neighbourhood]  WITH CHECK ADD  CONSTRAINT [FK_Neighbourhood_District] FOREIGN KEY([DistrictId])
REFERENCES [dbo].[District] ([DistrictId])
GO
ALTER TABLE [dbo].[Neighbourhood] CHECK CONSTRAINT [FK_Neighbourhood_District]
GO
ALTER TABLE [dbo].[Party]  WITH CHECK ADD  CONSTRAINT [FK_Party_President] FOREIGN KEY([PresidentId])
REFERENCES [dbo].[President] ([PresidentId])
GO
ALTER TABLE [dbo].[Party] CHECK CONSTRAINT [FK_Party_President]
GO
ALTER TABLE [dbo].[Party]  WITH CHECK ADD  CONSTRAINT [FK_Party_Province] FOREIGN KEY([HeadquartersId])
REFERENCES [dbo].[Province] ([ProvinceId])
GO
ALTER TABLE [dbo].[Party] CHECK CONSTRAINT [FK_Party_Province]
GO
ALTER TABLE [dbo].[President]  WITH CHECK ADD  CONSTRAINT [FK_President_Province] FOREIGN KEY([BirthplaceId])
REFERENCES [dbo].[Province] ([ProvinceId])
GO
ALTER TABLE [dbo].[President] CHECK CONSTRAINT [FK_President_Province]
GO
ALTER TABLE [dbo].[Province]  WITH CHECK ADD  CONSTRAINT [FK_Province_Election] FOREIGN KEY([ElectionId])
REFERENCES [dbo].[Election] ([ElectionId])
GO
ALTER TABLE [dbo].[Province] CHECK CONSTRAINT [FK_Province_Election]
GO
ALTER TABLE [dbo].[Vote]  WITH CHECK ADD  CONSTRAINT [FK_Vote_BallotBox] FOREIGN KEY([BallotBoxId])
REFERENCES [dbo].[BallotBox] ([BallotBoxId])
GO
ALTER TABLE [dbo].[Vote] CHECK CONSTRAINT [FK_Vote_BallotBox]
GO
ALTER TABLE [dbo].[Vote]  WITH CHECK ADD  CONSTRAINT [FK_Vote_Party] FOREIGN KEY([PartyId])
REFERENCES [dbo].[Party] ([PartyId])
GO
ALTER TABLE [dbo].[Vote] CHECK CONSTRAINT [FK_Vote_Party]
GO
