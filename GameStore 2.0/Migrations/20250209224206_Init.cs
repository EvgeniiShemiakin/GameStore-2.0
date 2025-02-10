using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameStore_2._0.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    BuySum = table.Column<decimal>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    ClickCount = table.Column<int>(type: "INTEGER", nullable: false),
                    Genres = table.Column<string>(type: "TEXT", nullable: true),
                    CrslImg = table.Column<string>(type: "TEXT", nullable: true),
                    CoverImg = table.Column<string>(type: "TEXT", nullable: true),
                    Scr_Thumb = table.Column<string>(type: "TEXT", nullable: true),
                    Trailer = table.Column<string>(type: "TEXT", nullable: true),
                    Trailer_Thumb = table.Column<string>(type: "TEXT", nullable: true),
                    ScreenImg = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Phone = table.Column<string>(type: "TEXT", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ActivationKeys = table.Column<string>(type: "TEXT", nullable: false),
                    OrderCost = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Wishlists",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wishlists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wishlists_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartPositions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    GameId = table.Column<int>(type: "INTEGER", nullable: false),
                    Amount = table.Column<int>(type: "INTEGER", nullable: false),
                    CartId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartPositions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartPositions_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartPositions_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderPositions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    GameId = table.Column<int>(type: "INTEGER", nullable: false),
                    Amount = table.Column<int>(type: "INTEGER", nullable: false),
                    OrderId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderPositions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderPositions_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderPositions_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WishlistGames",
                columns: table => new
                {
                    WishlistId = table.Column<Guid>(type: "TEXT", nullable: false),
                    GameId = table.Column<int>(type: "INTEGER", nullable: false),
                    DateAdded = table.Column<DateOnly>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishlistGames", x => new { x.WishlistId, x.GameId });
                    table.ForeignKey(
                        name: "FK_WishlistGames_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WishlistGames_Wishlists_WishlistId",
                        column: x => x.WishlistId,
                        principalTable: "Wishlists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "ClickCount", "CoverImg", "CrslImg", "Description", "Genres", "Price", "Scr_Thumb", "ScreenImg", "Title", "Trailer", "Trailer_Thumb" },
                values: new object[,]
                {
                    { 1, 0, "/images/bg3/cover.jpg", "/images/bg3/crsl.jpg", "Baldur's Gate 3 — это захватывающая ролевая игра от Larian Studios, вдохновлённая классическими системами Dungeons & Dragons. Действие разворачивается в легендарном мире Forgotten Realms, где вам предстоит возглавить уникальную группу героев и принять участие в эпической борьбе, затрагивающей судьбы всего Фаэруна.  \r\n\r\nСюжет начинается с похищения вашего героя иллитидом, который заражает его смертельно опасной личинкой. Ваша цель — найти способ остановить превращение и сохранить человечность, сталкиваясь с древними магиями, могущественными врагами и сложными моральными дилеммами.  \r\n\r\nBaldur's Gate 3 предлагает богатый открытый мир, где каждое ваше действие имеет значение. Вас ждут глубокие диалоги, сложные тактические сражения, использование правил D&D 5-й редакции и полная свобода в исследованиях. Уникальные спутники с собственными историями и мотивацией будут сопровождать вас в этом путешествии, а ваша связь с ними станет важной частью приключения.  \r\n\r\nСоздайте собственного героя, выбирая из множества рас и классов, или начните игру за одного из проработанных персонажей. Проходите сюжет в одиночку или с друзьями в кооперативном режиме до четырёх игроков. Взаимодействуйте с миром и его жителями так, как пожелаете, и откройте неожиданные тайны.  \r\n\r\nЭто история о судьбе, магии и выборе. Сможете ли вы спасти себя и мир, или погрузитесь в хаос и разрушение? Ваши решения определят всё.", "[1]", 2000m, "/images/bg3/scr_thumb.jpg", "[\"/images/bg3/scr1.jpg\",\"/images/bg3/scr2.jpg\",\"/images/bg3/scr3.jpg\"]", "Baldur's Gate 3", "https://www.youtube.com/embed/1T22wNvoNiU?si=UyFarE5lI2JIhGDf", "https://img.youtube.com/vi/1T22wNvoNiU/sddefault.jpg" },
                    { 2, 0, "/images/cyberpunk/cover.jpg", "/images/cyberpunk/crsl1.jpg", "Cyberpunk 2077 — это захватывающая ролевая игра в жанре научной фантастики от CD Projekt Red. Действие игры разворачивается в мрачном и высокотехнологичном мире Найт-Сити, где корпорации правят, технологии диктуют жизнь, а опасности подстерегают на каждом шагу.  \r\n\r\nВы играете за Ви — наёмника, который стремится обрести бессмертие, став обладателем уникального биочипа. Ваша история — это путь в мир, полный интриг, насилия и моральных выборов. Сюжет развивается в зависимости от вашего стиля игры и решений, которые вы принимаете, открывая множество альтернативных концовок.  \r\n\r\nИгра предлагает впечатляющий уровень детализации: от ярких улиц Найт-Сити, наполненных неоном и хаосом, до глубоко проработанных персонажей. Вы можете выбрать происхождение героя, кастомизировать внешность, развивать навыки и адаптировать стиль игры под себя.  \r\n\r\nСражайтесь с корпорациями, исследуйте мрачные тайны города, занимайтесь взломом систем, улучшайте своё тело с помощью имплантов и создавайте свою легенду. В открытом мире вас ждут динамичные перестрелки, погружение в мрачные истории и разнообразные активности, от гонок до выполнения сложных миссий.  \r\n\r\nCyberpunk 2077 — это не просто игра, а целая вселенная, где технологии стирают границы возможного, а ваш выбор влияет на всё. Готовы ли вы погрузиться в будущее, где мечты сбываются, а за ними стоит высокая цена?", "[1,2]", 2000m, "/images/cyberpunk/scr_thumb.jpg", "[\"/images/cyberpunk/scr1.jpg\",\"/images/cyberpunk/scr2.jpg\",\"/images/cyberpunk/scr3.jpg\"]", "Cyberpunk 2077", "https://www.youtube.com/embed/8X2kIfS6fb8?si=jGCvw1k4EpEScSJq", "https://img.youtube.com/vi/8X2kIfS6fb8/sddefault.jpg" },
                    { 3, 0, "/images/disco/cover.jpg", "/images/disco/crsl.jpg", "Disco Elysium — уникальная ролевая игра, созданная студией ZA/UM, которая сочетает в себе глубокую историю, необычную механику и художественный стиль. Действие происходит в мрачном городке Ревашоль, где вас ждёт мир, полный социальных конфликтов, политических интриг и личных трагедий.  \r\n\r\nВы берёте на себя роль детектива, который начинает расследование загадочного убийства. Однако есть одна проблема: ваш герой страдает от амнезии и алкоголизма, что делает каждый шаг на пути к истине непростым. Вас ждёт исследование не только места преступления, но и внутреннего мира вашего персонажа.  \r\n\r\nDisco Elysium предлагает невероятно проработанную систему диалогов, где вы можете взаимодействовать не только с другими персонажами, но и с различными сторонами своей личности. Каждое ваше решение и каждая реплика формируют уникальный путь и открывают новые возможности.  \r\n\r\nМир игры богат деталями: множество персонажей с уникальными историями, политические идеологии, которые вы можете поддерживать или отвергать, и запутанные моральные дилеммы. Всё это подчёркнуто атмосферным саундтреком и великолепным визуальным стилем.  \r\n\r\nЭто игра о сложных вопросах, личных сражениях и поиске смысла в хаосе. Какой детектив вы станете — принципиальным профессионалом, отчаянным циником или мечтателем, потерявшимся в философских раздумьях? Выбор за вами.", "[1]", 1000m, "/images/disco/scr_thumb.jpg", "[\"/images/disco/scr1.jpg\",\"/images/disco/scr2.jpg\",\"/images/disco/scr3.jpg\"]", "Disco Elysium", "https://www.youtube.com/embed/P-UY6IyI03Q?si=S6Y9JAImFebvi5Jc", "https://img.youtube.com/vi/P-UY6IyI03Q/sddefault.jpg" },
                    { 4, 0, "/images/fallout4/cover.jpg", "/images/fallout4/crsl1.jpg", "Fallout 4 — культовая ролевая игра от Bethesda Game Studios, действие которой разворачивается в постапокалиптическом мире, разрушенном ядерной войной. Игра переносит вас в разорённые земли Содружества, где каждое решение влияет на ваше выживание и судьбу окружающего мира.  \r\n\r\nВы играете за жителя Убежища 111, который выходит на поверхность спустя 200 лет после ядерного апокалипсиса, чтобы найти своего похищенного сына. Мир полон опасностей: от мутантов и рейдеров до загадочных институтов и фракций, каждая из которых имеет свои цели и взгляды на восстановление цивилизации.  \r\n\r\nFallout 4 предлагает огромный открытый мир с бесчисленными возможностями для исследования. Вы можете строить свои поселения, модифицировать оружие и броню, взаимодействовать с местными фракциями и находить неожиданные сюжеты за каждым углом.  \r\n\r\nСистема S.P.E.C.I.A.L. позволяет кастомизировать персонажа, определяя его способности и стиль игры. Вас ждут напряжённые сражения, глубокие диалоги и сложные моральные выборы, которые определяют, каким будет будущее Содружества.  \r\n\r\nFallout 4 — это история о выживании, утрате и надежде. Как выстроить новую жизнь среди руин старого мира? Это зависит только от вас.", "[1,2]", 800m, "/images/fallout4/scr_thumb.jpg", "[\"/images/fallout4/scr1.jpg\",\"/images/fallout4/scr2.jpg\",\"/images/fallout4/scr3.jpg\"]", "Fallout 4", "https://www.youtube.com/embed/X5aJfebzkrM?si=lMdWkj0k_R61Rsos", "https://img.youtube.com/vi/X5aJfebzkrM/sddefault.jpg" },
                    { 5, 0, "/images/forza/cover.jpg", "/images/forza/crsl1.jpg", "Forza Horizon 5 — великолепная гоночная игра от Playground Games, которая предлагает игрокам отправиться в живописный и детально проработанный открытый мир, вдохновлённый разнообразными пейзажами Мексики. Это самая масштабная и визуально впечатляющая часть в серии, сочетающая реалистичную физику с элементами аркадного веселья.  \r\n\r\nВас ждёт более 500 автомобилей, каждый из которых можно настроить под свой стиль вождения. От культовых спортивных машин до внедорожников и экзотических суперкаров — Forza Horizon 5 предлагает что-то для каждого. Разнообразие гонок включает в себя уличные заезды, ралли и экстремальные трюки.  \r\n\r\nИгровой мир удивляет своей красотой и масштабом: от пустынь и джунглей до вулканов и исторических городов. Благодаря смене времён года каждая гонка выглядит уникально, а динамическая погода создаёт неожиданные вызовы.  \r\n\r\nИгра наполнена активностями и событиями, от сетевых соревнований с друзьями до одиночных испытаний и эпичных фестивалей. Кампания позволяет вам стать легендой Horizon, участвуя в крупнейшем автомобильном шоу мира.  \r\n\r\nForza Horizon 5 — это идеальное сочетание скорости, свободы и красоты. Откройте для себя мир без границ, где каждая гонка — это новое приключение.", "[3]", 2000m, "/images/forza/scr_thumb.jpg", "[\"/images/forza/scr1.jpg\",\"/images/forza/scr2.jpg\",\"/images/forza/scr3.jpg\"]", "Forza Horizon 5", "https://www.youtube.com/embed/FYH9n37B7Yw?si=oF7rOSpHwHPiH5oN", "https://img.youtube.com/vi/FYH9n37B7Yw/sddefault.jpg" },
                    { 6, 0, "/images/poe2/cover.jpg", "/images/poe2/crsl.jpg", "Path of Exile 2 — это продолжение легендарной action-RPG от Grinding Gear Games, которое обещает ещё больше глубины, вызовов и разнообразия. Игра сохраняет мрачный тон оригинала, расширяя его новыми механиками и историями, которые разворачиваются спустя 20 лет после событий первой части.  \r\n\r\nPath of Exile 2 предлагает полностью переработанную кампанию из семи актов, которая идёт параллельно с оригинальной сюжетной линией. Игроки могут исследовать новый мир, где враги стали ещё умнее, а битвы — более динамичными. Визуальные эффекты и анимации значительно улучшены, что делает каждую способность зрелищной и мощной.  \r\n\r\nГлавная особенность — новая система пассивных умений и улучшенные драгоценные камни навыков. Теперь гнёзда напрямую связаны с экипировкой, что открывает ещё больше возможностей для уникальных билдов. Игроки смогут экспериментировать с 19 новыми архетипами классов, сохраняя доступ к старым вариантам из оригинальной игры.  \r\n\r\nPath of Exile 2 сохраняет ключевые аспекты серии: сложность, огромное древо навыков, масштабные эндгейм-события и постоянное развитие. Игра остаётся бесплатной, предлагая тонны контента без необходимости платить за победу.  \r\n\r\nЭто идеальное продолжение для преданных фанатов и отличная точка входа для новых игроков, желающих испытать мрачный и богатый мир Path of Exile.", "[1]", 500m, "/images/poe2/scr_thumb.jpg", "[\"/images/poe2/scr1.jpg\",\"/images/poe2/scr2.jpg\",\"/images/poe2/scr3.jpg\"]", "Path of Exile 2", "https://www.youtube.com/embed/QpbGfihd0_Q?si=qIOOoGKMSF-gnlgT", "https://img.youtube.com/vi/QpbGfihd0_Q/sddefault.jpg" },
                    { 7, 0, "/images/silenthill/cover.jpg", "/images/silenthill/crsl1.jpg", "Silent Hill 2 Remake — переосмысленная версия культовой психологической хоррор-игры от Bloober Team и Konami, которая переносит классическую историю в современную графическую и технологическую эпоху. Эта игра возвращает игроков в зловещий город Сайлент Хилл, где кошмары оживают, а грань между реальностью и иллюзией стирается.  \r\n\r\nВ центре сюжета — Джеймс Сандерленд, получивший письмо от своей покойной жены Мэри, которая зовёт его в Сайлент Хилл. Погрузившись в город, он сталкивается с искалеченными монстрами, загадочными персонажами и туманной атмосферой, которая становится отражением его подавленных чувств и тёмных тайн.  \r\n\r\nRemake обновляет оригинал, используя мощь Unreal Engine 5, чтобы передать мельчайшие детали города, устрашающих существ и эмоции персонажей. В игре полностью переработаны модели, анимации и освещение, что усиливает атмосферу страха и безысходности.  \r\n\r\nРазработчики добавили современные элементы управления, улучшили боевую систему и адаптировали звуковое сопровождение под новые технологии. Музыка от Акиры Ямаоки и обновлённая озвучка персонажей усиливают эмоциональную вовлечённость.  \r\n\r\nSilent Hill 2 Remake сохраняет дух оригинала, но предлагает свежий взгляд на один из величайших хорроров в истории. Эта игра приглашает как давних фанатов, так и новых игроков погрузиться в пугающий и незабываемый опыт путешествия в глубины человеческого сознания.", "[5]", 2000m, "/images/silenthill/scr_thumb.jpg", "[\"/images/silenthill/scr1.jpg\",\"/images/silenthill/scr2.jpg\",\"/images/silenthill/scr3.jpg\"]", "Silent Hill 2", "https://www.youtube.com/embed/pyC_qiW_4ZY?si=CLiHsguU7kyPF-ch", "https://img.youtube.com/vi/pyC_qiW_4ZY/sddefault.jpg" },
                    { 8, 0, "/images/starfield/cover.jpg", "/images/starfield/crsl1.jpg", "Starfield — это долгожданная RPG от Bethesda Game Studios, предлагающая игрокам исследовать бескрайние просторы космоса. Это первая новая игровая вселенная студии за последние 25 лет, сочетающая в себе масштаб и детализацию, которыми славятся их проекты, с уникальной атмосферой космических приключений.  \r\n\r\nСюжет разворачивается в 2330 году, когда человечество колонизировало множество планет и звёздных систем. Вы становитесь членом \"Созвездия\" — организации исследователей, которая занимается поиском ответов на самые глубокие загадки вселенной. Игроки смогут свободно перемещаться по тысячам планет, обживать далекие уголки галактики и взаимодействовать с многочисленными фракциями, каждая из которых имеет свои цели и ценности.  \r\n\r\nИгра предлагает глубоко проработанную систему кастомизации персонажа и корабля. Вы можете не только настроить внешность и навыки своего героя, но и построить уникальный звездолёт, подходящий под ваш стиль игры — от дипломатического исследователя до опасного космического пирата.  \r\n\r\nБоевая система включает перестрелки в космосе и на планетах, а также схватки на ближних дистанциях. Важным элементом игры являются исследования: на планетах вы можете собирать ресурсы, строить базы и разгадывать таинственные артефакты, которые влияют на ход всей истории.  \r\n\r\nStarfield — это беспрецедентный по масштабам и возможностям проект, который переносит классические механики Bethesda в совершенно новый космический антураж. Игра предлагает богатый сюжет, захватывающие приключения и свободу, о которой мечтают поклонники научной фантастики.", "[1,2]", 3000m, "/images/starfield/scr_thumb.jpg", "[\"/images/starfield/scr1.jpg\",\"/images/starfield/scr2.jpg\",\"/images/starfield/scr3.jpg\"]", "Starfield", "https://www.youtube.com/embed/Ek3I6_9c58E?si=2rbnk7_NtQbFTIcC", "https://img.youtube.com/vi/Ek3I6_9c58E/sddefault.jpg" },
                    { 9, 0, "/images/tekken8/cover.jpg", "/images/tekken8/crsl.jpg", "Tekken 8 — это последняя часть легендарной серии файтингов от Bandai Namco, продолжение знаменитой истории о борьбе между участниками жестокого турнира и их судьбах, переплетенных с темными семейными тайнами. В Tekken 8 игроков ожидает еще больше динамичных боев, улучшенная графика, новые персонажи и возвращение знакомых бойцов.\r\n\r\nИгровой процесс сохранил традиционное для Tekken сочетание стратегии и экшен-элементов, с возможностью комбинировать различные удары, защитные маневры и специальные приемы. В новом издании особое внимание уделено зрелищным финальным атакам, а также обновленному балансу персонажей.\r\n\r\nСреди нововведений — улучшенная система AI, которая делает противников умнее и непредсказуемее, и различные режимы игры, включая как одиночные кампании, так и многопользовательские бои. Каждый бой в Tekken 8 — это уникальный опыт, где решается не только мастерство, но и личная сила воли.\r\n\r\nTekken 8 продолжает традиции серии, предлагая фанатам как новые возможности для самовыражения, так и более глубокие механики для опытных игроков, желающих освоить каждый уголок игры.", "[4]", 2000m, "/images/tekken8/scr_thumb.jpg", "[\"/images/tekken8/scr1.jpg\",\"/images/tekken8/scr2.jpg\",\"/images/tekken8/scr3.jpg\"]", "Tekken 8", "https://www.youtube.com/embed/_MM4clV2qjE?si=iPeLufVnaC6LaQ9j", "https://img.youtube.com/vi/_MM4clV2qjE/sddefault.jpg" },
                    { 10, 0, "/images/warthunder/cover.jpg", "/images/warthunder/crsl1.jpg", "War Thunder — это многопользовательская военная онлайн-игра, которая предлагает игрокам участвовать в эпичных битвах с использованием разнообразной техники, включая авиацию, бронетехнику и корабли, в сражениях различных исторических эпох. Игра объединяет реализм и динамичный игровой процесс, предоставляя широкие возможности для стратегического планирования и боевых действий.\r\n\r\nВ War Thunder игроки могут погружаться в крупномасштабные сражения на различных фронтах Второй мировой войны, а также в более современные конфликты, управляя как исторической техникой, так и современными боевыми машинами. Игра предлагает разнообразные режимы, от аркадных боев до более реалистичных и симуляционных матчей.\r\n\r\nСистема прогрессии позволяет игрокам улучшать свою технику, открывая новые модули, оружие и улучшения, что даёт возможность адаптироваться к различным стилям игры. Разнообразие карт, техники и режимов создают уникальную атмосферу и делают каждую битву неповторимой.\r\n\r\nWar Thunder продолжает развиваться, предлагая новые обновления с техникой и картами, что делает её одной из самых популярных и масштабных военных онлайн-игр в мире.", "[2]", 5000m, "/images/warthunder/scr_thumb.jpg", "[\"/images/warthunder/scr1.jpg\",\"/images/warthunder/scr2.jpg\",\"/images/warthunder/scr3.jpg\"]", "War Thunder", "https://www.youtube.com/embed/miVz9nsMYEw?si=Fiq-hMRfU2P9ntwj", "https://img.youtube.com/vi/miVz9nsMYEw/sddefault.jpg" },
                    { 11, 0, "/images/wow/cover.jpg", "/images/wow/crsl1.jpg", "World of Warcraft: War Within — это захватывающее дополнение к легендарной MMORPG от Blizzard Entertainment, которое погружает игроков в эпическое столкновение сил в условиях разрушительного внутреннего конфликта. В этой главе мира Азерота открываются новые горизонты борьбы, и в центре событий оказываются самые могущественные фракции, готовые к решающим битвам.\r\n\r\nДополнение \"War Within\" фокусируется на разрушительном конфликте внутри ключевых народов Азерота. Игрокам предстоит принять участие в сражениях, которые потрясут основы мира, где старые альянсы разрушаются, а новые вражды вспыхивают с небывалой силой. В новой истории игроки смогут исследовать неожиданные сюжетные повороты, раскрывая тайны о предательстве, борьбе за власть и угрозах, которые исходят от самых неожиданных источников.\r\n\r\nДополнение включает в себя новые зоны, подземелья и рейды, которые открывают новые возможности для исследования и сражений. Также будут добавлены новые расы, классы и возможности кастомизации персонажей, позволяя игрокам погрузиться в мир с еще большей глубиной.\r\n\r\nWorld of Warcraft: War Within — это эпическая глава, которая подарит игрокам невероятные приключения, новые испытания и незабываемые моменты в любимом мире Азерота.", "[1]", 8000m, "/images/wow/scr_thumb.jpg", "[\"/images/wow/scr1.jpg\",\"/images/wow/scr2.jpg\",\"/images/wow/scr3.jpg\"]", "World Of Warcraft: War Within", "https://www.youtube.com/embed/o03STclgxSc", "//img.youtube.com/vi/o03STclgxSc/mqdefault.jpg" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartPositions_CartId",
                table: "CartPositions",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartPositions_GameId",
                table: "CartPositions",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId",
                table: "Carts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPositions_GameId",
                table: "OrderPositions",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPositions_OrderId",
                table: "OrderPositions",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WishlistGames_GameId",
                table: "WishlistGames",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Wishlists_UserId",
                table: "Wishlists",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CartPositions");

            migrationBuilder.DropTable(
                name: "OrderPositions");

            migrationBuilder.DropTable(
                name: "WishlistGames");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Wishlists");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
