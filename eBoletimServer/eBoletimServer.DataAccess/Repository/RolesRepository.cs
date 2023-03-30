using eBoletimServer.DataAccess.Interface;
using eBoletimServer.DataAccess.Repository.Base;
using eBoletimServer.Domain.Models;
using eBoletimServer.Infra.Context;

namespace eBoletimServer.DataAccess.Repository
{
    public class RolesRepository : BaseRepository<Roles>, IRolesRepository
    {

        public RolesRepository(EBoletimDbContext context) : base(context)
        {

        }

    }
}
