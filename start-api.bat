@echo off
cd ../BookCatalog/BookCatalog.WebAPI
dotnet restore
dotnet build
dotnet run