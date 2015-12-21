using System;
using System.Collections.Generic;
using System.Linq;
using WaterPoint.Core.Domain.Dtos.RequestParameters;

namespace WaterPoint.Core.RequestProcessor
{
    public class JobStatusQueryParameterConverter
    {
        public string Status { get; set; }

        private static readonly Dictionary<string, string> JobStatusMeaningColumns = new Dictionary<string, string>
        {
            {"planned", "ForPlanned"},
            {"deleted", "ForDeleted"},
            {"onhold", "ForOnHold"},
            {"completed", "ForCompleted"},
            {"inprogress", "ForInProgress"},
            {"cancelled", "ForCancelled"},
        };

        public JobStatusQueryParameterConverter Convert(JobStatusParameter paramter)
        {
            var statusMeaningColumn = JobStatusMeaningColumns
                .SingleOrDefault(i => string.Equals(i.Key, paramter.Status, StringComparison.CurrentCultureIgnoreCase));

            Status = statusMeaningColumn.Value;

            return this;
        }
    }
}
