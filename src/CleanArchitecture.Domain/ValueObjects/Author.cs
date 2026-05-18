using System.ComponentModel.DataAnnotations;
using Vogen;
 
namespace CleanArchitecture.Domain.ValueObjects;
 
[ValueObject<string>]
public partial struct Author
{
    private static Validation Validate(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return Validation.Invalid("Author cannot be empty.");
 
        if (input.Length > 50)
            return Validation.Invalid("Author cannot exceed 50 characters.");
 
        return Validation.Ok;
    }
}