using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;

namespace UserIdentityAccount.BLL.DataTable;

public class Table:ITable
{
    public List<string> GetDataFromTable()
    {
        var dataList = new List<string>();
        HSSFWorkbook hssfwb;
        using (FileStream file = new FileStream(@"C:\Users\PC\RiderProjects\UserIdentityAccount\UserIdentityAccount.Web\ClientApp\src\Data\data.xlsx", FileMode.Open, FileAccess.Read))
        {
            hssfwb= new HSSFWorkbook(file);
        }

        ISheet sheet = hssfwb.GetSheet("CompleteList");
        for (int row = 0; row <= sheet.LastRowNum; row++)
        {
            if (sheet.GetRow(row) != null) //null is when the row only contains empty cells 
            {
                dataList.Add(string.Format("Row {0} = {1}", row, sheet.GetRow(row).GetCell(0).StringCellValue));
            }
        }

        return dataList;
    }
}