using RestAPI_ASPNET.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestAPI_ASPNET.Data.VO
{
    public class PersonVO
    {
        public  long Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Adress { get; set; }

        public string Gender { get; set; }
    }
}
