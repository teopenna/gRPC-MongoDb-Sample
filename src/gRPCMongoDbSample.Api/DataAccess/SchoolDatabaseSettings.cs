﻿namespace gRPCMongoDbSample.Api.DataAccess
{
    public class SchoolDatabaseSettings : ISchoolDatabaseSettings
    {
        public string StudentsCollectionName { get; set; }
        public string CoursesCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
