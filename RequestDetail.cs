using kanusaoft1.Model;

namespace kanusaoft1.Models
{
    public class RequestDetail
    {
        public int RequestDetailId { get; set; }
        public int RequestId { get; set; }
        public string Supplement { get; set; }
        public supplement supplement { get; set; }
        public location location { get; set; }
        public int Amount { get; set; }
        public Request request { get; set; }
    }
}