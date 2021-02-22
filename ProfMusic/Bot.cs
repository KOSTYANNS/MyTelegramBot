using System;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;

namespace ProfMusic
{
    public class Bot
    {
        static ITelegramBotClient botClient;

        public void BotClient(string Token)
        {
            botClient = new TelegramBotClient(Token);

            var me = botClient.GetMeAsync().Result;
            Console.WriteLine($"Start listening for @{me.Username}");

            botClient.OnMessage += Bot_Message;
            botClient.StartReceiving();
            Console.WriteLine();
            Thread.Sleep(int.MaxValue);
        }

        private static async void Bot_Message(object sender, MessageEventArgs e)
        {
            
            if (e.Message != null || e.Message.Type == MessageType.Text)
            {
                var message = e.Message.Text.ToLower().Split(';');

                if (message.Length > 0)
                {
                    switch (message[0])
                    {
                        case "/start":
                            await botClient.SendTextMessageAsync(e.Message.Chat.Id, "Привет");
                            break;

                        case "/post":
                            var response = GetPost.GetVkPost(Config.vkurl);

                            if (response != null)
                            {
                                foreach (var item in response)
                                {
                                    if (item.Id > 0 && !string.IsNullOrWhiteSpace(item.OwnerId.ToString()))
                                    {
                                        await botClient.SendTextMessageAsync(e.Message.Chat.Id,
                                            $"{Config.urlname}{item.OwnerId}_{item.Id}");
                                    }
                                }
                            }
                            else
                            {
                                await botClient.SendTextMessageAsync(e.Message.Chat.Id, "Записей нет");
                            }
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Внутри сообщения ничего нет");
                }
            }
            else
            {
                Console.WriteLine("Broken message");
            }
        }
    }
}