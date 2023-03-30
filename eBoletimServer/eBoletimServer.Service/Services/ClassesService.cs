using eBoletim.Server.CrossCutting;
using eBoletimServer.DataAccess.Interface;
using eBoletimServer.Domain.Models;
using eBoletimServer.Service.Interface;
using eBoletimServer.Service.Services.Base;

namespace eBoletimServer.Service.Services
{
    public class ClassesService : BaseService<Classes, IClassesRepository>, IClassesService
    {

        public ClassesService(IClassesRepository classes) : base(classes)
        {
            //??
        }

        public async Task<ReturnObject> Insert(Classes classe)
        {
            var returnObject = new ReturnObject();
            try
            {
                returnObject = await _repository.Insert(classe);
            }
            catch (Exception ex)
            {
                returnObject = Util.CreateInternalServerError(ex);
            }
            return returnObject;
        }

        public async Task<ReturnObject> Update(Classes classe)
        {
            var returnObject = new ReturnObject();
            try
            {
                var classeExists = await _repository.Select(classe);
                if (classeExists == null) return Util.CreateBadRequest("Cadastro não encontrado!");

                classeExists.TeacherId = classe.TeacherId;
                classeExists.Year = classe.Year;
                classeExists.SubjectId = classe.SubjectId;

                returnObject = await _repository.Update(classeExists);
            }
            catch (Exception ex)
            {
                returnObject = Util.CreateInternalServerError(ex);
            }
            return returnObject;
        }
    }
}
