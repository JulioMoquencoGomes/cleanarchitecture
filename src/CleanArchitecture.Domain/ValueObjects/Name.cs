using System.ComponentModel.DataAnnotations;
using Vogen;
 
namespace CleanArchitecture.Domain.ValueObjects;
 
[ValueObject<string>]
public partial struct Name
{
    private static Validation Validate(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return Validation.Invalid("Name cannot be empty.");
 
        if (input.Length > 100)
            return Validation.Invalid("Name cannot exceed 100 characters.");
 
        return Validation.Ok;
    }
}