using RestAPI_ASPNET.Hypermedia;
using RestAPI_ASPNET.Hypermedia.Abstract;
using RestAPI_ASPNET.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestAPI_ASPNET.Data.VO
{
    public class BookVO : ISupporstHyperMedia
    {
        public long Id { get; set; }

        public string Author { get; set; }

        public DateTime LaunchDate { get; set; }

        public decimal Price { get; set; }

        public string Title { get; set; }
        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}
