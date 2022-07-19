using Ardalis.HttpClientTestExtensions;
using KG_CleanArchitecture.Web;
using KG_CleanArchitecture.Web.Endpoints.ProjectEndpoints;
using Xunit;

namespace KG_CleanArchitecture.FunctionalTests.ApiEndpoints;

[Collection("Sequential")]
public class PhonebookList : IClassFixture<CustomWebApplicationFactory<WebMarker>>
{
  private readonly HttpClient _client;

  public PhonebookList(CustomWebApplicationFactory<WebMarker> factory)
  {
    _client = factory.CreateClient();
  }

  [Fact]
  public async Task ReturnsOneProject()
  {
    var result = await _client.GetAndDeserialize<PhonebookListResponse>("/Phonebook");

    Assert.Single(result.Phonebook);
    Assert.Contains(result.Phonebook, i => i.Name == SeedData.TestProject1.Name);
  }
}
