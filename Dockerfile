# Usa a imagem oficial do SDK do .NET Core como imagem base
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Define o diret�rio de trabalho dentro do cont�iner para /app
WORKDIR /app

# Copia o arquivo do projeto (.csproj) para o cont�iner e restaura as depend�ncias
COPY *.csproj ./
RUN dotnet restore

# Copia o resto do c�digo da aplica��o para o cont�iner
COPY . .

# Compila a aplica��o com a configura��o de Release e publica os artefatos no diret�rio 'out'
RUN dotnet publish -c Release -o dist

# Inicia a constru��o da imagem de tempo de execu��o utilizando a imagem do ASP.NET Core
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

# Define o diret�rio de trabalho para /app na imagem de tempo de execu��o
WORKDIR /app

# Define a vari�vel de ambiente ASPNETCORE_URLS para que a aplica��o aceite tr�fego na porta 80 de todas as interfaces de rede
ENV ASPNETCORE_URLS=http://+:80

# Copia os artefatos publicados da etapa de constru��o para o diret�rio de trabalho na imagem de tempo de execu��o
COPY --from=build /app/dist ./

# Informa ao Docker que a aplica��o dentro do cont�iner estar� escutando na porta 80
EXPOSE 80

# Define o comando que ser� executado quando o cont�iner iniciar, que nesse caso, inicia a aplica��o .NET
ENTRYPOINT ["dotnet", "TodoListAPI.dll"]