using WaterPoint.Core.Domain.Db;
using WaterPoint.Core.Domain.QueryParameters;
using WaterPoint.Data.Entity.Pocos.TaskDefinitions;

namespace WaterPoint.Core.Bll.Queries.TaskDefinitions
{
    public class SearchTaskDefByNameQuery : IQuery<SearchByName, TaskDefinitionBasicPoco>
    {
        private const string Sql = @"
            SELECT TOP 20
                t.[Id]
                ,t.[OrganizationId]
                ,t.[LastChangeOrganizationUserId]
                ,t.[ShortDescription]
                ,t.[LongDescription]
                ,t.[BaseRate]
                ,t.[BillableRate]
                ,t.[IsDeleted]
                ,t.[Version]
                ,t.[UtcCreated]
                ,t.[UtcUpdated]
                ,t.[Uid]
            FROM
                [dbo].[TaskDefinition] t
            WHERE
                CONTAINS(c.[ShortDescription], @searchterm)
                AND c.OrganizationId = @organizationid";

        public void BuildQuery(SearchByName parameter)
        {
            Query = Sql;

            Parameters = new
            {
                organizationId = parameter.OrganizationId,
                searchterm = parameter.SearchTerm
            };
        }

        public string Query { get; private set; }
        public object Parameters { get; private set; }
        public bool IsStoredProcedure => false;
    }
}
