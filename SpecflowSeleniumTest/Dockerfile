FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

ADD https://github.com/ufoscout/docker-compose-wait/releases/download/2.9.0/wait /wait
RUN chmod +x /wait

COPY ["SpecflowSeleniumTest/SpecflowSeleniumTest.csproj", "SpecflowSeleniumTest/"]
RUN dotnet restore "SpecflowSeleniumTest/SpecflowSeleniumTest.csproj"

COPY . .
WORKDIR "/src/SpecflowSeleniumTest"
RUN dotnet build
CMD /wait && dotnet test --no-build --logger trx
