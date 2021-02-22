using System;

namespace ProfMusic
{
    public class GetPost
    {
        public static Item[] GetVkPost(string vkurl)
        {
            var response = Request.GetRequest(vkurl);

            if (string.IsNullOrEmpty(response))
            {
                Console.WriteLine("Строка ответа пуста");
            }

            var result = Request.DeserializeJsonToObject<Temperatures>(response);

            if (result.Response != null)
            {
                if (result.Response != null)
                    return result.Response.Items;
                
            }

            Console.WriteLine("Ответ пустой");
            return null;
        }
    }
}