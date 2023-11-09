:: --------------------------------------------
:: Start up the sass compiler
:: --------------------------------------------

@REM cd C:\xampp\htdocs\files\blog\src\blog\static\css
@REM sass --watch style.scss style.css


cd C:\xampp\htdocs\files\blog\src\gui\Blog\Blog.Gui\wwwroot\css

sass --watch custom/style.scss:dist/style.css

