using SafeHaven.DAL.Entities;
using SafeHaven.DAL.Interfaces;

namespace SafeHaven.DAL.Repositories;

public class ClientRepository(InsuranceDbContext context) : GenericRepository<Client>(context), IClientRepository
{
    
}