using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Todo.Services
{
    public static class GravatarService
    {
        private const string GravatarBaseUrl = "https://www.gravatar.com/";

        public static async Task<(string Name, string AvatarUrl)> GetProfileInfo(string emailAddress)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var hash = GetHash(emailAddress);
                    var url = $"{GravatarBaseUrl}{hash}.json";
                    var response = await httpClient.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        var json = await response.Content.ReadAsStringAsync();
                        var profile = JObject.Parse(json);
                        var displayName = (string)profile["entry"][0]["displayName"];
                        var avatarUrl = (string)profile["entry"][0]["thumbnailUrl"];
                        return (displayName, avatarUrl);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching Gravatar profile: {ex.Message}");
            }

            return (null, null);
        }

        public static string GetHash(string emailAddress)
        {
            using (var md5 = System.Security.Cryptography.MD5.Create())
            {
                var inputBytes = System.Text.Encoding.ASCII.GetBytes(emailAddress.Trim().ToLowerInvariant());
                var hashBytes = md5.ComputeHash(inputBytes);

                var builder = new System.Text.StringBuilder();
                foreach (var b in hashBytes)
                {
                    builder.Append(b.ToString("X2"));
                }
                return builder.ToString().ToLowerInvariant();
            }
        }
    }
}
