using eBoletimServer.DataAccess.Interface;
using eBoletimServer.DataAccess.Repository.Base;
using eBoletimServer.Domain.Models;
using eBoletimServer.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace eBoletimServer.DataAccess.Repository
{
    public class StudentClassesRepository : BaseRepository<StudentClasses>, IStudentClassesRepository
    {

        public StudentClassesRepository(EBoletimDbContext context) : base(context)
        {

        }

        #region Listar StudentClasses
        public async Task<StudentClasses> Select(StudentClasses studentclass)
        {
            try
            {
                return await _context.StudentClasses
                    .FirstOrDefaultAsync(sc => sc.Id == studentclass.Id ||
                    (sc.StudentId == studentclass.StudentId && sc.ClassId == studentclass.ClassId));
            }
            catch
            {
                return null;
            }
        }
        #endregion
    }
}
