using eBoletimServer.DataAccess.Interface;
using eBoletimServer.DataAccess.Repository.Base;
using eBoletimServer.Domain.Models;
using eBoletimServer.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace eBoletimServer.DataAccess.Repository
{
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        public PersonRepository(EBoletimDbContext context) : base(context)
        {

        }

        #region Listar Person
        public new async Task<Person> Select(Person person)
        {
            try
            {
                return await _db.FirstOrDefaultAsync(per => per.Id == person.Id || per.Email == person.Email || per.CPF == person.CPF);
            }
            catch
            {
                return null;
            }
        }
        #endregion
    }
}
