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
using System;

/// <summary>
/// Our class for generating test data in our API tests
/// </summary>
public class GeneratePet
{
	public static PetJsonModel petData()
	{
        const string PHOTOURL = "https://www.rd.com/wp-content/uploads/2021/04/GettyImages-988013222-scaled-e1618857975729.jpg?w=1670";

        return new PetJsonModel
        {
            Id = 8,
            Category = new Category()
            {
                Id = 0,
                Name = "cat"
            },
            Name = "TestCat",
            PhotoUrls = PHOTOURL.Split(),
            Status = "available",
            Tags = new[]
            {
            new Category()
            {
                Id = 0,
                Name = "fur animals"
                },
                new Category()
                {
                    Id = 1,
                    Name = "cats"
                 },
            }
        };
	}
}
