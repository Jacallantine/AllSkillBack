namespace Api.Models{

    public class Internet
    {
        public required Guid Id {get; set;} = Guid.NewGuid();
        public int Price {get; set;}
        public string Description {get; set;}
        public int IsActive {get; set;} = 1;
    }


}