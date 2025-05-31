namespace Api.Models{

    public class User{
         public required Guid id {get; init;}
        public string firstName {get; set;}
        public string lastName {get; set;}
        public string email {get; set;}
        public string password {get; set;}
        public string role {get; set;}

    }

}