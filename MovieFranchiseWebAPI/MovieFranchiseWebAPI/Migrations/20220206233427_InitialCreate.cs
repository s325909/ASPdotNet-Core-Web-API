using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieFranchiseWebAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Character",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Alias = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PictureURL = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Character", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Franchise",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Franchise", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tittle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true),
                    ReleaseYear = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    Director = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PictureURL = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    TrailerURL = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    FranchiseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movie_Franchise_FranchiseId",
                        column: x => x.FranchiseId,
                        principalTable: "Franchise",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MovieCharacter",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    CharacterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieCharacter", x => new { x.MovieId, x.CharacterId });
                    table.ForeignKey(
                        name: "FK_MovieCharacter_Character_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Character",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieCharacter_Movie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Character",
                columns: new[] { "Id", "Alias", "FullName", "Gender", "PictureURL" },
                values: new object[,]
                {
                    { 1, "Baba Yaga", "John Wick", "Male", "https://static1.colliderimages.com/wordpress/wp-content/uploads/2021/03/john-wick-keanu-reeves-social-1.jpg" },
                    { 2, "Iron Man", "Tony Stark", "Male", "https://img.joomcdn.net/dace9a3da47d7d748e13af43f96344a4449c7688_original.jpeg" },
                    { 3, "Captain America", "Steve Rogers", "Male", "https://static.wikia.nocookie.net/marvel-cinematic/images/3/32/Steve_Rogers_2.jpg/revision/latest?cb=20131025030358" },
                    { 4, "Black Widow", "Natasha Romanoff", "Female", "https://pbs.twimg.com/media/FC-HLpbWUAI4UCa.jpg" },
                    { 5, "The Incredible Hulk", "Bruce Banner", "Male", "https://upload.wikimedia.org/wikipedia/en/thumb/3/3b/Mark_Ruffalo_as_%22Professor_Hulk%22.jpeg/200px-Mark_Ruffalo_as_%22Professor_Hulk%22.jpeg" },
                    { 6, "Spider-Man", "Peter Parker", "Male", "https://www.koimoi.com/wp-content/new-galleries/2021/12/new-spider-man-trilogy-to-witness-tom-hollands-peter-parker-in-college-001.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Franchise",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "John Wick is an American neo-noir action-thriller media franchise created by screenwriter Derek Kolstad and starring Keanu Reeves as John Wick, a former hitman who is forced back into the criminal underworld he abandoned.", "John Wick" },
                    { 2, "The Marvel Cinematic Universe (MCU) is an American media franchise and shared universe centered on a series of superhero films produced by Marvel Studios.", "The Marvel Cinematic Universe" }
                });

            migrationBuilder.InsertData(
                table: "Movie",
                columns: new[] { "Id", "Director", "FranchiseId", "Genre", "PictureURL", "ReleaseYear", "Tittle", "TrailerURL" },
                values: new object[,]
                {
                    { 5, "Chad Stahelski", 1, "Action, Crime, Drama, Thriller", "https://filmyhotspot.com/wp-content/uploads/2020/12/39e611e5-870c-4c6d-97a1-e7c9ee51a97b.jpg", 2023, "John Wick: Chapter 4", "https://www.youtube.com/watch?v=gy31U2bvVGU" },
                    { 6, "Chad Stahelski", 1, "Action, Mystery, thriller", "https://www.the-rampage.org/wp-content/uploads/2019/06/268x0w.png", 2019, "John Wick: Chapter 3", "https://www.youtube.com/watch?v=M7XM597XO94" },
                    { 7, "Chad Stahelski", 1, "Action, Drama", "https://m.media-amazon.com/images/M/MV5BMjE2NDkxNTY2M15BMl5BanBnXkFtZTgwMDc2NzE0MTI@._V1_.jpg", 2017, "John Wick: Chapter 2", "https://www.youtube.com/watch?v=XGk2EfbD_Ps" },
                    { 8, "Chad Stahelski", 1, "Action, Crime, Drama, Thriller, Tragedy", "https://m.media-amazon.com/images/M/MV5BMTU2NjA1ODgzMF5BMl5BanBnXkFtZTgwMTM2MTI4MjE@._V1_.jpg", 2014, "John Wick (2014)", "https://www.youtube.com/watch?v=2AUmvWm5ZDQ" },
                    { 1, "Joe Johnston", 2, "Action, Crime, Drama, Thriller", "https://m.media-amazon.com/images/M/MV5BMTYzOTc2NzU3N15BMl5BanBnXkFtZTcwNjY3MDE3NQ@@._V1_FMjpg_UX1000_.jpg", 2011, "Captain America: The First Avenger", "https://www.youtube.com/watch?v=JerVrbLldXw" },
                    { 2, "Anthony Russo, Joe Russo", 2, "Action, Drama, Romace", "https://m.media-amazon.com/images/M/MV5BMzA2NDkwODAwM15BMl5BanBnXkFtZTgwODk5MTgzMTE@._V1_.jpg", 2014, "Captain America: The Winter Soldier", "https://www.youtube.com/watch?v=tbayiPxkUMM" },
                    { 3, "Anthony Russo, Joe Russo", 2, "Action, Drama", "https://m.media-amazon.com/images/M/MV5BMzA2NDkwODAwM15BMl5BanBnXkFtZTgwODk5MTgzMTE@._V1_.jpg", 2016, "Captain America: Civil War", "https://www.youtube.com/watch?v=tbayiPxkUMM" },
                    { 4, "Anthony Russo, Joe Russo", 2, "Action, Comedy, Drama, Romance", "https://m.media-amazon.com/images/M/MV5BMjMxNjY2MDU1OV5BMl5BanBnXkFtZTgwNzY1MTUwNTM@._V1_.jpg", 2018, "Avengers: Infinity War", "https://www.youtube.com/watch?v=QwievZ1Tx-8" }
                });

            migrationBuilder.InsertData(
                table: "MovieCharacter",
                columns: new[] { "CharacterId", "MovieId" },
                values: new object[,]
                {
                    { 1, 5 },
                    { 1, 6 },
                    { 1, 7 },
                    { 1, 8 },
                    { 3, 1 },
                    { 3, 2 },
                    { 4, 2 },
                    { 2, 3 },
                    { 3, 3 },
                    { 4, 3 },
                    { 6, 3 },
                    { 2, 4 },
                    { 3, 4 },
                    { 4, 4 },
                    { 5, 4 },
                    { 6, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movie_FranchiseId",
                table: "Movie",
                column: "FranchiseId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieCharacter_CharacterId",
                table: "MovieCharacter",
                column: "CharacterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieCharacter");

            migrationBuilder.DropTable(
                name: "Character");

            migrationBuilder.DropTable(
                name: "Movie");

            migrationBuilder.DropTable(
                name: "Franchise");
        }
    }
}
