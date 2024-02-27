using RestAPI_ASPNET.Data.VO;
using RestAPI_ASPNET.Model;

namespace RestAPI_ASPNET.Business
{
    public interface IPersonBusiness
    {
        PersonVO Create(PersonVO person);
        PersonVO FindById(long id);
        List<PersonVO> FindAll();
        PersonVO Update(PersonVO person);
        void Delete(long id);
    }
}
