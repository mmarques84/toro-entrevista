# Use a imagem base do .NET Framework 4.7.2
FROM mcr.microsoft.com/dotnet/framework/runtime:4.7.2-windowsservercore-ltsc2019

# Defina o diretório de trabalho no contêiner
WORKDIR /app

# Copie todos os arquivos do diretório atual para o diretório de trabalho no contêiner
COPY . /app

# Instale o RabbitMQ.Client e Newtonsoft.Json via NuGet
RUN powershell -Command \
    nuget install RabbitMQ.Client -Version 5.1.0 -OutputDirectory packages; \
    nuget install Newtonsoft.Json -Version 12.0.3 -OutputDirectory packages

# Defina o ponto de entrada para o aplicativo
ENTRYPOINT ["dotnet", "ConsoleApp.dll"]
