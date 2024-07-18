namespace TranslationManagement.Api;

using Microsoft.AspNetCore.Mvc;
public sealed class ApiRouteAttribute : RouteAttribute
{
    public ApiRouteAttribute(string temaplte) : base($"api/v{{v:apiVersion}}/{temaplte}")
    {

    }
}