Представляю свой пет-проект онлайн магазина компьютерных игр. Сайт был сделан с душой, но по принципу: появилась идея – реализовал. Поэтому четкой структуры во фронте и бекенде нету, как и не все еще нравится по части визуальной составляющей сайта, но основной задуманный функционал реализован, а остальное буду доделывать со временем. Фронтенд реализован по большей части с помощью Bootstrap, но масштабируемость пока не реализована, поэтому сайт нормально отображается только на мониторах со стандартными разрешениями. Бекенд реализован почти целиком на ASP.NET MVC, но также ради практики в некоторых местах используются Razor Pages и Blazor-компонент. База данных используется Sqlite ввиду удобства публикации на гитхабе, хотя изначально была Microsoft SQL Server. Для работы с БД используется ORM Entity Framework Core. Для работы с классом пользователей используется ASP Identity.

Данные авторизации админа : Логин - admin@admin.com , Пароль - Admin123

Немного о концепции сайта:

- Т.к. магазин цифровых игр, то результатом покупки являются ключи, которые уникальны для каждой игры. В проекте они условно реализован в виде типа GUID и после покупки пользователь может найти их в личном кабинете. Для доставки таких товаров достаточно почты или телефона, поэтому я не стал реализовывать стандартный адрес для доставки. * результат заказа имеет модель словаря типа ключ-игра. Для преобразования данного типа в БД и обратно сделал собственный метод сериализации в строку и обратно.

- Для пользователей реализована простая система накопительных скидок : 1% скидки за 1000 р. покупок, вплоть до 15%.

- В личном кабинете отображаются данные пользователя, а также отдельная панель с кнопками, где можно посмотреть историю заказов и изменить данные. Если пользователь имеет роль админа, то отображается доп.кнопка которая переводит в админ. панель.

- На главной странице сайта создана карусель с играми, которые являются самыми «популярными» на сайте. Реализовал это популярность по количеству переходов на страницу конкретной игры.

- Корзина и избранное, после авторизации, в хедере имеют View-Component, которые отображают количество товаров, находящееся в них.

- Со страницы списка игр можно кликнув на карточку перейти на страницу игры, также есть кнопки «купить» - переводит с товаром в корзину и «добавить в корзину» - которая добавляет в корзину методом AJAX без обновления страницы.

- На странице конкретной игры реализованы модальные окна, хранящие скриншоты игры и ссылку на трейлер в ютубе

- Список избранного и поиск по сайту реализован на Razor pages. Также поиск по играм использует Blazor-компонент, который выводит результаты после каждого ввода символа в инпут и без обновления страницы.

Будто бы пока на этом все, но еще есть что изменить и буду дальше улучшать свой проект.

# GameStore

This is a GameStore project built with ASP.NET Core. The project includes user authentication and management, SQLite database, and a web-based interface for managing game store data.

## Dependencies

### Backend

This project uses the following NuGet packages:

- **Microsoft.AspNetCore.Components.Web** (Version 9.0.1)  
  For Blazor Web components and interactions.
  
- **Microsoft.AspNetCore.Identity.EntityFrameworkCore** (Version 9.0.1)  
  Provides integration of ASP.NET Core Identity with Entity Framework Core.

- **Microsoft.AspNetCore.Identity.UI** (Version 9.0.1)  
  Provides UI components and functionality for Identity in ASP.NET Core apps.

- **Microsoft.EntityFrameworkCore.Sqlite** (Version 9.0.1)  
  The SQLite database provider for Entity Framework Core.

- **Microsoft.EntityFrameworkCore.Tools** (Version 9.0.1)  
  Provides Entity Framework Core tools for commands like `Add-Migration` and `Update-Database`.

- **Microsoft.VisualStudio.Web.CodeGeneration.Design** (Version 9.0.0)  
  Provides scaffolding tools for ASP.NET Core projects, allowing easy code generation.

### Frontend

This project uses the following frontend libraries:

- **Bootstrap** (Version 5.3.0)  
  A popular CSS framework for creating responsive and modern web interfaces.  

- **jQuery** (Version 3.7.1)
A fast, small, and feature-rich JavaScript library that simplifies HTML document traversal, event handling, and animation.


