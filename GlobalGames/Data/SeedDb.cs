using Microsoft.AspNetCore.Identity;
using GlobalGames.Data.Entidades;
using GlobalGames.Helpers;
using System;
using System.Linq;
using System.Threading.Tasks;


namespace GlobalGames.Data
{
    public class SeedDb
    {

        private readonly DataContext context;
        private readonly IUserHelper userHelper;
        private readonly Random random;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            this.context = context;
            this.userHelper = userHelper;
            this.random = new Random();

        }

        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();

            var user = await this.userHelper.GetUserByEmailAsync("jpldias13@gmail.com");
            if (user == null)
            {
                user = new User
                {
                    FirstName = "Joao",
                    LastName = "Dias",
                    Email = "jpldias13@gmail.com",
                    UserName = "jpldias13@gmail.com",
                    PhoneNumber = "523456789"
                };

                var result = await this.userHelper.AddUserAsync(user, "123456");

                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Nao conseguiu criar o utilizador na seed");
                }

            }

            if (!this.context.UserLogin.Any())
            {
                this.AddUserLogin("Jose", user);
                this.AddUserLogin("Rita", user);
                this.AddUserLogin("Filipe", user);
                this.AddUserLogin("Tiago", user);
                this.AddUserLogin("Ana", user);
                await this.context.SaveChangesAsync();
            }
        }

        private void AddUserLogin(string name, User user)
        {
            this.context.UserLogin.Add(new UserLogin
            {
                Name = name,
                User = user
            });
        }
    }
}

