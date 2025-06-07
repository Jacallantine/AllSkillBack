namespace Api.Models.Dto{

    public class EditCaseDto{
        public Guid Id {get; set;} 
        public int Price {get; set;}
        public string Name {get; set;}
        public string Url {get; set;}
        public string Type  {get; set;}
        public int IsActive {get;set;}

    }

    public class EditCpuDto{
        public Guid Id {get; set;} 
        public int Price {get; set;}
        public string Name {get; set;}
        public string Url {get; set;}
        public string Type  {get; set;}
        public int IsActive {get;set;}

    }
     public class EditGpuDto{
        public Guid Id {get; set;} 
        public int Price {get; set;}
        public string Name {get; set;}
        public string Url {get; set;}
        public string Type  {get; set;}
        public int IsActive {get;set;}


    }
      public class EditRamDto{
        public Guid Id {get; set;} 
        public int Price {get; set;}
        public string Name {get; set;}
        public string Url {get; set;}
        public string Type  {get; set;}
        public int IsActive {get;set;}


    }
     public class EditMoboDto{
        public Guid Id {get; set;} 
        public int Price {get; set;}
        public string Name {get; set;}
        public string Url {get; set;}
        public string Type  {get; set;}
        public int IsActive {get;set;}

    }

    public class EditPsuDto{
        public Guid Id {get; set;} 
        public int Price {get; set;}
        public string Name {get; set;}
        public string Url {get; set;}
        public string Rating  {get; set;}
        public int Watt {get; set;}
        public int IsActive {get;set;}

    }

    public class EditStorageDto{
        public Guid Id {get; set;} 
        public int Price {get; set;}
        public string Name {get; set;}
        public string Url {get; set;}
        public string Type  {get; set;}
        public int IsActive {get;set;}

    }
}