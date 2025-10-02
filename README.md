# Teste Técnico Kogui

### Desenvolvimento de aplicação mobile com .NET MAUI (Android / .NET 8)

Este projeto foi desenvolvido usando o Visual Studio a partir da proposta de teste técnico enviada.  
De forma geral, permitiu exercitar conceitos fundamentais de **C#**, **.NET MAUI** e **arquitetura de software** aplicados ao contexto de aplicações mobile.

---

## Objetivo

O objetivo do projeto é a construção de uma aplicação com interface gráfica dividida em três seções principais:

1. **Lista inicial**  
   Apresentação de uma lista de cores pré-definidas e seus respectivos componentes.

2. **Cards buscados na API**  
   Exibição de uma sequência de *cards* representando cores obtidas através da integração com a [The Color API](https://www.thecolorapi.com/).

3. **Matriz oculta**  
   Representação de uma figura escondida em uma matriz, com a exibição de seu nome correspondente.

---

## Protótipo de Interface

Para guiar a produção da interface em XAML, foi criado previamente um protótipo no **Figma**, onde foram exploradas ideias de layout e combinação de cores sugeridas no enunciado do teste.  
<img width="989" height="599" alt="image" src="https://github.com/user-attachments/assets/bd40f4bf-a5fe-40d0-bcc9-19a25c50e4b1" />

Link para o protótipo:  
[KoguiApp](https://www.figma.com/proto/ma71HgJPr08EItZ1Dp1i9L/KoguiApp?node-id=0-1&t=6fgjSg56FoMgFd2P-1)

---

## Estrutura do Projeto

O desenvolvimento iniciou com a implementação da classe principal **`ChaveCor`**, a partir da qual toda a lógica foi organizada.  

A construção seguiu princípios de **separação de camadas**:

- **Modelos (`Models`)**  
  Classes responsáveis por estruturar os dados, como `ChaveCor`, `ColorInfo` etc.

- **Serviços (`Services`)**  
  Responsáveis pela comunicação com a API externa, encapsulando chamadas HTTP e processamento de respostas.

- **ViewModels (`ViewModels`)**  
  Intermediários entre a interface (View) e os modelos. Implementam o padrão **MVVM**, garantindo *bindings* reativos com a UI.

- **Interface (`Views` / XAML)**  
  Definição da camada de apresentação, layouts e estilos.

---

## Principais Conhecimentos Aplicados

Durante a construção do projeto, os seguintes conceitos e práticas foram exercitados:

- **Lógica de Programação**  
- **Fundamentos de C# e .NET MAUI**  
- **Padrão de Arquitetura MVVM (Model–View–ViewModel)**  
- **Consumo de APIs REST 
- **Noções de Injeção de Dependências (Dependency Injection)**  
- **Boas práticas de versionamento de código com Git e GitHub**  

---

## Execução do Projeto

Para clonar e executar o projeto:

```bash
git clone <URL_DO_REPOSITORIO>
cd AplicativoTesteTecnicoKogui

# Restaurar dependências
dotnet restore

# Rodar aplicação (Android em .NET 8 / MAUI)
dotnet build
