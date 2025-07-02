dotnet new sln
dotnet new classlib -o CheckoutService -f net9.0
dotnet new xunit -o CheckoutService.Tests -f net9.0

dotnet sln add CheckoutService/CheckoutService.csproj
dotnet sln add CheckoutService.Tests/CheckoutService.Tests.csproj

dotnet add CheckoutService.Tests/CheckoutService.Tests.csproj reference CheckoutService/CheckoutService.csproj

dotnet add package StyleCop.Analyzers