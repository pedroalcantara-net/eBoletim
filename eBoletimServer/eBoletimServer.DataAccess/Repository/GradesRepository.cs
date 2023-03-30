using eBoletimServer.DataAccess.Interface;
using eBoletimServer.DataAccess.Repository.Base;
using eBoletimServer.Domain.Models;
using eBoletimServer.Infra.Context;

namespace eBoletimServer.DataAccess.Repository
{
    public class GradesRepository : BaseRepository<Grades>, IGradesRepository
    {

        public GradesRepository(EBoletimDbContext context) : base(context)
        {

        }
    }
}
