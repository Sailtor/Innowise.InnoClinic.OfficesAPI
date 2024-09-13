﻿namespace Infrastructure.Persistence.MongoDb.Configurations
{
    public class OfficesAPIDbSettings : IOfficesAPIDbSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string OfficesCollectionName { get; set; }
    }
}
