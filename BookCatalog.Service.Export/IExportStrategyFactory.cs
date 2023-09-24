namespace BookCatalog.Service.Export
{
    /// <summary>
    /// Represents a factory for creating export strategy instances.
    /// </summary>
    public interface IExportStrategyFactory
    {
        /// <summary>
        /// Creates an export strategy instance based on the specified export strategy type.
        /// </summary>
        /// <param name="type">The type of export strategy to create.</param>
        /// <returns>An instance of an export strategy.</returns>
        IExportStrategy Create(ExportStrategyType type);
    }
}