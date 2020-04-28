using Microsoft.EntityFrameworkCore.Migrations;

namespace LiquorStore.DAL.Migrations
{
    public partial class LiquorPaginatedDataStoredProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
GO
/****** Object:  StoredProcedure [dbo].[usp_ClientGetPaginatedData]    Script Date: 04/27/2020 3:34:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:        Kenneth Razo
-- Create date:
-- Description:
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[usp_GetLiquorPaginatedData]
   -- Add the parameters for the stored procedure here
   @PageSize int,
   @PageNumber int,
   @SearchKeyword varchar(50),
   @SortColumn varchar(50),
   @SortOrder varchar(50)
AS
BEGIN
   -- SET NOCOUNT ON added to prevent extra result sets from
   -- interfering with SELECT statements.
   SET NOCOUNT ON;
  -- Insert statements for procedure here
  Declare @PageSize_P int = @PageSize;
Declare @PageNumber_P int = @PageNumber;
Declare @SearchKeyword_P varchar(50) = @SearchKeyword;
Declare @SortColumn_P varchar(50) = @SortColumn;
Declare @SortOrder_P varchar(50) = @SortOrder;
Declare @TotalCount int;
Declare @TotalPages int;

SELECT l.LiquorId, l.LiquorName, l.LiquorType from Liquors l 
where l.LiquorName like '%'+@SearchKeyword_P+'%'
ORDER BY
Case When (@SortColumn_P = 'LiquorId' and @SortOrder_P = 'Asc' ) Then l.LiquorId end  Asc,
Case When (@SortColumn_P = 'LiquorId' and @SortOrder_P = 'Desc' ) Then l.LiquorId end  Desc,
Case When (@SortColumn_P = 'LiquorName' and @SortOrder_P = 'Asc' ) Then l.LiquorName end  Asc,
Case When (@SortColumn_P = 'LiquorName' and @SortOrder_P = 'Desc' ) Then l.LiquorName end  Desc,
Case When (@SortColumn_P = 'LiquorType' and @SortOrder_P = 'Asc' ) Then l.LiquorType end  Asc,
  Case When (@SortColumn_P = 'LiquorType' and @SortOrder_P = 'Desc' ) Then l.LiquorType end  Desc
OFFSET @PageSize_P * (@PageNumber_P - 1) ROWS
FETCH NEXT @PageSize_P ROWS ONLY;
Select @TotalCount = Count(*) from Liquors l where l.LiquorName like '%'+@SearchKeyword_P+'%'
Select @TotalCount as TotalCount
Select @TotalPages = CEILING(Convert(float,@TotalCount)/Convert(float,@PageSize_P))
Select @TotalPages as TotalPages
 IF @TotalCount = 0
 BEGIN
 Select Convert(bit,0) as IsFirstPage
 END
 ELSE
 BEGIN
  Select ISNULL(Case When @PageNumber_P = 1 then Convert(bit,1) else Convert(bit,0) end,Convert(bit,0)) as IsFirstPage
 END
IF @TotalCount = 0
 BEGIN
 Select Convert(bit,0) as isLastPage
 END
 ELSE
 BEGIN
Select ISNULL(Case When @PageNumber_P = @TotalPages then Convert(bit,1) else Convert(bit,0) end,Convert(bit,0)) as isLastPage
 END
IF @TotalCount = 0
BEGIN
Select Convert(bit,0) as IsOutOfBounds
END
ELSE
BEGIN
  Select Case when @PageNumber_P Between 1 and @TotalPages then Convert(bit,0) else Convert(bit,1) end as IsOutOfBounds
END
Select @PageNumber_P as PageNumber
Select @PageSize_P as PageSize
END
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
