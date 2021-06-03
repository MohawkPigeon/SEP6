#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat 

FROM mcr.microsoft.com/dotnet/framework/aspnet:4.8-windowsservercore-ltsc2019
ARG source
WORKDIR /inetpub/wwwroot
COPY ${source:-obj/Docker/publish} .


#FROM microsoft/dotnet-framework:4.7.2-sdk-windowsservercore-1803 AS build
#WORKDIR /app
#COPY . ./
#RUN dotnet restore
#COPY . ./
#RUN dotnet publish -c Release -o out
#FROM microsoft/aspnet:4.7.2-windowsservercore-1803 AS runtime
#WORKDIR /app
#COPY --from=build /app/out .
#ENTRYPOINT ["dotnet", "SEP6Film.dll"]