using Dapper;
using HotelDBFinal.DomainSystem;
using HotelDBMiddle;

namespace HotelDBFinal.InterfaceAndServiceSystem
{
    public class ServiceService : IServiceService
{
    private readonly DapperContext _context;

    public ServiceService(DapperContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Service>> GetAllAsync()
    {
        var query = "SELECT * FROM ServicesS";
        using var connection = _context.CreateConnection();
        return await connection.QueryAsync<Service>(query);
    }

    public async Task<Service> GetByIdAsync(int id)
    {
        var query = "SELECT * FROM ServicesS WHERE ServiceID = @ServiceID";
        using var connection = _context.CreateConnection();
        return await connection.QuerySingleOrDefaultAsync<Service>(query, new { ServiceID = id });
    }

    public async Task<int> CreateAsync(Service service)
    {
        var query = @"INSERT INTO ServicesS (ServiceName, Price) VALUES (@ServiceName, @Price);
                      SELECT CAST(SCOPE_IDENTITY() as int)";
        using var connection = _context.CreateConnection();
        return await connection.QuerySingleAsync<int>(query, service);
    }

    public async Task<bool> UpdateAsync(Service service)
    {
        var query = @"UPDATE ServicesS SET ServiceName = @ServiceName,  Price = @Price WHERE ServiceID = @ServiceID";
        using var connection = _context.CreateConnection();
        var rows = await connection.ExecuteAsync(query, service);
        return rows > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var query = "DELETE FROM ServicesS WHERE ServiceID = @ServiceID";
        using var connection = _context.CreateConnection();
        var rows = await connection.ExecuteAsync(query, new { ServiceID = id });
        return rows > 0;
    }
}
}