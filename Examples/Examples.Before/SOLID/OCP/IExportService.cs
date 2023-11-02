using static Examples.Models.Static.Enums;

namespace Examples.After.SOLID.OCP;

public interface IExportService
{
    public Stream Export(ExportType exportType);
}
