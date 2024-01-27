using static Examples.Models.Static.Enums;

namespace Examples.Before.SOLID.OCP;

public interface IExportService
{
    public Stream Export(ExportType exportType);
}
