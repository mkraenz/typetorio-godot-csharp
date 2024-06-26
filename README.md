# Typetorio

## Modi

- [x] Classic (Highscore in fixed time) - How many words + points can you get in a fixed time frame?
  - [x] times
    - [x] 1min
  - [x] main menu
  - [x] dynamically start a game session
- [ ] No Typos - Lose health on typo - survive as long as possible + reach highscore.
- [x] Survival - time always runs out. Type words and reach combos to enlengthen it. How long can you survive? How much score can you accumulate?

## Other features

- [x] bonus words - increase your combo by +5
  - rainbow colored word
- [ ] highscore board
  - [x] classic
  - [ ] survival
    - [ ] max time survived?

## Releases

```sh
npm run bump:patch # or bump:minor or bump:major to increase version number
npm run deploy:prod
```

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

## Feature Deep Dive

### Hall of Fame

```cs
interface IRankingDto {
    string playerName;
    int score;
    int maxCombo;
    int wordsCleared;
}
```

Only keep highest scores, but allow sorting by maxCombo + wordsCleared.
Limit to 25 scores. (to keep storage needs low)

Pros: only one list instead of 3 (or whatever number of stats we're tracking)
Cons: Somebody games might be kicked out of the list even though they have a higher maxCombo/wordsCleared than others.
