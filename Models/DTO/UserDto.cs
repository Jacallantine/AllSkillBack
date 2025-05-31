namespace Api.Models.Dto{

    public class UserDto{

        public required Guid Id {get; init;} = Guid.NewGuid();
        public string FirstName {get; set;}
        public string LastName {get; set;}

    }
}