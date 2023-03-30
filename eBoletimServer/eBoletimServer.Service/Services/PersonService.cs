using eBoletim.Server.CrossCutting;
using eBoletimServer.DataAccess.Interface;
using eBoletimServer.Domain.Models;
using eBoletimServer.Service.Interface;
using eBoletimServer.Service.Services.Base;

namespace eBoletimServer.Service.Services
{
    public class PersonService : BaseService<Person, IPersonRepository>, IPersonService
    {
        public PersonService(IPersonRepository person) : base(person)
        {

        }

        public async Task<List<Person>> GetPersonByRoleId(int id)
        {
            var personQuery = new Person()
            {
                Id = id,
            };

            var person = await _repository.SelectAll();

            return person.Where(p => p.RoleId == id).ToList();
        }

        public async Task<Person> GetPersonByEmail(string email)
        {
            var personQuery = new Person()
            {
                Email = email,
            };

            var person = await _repository.Select(personQuery);
            person.Password = null;

            return person;
        }

        public async Task<Person> GetPersonByCPF(string CPF)
        {
            var personQuery = new Person()
            {
                CPF = CPF,
            };

            var person = await _repository.Select(personQuery);
            person.Password = null;

            return person;
        }

        public async Task<ReturnObject> Insert(Person person)
        {
            var returnObject = new ReturnObject();
            try
            {
                #region Validações
                if (!Validation.ValidateCPF(person.CPF)) return Util.CreateBadRequest("CPF inválido!");
                if (!Validation.ValidateEmail(person.Email)) return Util.CreateBadRequest("E-mail inválido!");
                #endregion

                //#region Preparações para inserção na base
                //var person = new Person()
                //{
                //    CPF = tempPerson.CPF,
                //    Name = tempPerson.Name,
                //    Surname = tempPerson.Surname,
                //    Email = tempPerson.Email,
                //    Password = Convert.ToBase64String(Criptography.Encrypt(tempPerson.Password)),
                //    RoleId = tempPerson.RoleId,
                //    RegistrationDate = DateTime.Now,
                //};
                //#endregion

                person.Password = Convert.ToBase64String(Criptography.Encrypt(person.Password));
                person.RegistrationDate = DateTime.Now;

                returnObject = await _repository.Insert(person);
            }
            catch (Exception ex)
            {
                returnObject = Util.CreateInternalServerError(ex);
            }
            return returnObject;
        }

        public async Task<ReturnObject> Update(Person person)
        {
            var returnObject = new ReturnObject();
            try
            {
                var personExists = await _repository.Select(person);
                if (personExists == null) return Util.CreateBadRequest("Cadastro não encontrado!");

                personExists.Name = !String.IsNullOrWhiteSpace(person.Name) ? person.Name : personExists.Name;
                personExists.Surname = !String.IsNullOrWhiteSpace(person.Surname) ? person.Surname : personExists.Surname;
                personExists.Email = !String.IsNullOrWhiteSpace(person.Email) ? person.Email : personExists.Email;
                personExists.Password = !String.IsNullOrWhiteSpace(person.Password) ? Convert.ToBase64String(Criptography.Encrypt(person.Password)) : personExists.Password;

                returnObject = await _repository.Update(personExists);
            }
            catch (Exception ex)
            {
                returnObject = Util.CreateInternalServerError(ex);
            }
            return returnObject;
        }
    }
}
