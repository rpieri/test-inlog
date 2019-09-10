using InLogTest.Shared.Repositories;
using System.Threading.Tasks;

namespace InLogTest.Domain.Vehicles.Repositories
{
    public interface IVehicleRepositoryAsync : IRepositoryAsync<Vehicle>
    {
        Task<Vehicle> GetAsync(string chassis);
    }
}
