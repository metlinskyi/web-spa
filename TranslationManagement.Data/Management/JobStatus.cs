namespace TranslationManagement.Data.Management;

using System.ComponentModel;

public enum JobStatus : byte
{
    Default,
    [Description("New")] 
    New,
    [Description("InProgress")] 
    InProgress,
    [Description("Completed")] 
    Completed
}