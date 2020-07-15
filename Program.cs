using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryGetResultInTheSameSelect
{
	class Program
	{
		public static void Main()
		{
			var eventMarketsDictionary = new Dictionary<string, string>();
			eventMarketsDictionary.Add("market1", "event1");
			eventMarketsDictionary.Add("market2", "event1");
			eventMarketsDictionary.Add("market3", "event2");

			var fixtureMappingDictionary = new Dictionary<string, string>();
			fixtureMappingDictionary.Add("event1", "f-tag-1");
			fixtureMappingDictionary.Add("event2", "f-tag-1");

			var marketList = new List<MarketObject>();
			marketList.Add(new MarketObject("market1"));
			marketList.Add(new MarketObject("market2"));
			marketList.Add(new MarketObject("market3"));
			marketList.Add(new MarketObject("market4"));

			var result = marketList.Select(data => new {
				EventId = eventMarketsDictionary.TryGetValue(data.MarketId, out var eventId) ? eventId : string.Empty,
				FixtureTag = fixtureMappingDictionary.TryGetValue(eventId, out var fixtureTag) ? fixtureTag : string.Empty
			}).ToList();

			Console.WriteLine(result);
			Console.ReadLine();
		}

		public class MarketObject
		{

			public string MarketId { get; set; }

			public MarketObject(string marketId)
			{
				MarketId = marketId;
			}
		}
	}
}
