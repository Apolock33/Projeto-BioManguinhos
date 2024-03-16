using Firebase.Database;
using Firebase.Database.Query;
using ProjetoBioManguinhos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBioManguinhos.Services
{
    public class UserServices
    {
        FirebaseClient Client = new FirebaseClient("https://projetobiomanguinhos-default-rtdb.firebaseio.com/", new FirebaseOptions { AuthTokenAsyncFactory = () => Task.FromResult(Models.Database.Secret) });

        public async Task<bool> VeryfyAccessRegister(string username, string password)
        {
            try
            {
                var consult = (await Client.Child("Users").OnceAsync<User>())
                    .Where(u => u.Object.Username == username)
                    .Where(u => u.Object.Password == password)
                    .FirstOrDefault();

                if (consult.Object != null)
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao tentar logar. " + ex.Message);
            }
        }

        public async Task<bool> IsUserFirstLogin(string username)
        {
            try
            {
                FirebaseObject<User> verifyLogin = (await Client.Child("Users")
                    .OnceAsync<User>())
                    .Where(u => u.Object.Username == username)
                    .FirstOrDefault();

                if (verifyLogin.Object != null)
                {
                    if (verifyLogin.Object.IsFirstLogin == 1)
                    {
                        await Client.Child("Users").Child(verifyLogin.Key).PutAsync(new User()
                        {
                            Id = verifyLogin.Object.Id,
                            Username = verifyLogin.Object.Username,
                            Password = verifyLogin.Object.Password,
                            IsFirstLogin = 0
                        });

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao recuperar informações do usuário" + ex.Message);
            }
        }
    }
}
