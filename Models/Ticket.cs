namespace Api.Models{

    public class Ticket
    {
        public required Guid Id {get; set;}
        public string Email {get; set;}
        public DateTimeOffset Time {get; set;}
        public string Social {get; set;}
        public int IsComplete{get; set;}
        public int IsClaimed {get; set;}
        public string WhoClaimed {get; set;} = "";

        public PC? PC {get; set;}
        public Guid? PCId {get; set;}

        public Internet? Internet {get; set;}
        public Guid? InternetId {get; set;}

        public PcOpti? PcOpti {get; set;}
        public Guid? PcOptiId {get; set;}
    }


}