/*
Post-Deployment Script Template
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.
 Use SQLCMD syntax to include a file in the post-deployment script.
 Example:      :r .\myfile.sql
 Use SQLCMD syntax to reference a variable in the post-deployment script.
 Example:      :setvar TableName MyTable
               SELECT * FROM [$(TableName)]
--------------------------------------------------------------------------------------
*/

:r ".\PostDeployment\Countries.sql"

:r ".\PostDeployment\Reseeds.sql"

:r ".\PostDeployment\DemoOrganization.sql"

:r ".\PostDeployment\DemoJobCategories.sql"

:r ".\PostDeployment\DemoJobsStatuses.sql"

:r ".\PostDeployment\DemoCustomerTypes.sql"

:r ".\PostDeployment\DemoCustomers.sql"

:r ".\PostDeployment\DemoJobs.sql"

:r ".\PostDeployment\OrganizationUserTypes.sql"

:r ".\PostDeployment\DemoCredential.sql"

:r ".\PostDeployment\DemoOrganizationUserAndStaff.sql"

:r ".\PostDeployment\InvoiceTypes.sql"

:r ".\PostDeployment\InvoiceStatuses.sql"

:r "..\apiv1\Scripts\Script.PostDeployment.ApiV1.sql"

:r ".\PostDeployment\PriorityTypes.sql"

:r ".\PostDeployment\JobTimesheetTypes.sql"

:r ".\PostDeployment\Privileges.sql"

:r ".\PostDeployment\DemoOrgnizationUserPrivileges.sql"

:r ".\PostDeployment\QuoteStatuses.sql"

:r ".\PostDeployment\UnitOfMeasurements.sql"

:r ".\PostDeployment\CostItemTypes.sql"


