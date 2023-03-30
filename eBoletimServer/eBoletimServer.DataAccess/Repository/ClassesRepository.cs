using eBoletimServer.DataAccess.Interface;
using eBoletimServer.DataAccess.Repository.Base;
using eBoletimServer.Domain.Models;
using eBoletimServer.Infra.Context;

namespace eBoletimServer.DataAccess.Repository
{
    public class ClassesRepository : BaseRepository<Classes>, IClassesRepository
    {

        public ClassesRepository(EBoletimDbContext context) : base(context)
        {
        }

    }
}
