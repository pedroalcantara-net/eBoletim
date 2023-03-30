using eBoletimServer.DataAccess.Interface.Base;
using eBoletimServer.Domain.Models;

namespace eBoletimServer.DataAccess.Interface
{
    public interface IPersonRepository : IBaseRepository<Person>
    {
        Task<Person> Select(Person person);
    }
}