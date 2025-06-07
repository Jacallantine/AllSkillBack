namespace Api.Models{

    public class PcBudget
    {
        public Guid Id {get; set;} = Guid.NewGuid();
        public int Budget {get; set;}
        public string SpecialRequest {get;set;}
        public string Social {get;set;}
    }


}