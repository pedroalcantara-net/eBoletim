using eBoletimServer.Domain.Models;
using eBoletimServer.Service.Interface.Base;

namespace eBoletimServer.Service.Interface
{
    public interface IGradesService : IBaseService<Grades>
    {
        Task<ReturnObject> Insert(Grades grade);
        Task<ReturnObject> Update(Grades grade);
    }
}