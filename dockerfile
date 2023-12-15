# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Copiar archivos y restore
COPY ./*.sln ./
COPY ./EmployeesOps/*.csproj ./EmployeesOps/
COPY ./EmployeesOps.BLL/*.csproj ./EmployeesOps.BLL/
COPY ./EmployeesOps.DAL/*.csproj ./EmployeesOps.DAL/
RUN dotnet restore

# Copiar el resto de los archivos y compilar la aplicación
COPY . .
RUN dotnet build -c Release -o /app

# Stage 2: Publish
FROM build AS publish
WORKDIR /src/EmployeesOps
RUN dotnet publish -c Release -o /app

# Stage 3: Final Image
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS final
WORKDIR /app
COPY --from=publish /app .

# Entrypoint para la aplicación
ENTRYPOINT ["dotnet", "EmployeesOps.dll"]

# comands:
# docker build -t <nombre_image> .
# docker run -p <puerto_donde_correra>:<80 || 8080> <nombre_image>