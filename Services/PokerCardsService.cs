using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace intel_netcore_api.Services
{
    public class PokerCardsService
    {
        private readonly ILogger<PokerCardsService> _logger;

        private static Dictionary<string, int> values = new Dictionary<string, int>()
        {
         {"2",1},{"3",2},{"4",3},{"5",4},{"6",5},{"7",6},{"8",7},{"9",8},{"10",9},{"J",10},{"Q",11},{"K",12},{"A",13}
        };
        private static Dictionary<string, int> suits = new Dictionary<string, int>()
        {
         {"d",0},{"s",13},{"c",26},{"h",39}
        };
        public PokerCardsService(ILogger<PokerCardsService> logger)
        {
            _logger = logger;
        }
        public List<string> SortCards(List<string> cards)
        {
            try
            {
                SortedList<int, string> sortedCards = new SortedList<int, string>();
                foreach (var item in cards)
                {
                    var value = item[..^1]; //using ..^1 is to get last char
                    var suite = $"{item[^1]}"; //using ^1 is to ignore last char F
                    int cardPosition = values[value] + suits[suite];
                    sortedCards.Add(cardPosition, item);
                }
                return sortedCards.Values.ToList();
            }
            catch (Exception e)
            {
                this._logger.LogError(e.Message);
                throw e;
            }

        }

    }
}
