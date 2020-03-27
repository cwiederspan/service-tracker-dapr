using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using Dapr.Client;

using Quakes.Api.Models;

namespace Quakes.Api.Controllers {

    [ApiController]
    public class QuakesController : ControllerBase {

        private const string STORE_NAME = "quakes";
        
        private const string STORE_KEY_ALL = "all";

        [HttpGet("list")]
        public async Task<ActionResult<QuakeResponse>> GetQuakesAsync([FromServices] DaprClient stateClient) {
            
            var state = await stateClient.GetStateEntryAsync<Quake[]>(STORE_NAME, STORE_KEY_ALL);

            if (state.Value == null) {
                var quakes = await this.GetQuakesDataFromServiceAsync();
                state.Value = quakes;
                await state.SaveAsync();
            }

            return this.Ok(new QuakeResponse(state.Value));
        }

        private async Task<Quake[]> GetQuakesDataFromServiceAsync() {

            var quakes = new Quake[0];

            using (var client = new HttpClient()) {

                var url = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/4.5_month.geojson";

                var values = await client.GetStringAsync(url);

                var data = JsonSerializer.Deserialize<QuakeData>(values);

                quakes = data.features;
            }

            return quakes;
        }
    }
}