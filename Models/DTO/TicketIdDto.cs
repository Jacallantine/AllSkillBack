namespace Api.Models.Dto{

    public class TicketIdDto{

        public Guid Id {get; set;} 
        public string FirstName {get; set;}
        public Guid WhoClaimedId {get; set;}
}
}