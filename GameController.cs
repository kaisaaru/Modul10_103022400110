using Microsoft.AspNetCore.Mvc;
using Modul10_103022400110;

namespace Modul10_103022400110
{
    // Controller untuk mengelola data game
    [ApiController]
    [Route("api/[controller]")]

    // class GameController yang mengatur endpoint untuk operasi CRUD pada data game
    public class GameController : ControllerBase
    {
        // List statis untuk menyimpan data game sementara
        private static List<Game> games = new List<Game>
        {
            new Game {
                id = 1,
                Nama = "Valorant",
                Developer = "Riot Games",
                TahunRilis = 2020,
                Genre = "FPS",
                Rating = 8.5,
                Platform = new string[] { "PC" },
                Mode = new string[] { "Multiplayer" },
                IsOnline = true,
                Harga = 0
            },
            new Game
            {
                id = 2,
                Nama = "GTA V",
                Developer = "Rockstar Games",
                TahunRilis = 2013,
                Genre = "Open World",
                Rating = 9.5,
                Platform = new string[] { "PC", "PS4", "Xbox" },
                Mode = new string[] { "Singleplayer", "Multiplayer" },
                IsOnline = true,
                Harga = 300000
            },
            new Game
            {
                id = 3,
                Nama = "The Witcher 3",
                Developer = "CD Projekt Red",
                TahunRilis = 2015,
                Genre = "RPG",
                Rating = 9.7,
                Platform = new string[] { "PC", "PS4", "PS5", "Xbox", "Switch" },
                Mode = new string[] { "Singleplayer" },
                IsOnline = false,
                Harga = 250000
            }
        };

        // Endpoint untuk mendapatkan semua game
        [HttpGet]
        public ActionResult<IEnumerable<Game>> GetAll()
        {
            return games;
        }

        // Endpoint untuk mendapatkan game berdasarkan ID
        [HttpGet("{id}")]
        public ActionResult<Game> GetByIdFixed(int id)
        {
            if (id <= 0 || id > games.Count)
            {
                return NotFound("ID game tidak valid");
            }
            return games[id - 1];
        }

        // Endpoint untuk menambahkan game baru
        [HttpPost]
        public ActionResult Create([FromBody] Game newGame)
        {
            if (newGame == null || string.IsNullOrEmpty(newGame.Nama) || string.IsNullOrEmpty(newGame.Developer) || newGame.TahunRilis <= 0 || newGame.Rating < 0 || newGame.Rating > 10 || newGame.Platform == null || newGame.Mode == null)
            {
                return BadRequest("Data game tidak valid");
            }

            // Buat validasi id agar +1 dari id terakhir, dan tidak mengambil id dari request body
            newGame.id = games.Count + 1;
            games.Add(newGame);
            return Ok("Game berhasil ditambahkan");
        }

        // Endpoint untuk memperbarui data game berdasarkan ID
        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] Game updatedGame)
        {
            // Validasi ID dan data game yang diperbarui
            if (id <= 0 || id >= games.Count)
            {
                return NotFound("ID game tidak valid");
            }
            if (updatedGame == null || string.IsNullOrEmpty(updatedGame.Nama) || string.IsNullOrEmpty(updatedGame.Developer) || updatedGame.TahunRilis <= 0 || updatedGame.Rating < 0 || updatedGame.Rating > 10 || updatedGame.Platform == null || updatedGame.Mode == null)
            {
                return BadRequest("Data game tidak valid");
            }

            // Update data game tanpa mengubah id
            games[id - 1].Nama = updatedGame.Nama;
            games[id - 1].Developer = updatedGame.Developer;
            games[id - 1].TahunRilis = updatedGame.TahunRilis;
            games[id - 1].Genre = updatedGame.Genre;
            games[id - 1].Rating = updatedGame.Rating;
            games[id - 1].Platform = updatedGame.Platform;
            games[id - 1].Mode = updatedGame.Mode;
            games[id - 1].IsOnline = updatedGame.IsOnline;
            games[id - 1].Harga = updatedGame.Harga;
            return Ok("Game berhasil diperbarui");
        }

        // Endpoint untuk menghapus game berdasarkan ID
        [HttpDelete("{id}")]
        public ActionResult DeleteById(int id)
        {
            if (id <= 0 || id >= games.Count)
            {
                return NotFound("ID game tidak valid");
            }
            games.RemoveAt(id - 1);
            return Ok("Game berhasil dihapus");

        }

        // Kenapa id - 1? Karena id dimulai dari 1, sedangkan indeks list dimulai dari 0. Jadi, untuk mendapatkan game dengan id tertentu, kita perlu mengurangi 1 dari id tersebut untuk mendapatkan indeks yang benar dalam list. Hal ini bisa menyebabkan error, jika id yang diberikan tidak valid (misalnya, id 0 atau id yang lebih besar dari jumlah game dalam list), maka akan terjadi error karena indeks yang diakses tidak ada. Oleh karena itu, penting untuk melakukan validasi pada id sebelum mencoba mengakses game dalam list.
    }
}
