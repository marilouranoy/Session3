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

using System;

/// <summary>
/// class for defining and initializing base URL and endpoints for the different methods (Post, Get, and Delete)
/// </summary>
public class EndPoints
{
    private static readonly string BaseURL = "https://petstore.swagger.io/v2";
    private static readonly string PetEndPoint = "pet";
    private static string GetURL(string endpoint) => $"{BaseURL}/{endpoint}";
    private static Uri GetURI(string endpoint) => new Uri(GetURL(endpoint));

    public static string GetPetById(long petId) => $"{BaseURL}/{PetEndPoint}/{petId}";

    public static string PostPet() => $"{BaseURL}/{PetEndPoint}";

    public static string DeletePetById(long petId) => $"{BaseURL}/{PetEndPoint}/{petId}";

}
