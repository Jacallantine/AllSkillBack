namespace Api.Models{

    public class PcOpti
    {
        public required Guid Id {get; set;} = Guid.NewGuid();
        public int Price {get; set;}
    }


}