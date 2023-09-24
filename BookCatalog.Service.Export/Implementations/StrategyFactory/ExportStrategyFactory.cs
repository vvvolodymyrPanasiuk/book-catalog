using BookCatalog.Service.Export.Implementations.ExcelExportImplementation;
using BookCatalog.Service.Export.Implementations.PdfExportImplementation;

namespace BookCatalog.Service.Export.Implementations.StrategyFactory
{
    public class ExportStrategyFactory : IExportStrategyFactory
    {
        public IExportStrategy Create(ExportStrategyType type)
        {
            switch (type)
            {
                case ExportStrategyType.Excel:
                    return new ExcelExportStrategy();
                case ExportStrategyType.Pdf:
                    return new PdfExportStrategy();
                default:
                    throw new ArgumentException($"Unknown export strategy: {type}");
            }
        }
    }
}