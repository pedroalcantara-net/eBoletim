using eBoletimServer.DataAccess.Interface.Base;
using eBoletimServer.Domain.Models;

namespace eBoletimServer.DataAccess.Interface
{
    public interface IStudentClassesRepository : IBaseRepository<StudentClasses>
    {
        Task<StudentClasses> Select(StudentClasses studentclass);
    }
}