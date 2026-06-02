using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace QuanLySinhVien
{
    public static class AIService
    {

        private static readonly string apiKey = "AQ.Ab8RN6K6RnR4aKOJfGwACG17kgINYjYft70Zw339_ng6LJRssw";

        private static readonly string apiUrl = $"https://generativelanguage.googleapis.com/v1/models/gemini-2.5-flash:generateContent?key={apiKey}";

        /// <summary>
        /// Hàm gửi yêu cầu phân tích môn học lên Google Gemini API chính thức
        /// </summary>
        public static async Task<string> AskChatGPTAsync(string prompt)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Cấu hình chuỗi JSON Payload gửi đi theo đúng chuẩn kiến trúc dữ liệu mới nhất
                    var requestBody = new
                    {
                        contents = new[]
                        {
                            new { parts = new[] { new { text = prompt } } }
                        }
                    };

                    string jsonPayload = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
                    HttpContent content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                    // Thực hiện bắn request lên máy chủ Google
                    HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseString = await response.Content.ReadAsStringAsync();

                        // Bóc tách cây dữ liệu JSON phản hồi
                        JObject json = JObject.Parse(responseString);
                        string aiResult = json["candidates"][0]["content"]["parts"][0]["text"].ToString().Trim();

                        return aiResult;
                    }
                    else
                    {
                        string errorDetails = await response.Content.ReadAsStringAsync();
                        return $"[Lỗi hệ thống API Gemini]: {response.StatusCode} - {errorDetails}";
                    }
                }
            }
            catch (Exception ex)
            {
                return $"[Lỗi kết nối mạng Internet]: {ex.Message}";
            }
        }
    }
}