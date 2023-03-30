using eBoletimServer.DataAccess.Interface.Base;
using eBoletimServer.Domain.Models;

namespace eBoletimServer.DataAccess.Interface
{
    public interface IGradesRepository : IBaseRepository<Grades>
    {
        Task<Grades> Select(Grades grade);
    }
}