# Shared Architecture Guidelines for JuulTimesedler

## 1. DTO Design Pattern
Follow this pattern for all shared DTOs to ensure they are compatible with both Blazor and Umbraco.

```csharp
using System.ComponentModel.DataAnnotations;

namespace SharedModels.DTOs
{
    public class PutTimesheetDTO
    {
        [Required]
        public int ProjectId { get; set; }

        [Required]
        [Range(0.1, 24, ErrorMessage = "Hours must be between 0.1 and 24.")]
        public decimal Hours { get; set; }

        [Required]
        public DateTime WorkDate { get; set; }

        [StringLength(500)]
        public string? Notes { get; set; }
    }
}
```

## 2. Using Shared Enums
Centralize all status codes, types, and day definitions in `SharedModels/Enums`.

```csharp
namespace SharedModels.Enums
{
    public enum WeekDays
    {
        Mandag = 1,
        Tirsdag = 2,
        Onsdag = 3,
        Torsdag = 4,
        Fredag = 5,
        Lørdag = 6,
        Søndag = 7
    }
}
```

## 3. Serialization Consistency
Always use `System.Text.Json` for serialization to maintain cross-platform compatibility without extra dependencies.

```csharp
// Use this pattern in services
var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
var json = JsonSerializer.Serialize(dto, options);
```

## 4. Cross-Project References
Ensure `SharedModels.csproj` is correctly referenced in both:
- `JuulTimesedler_BE.csproj`
- `JuulTimesedler_FE.csproj`
