using Microsoft.AspNetCore.Identity;
using StudentDotNetCore6.Models;

namespace StudentDotNetCore6.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateUserAsync(SignUpUserModel userModel);
        Task<SignInResult> PasswordSignInAsync(SignInModel signInModel);

        Task SignOutAsync();
    }
}