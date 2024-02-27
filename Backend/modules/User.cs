using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Todo_api;

//IdentityUser skapar en användare med lösenord 
public class User : IdentityUser {

public List<Todo> todos {get; set;}

public User(){}
}