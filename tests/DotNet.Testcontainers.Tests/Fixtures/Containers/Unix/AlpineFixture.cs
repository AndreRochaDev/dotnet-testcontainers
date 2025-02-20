namespace DotNet.Testcontainers.Tests.Fixtures
{
  using System;
  using System.Threading.Tasks;
  using DotNet.Testcontainers.Builders;
  using DotNet.Testcontainers.Containers;
  using Xunit;

  public sealed class AlpineFixture : IAsyncLifetime
  {
    public ITestcontainersContainer Container { get; }
      = new TestcontainersBuilder<TestcontainersContainer>()
        .WithImage("alpine")
        .WithCommand(KeepTestcontainersUpAndRunning.Command)
        .WithStartupCallback((_, ct) => Task.Delay(TimeSpan.FromMinutes(1), ct))
        .Build();

    public Task InitializeAsync()
    {
      return Task.CompletedTask;
    }

    public Task DisposeAsync()
    {
      return this.Container.DisposeAsync().AsTask();
    }
  }
}
