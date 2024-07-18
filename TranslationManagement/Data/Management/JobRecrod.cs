namespace TranslationManagement.Data.Management;

public sealed record JobRecrod
(
    Guid Id
) : Entity(Id){
    public JobStatus Status { get; set; }
}