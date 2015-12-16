﻿namespace WaterPoint.Data.DbContext.Dapper
{
    public interface IQuery
    {
        string Query { get; }
        object Parameters { get; }
    }

    public interface IListPaginatedWithOrgIdQuery : IQuery
    {
        void BuildQuery(int orgId, int offset, int pageSize, string orderBy, bool isDesc, string searchTerm);
    }
}
