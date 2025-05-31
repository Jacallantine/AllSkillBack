namespace Api.Models{



public class PC
{
    public Guid Id { get; set; } = Guid.NewGuid();

    // Foreign Keys
    public Guid CpuId { get; set; }
    public Guid GpuId { get; set; }
    public Guid RamId { get; set; }
    public Guid MoboId { get; set; }
    public Guid PsuId { get; set; }
    public Guid CaseId { get; set; }
    public Guid StorageId {get; set;}

    // Navigation Properties
    public Cpu Cpu { get; set; }
    public Gpu Gpu { get; set; }
    public Ram Ram { get; set; }
    public Mobo Mobo { get; set; }
    public Psu Psu { get; set; }
    public Case Case { get; set; }
    public Storage Storage {get; set;}

    public ICollection<Ticket> Tickets { get; set; }
}
}