using System.ComponentModel.DataAnnotations.Schema;

namespace RestAPI_ASPNET.Model.Base
{
    public class BaseEntity
    {
        [Column("id")]
        public long Id { get; set; }
    }
}
