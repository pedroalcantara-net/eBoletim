using eBoletim.Server.CrossCutting;
using eBoletimServer.DataAccess.Interface;
using eBoletimServer.Domain.Models;
using eBoletimServer.Service.Interface;
using eBoletimServer.Service.Services.Base;

namespace eBoletimServer.Service.Services
{
    public class RolesService : BaseService<Roles, IRolesRepository>, IRolesService
    {
        public RolesService(IRolesRepository roles) : base(roles)
        {
        }

        public async Task<ReturnObject> Insert(string tempRole)
        {
            var returnObject = new ReturnObject();
            try
            {
                #region Preparações para inserção na base
                var role = new Roles()
                {
                    Role = tempRole
                };
                #endregion

                returnObject = await _repository.Insert(role);
            }
            catch (Exception ex)
            {
                returnObject = Util.CreateInternalServerError(ex);
            }
            return returnObject;
        }

        public async Task<ReturnObject> Update(Roles role)
        {
            var returnObject = new ReturnObject();
            try
            {
                var roleExists = await _repository.Select(role);
                if (roleExists == null) return Util.CreateBadRequest("Cadastro não encontrado!");

                roleExists.Role = role.Role;

                returnObject = await _repository.Update(roleExists);
            }
            catch (Exception ex)
            {
                returnObject = Util.CreateInternalServerError(ex);
            }
            return returnObject;
        }
    }
}
