namespace ProfMusic
{
    public class Config
    {
        public static string urlname = "https://vk.com/profmusickz?w=wall";
        public static string domain = "profmusickz"; //Домен группы в вк
        public static string method = "wall.get"; //метод получения записей 
        public static string count = "5"; //Кол-во записей
        public static string Token = ""; //Телеграмм токен


        public static string vkurl =
            ($"https://api.vk.com/method/{method}?domain={domain}&count={count}&v=5.52&access_token={vktoken}"); //Cтрока запроса для получения записей


        public static string vktoken =
            ""; //Авторизационный токен для вк
    }
}