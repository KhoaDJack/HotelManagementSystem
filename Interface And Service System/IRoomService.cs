using HotelDBFinal.DomainSystem;

namespace HotelDBFinal.InterfaceAndServiceSystem
{
    public interface IRoomService
    {
        Task<IEnumerable<Room>> GetAllAsync();
        Task<Room> GetByIdAsync(int id);
        Task<int> CreateAsync(Room room);
        Task<bool> UpdateAsync(Room room);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<Room>> GetPagedAndSearchedAsync(int page, int pageSize, string? query);
    }
}