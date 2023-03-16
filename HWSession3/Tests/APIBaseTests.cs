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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System;

/// <summary>
/// Our base test which is inherited by our test class
/// In here, we can define reusable data and methods that can be used by our test classes
/// </summary>
public class APIBaseTests
{
	public RestClient RestClient { get; set; }
	public PetJsonModel PetDetails { get; set; }

    //test initialize method which is first called before any other methods
    [TestInitialize]
	public void Initialize()
    {
        RestClient = new RestClient();
    }

    //test cleanup method which is called before ending our test
    [TestCleanup]
    public void CleanUp()
    {

    }
}
