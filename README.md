# Typetorio

## Modi

- Classic (Highscore in fixed time) - How many words + points can you get in a fixed time frame? (1min, 3min, 5min, 10min).
  - main menu
  - dynamically start a game session
- No Typos - Lose health on typo - survive as long as possible + reach highscore.
- Survival - time always runs out. Type words and reach combos to enlengthen it. How long can you survive? How much score can you accumulate?

## Other features

- [x] bonus words - increase your combo by +5
  - rainbow colored word

## Tooling

### Code Analysis

We use the [dotnet inbuilt analysis mode](https://learn.microsoft.com/en-us/dotnet/core/project-sdk/msbuild-props#analysismode).

```xml
<!-- Inside .csproj -->
<AnalysisLevel>latest-Recommended</AnalysisLevel>
```

### Lint & Prettify

Setup

```sh
dotnet new tool-manifest
dotnet tool install csharpier
```

Prettify

```sh
dotnet csharpier .
```
