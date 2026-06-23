# GiaPha Backend

ASP.NET Web API scaffold for the future GiaPha OS backend.

## Current shape

- Solution: `GiaPha.Backend.sln`
- API project: `GiaPha.Api`
- Framework: .NET 9
- First endpoint: `GET /api/health`

## Local run

```bash
dotnet run --project backend/GiaPha.Api/GiaPha.Api.csproj
```

## Authentication direction

The planned model is Google sign-in plus an application allowlist:

1. User signs in with Google.
2. Backend validates the Google identity token or OAuth cookie.
3. Backend checks the normalized email against `AuthAccess:AllowedEmails`.
4. Only allowlisted emails receive app access.

This is a good fit for a family/private deployment. Keep the allowlist outside
source control in production by using environment variables, a database table,
or a secret manager.
