namespace APIUserStore.Models
{
    public class UserStoreDataBaseSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DataBaseName { get; set; } = null!;
        public string UserCollectionName { get; set; } = null!;
    }
}
