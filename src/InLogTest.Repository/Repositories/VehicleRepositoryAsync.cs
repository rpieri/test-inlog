using System.Threading.Tasks;
using InLogTest.Domain.Vehicles;
using InLogTest.Domain.Vehicles.Repositories;
using InLogTest.Repository.Contexts;
using Microsoft.EntityFrameworkCore;

namespace InLogTest.Repository.Repositories
{
    public class VehicleRepositoryAsync : RepositoryAsync<Vehicle>, IVehicleRepositoryAsync
    {
        public VehicleRepositoryAsync(EntityContext context) : base(context)
        {
        }

        public async Task<Vehicle> GetAsync(string chassis) => await dbSet.FirstOrDefaultAsync(x => x.Chassis.Equals(chassis) && !x.Deleted);
    }
}
