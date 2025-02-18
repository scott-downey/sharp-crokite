﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Windows;

namespace SharpCrokite.Core.PriceUpdater.FuzzworkPriceRetrieval
{
    public class FuzzworkPriceRetrievalService : IPriceRetrievalService
    {
        private const string BaseUrl = "https://market.fuzzwork.co.uk/aggregates/";

        private readonly Dictionary<int, string> systemsToGetPricesFor = new() // TODO: pull up
        {
            { 30000142, "Jita" }
        };

        public IEnumerable<PriceDto> Retrieve(IList<int> allTypeIds)
        {
            List<PriceDto> priceDtos = new();

            foreach (int systemId in systemsToGetPricesFor.Keys)
            {
                Dictionary<string, FuzzworkPricesJson> pricesPerItemForSystem = RetrievePricesAsJson(BuildUrl(allTypeIds, systemId));

                priceDtos.AddRange(MapJsonToPriceDto(pricesPerItemForSystem, systemId));
            }

            return priceDtos;
        }

        private static Dictionary<string, FuzzworkPricesJson> RetrievePricesAsJson(string url)
        {
            Dictionary<string, FuzzworkPricesJson> priceJson = new();

            using HttpClient client = new();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                string responseString = response.Content.ReadAsStringAsync().Result;

                return JsonSerializer.Deserialize<Dictionary<string, FuzzworkPricesJson>>(responseString);
            }

            _ = MessageBox.Show($"Something went wrong while calling Fuzzwork API:\n{url}");

            return priceJson;
        }

        private static string BuildUrl(IEnumerable<int> allTypeIds, int systemId)
        {
            StringBuilder stringBuilder = new();

            _ = stringBuilder.Append($"{BaseUrl}?region={systemId}&types=");

            foreach (int typeId in allTypeIds)
            {
                _ = stringBuilder.Append($"{typeId},");
            }

            return stringBuilder.ToString();
        }

        private static IEnumerable<PriceDto> MapJsonToPriceDto(Dictionary<string, FuzzworkPricesJson> pricesAsJson, int systemKey)
        {
            List<PriceDto> priceDtos = new();

            foreach ((string key, FuzzworkPricesJson value) in pricesAsJson)
            {
                priceDtos.Add(new PriceDto
                {
                    TypeId = Convert.ToInt32(key),
                    SystemId = systemKey,
                    BuyMax = Convert.ToDecimal(value.buy.max),
                    BuyMin = Convert.ToDecimal(value.buy.min),
                    BuyPercentile = Convert.ToDecimal(value.buy.percentile),
                    SellMax = Convert.ToDecimal(value.sell.max),
                    SellMin = Convert.ToDecimal(value.sell.min),
                    SellPercentile = Convert.ToDecimal(value.sell.percentile)
                });
            }
            return priceDtos;
        }
    }
}