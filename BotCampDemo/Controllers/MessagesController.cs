using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.Bot.Connector;
using Newtonsoft.Json;

namespace BotCampDemo
{
	[BotAuthentication]
	public class MessagesController : ApiController
	{
		/// <summary>
		/// POST: api/Messages
		/// Receive a message from a user and reply to it
		/// </summary>
		public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
		{
			if (activity.Type == ActivityTypes.Message)
			{
				ConnectorClient connector = new ConnectorClient(new Uri(activity.ServiceUrl));
				Activity reply = activity.CreateReply();

				List<Attachment> att = new List<Attachment>();
				att.Add(new HeroCard()
				{
					Title = "iPad Pro",
					Images = new List<CardImage>() { new CardImage("https://s.yimg.com/wb/images/936392DB6B69D9C6D1B897B8DAB20AE595E96FA4") },
					Buttons = new List<CardAction>()
						{
							new CardAction(ActionTypes.OpenUrl, "Yahoo購物中心", value: $"https://tw.buy.yahoo.com/gdsale/MM172-6798747.html")
						}
				}.ToAttachment());
				att.Add(new HeroCard()
				{
					Title = "Surface Pro",
					Images = new List<CardImage>() { new CardImage("https://s.yimg.com/wb/images/268917ABD27238C9A20428002A8143AEEF40A048") },
					Buttons = new List<CardAction>()
						{
							new CardAction(ActionTypes.OpenUrl, "Yahoo購物中心", value: $"https://tw.buy.yahoo.com/gdsale/gdsale.asp?act=gdsearch&gdid=6561885")
						}
				}.ToAttachment());
				reply.AttachmentLayout = AttachmentLayoutTypes.Carousel;
				reply.Attachments = att;

				await connector.Conversations.ReplyToActivityAsync(reply);
			}
			else
			{
				HandleSystemMessage(activity);
			}
			var response = Request.CreateResponse(HttpStatusCode.OK);
			return response;
		}

		private Activity HandleSystemMessage(Activity message)
		{
			if (message.Type == ActivityTypes.DeleteUserData)
			{
				// Implement user deletion here
				// If we handle user deletion, return a real message
			}
			else if (message.Type == ActivityTypes.ConversationUpdate)
			{
				// Handle conversation state changes, like members being added and removed
				// Use Activity.MembersAdded and Activity.MembersRemoved and Activity.Action for info
				// Not available in all channels
			}
			else if (message.Type == ActivityTypes.ContactRelationUpdate)
			{
				// Handle add/remove from contact lists
				// Activity.From + Activity.Action represent what happened
			}
			else if (message.Type == ActivityTypes.Typing)
			{
				// Handle knowing tha the user is typing
			}
			else if (message.Type == ActivityTypes.Ping)
			{
			}

			return null;
		}
	}
}