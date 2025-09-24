using System.Reflection.Metadata.Ecma335;

namespace Task_Tracker_V4.HelperClasses
{
    public static class StatusMapper
    {
        private static readonly Dictionary<long, string> StatusDic = new()
        {
            {1, "Active"},
            {2, "InActive"},
            {3, "Not Started"},
            {4, "In Progress"},
            {5, "Completed"},
            {8, "Read"},
            {9, "UnRead"}
        };

        public static string MapToStatus(long statusId)
        {
            return StatusDic[statusId];
        }
        public static long MapToStatusID(string status)
        {
            foreach(var pair  in StatusDic)
            {
                if (pair.Value == status)
                {
                    return pair.Key;
                }
            }
            return 1;
        }


        // will take the Read Status Id and Map it to boolean
        public static bool MapReadStatusBoolean(long? statusId)
        {
            return statusId == 8 ? true : false;
        }

        // will take a boolean isRead or not, then map to Read Status ID
        public static long MapReadStatusId(bool? isRead)
        {
            return isRead == true ? 8 : 9;
        }

    }
}
