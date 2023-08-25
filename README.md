## Тестовое задание - Web-приложение для управления списком покупок

Данный код выполнен в рамках обучения создания веб-приложений на платформе ASP.NET Core на языке C# с подключением базы данных PosrgreSQL.

##### Задача: 
- Среда разработки - Microsoft Visual Studio, язык - C#, база данных - Microsoft SQL Server, framework - ASP.NET Core MVC.
- Продукт содержит следующие поля: id, название, описание, цена. Информацию о продуктах хранить в базе данных с помощью Entity Framework.
- Раздел для управления продуктами. Доступ к разделу разрешать только авторизованному пользователю, логин и пароль которого прописан в конфигурационном файле.
- Для авторизации создать страницу логина.
- Страница со списком продуктов. В списке выводить id, название, цену и ссылку на страницу редактирования. Перед списком добавить ссылку для создания нового продукта.
- Страница создания / редактирования продукта.

##### Установка:
1) Клонируйте проект
2) Запустите Web App Shop V1.sln;
3) В решении проекта в файле appsettings.json перепишите данные соответтсвующие вашей базе данных «Host=localhost;Port=5432;Database=ShopNew1;Username=postgres;Password=<Ваш пароль>"

##### Как пользоваться:
1) После запуска в браузере откроется вкладка приложения, и если вы правильно подключили базу данных, то в базе создадутся 2 таблицы Product(хранит данные о продуктах), user(хранит данные о пользователях, притом первый пользователь это Admin имеющий доступ к функционалу создания, редактирования и удаления продуктов). Login: Polet, Password: 123321(можете изменить данные на свои в DAL.ApplicationDbContext);
![Стартовая страница]([URL](https://github.com/Poli-Max/WebAppShoppingList/blob/main/Web%20App%20Shop%20V1/Images/%D0%A1%D0%BD%D0%B8%D0%BC%D0%BE%D0%BA%20%D1%8D%D0%BA%D1%80%D0%B0%D0%BD%D0%B0%202023-08-25%20%D0%B2%2016.57.20.png))
2) Так же можно пройти регистрацию и авторизацию пользователей(пока функционал не реализован);
3) Чтобы создать продукты надо авторизоваться Admin-ом, перейти на вкладку каталог вам будет доступна функция создать продукт, заполните форму и отправьте, так же можно редактировать и удалять уже имеющиеся продукты. Обычные пользователи не имеют такого функционала;
4) Так же доступен фильтр по имени и диапазону цен.

##### Реализация:
1) Реализована луковичная архитектура;
2) реализована аутентификации c помощью куки (Cookie Authentication) в ASP.NET Core.
