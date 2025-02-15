USE [C121_brendalis.sanchez2018_gmail]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 1/23/2023 6:12:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[Id] [int] NOT NULL,
	[EmployeeNumber] [int] NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[MiddleName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Dependents] [int] NULL,
	[Paycheck] [int] NOT NULL,
	[Status] [nvarchar](50) NOT NULL,
	[DateCreated] [datetime2](7) NOT NULL,
	[DateModified] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Employees] ADD  CONSTRAINT [DF_Employees_DateCreated]  DEFAULT (getutcdate()) FOR [DateCreated]
GO
ALTER TABLE [dbo].[Employees] ADD  CONSTRAINT [DF_Employees_DateModified]  DEFAULT (getutcdate()) FOR [DateModified]
GO
/****** Object:  StoredProcedure [dbo].[Employee_Insert]    Script Date: 1/23/2023 6:12:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[Employee_Insert]

		@EmployeeNumber int
		,@FirstName nvarchar(50)
		,@MiddleName nvarchar(50)
		,@LastName nvarchar(50)
		,@Dependents int
		,@Paycheck int
		,@Status nvarchar(50)        
		
		,@Id int OUTPUT


/* ----- Test Code -----

	Declare Id int = 1
			,@EmployeeNumber int = 101
			,@FirstName nvarchar(50) = 'John'
			,@MiddleName nvarchar(50) = 'Doe'
			,@LastName nvarchar(50) = 'Smith'
			,@Dependents int = 0
			,@Paycheck int = 2000
			,@Status nvarchar(50) = 'Active'

	Execute dbo.Employee_Insert

	Select *
	From dbo.Employees
	Where Id = @Id

*/

as

BEGIN

INSERT INTO [dbo].[Employees]
           ([Id]
			,[EmployeeNumber]
			,[FirstName]
			,[MiddleName]
			,[LastName]
			,[Dependents]
			,[Paycheck]
			,[Status]
           )

     VALUES
			(@Id
			,@EmployeeNumber
			,@FirstName
			,@MiddleName
			,@LastName
			,@Dependents
			,@Paycheck
			,@Status
			)

	SET @Id = SCOPE_IDENTITY()   

END
GO
/****** Object:  StoredProcedure [dbo].[Employee_SelectByEmployeeNumber]    Script Date: 1/23/2023 6:12:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[Employee_SelectByEmployeeNumber]
		@EmployeeNumber int
as

/* ----- Test Code -----

	Declare @Id int = 1;

	Execute dbo.Employee_SelectByEmployeeNumber @EmployeeNumber

*/

BEGIN

	SELECT [Id]
			,[EmployeeNumber]
			,[FirstName]
			,[MiddleName]
			,[LastName]
			,[Dependents]
			,[Paycheck]
			,[Status]
			,[DateCreated]
			,[DateModified]		  
  FROM [dbo].[Employees]
  Where EmployeeNumber = @EmployeeNumber

END
GO
/****** Object:  StoredProcedure [dbo].[Employee_Update]    Script Date: 1/23/2023 6:12:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[Employee_Update]
		@Id int
		,@EmployeeNumber int
		,@FirstName nvarchar(50)
		,@MiddleName nvarchar(50)
		,@LastName nvarchar(50)
		,@Dependents int
		,@Paycheck int
		,@Status nvarchar(50)          
		
as

/* 
		Declare @Id int = 1;

		Declare Id int = 1
				,@EmployeeNumber int = 101
				,@FirstName nvarchar(50) = 'John'
				,@MiddleName nvarchar(50) = 'Doe'
				,@LastName nvarchar(50) = 'Smith'
				,@Dependents int = 0
				,@Paycheck int = 2000
				,@Status nvarchar(50) = 'Active'
				
		Select *
		From dbo.Employees
		Where EmployeeNumber = @EmployeeNumber
				
*/

BEGIN

	Declare @dateNow datetime2 = getutcdate()

	UPDATE [dbo].[Employees]
	   SET [Id] = @Id
			,[EmployeeNumber] = @EmployeeNumber
			,[FirstName] = @FirstName
			,[MiddleName] = @MiddleName
			,[LastName] = @LastName
			,[Dependents] = @Dependents
			,[Paycheck] = @Paycheck
			,[Status] = @Status
		  
	 WHERE EmployeeNumber = @EmployeeNumber

END
GO
/****** Object:  StoredProcedure [dbo].[Employees_SelectAll]    Script Date: 1/23/2023 6:12:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[Employees_SelectAll]

as

/* ----- Test Code -----

	Execute dbo.Employees_SelectAll @EmployeeNumber

*/


BEGIN

	SELECT [Id]
			,[EmployeeNumber]
			,[FirstName]
			,[MiddleName]
			,[LastName]
			,[Dependents]
			,[Paycheck]
			,[Status]
			,[DateCreated]
			,[DateModified]		  
		  
  FROM [dbo].[Employees]
  
END
GO
