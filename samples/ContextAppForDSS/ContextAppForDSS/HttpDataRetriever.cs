﻿using ContextualDataIngestor;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ContextualDataIngestor
{
    internal class HttpDataRetriever : IDataRetriever
    {
        private readonly HttpClient _httpClient;
        private readonly IAuthenticator _authenticator;
        private bool _disposed = false;
        public HttpDataRetriever(HttpClient httpClient, IAuthenticator authenticator)
        {
            _httpClient = httpClient;
            _authenticator = authenticator;
        }

        /*
        // The output will look something like this:
        country: uk
        viscosity: 0.51
        sweetness: 0.81
        particle_size: 0.71

        country: uk
        viscosity: 0.52
        sweetness: 0.82
        particle_size: 0.72
        */
        public async Task<string> RetrieveDataAsync(UserConfig userConfig)
        {
            _authenticator.ApplyAuthentication(_httpClient);
            // Implement HTTP data retrieval logic
            var response = await _httpClient.GetAsync(userConfig.Endpoint);
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();

                List<string> formattedRecords = new List<string>();

                using (JsonDocument document = JsonDocument.Parse(responseBody))
                {
                    JsonElement root = document.RootElement;

                    foreach (JsonElement record in root.EnumerateArray())
                    {
                        string formattedRecord = FormatRecord(record);
                        formattedRecords.Add(formattedRecord);
                    }
                }

                // Join all formatted records with double newlines
                return string.Join("\n\n", formattedRecords);
            }
            else
            {
                throw new HttpRequestException($"Request to {userConfig.ConnectionStringOrBaseUrl} failed with status code {response.StatusCode}");
            }
        }

        static string FormatRecord(JsonElement record)
        {
            return string.Join("\n",
                record.EnumerateObject()
                    .Take(4)  // Limit to 4 properties as per requirement
                    .Select(prop => $"{prop.Name}: {FormatValue(prop.Value)}"));
        }

        static string FormatValue(JsonElement value)
        {
            return value.ValueKind switch
            {
                JsonValueKind.String => value.GetString() ?? string.Empty, // Provide a default value
                JsonValueKind.Number => value.GetDouble().ToString(),
                _ => value.ToString()
            };
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // Dispose managed resources
                    _httpClient?.Dispose();
                }

                // Set large fields to null
                _disposed = true;
            }
        }

        // Destructor
        ~HttpDataRetriever()
        {
            Dispose(false);
        }
    }
}