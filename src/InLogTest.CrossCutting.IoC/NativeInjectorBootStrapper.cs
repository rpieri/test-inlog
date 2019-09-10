using InLogTest.Domain.Vehicles.CommandHandlers;
using InLogTest.Domain.Vehicles.Commands;
using InLogTest.Domain.Vehicles.Repositories;
using InLogTest.Repository.Contexts;
using InLogTest.Repository.Repositories;
using InLogTest.Repository.UoW;
using InLogTest.Shared.Commands;
using InLogTest.Shared.Handlers;
using InLogTest.Shared.Interface;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace InLogTest.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void InitialService(IServiceCollection services)
        {
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            services.AddScoped<IRequestHandler<CreateVehicleCommand, CommandResult>, CreateVehicleCommandHandler>();
            services.AddScoped<IRequestHandler<EditVehicleCommand, CommandResult>, EditVehicleCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveVehicleCommand, CommandResult>, RemoveVehicleCommandHandler>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<EntityContext>();
            services.AddScoped<IVehicleRepositoryAsync, VehicleRepositoryAsync>();
        }
    }
}
