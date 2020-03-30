
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace NosazEntertainment.Web.Models
{
    public class ApiResult
    {
        public ApiResultStatus Status { get; set; }
        public ModelStateDictionary ModelErrors { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }

    public enum ApiResultStatus
    {
        success=0, logical=1, ModelValidation=2
    }
}
