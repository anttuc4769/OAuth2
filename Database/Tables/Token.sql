CREATE TABLE [dbo].[Token]
(
    [Id] [int] IDENTITY(1,1) NOT NULL,
	[Source] [nvarchar](25) NOT NULL,
	[TokenType] [nvarchar](50) NULL,
	[AccessToken] [nvarchar](max) NOT NULL,
	[ExpiresIn] [bigint] NULL,
	[ExpiresOn] [bigint] NULL,
	[RefreshToken] [nvarchar](max) NULL,
	[RefreshTokenExpiresIn] [bigint] NULL,
    [Resource] [nvarchar](50) NULL,
	[ProfileInfo] [nvarchar](500) NULL,
	[Scope] [nvarchar](500) NULL,
	[Created] [datetimeoffset](7) NOT NULL,
	[Modified] [datetimeoffset](7) NULL,
	[Active] [bit] NOT NULL,
	 CONSTRAINT [PK_Token] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
