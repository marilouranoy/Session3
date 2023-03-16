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

using HWSession3;
using RestSharp;
using System;

/// <summary>
/// Class where we can define our reusable test methods
/// </summary>
public class PetHelper
{
    /// <summary>
    /// Method for adding new pet using Post request
    /// </summary>
    /// <param name="client"></param>
    /// <returns></returns>
	public static async Task<PetJsonModel> AddNewPet(RestClient client)
    {
        var newPetData = GeneratePet.petData();
        var postRequest = new RestRequest(EndPoints.PostPet());

        postRequest.AddJsonBody(newPetData);
        var postResponse = await client.ExecutePostAsync<PetJsonModel>(postRequest);

        var createdPetData = newPetData;
        return createdPetData;
    }

    /// <summary>
    /// Method for getting pet data using Get request and with parameter Pet Id
    /// </summary>
    /// <param name="client"></param>
    /// <param name="petId"></param>
    /// <returns></returns>
    public static async Task<PetJsonModel> GetPetById(RestClient client, int petId)
    {
        var getRequest = new RestRequest(EndPoints.GetPetById(petId));
        var getResponse = await client.ExecutePostAsync<PetJsonModel>(getRequest);

        var retrievedPetData = getResponse.Data;
        return retrievedPetData;
    }
}
