using eBoletimServer.DataAccess.Interface.Base;
using eBoletimServer.Domain.Models;

namespace eBoletimServer.DataAccess.Interface
{
    public interface ISubjectsRepository : IBaseRepository<Subjects>
    {
        Task<Subjects?> Select(Subjects subject);
    }
}