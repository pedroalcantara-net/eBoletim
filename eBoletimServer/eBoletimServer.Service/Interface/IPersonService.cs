using eBoletimServer.Domain.Models;
using eBoletimServer.Service.Interface.Base;

namespace eBoletimServer.Service.Interface
{
    public interface IPersonService : IBaseService<Person>
    {
        Task<Person> GetPersonByCPF(string CPF);
        Task<Person> GetPersonByEmail(string email);
        Task<List<Person>> GetPersonByRoleId(int id);
        Task<ReturnObject> Insert(Person tempPerson);
        Task<ReturnObject> Update(Person person);
    }
}