﻿using System.Net.Http;
using Catharsium.Util.Web.Interfaces;
using RestSharp;

namespace Catharsium.Util.Web.Services
{
    public class RestService : IRestService
    {
        private readonly IRestClient client;


        public RestService(IRestClient client)
        {
            this.client = client;
        }


        public string PostToJsonService(string resource, object data)
        {
            var request = new RestRequest(resource, Method.POST);
            request.AddHeader("Content-type", "application/json");
            request.AddJsonBody(data);
            var response = this.client.Execute(request);
            if (!response.IsSuccessful) {
                throw new HttpRequestException($"Unsuccessful call to {resource}");
            }

            return response.Content;
        }


        public long PostToJsonServiceWithLongResponseType(string resource, object data)
        {
            return long.Parse(this.PostToJsonService(resource, data));
        }
    }
}