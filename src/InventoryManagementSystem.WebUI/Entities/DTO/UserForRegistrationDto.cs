using System.ComponentModel.DataAnnotations;

namespace InventoryManagementSystem.WebUI.Entities.DTO;

public class UserForRegistrationDto
{
    [Required(ErrorMessage = "Email is required.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "First name is required.")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Last name is required.")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Password is required")]
    public string Password { get; set; }

    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    public string ConfirmPassword { get; set; }
}