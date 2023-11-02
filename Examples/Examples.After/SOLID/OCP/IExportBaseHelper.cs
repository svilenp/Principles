using OfficeOpenXml;

namespace Examples.After.SOLID.OCP;

public interface IExportBaseHelper
{
    ExcelWorksheet BuildSheet(ExcelPackage package);
    void SetCellValue(ExcelWorksheet worksheet);
    void CollectOrdersData(ExcelWorksheet worksheet);
    void CollectUsersData(ExcelWorksheet worksheet);
    void AddHeaderSection(ExcelWorksheet worksheet);
    void AddFooterSection(ExcelWorksheet worksheet);
}
