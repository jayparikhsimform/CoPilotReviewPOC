# Copilot Review POC

This proof of concept demonstrates how GitHub Copilot and GitHub Actions can be used to automate code reviews and improve code quality.

## Key Features
- GitHub Actions workflow with formatting, static analysis, test execution, and CodeQL security scans
- Simulated Copilot suggestions in PR summaries
- Sample .NET 8 Web API with intentionally poor practices for Copilot to catch
- Pull request template to guide human reviewers

## Setup
```bash
dotnet restore
dotnet build
dotnet run --project CopilotReviewPOC.API
```

Visit `https://localhost:5001/weatherforecast` to test the API.

## Simulated Enhancements
- Add real Copilot CLI or API when available
- Extend PR comments with Copilot suggestions via bots