using Microsoft.EntityFrameworkCore.Migrations;

namespace LiquorStore.DAL.Migrations
{
    public partial class AuthenticateUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
GO

/****** Object:  StoredProcedure [dbo].[usp_LoginUser]    Script Date: 04/15/2020 4:12:43 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Jeinz Hernandez
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[usp_LoginUser] 
	-- Add the parameters for the stored procedure here
	@Username nvarchar(50), 
    @Password nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

SELECT TOP 1 Id FROM [dbo].[Users] WHERE Username=@Username AND [Password]=HASHBYTES('SHA2_512', @Password+CAST(Salt AS NVARCHAR(36)))

END


GO


");

            migrationBuilder.Sql(@"
GO

/****** Object:  StoredProcedure [dbo].[usp_CreateUser]    Script Date: 04/15/2020 4:13:32 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Jeinz Hernandez
-- Create date: 
-- Description:	
-- =============================================
CREATE   PROCEDURE [dbo].[usp_CreateUser]
	-- Add the parameters for the stored procedure here
	@Username nvarchar(50), 
    @Password nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	DECLARE @Salt UNIQUEIDENTIFIER=NEWID()
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO dbo.[Users] (Username, [Password], Salt)
        VALUES(@Username, HASHBYTES('SHA2_512', @Password+CAST(@Salt AS NVARCHAR(36))), @Salt)

END

GO


");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE usp_CreateUser");
            migrationBuilder.Sql("DROP PROCEDURE usp_LoginUser");
        }
    }
}
