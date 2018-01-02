using FluentMigrator;

namespace XWingLeague.DatabaseMigrations
{
    public class MigrationOptions : IMigrationProcessorOptions
    {
        public bool PreviewOnly { get; set; }
        public int Timeout { get; set; }
        public string ProviderSwitches { get; set; }
    }
}
