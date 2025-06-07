namespace Api.Models.Dto{

    public class PcBudgetDto{

        public Guid Id {get;set;} = Guid.NewGuid();
        public string Email {get;set;}
        public string Social {get;set;}
        public int Budget {get;set;}
        public string SpecialRequest {get;set;}

    }

}