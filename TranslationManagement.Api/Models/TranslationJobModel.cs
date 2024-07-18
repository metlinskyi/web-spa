using System;

namespace TranslationManagement.Api.Models;

public class TranslationJobModel : ApiModel
{
    public string Id { get; set; }
    public string CustomerName { get; set; }
    public string Status { get; set; }
    public string OriginalContent { get; set; }
    public string TranslatedContent { get; set; }
    public decimal Price { get; set; }
}