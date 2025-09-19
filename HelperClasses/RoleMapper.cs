namespace Task_Tracker_V4.HelperClasses
{
    public static class RoleMapper
    {
        // the keys in this Dictionary will be changed later
        public static readonly Dictionary<long, string> RolesDic = new()
        {
            { 1, "Super Admin" },
            { 2, "Admin" },
            { 3, "Senior Engineer" },
            { 4, "Engineer" },
            { 5, "Senior Teacher" },
            { 6, "Teacher" }
        };

        public static readonly Dictionary<string, string> RolesHash = new()
        {
            { "e64d8a3d9a", "Super Admin" },
            { "8c6976e5b5", "Admin" },
            { "a55c5c897d", "Senior Engineer" },
            { "f9a27d94f2", "Engineer" },
            { "b5284c8720", "Senior Teacher" },
            { "b5284c8720", "Teacher" }
        };


        public static string? GetRoleName(long roleId)
        {
            return RolesDic.TryGetValue(roleId, out var roleName)
                ? roleName
                : null;
        }
        public static long GetRoleId(string roleName)
        {
            foreach (var pair in RolesDic)
            {
                if (pair.Value.Equals(roleName, StringComparison.OrdinalIgnoreCase))
                {
                    return pair.Key;
                }
            }
            throw new KeyNotFoundException($"Role '{roleName}' not found in dictionary.");
        }

        public static long MapRoleHashToId(string roleHash)
        {
            // return the role name from the hash
            string roleName = RolesHash.TryGetValue(roleHash, out var roleId)
                ? roleId : throw new KeyNotFoundException($"Role Hash '{roleHash}' not found in dictionary.");

            return GetRoleId(roleName);
        }
        public static string MapIdToRoleHash(long roleId)
        {
            // Convert the Role Id to Role Name
            string roleName = GetRoleName(roleId);

            foreach (var pair in RolesHash)
            {
                if (pair.Value.Equals(roleName, StringComparison.OrdinalIgnoreCase))
                {
                    return pair.Key;
                }
            }
            throw new KeyNotFoundException($"this Rold Id not found in dictionary.");
        }

    }
}
