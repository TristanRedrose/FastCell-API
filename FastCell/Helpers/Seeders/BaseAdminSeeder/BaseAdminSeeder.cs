using FastCell_DAL.Enums;
using FastCell_DAL.Models.DTO.Auth.Request;
using FastCell_DAL.Models.Entities.Auth;
using FastCell_DAL.Models.Entities.Auth.Info;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace FastCell.Helpers.Seeders.BaseAdminSeeder
{
    public class BaseAdminSeeder : IBaseAdminSeeder
    {
        private UserManager<User> _userManager;

        public BaseAdminSeeder(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task SeedBaseAdminAsync()
        {
            var adminExists = await AdminExistAsync();

            if (!adminExists)
            {
                await AddAdminAsync();
            }

            return;
        }

        public async Task<bool> AdminExistAsync()
        {
            var adminList = await _userManager.GetUsersInRoleAsync("Admin");

            if (adminList.Count == 0)
            {
                return false;
            }

            return true;
        }

        public async Task AddAdminAsync()
        {
            string addUsername()
            {
                Console.Write("Enter email/username: ");
                string username = Console.ReadLine();

                if (username.Any(c => char.IsWhiteSpace(c)))
                {
                    Console.WriteLine("Email/username cannot contain whitespace");
                    username = addUsername();
                }

                if (username.Trim(' ').IsNullOrEmpty())
                {
                    Console.WriteLine("Email/username cannot be empty");
                    username = addUsername();
                }

                bool isValid = new EmailAddressAttribute().IsValid(username);

                if (!isValid)
                {
                    Console.WriteLine("Username must be a valid email format");
                    username = addUsername();
                }

                return username;
            }

            string addPassword()
            {
                Console.Write("Enter password: ");
                string password = Console.ReadLine();

                if (password.Length < 8)
                {
                    Console.WriteLine("Password must contain at least 8 characters");
                    password = addPassword();
                }

                if (password.Trim(' ').IsNullOrEmpty())
                {
                    Console.WriteLine("Password cannot be empty");
                    password = addPassword();
                }

                return password;
            }

            string confirmPassword(string password)
            {
                Console.Write("Confirm Password: ");
                string passConfirm = Console.ReadLine();

                if (passConfirm != password)
                {
                    Console.WriteLine("Passwords must match");
                    passConfirm = confirmPassword(password);
                }

                return passConfirm;
            }

            string username = addUsername();
            string password = addPassword();
            string passConfirm = confirmPassword(password);

            var defaultAdmin = ReturnDefaultAdminInfo(username);

            var result = await _userManager.CreateAsync(defaultAdmin, password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(defaultAdmin, "Admin");
            }
        }

        public User ReturnDefaultAdminInfo(string username)
        {
            var contactinfo = new ContactInfo
            {
                Name = "John",
                Surname = "Doe",
                Address = "Nowhere",
                City = "New Jersey",
                Country = "Jerseysville",
                PhoneNumber = "0123456789",
                PostalCode = "000000"
            };

            var employeeInfo = new EmployeeInfo
            {
                Position = "Admin",
                EmploymentType = EmploymentType.Full_Time,
                Salary = 1000,
                Active = true,
            };

            var defaultAdminInfo = new User
            {
                Email = username,
                UserName = username,
                ContactInfo = contactinfo,
                EmployeeInfo = employeeInfo,
            };

            return defaultAdminInfo;
        }
    }
}
