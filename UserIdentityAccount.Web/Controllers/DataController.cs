using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace UserIdentityAccount.Web.Controllers;


[AllowAnonymous]
[Route("api/[controller]")]
[ApiController]
public class DataController:ControllerBase
{
    [HttpGet("GetTable")]
    public List<string> GetTable()
    {
        var dataList = new List<string>();
        XSSFWorkbook hssfwb;
        using (FileStream file = new FileStream(@"C:\Users\PC\RiderProjects\UserIdentityAccount\UserIdentityAccount.Web\ClientApp\src\Data\data.xlsx", FileMode.Open, FileAccess.Read))
        {
            hssfwb= new XSSFWorkbook(file);
        }

        try
        {
            ISheet sheet = hssfwb.GetSheet("CompleteList");
            for (int row = 0; row <= 85; row++)  //sheet.LastRowNum  //4474
            {
                if (sheet.GetRow(row) != null) //null is when the row only contains empty cells 
                {
                    dataList.Add(string.Format("Row {0} = {1}", row, sheet.GetRow(row).GetCell(0).StringCellValue));
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return dataList;
    }
}