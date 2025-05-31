namespace Api.Models{

    public class Ram
    {
        public required Guid Id {get; set;} = Guid.NewGuid();
        public int Price {get; set;}
        public string Name {get; set;}
        public string Url {get; set;}
        public string Type {get; set;}
        public int IsActive {get; set;} = 1;
    }


}