namespace Api.Models.Dto{

     public class TicketDto
    {
        public Guid Id {get; set;}
        public string Email { get; set; }
        public DateTimeOffset Time { get; set; } = DateTimeOffset.UtcNow;
        public string Social { get; set; }
        public int IsComplete { get; set; } = 0;
        public int IsClaimed { get; set; } = 0;
        public string WhoClaimed { get; set; } = string.Empty;

        public Guid? InternetId { get; set; }
        public Guid? PcOptiId { get; set; }
        public Guid? PCId {get; set;} = Guid.NewGuid();
        public PcDto? PC { get; set; } 
    }


}