namespace TranslationManagement.Data.Management;

using System.ComponentModel;

public enum TranslatorStatus : byte
{
    Default,
    [Description("Applicant")] 
    Applicant,
    [Description("Certified")] 
    Certified,
    [Description("Deleted")] 
    Deleted
}