using Firebase.Database;
using ProjetoBioManguinhos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBioManguinhos.Services
{
    public class StudyServices
    {
        FirebaseClient Client = new FirebaseClient("https://projetobiomanguinhos-default-rtdb.firebaseio.com/", new FirebaseOptions { AuthTokenAsyncFactory = () => Task.FromResult(Models.Database.Secret) });

        public async Task<Study> GetStudy(Guid id)
        {
            try
            {
                var verify = (await Client.Child("Study").OnceAsync<Study>())
                    .Where(u => u.Object.Id == id)
                    .FirstOrDefault();

                if (verify.Object.Id != null)
                {
                    return verify.Object;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Study>> GetStudies()
        {
            try
            {
                var verify = (await Client.Child("Study").OnceAsync<Study>()).Select(item => item.Object);

                return verify.AsEnumerable();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
