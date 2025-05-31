namespace Api.Models.Dto{

    public class AddCaseDto{
        public Guid Id {get; set;} = Guid.NewGuid();
        public int Price {get; set;}
        public string Name {get; set;}
        public string Url {get; set;}
        public string Type  {get; set;}

    }

    public class AddCpuDto{
        public Guid Id {get; set;} = Guid.NewGuid();
        public int Price {get; set;}
        public string Name {get; set;}
        public string Url {get; set;}
        public string Type  {get; set;}

    }
     public class AddGpuDto{
        public Guid Id {get; set;} = Guid.NewGuid();
        public int Price {get; set;}
        public string Name {get; set;}
        public string Url {get; set;}
        public string Type  {get; set;}


    }
      public class AddRamDto{
        public Guid Id {get; set;} = Guid.NewGuid();
        public int Price {get; set;}
        public string Name {get; set;}
        public string Url {get; set;}
        public string Type  {get; set;}


    }
     public class AddMoboDto{
        public Guid Id {get; set;} = Guid.NewGuid();
        public int Price {get; set;}
        public string Name {get; set;}
        public string Url {get; set;}
        public string Type  {get; set;}

    }

    public class AddPsuDto{
        public Guid Id {get; set;} = Guid.NewGuid();
        public int Price {get; set;}
        public string Name {get; set;}
        public string Url {get; set;}
        public string Rating  {get; set;}
        public int Watt {get; set;}

    }

    public class AddStorageDto{
        public Guid Id {get; set;} = Guid.NewGuid();
        public int Price {get; set;}
        public string Name {get; set;}
        public string Url {get; set;}
        public string Type  {get; set;}

    }
}