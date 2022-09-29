namespace E02.SimpleChat.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using Models;

    public class ChatController : Controller
    {
        //Suggested to use a DB if we ever want to make such an app
        //The chat will be saved even after the app has been closed
        //Using KeyValuePair instead of a dictionary
        //This way we can have duplicate messages
        private static List<KeyValuePair<string, string>> Messages 
            = new List<KeyValuePair<string, string>>();

        //GET
        public IActionResult Show()
        {
            if(Messages.Count < 1)
            {
                return View(new ChatViewModel());
            }

            var chatModel = new ChatViewModel()
            {
                Messages = Messages
                    .Select(m => new MessageViewModel()
                    {
                        Sender = m.Key,
                        MessageText = m.Value
                    })
                    .ToList()
            };

            return View(chatModel);
        }

        //POST
        [HttpPost]
        public IActionResult Send(ChatViewModel chat)
        {
            var newMessage = chat.CurrentMessage;

            Messages.Add(new KeyValuePair<string, string>
                (newMessage.Sender, newMessage.MessageText));

            return RedirectToAction("Show");
        }
    }
}
