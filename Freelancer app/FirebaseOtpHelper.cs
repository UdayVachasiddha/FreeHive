using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Freelancer_app
{
    public class FirebaseOtpHelper
    {
        private const string FirebaseApiKey = "AIzaSyBu5e4KvKCg_w66hicvyq19rgX6ARp25I4"; // Your Web API Key

        public static async Task<string> SendVerificationCodeAsync(string phoneNumber)
        {
            string url = $"https://identitytoolkit.googleapis.com/v1/accounts:sendVerificationCode?key={FirebaseApiKey}";

            using (HttpClient client = new HttpClient())
            {
                var payload = new
                {
                    phoneNumber = phoneNumber
                    // For production, add reCAPTCHA to prevent abuse:
                    // recaptchaToken = "your-recaptcha-token-here" (obtain via WebBrowser control or external service)
                };

                var json = JsonConvert.SerializeObject(payload);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(url, content);
                string result = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    JObject jsonObj = JObject.Parse(result);
                    return jsonObj["sessionInfo"]?.ToString();
                }
                else
                {
                    JObject jsonObj = JObject.Parse(result);
                    throw new Exception(jsonObj["error"]?["message"]?.ToString() ?? "Unknown error");
                }
            }
        }

        public static async Task<string> VerifyOtpAsync(string sessionInfo, string otpCode)
        {
            string url = $"https://identitytoolkit.googleapis.com/v1/accounts:signInWithPhoneNumber?key={FirebaseApiKey}";

            using (HttpClient client = new HttpClient())
            {
                var payload = new
                {
                    sessionInfo = sessionInfo,
                    code = otpCode
                };

                var json = JsonConvert.SerializeObject(payload);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(url, content);
                string result = await response.Content.ReadAsStringAsync();

                JObject jsonObj = JObject.Parse(result);

                // If successful, Firebase returns an idToken (auth proof)
                return jsonObj["idToken"]?.ToString();
            }
        }
    }
}