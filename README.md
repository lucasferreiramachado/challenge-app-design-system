# ChallengeApp.DesignSystem

Biblioteca MAUI com controles, estilos, fontes e conversores reutilizáveis pelos módulos ChallengeApp.

## Estrutura

- `DesignSystem`: biblioteca publicada como `ChallengeApp.DesignSystem`.
- `DesignSystem.Tests`: testes unitários e cobertura.
- `Example`: aplicação MAUI mínima para validar o módulo.

## Desenvolvimento local no app host

Para desenvolvimento local, substitua o pacote por uma referência ao clone:

```xml
<ProjectReference Include="../challenge-app-design-system/DesignSystem/DesignSystem.csproj" />
```

Ou execute:

```bash
dotnet build -p:UseLocalModules=true
```

Sem essa propriedade, o consumo padrão deve ser feito pelo pacote do GitHub Packages.

## GitHub Packages

O pacote é publicado após alterações na branch `main`. Configure o feed localmente sem versionar credenciais:

```bash
dotnet nuget add source \
  "https://nuget.pkg.github.com/<ORGANIZATION>/index.json" \
  --name github \
  --username "<GITHUB_USER>" \
  --password "<TOKEN>"
```

## Comandos

```bash
dotnet restore DesignSystem.sln
dotnet build DesignSystem/DesignSystem.csproj --configuration Release --framework net10.0
dotnet test DesignSystem.Tests/DesignSystem.Tests.csproj --configuration Release --framework net10.0
dotnet pack DesignSystem/DesignSystem.csproj --configuration Release
```

Android e iOS são compilados sem assinatura na CI. Assinatura e publicação em lojas pertencem ao repositório host `ChallengeApp`.
