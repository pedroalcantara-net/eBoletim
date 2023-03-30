using eBoletimServer.Domain.Models;
using eBoletimServer.Service.Interface.Base;

namespace eBoletimServer.Service.Interface
{
    public interface ISubjectsService : IBaseService<Subjects>
    {
        Task<ReturnObject> Insert(string tempSubject);
        Task<ReturnObject> Update(Subjects subject);
    }
}