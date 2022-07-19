using Ardalis.HttpClientTestExtensions;
using KG_CleanArchitecture.Web;
using KG_CleanArchitecture.Web.Endpoints.ProjectEndpoints;
using Xunit;

namespace KG_CleanArchitecture.FunctionalTests.ApiEndpoints;

[Collection("Sequential")]
public class PhonebookGetById : IClassFixture<CustomWebApplicationFactory<WebMarker>>
{
  private readonly HttpClient _client;

  public PhonebookGetById(CustomWebApplicationFactory<WebMarker> factory)
  {
    _client = factory.CreateClient();
  }

  [Fact]
  public async Task ReturnsSeedProjectGivenId1()
  {
    var result = await _client.GetAndDeserialize<GetPhonebookByIdResponse>(GetPhonebookByIdRequest.BuildRoute(1));

    Assert.Equal(1, result.Id);
    Assert.Equal(SeedData.TestProject1.Name, result.Name);
    Assert.Equal(3, result.Entries.Count);
  }

  [Fact]
  public async Task ReturnsNotFoundGivenId0()
  {
    string route = GetPhonebookByIdRequest.BuildRoute(0);
    _ = await _client.GetAndEnsureNotFound(route);
  }
}
