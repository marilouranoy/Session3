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

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RestSharp;
using System.Net;

namespace HWSession3
{
    /// <summary>
    /// This is where our test classes are defined
    /// It inherits our base class APIBaseTests
    /// </summary>
    [TestClass]
    public class RestClientTests : APIBaseTests
    {
        //define our cleanup list
        private static List<PetJsonModel> petCleanUpList = new List<PetJsonModel>();

        //test initialize method which also gets called after the main test initialize method in our base class
        [TestInitialize]
        public async Task TestInitialize()
        {
            PetDetails = await PetHelper.AddNewPet(RestClient);
        }

        //test clean up method where we clean up/delete the test data that we used in our Post request
        [TestCleanup]
        public async Task TestCleanUp()
        {
            foreach (var petData in petCleanUpList)
            {
                var deletePetRequest = new RestRequest(EndPoints.GetPetById(petData.Id));
                var deletePetResponse = await RestClient.DeleteAsync(deletePetRequest);
            }
        }

        //test method for Get pet request
        [TestMethod]
        public async Task TestGetPet()
        {
            //Arrange - we define and initialize data to use in our test method
            var getRequest = new RestRequest(EndPoints.GetPetById(PetDetails.Id));
            petCleanUpList.Add(PetDetails);

            //Act - we call the corresponding operation/method for our API test
            var restResponse = await RestClient.ExecuteGetAsync<PetJsonModel>(getRequest);

            //Assert - we check expected outputs to determine if our test passed or failed

            //Add an Assertion if status is 200 and if pet name, category, photo URLS, tags, and status are correctly reflected
            Assert.AreEqual(HttpStatusCode.OK, restResponse.StatusCode, "Status code is not equal to 200.");
            Assert.AreEqual(PetDetails.Name, restResponse.Data.Name, "Name did not match.");

            //in order to compare values, we need to serialize objects and convert them into JSON strings
            Assert.AreEqual(JsonConvert.SerializeObject(PetDetails.Category), JsonConvert.SerializeObject(restResponse.Data.Category), "Category did not match.");
            Assert.AreEqual(JsonConvert.SerializeObject(PetDetails.PhotoUrls), JsonConvert.SerializeObject(restResponse.Data.PhotoUrls), "Photo URL did not match.");
            Assert.AreEqual(JsonConvert.SerializeObject(PetDetails.Tags), JsonConvert.SerializeObject(restResponse.Data.Tags), "Tag did not match.");
            Assert.AreEqual(PetDetails.Status, restResponse.Data.Status, "Status did not match.");
        }
    }
}