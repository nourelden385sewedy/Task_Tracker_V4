using Task_Tracker_V4.Data.Models;

namespace Task_Tracker_V4.Repositories.Interfaces
{
    public interface ILoginRepository
    {
        Task<Login?> GetByEmailAsync(string email); 
    }
}
