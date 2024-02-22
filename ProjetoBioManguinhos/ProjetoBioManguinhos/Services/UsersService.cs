using Firebase.Database;
using Firebase.Database.Query;
using ProjetoBioManguinhos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBioManguinhos.Services
{
    public class UsersService
    {
        public static string AccessKey = "MtR1OlCqhNrJAsExzXXDmE0lYtdG2J8ti3MB0GiQ";

        FirebaseClient Client = new FirebaseClient("https://projetobiomanguinhos-default-rtdb.firebaseio.com/", new FirebaseOptions { AuthTokenAsyncFactory = () => Task.FromResult(AccessKey) });

        public async Task<bool> EnterOrCreate(string login, string password)
        {
            try
            {
                var verify = (await Client.Child("Users")
                .OnceAsync<Users>())
                .Where(c => c.Object.Login == login && c.Object.Password == password)
                .FirstOrDefault();

                if (login == "carlos.gomes" && password == "123" && verify == null)
                {
                    await Client.Child("Users")
                   .PostAsync(new Users()
                   {
                       Login = login,
                       Password = password
                   });

                    return true;
                }

                if (verify == null)
                {
                    return false;
                }

                return true;
            }
            catch(Exception ex)
            {
                var error = ex.Message;
                return false;
            }
        }
    }
}
