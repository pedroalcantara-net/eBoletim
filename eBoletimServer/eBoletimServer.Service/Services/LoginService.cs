using eBoletim.Server.CrossCutting;
using eBoletimServer.DataAccess.Interface;
using eBoletimServer.Domain.Models;
using eBoletimServer.Domain.Models.ViewModels;
using eBoletimServer.Service.Interface;

namespace eBoletimServer.Service.Services
{
    public class LoginService : ILoginService
    {
        IPersonRepository _person;
        public LoginService(IPersonRepository person)
        {
            _person = person;
        }
        public async Task<ReturnObject> Login(LoginModel login)
        {
            var returnObject = new ReturnObject();
            try
            {
                #region Validações
                if (!Validation.ValidateCPF(login.CPF)) return Util.CreateBadRequest("CPF inválido!");
                if (String.IsNullOrWhiteSpace(login.Password)) return Util.CreateBadRequest("Senha obrigatória!");
                #endregion

                #region Preparações para busca na base
                var person = new Person()
                {
                    CPF = login.CPF
                };
                #endregion

                var encryptedPassword = Convert.ToBase64String(Criptography.Encrypt(login.Password));
                var user = await _person.Select(person);

                if (user != null)
                {
                    if (encryptedPassword == user.Password)
                    {
                        returnObject.Code = 200;
                        returnObject.Status = true;
                        returnObject.Message = user.Id.ToString();
                    }
                    else
                    {
                        returnObject.Code = 401;
                        returnObject.Status = false;
                        returnObject.Message = "LoginError";
                    }
                }
                else
                {
                    returnObject.Code = 401;
                    returnObject.Status = false;
                    returnObject.Message = "LoginError";
                }

            }
            catch (Exception ex)
            {
                returnObject = Util.CreateInternalServerError(ex);
            }

            return returnObject;
        }
    }
}
