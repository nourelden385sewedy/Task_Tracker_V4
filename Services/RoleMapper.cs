using Microsoft.EntityFrameworkCore;
using System;
using Task_Tracker_V4.Data;
using Task_Tracker_V4.Data.Models;

namespace Task_Tracker_V4.Services
{
    public class RoleMapper
    {
        private readonly Dictionary<long, string> _rolesDic;

        public RoleMapper(MyDbContext context)
        {
            _rolesDic = context.Roles.AsNoTracking().ToDictionary(s => s.Id, s => s.RoleName);
        }

        public string MapToRole(long roleId) =>
        _rolesDic.TryGetValue(roleId, out var role) ? role : "Unknown";

        public long MapToRoleID(string role) =>
            _rolesDic.FirstOrDefault(p => p.Value == role).Key;

    }
}
