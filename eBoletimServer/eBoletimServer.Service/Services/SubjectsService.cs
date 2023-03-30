using eBoletim.Server.CrossCutting;
using eBoletimServer.DataAccess.Interface;
using eBoletimServer.Domain.Models;
using eBoletimServer.Service.Interface;
using eBoletimServer.Service.Services.Base;

namespace eBoletimServer.Service.Services
{
    public class SubjectsService : BaseService<Subjects, ISubjectsRepository>, ISubjectsService
    {

        public SubjectsService(ISubjectsRepository subjects) : base(subjects)
        {
        }

        public async Task<ReturnObject> Insert(string tempSubject)
        {
            var returnObject = new ReturnObject();
            try
            {
                #region Preparações para inserção na base
                var subject = new Subjects()
                {
                    SubjectName = tempSubject
                };
                #endregion

                returnObject = await _repository.Insert(subject);
            }
            catch (Exception ex)
            {
                returnObject = Util.CreateInternalServerError(ex);
            }
            return returnObject;
        }

        public async Task<ReturnObject> Update(Subjects subject)
        {
            var returnObject = new ReturnObject();
            try
            {
                var subjectExists = await _repository.Select(subject);
                if (subjectExists == null) return Util.CreateBadRequest("Cadastro não encontrado!");

                subjectExists.SubjectName = subject.SubjectName;

                returnObject = await _repository.Update(subjectExists);
            }
            catch (Exception ex)
            {
                returnObject = Util.CreateInternalServerError(ex);
            }
            return returnObject;
        }
    }
}
