using eBoletimServer.Domain.Models;
using eBoletimServer.Service.Interface.Base;

namespace eBoletimServer.Service.Interface
{
    public interface IStudentClassesService : IBaseService<StudentClasses>
    {
        Task<ReturnObject> Insert(StudentClasses tempStudentClasses);
        Task<ReturnObject> Update(StudentClasses studentClasses);
    }
}