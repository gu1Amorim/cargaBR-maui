# CargaBR

Aplicativo móvel de gestão de frota para caminhoneiros autônomos e pequenas transportadoras, construído em **.NET MAUI**. Permite acompanhar caminhão, carretas, cargas disponíveis e fretes realizados, com autenticação e tema claro/escuro.

> Este projeto está em fase de **base técnica pronta**: toda a navegação, arquitetura, telas e camada de serviços estão implementadas e funcionais com dados fake (simulando delay de rede). A conexão com a API/banco de dados real ainda precisa ser implementada — veja a seção [Próximos passos](#próximos-passos-conectar-a-api-real).

## Stack técnica

- **.NET 10** / **.NET MAUI** (Android, iOS, MacCatalyst, Windows)
- **CommunityToolkit.Mvvm** — `ObservableObject`, `[ObservableProperty]`, `[RelayCommand]`
- **CommunityToolkit.Maui** — conversores e utilitários de UI
- **Shell** — navegação única (mesma estrutura em mobile e desktop, com `TabBar`)
- Compiled bindings (`x:DataType`) habilitado via `MauiXamlInflator=SourceGen`

## Estrutura do projeto

```
CargaBR/
├── App.xaml(.cs)              # Bootstrap da aplicação, aplica o tema salvo no startup
├── AppShell.xaml(.cs)         # Rotas: splash/login/register + TabBar (Início/Caminhão/Carga/Fretes/Perfil)
├── MauiProgram.cs             # Injeção de dependência, fontes, CommunityToolkit
│
├── Models/                    # Entidades de domínio (POCOs)
│   ├── Truck.cs, Trailer.cs, Load.cs, Freight.cs, User.cs
│   └── Enums/                 # TruckSize, LoadStatus, FreightStatus
│
├── Services/
│   ├── Api/                   # Interfaces de domínio (IAuthService, ITruckService, ILoadService, IFreightService)
│   │   └── Fake/              # Implementações fake (dados simulados com delay de rede)
│   ├── Theme/                 # IThemeService — troca e persiste o tema claro/escuro/sistema
│   └── ISubscriptionService.cs
│
├── ViewModels/                 # Um ViewModel por tela, usando CommunityToolkit.Mvvm
│   └── Auth/                   # LoginPageViewModel, RegisterPageViewModel
│
├── Views/                      # Páginas XAML
│   ├── Auth/                   # LoginPage, RegisterPage
│   ├── SplashPage.xaml          # Decide login vs. home ao abrir o app
│   ├── HomePage, TruckPage, LoadPage, FreightPage, SettingPage
│
├── Converters/                 # Conversores de valor usados nos bindings
└── Resources/
    ├── Styles/                 # Colors.xaml (paleta) e Styles.xaml (estilos reutilizáveis)
    ├── AppIcon/, Splash/        # Ícone e splash screen com a identidade visual do CargaBR
    └── Fonts/                   # Inclui Font Awesome (ícones da UI)
```

## Funcionalidades já implementadas

- **Autenticação (fake)**: Splash → Login/Cadastro → Home, com validação de formulário, estado de carregamento e mensagens de erro. Sessão persistida localmente (`Preferences`).
- **Navegação unificada**: um único `AppShell` com `TabBar` (Início, Caminhão, Carga, Fretes, Perfil), igual em qualquer plataforma.
- **Tema claro/escuro**: paleta própria com suporte total a `AppThemeBinding`; alternância manual (Claro/Escuro/Sistema) na tela de Perfil, persistida entre sessões.
- **Painel Início**: resumo de ganhos do mês e entregas, atalhos para Cargas e Caminhão.
- **Meu Caminhão**: dados do veículo, lista de carretas (`CollectionView`), cadastro de nova carreta.
- **Cargas Disponíveis**: lista de cargas (`CollectionView`) com aceite de carga.
- **Meus Transportes**: histórico de fretes realizados.
- **Perfil**: dados do usuário, assinatura, troca de tema, logout.

## Próximos passos: conectar a API real

Toda a camada de dados está isolada atrás de interfaces em `Services/Api/`, com implementações fake (pasta `Fake/`) registradas no `MauiProgram.cs`. Para plugar a API real:

1. Crie as implementações reais (ex.: `TruckApiService : ITruckService`) usando `HttpClient`.
2. Defina a URL base em `Services/Api/ApiSettings.cs` (`BaseUrl`).
3. No `MauiProgram.cs`, troque o registro `AddSingleton<ITruckService, FakeTruckService>()` por `AddHttpClient<ITruckService, TruckApiService>(c => c.BaseAddress = new Uri(ApiSettings.BaseUrl))` — o pacote `Microsoft.Extensions.Http` já está referenciado no `.csproj` para isso.
4. Repita para `IAuthService`, `ILoadService`, `IFreightService`.
5. Busque por `// TODO` no código — cada método fake tem um comentário indicando qual chamada HTTP real deveria substituí-lo.

Nenhuma tela ou ViewModel precisa mudar nesse processo — eles dependem apenas das interfaces.

## Como rodar

Requer **.NET 10 SDK** e os workloads MAUI (`android`, `ios`, `maccatalyst`, `maui-windows`) atualizados para a versão 10.

```powershell
# Restaurar dependências
dotnet restore

# Build para Windows
dotnet build CargaBR.csproj -f net10.0-windows10.0.19041.0

# Rodar no Windows
dotnet build CargaBR.csproj -f net10.0-windows10.0.19041.0 -t:Run

# Build para todas as plataformas configuradas
dotnet build CargaBR.csproj
```

Ou abra `CargaBR.slnx` no Visual Studio 2022 (17.14+) e rode direto pela IDE.
