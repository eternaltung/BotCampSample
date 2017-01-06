using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace BotCampDemo.Model
{
	public class FBChannelModel
	{
		public Sender sender { get; set; }
		public Recipient recipient { get; set; }
		public long timestamp { get; set; }
		public FBMessage message { get; set; }
		public Postback postback { get; set; }
		public Location location { get; set; }
	}

	public class Location
	{
		public double altitude { get; set; }
		public double latitude { get; set; }
		public double longitude { get; set; }
		public string name { get; set; }
	}

	public class Postback
	{
		public string payload { get; set; }
	}

	public class Sender
	{
		public string id { get; set; }
	}

	public class Recipient
	{
		public string id { get; set; }
	}

	public class FBMessage
	{
		public string mid { get; set; }
		public int seq { get; set; }
		public string text { get; set; }
		public List<FBAttachment> attachments { get; set; }
		public QuickReplyMessage quick_reply { get; set; }
		public string sticker_id { get; set; }
	}

	public class QuickReplyMessage
	{
		public string payload { get; set; }
	}

	public class FBAttachment
	{
		public string title { get; set; }
		public string url { get; set; }
		public string type { get; set; }
		public Payload payload { get; set; }
	}

	public class Payload
	{
		public Coordinates coordinates { get; set; }
		public string url { get; set; }
	}

	public class Coordinates
	{
		public float lat { get; set; }
		[JsonProperty("long")]
		public float lng { get; set; }
	}
}