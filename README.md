# Trabalho em Grupo

**Alunos:** Eduardo Klug e João Artur Ramos Belli

## Descrição

Foi criada uma API para gerar logs de todos os níveis: Debug, Information, Error, Warning, e Critical.

## Tecnologia Utilizada

O projeto foi desenvolvido utilizando **.NET Core 8**.

## Dependências

Para a geração de logs, foi utilizado o pacote NuGet **Serilog** em conjunto com o **DataDog**.

### Pacotes NuGet Necessários

```xml
<PackageReference Include="Serilog" Version="2.10.0" />
<PackageReference Include="Serilog.Sinks.Console" Version="4.1.0" />
<PackageReference Include="Serilog.Sinks.Datadog.Logs" Version="1.0.1" />
```

## Configuração

A chave de API do DataDog deve estar configurada no arquivo `appsettings.json` como uma variável de ambiente.

## Como Rodar o Projeto

Para rodar o projeto, siga os passos abaixo:

1. **Certifique-se de ter o Docker instalado e em funcionamento.**

2. **Compile e inicie o Dockerfile na pasta raiz do projeto usando os seguintes comandos:**

   ```bash
   # Navegue até a pasta raiz do projeto
   cd /caminho/para/o/projeto

   # Construa a imagem Docker
   docker build -t nome-da-imagem .

   # Execute o contêiner Docker
   docker run -d -p 5000:80 nome-da-imagem
   ```

## Links Úteis

- **[Vídeo Explicativo](https://youtu.be/n9dz-16Es08)** 
- **[Dashboard Datadog](https://p.datadoghq.com/sb/9159a714-5b4f-11ef-af2b-025c0c443a64-6f804b14d754b576af40fffe9d23ac63)**

