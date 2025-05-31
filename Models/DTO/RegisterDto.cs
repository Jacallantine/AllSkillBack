namespace Api.Models.Dto{

    public class RegisterDto{
        public Guid id {get; init;} = Guid.NewGuid();
        public string firstName {get; set;}
        public string lastName {get; set;}
        public string email {get; set;}
        public string password {get; set;}
        public string role {get; init;} = "cust";

    }
}