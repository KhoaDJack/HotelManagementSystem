using HotelDBFinal.DomainSystem;

namespace HotelDBFinal.InterfaceAndServiceSystem
{
    public interface IGuestServiceService
    {
        Task<IEnumerable<GuestServiceNew>> GetAllAsync();
        Task<GuestServiceNew> GetByIdAsync(int id);
        Task<int> CreateAsync(GuestServiceNew guestServiceNew);
        Task<bool> UpdateAsync(GuestServiceNew guestServiceNew);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<GuestServiceNew>> GetPagedAndFilteredAsync(int page, int pageSize, int? bookingId, int? serviceId);
    }
}