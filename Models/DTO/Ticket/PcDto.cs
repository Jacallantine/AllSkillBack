namespace Api.Models.Dto{

    public class PcDto{

        public Guid CpuId { get; set; }
        public Guid GpuId { get; set; }
        public Guid RamId { get; set; }
        public Guid MoboId { get; set; }
        public Guid PsuId { get; set; }
        public Guid CaseId { get; set; }
        public Guid StorageId {get; set;}

    }

}