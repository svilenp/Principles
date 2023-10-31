using static Examples.Models.Static.Enums;

namespace Examples.Before.Interfaces;

public interface IExportService
{
    public Stream Export(ExportType exportType);
}
