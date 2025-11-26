@echo off
cd C:\xampp\htdocs\files\blog

git pull

cd C:\xampp\htdocs\files\blog\src\gui\Blog

dotnet clean

dotnet build

pause