using System.Data.Common;

namespace CleanArchitectureProject1.Application.IntegrationTests;
public interface ITestDatabase
{
    Task InitialiseAsync();

    DbConnection GetConnection();

    Task ResetAsync();

    Task DisposeAsync();
}
