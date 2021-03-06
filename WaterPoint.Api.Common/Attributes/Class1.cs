﻿namespace WaterPoint.Api.Common.Attributes
{
    public enum Privileges
    {
        AddCus = 1,
        DelCus = 2,
        EditCus = 3,
        ViewCus = 4,
        AddJob = 5,
        DelJob = 6,
        EditJob = 7,
        ViewJob = 8,
        AddCost = 9,
        DelCost = 10,
        EditCost = 11,
        ViewCost = 12,
        AddTask = 13,
        DelTask = 14,
        EditTask = 15,
        ViewTask = 16,
        AddJobTime = 17,
        DelJobTime = 18,
        EditJobTime = 19,
        ViewJobTime = 20
    }

    public class DefaultUserPrivileges
    {
        public static Privileges[] Admin =
        {
            Privileges.AddCus,
            Privileges.DelCus,
            Privileges.EditCus,
            Privileges.ViewCus,
            Privileges.AddJob,
            Privileges.DelJob,
            Privileges.EditJob,
            Privileges.ViewJob,
            Privileges.AddCost,
            Privileges.DelCost,
            Privileges.EditCost,
            Privileges.ViewCost,
            Privileges.AddTask,
            Privileges.DelTask,
            Privileges.EditTask,
            Privileges.ViewTask,
            Privileges.AddJobTime,
            Privileges.DelJobTime,
            Privileges.EditJobTime,
            Privileges.ViewJobTime
        };

        public static Privileges[] Staff =
        {
            Privileges.ViewCus,
            Privileges.AddJob,
            Privileges.EditJob,
            Privileges.ViewJob,
            Privileges.AddCost,
            Privileges.DelCost,
            Privileges.EditCost,
            Privileges.ViewCost,
            Privileges.AddTask,
            Privileges.DelTask,
            Privileges.EditTask,
            Privileges.ViewTask,
            Privileges.AddJobTime,
            Privileges.DelJobTime,
            Privileges.EditJobTime,
            Privileges.ViewJobTime
        };

        public static Privileges[] Customer =
        {
            Privileges.ViewJob,
            Privileges.AddCost,
            Privileges.DelCost,
            Privileges.EditCost,
            Privileges.ViewCost,
            Privileges.AddTask,
            Privileges.DelTask,
            Privileges.EditTask,
            Privileges.ViewTask,
            Privileges.AddJobTime,
            Privileges.DelJobTime,
            Privileges.EditJobTime,
            Privileges.ViewJobTime
        };
    }
}
