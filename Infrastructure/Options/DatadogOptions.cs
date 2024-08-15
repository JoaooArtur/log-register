using System.ComponentModel.DataAnnotations;

namespace LogRegister.Infrastructure.Options
{
    public class DatadogOptions
    {
        [Required]
        public required string ApiKey { get; init; }
    }
}
