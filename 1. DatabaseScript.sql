USE [master]
GO
/****** Object:  Database [MyEhealthDB]    Script Date: 02-10-2023 20:07:50 ******/
CREATE DATABASE [MyEhealthDB]
GO
ALTER DATABASE [MyEhealthDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MyEhealthDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MyEhealthDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MyEhealthDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MyEhealthDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MyEhealthDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MyEhealthDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [MyEhealthDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MyEhealthDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MyEhealthDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MyEhealthDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MyEhealthDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MyEhealthDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MyEhealthDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MyEhealthDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MyEhealthDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MyEhealthDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MyEhealthDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MyEhealthDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MyEhealthDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MyEhealthDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MyEhealthDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MyEhealthDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MyEhealthDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MyEhealthDB] SET RECOVERY FULL 
GO
ALTER DATABASE [MyEhealthDB] SET  MULTI_USER 
GO
ALTER DATABASE [MyEhealthDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MyEhealthDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MyEhealthDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MyEhealthDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MyEhealthDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MyEhealthDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'MyEhealthDB', N'ON'
GO
ALTER DATABASE [MyEhealthDB] SET QUERY_STORE = OFF
GO
USE [MyEhealthDB]
GO
/****** Object:  Table [dbo].[Tbl_Patient]    Script Date: 02-10-2023 20:07:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Patient](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Address] [varchar](50) NOT NULL,
	[Mobile_Number] [nchar](10) NOT NULL,
	[DateOfBirth] [datetime] NOT NULL,
	[Age] [int] NOT NULL,
	[Gender] [varchar](50) NOT NULL,
	[BloodGroup] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Tbl_Patient] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[SP_CreatePatient]    Script Date: 02-10-2023 20:07:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_CreatePatient]
(  
   @Name varchar (50),
   @Email varchar (50),  
   @Address varchar (50),
   @Mobile_Number nchar (10),
   @DateOfBirth datetime,
   @Age int,
   @BloodGroup varchar (50),
   @Gender varchar (50)
)  
as  
begin  
   Insert into [dbo].[Tbl_Patient] (Name,Email,Address,Mobile_Number,DateOfBirth,Age,BloodGroup,Gender)
   values(@Name,@Email,@Address,@Mobile_Number,@DateOfBirth,@Age,@BloodGroup,@Gender)  
End
GO
/****** Object:  StoredProcedure [dbo].[SP_DeletePatient]    Script Date: 02-10-2023 20:07:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_DeletePatient]         
(            
   @Id int           
)            
as             
begin            
   Delete from [dbo].[Tbl_Patient] where Id=@Id            
End  
GO
/****** Object:  StoredProcedure [dbo].[SP_GetAllPatient]    Script Date: 02-10-2023 20:07:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_GetAllPatient]      
as        
Begin        
    select *        
    from [dbo].[Tbl_Patient]
    order by Id  
End  
GO
/****** Object:  StoredProcedure [dbo].[SP_UpdatePatient]    Script Date: 02-10-2023 20:07:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[SP_UpdatePatient]            
(            
    @Id INTEGER ,          
    @Name VARCHAR(50),           
    @Email VARCHAR(30),          
    @Address VARCHAR(220),           
    @Mobile_Number nchar(10),
	@DateOfBirth datetime,
	@Age int,
	@BloodGroup varchar (50),
    @Gender varchar (50)
)          
as            
begin            
   Update [dbo].[Tbl_Patient]             
   set Name=@Name,            
   Email=@Email,          
   Address=@Address,
   Mobile_Number=@Mobile_Number,   
   DateOfBirth = @DateOfBirth,
   @Age = @Age,
   @BloodGroup = @BloodGroup,
   @Gender = @Gender
   where Id=@Id       
End  
GO
ALTER DATABASE [MyEhealthDB] SET  READ_WRITE 
GO
