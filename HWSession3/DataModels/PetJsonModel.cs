/*
 * API Test Automation Training - Batch 4
 * Marilou A. Ranoy
 * 
 * Homework 3
 * RestApi Test using RestSharp and MSTest
 * Base URL: https://petstore.swagger.io/v2
 * Endpoint: /pet/{petId}
 * Create a test using GET request to pull up a pet of your choice {by ID} from the endpoint provided while making use of the following
 *  Façade Pattern
 *  AAA Pattern
 *  Object Assertion
 * Validate following Pet details
 *  Name
 *  PhotoUrls
 *  Tags
 *  Status
 * 
*/

using Newtonsoft.Json;

namespace HWSession3
{
    /// <summary>
    /// Class that defines our Pet model
    /// </summary>
    public partial class PetJsonModel
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("category")]
        public Category Category { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("photoUrls")]
        public string[] PhotoUrls { get; set; }

        [JsonProperty("tags")]
        public Category[] Tags { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }

    /// <summary>
    /// Class that defines our Category model
    /// </summary>
    public partial class Category
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
