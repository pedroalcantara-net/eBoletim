using eBoletimServer.DataAccess.Interface;
using eBoletimServer.DataAccess.Repository.Base;
using eBoletimServer.Domain.Models;
using eBoletimServer.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace eBoletimServer.DataAccess.Repository
{
    public class SubjectsRepository : BaseRepository<Subjects>, ISubjectsRepository
    {

        public SubjectsRepository(EBoletimDbContext context) : base(context)
        {

        }

        #region Listar Subjects
        public async Task<Subjects?> Select(Subjects subject)
        {
            try
            {
                return await _context.Subjects.FirstOrDefaultAsync(sub => sub.Id == subject.Id || sub.SubjectName == subject.SubjectName);
            }
            catch
            {
                return null;
            }
        }
        #endregion
    }
}
