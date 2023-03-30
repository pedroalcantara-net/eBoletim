using eBoletim.Server.CrossCutting;
using eBoletimServer.DataAccess.Interface;
using eBoletimServer.Domain.Models;
using eBoletimServer.Service.Interface;
using eBoletimServer.Service.Services.Base;

namespace eBoletimServer.Service.Services
{
    public class GradesService : BaseService<Grades, IGradesRepository>, IGradesService
    {
        public GradesService(IGradesRepository grades) : base(grades)
        {

        }

        public async Task<ReturnObject> Insert(Grades grade)
        {
            var returnObject = new ReturnObject();
            try
            {
                returnObject = await _repository.Insert(grade);
            }
            catch (Exception ex)
            {
                returnObject = Util.CreateInternalServerError(ex);
            }
            return returnObject;
        }

        public async Task<ReturnObject> Update(Grades grade)
        {
            var returnObject = new ReturnObject();
            try
            {
                var gradeExists = await _repository.Select(grade);
                if (gradeExists == null) return Util.CreateBadRequest("Cadastro não encontrado!");

                gradeExists.Grade = grade.Grade;

                returnObject = await _repository.Update(gradeExists);
            }
            catch (Exception ex)
            {
                returnObject = Util.CreateInternalServerError(ex);
            }
            return returnObject;
        }
    }
}
