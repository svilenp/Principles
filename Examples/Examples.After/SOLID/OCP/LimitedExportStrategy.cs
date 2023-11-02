using OfficeOpenXml;

namespace Examples.After.SOLID.OCP;

public class LimitedExportStrategy : IExportStrategy
{
    private readonly IExportBaseHelper _exportHelper;

    public LimitedExportStrategy(IExportBaseHelper exportHelper)
    {
        _exportHelper = exportHelper;
    }

    public Stream Export()
    {
        using var package = new ExcelPackage();
        var worksheet = _exportHelper.BuildSheet(package);

        _exportHelper.SetCellValue(worksheet);
        _exportHelper.CollectOrdersData(worksheet);
        _exportHelper.CollectUsersData(worksheet);
        _exportHelper.AddHeaderSection(worksheet);
        _exportHelper.AddFooterSection(worksheet);

        var stream = new MemoryStream();
        package.SaveAs(stream);

        return stream;
    }
}
