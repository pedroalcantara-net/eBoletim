using eBoletim.Server.CrossCutting;
using eBoletimServer.DataAccess.Interface;
using eBoletimServer.Domain.Models;
using eBoletimServer.Service.Interface;
using eBoletimServer.Service.Services.Base;

namespace eBoletimServer.Service.Services
{
    public class StudentClassesService : BaseService<StudentClasses, IStudentClassesRepository>, IStudentClassesService
    {
        public StudentClassesService(IStudentClassesRepository StudentClasses) : base(StudentClasses)
        {
        }

        public async Task<ReturnObject> Insert(StudentClasses studentClasses)
        {
            var returnObject = new ReturnObject();
            try
            {
                returnObject = await _repository.Insert(studentClasses);
            }
            catch (Exception ex)
            {
                returnObject = Util.CreateInternalServerError(ex);
            }
            return returnObject;
        }

        public async Task<ReturnObject> Update(StudentClasses studentClasses)
        {
            var returnObject = new ReturnObject();
            try
            {
                var studentClassesExists = await _repository.Select(studentClasses);
                if (studentClassesExists == null) return Util.CreateBadRequest("Cadastro não encontrado!");

                returnObject = await _repository.Update(studentClassesExists);
            }
            catch (Exception ex)
            {
                returnObject = Util.CreateInternalServerError(ex);
            }
            return returnObject;
        }
    }
}
