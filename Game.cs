namespace Modul10_103022400110
{
    public class Game
    {
        // Properti untuk kelas Game
        public int id { get; set; }
        public string Nama { get; set; }
        public string Developer { get; set; }
        public int TahunRilis { get; set; }
        public string Genre { get; set; }
        public double Rating { get; set; }
        public string[] Platform { get; set; }
        public string[] Mode { get; set; }
        public bool IsOnline { get; set; }
        public int Harga { get; set; }

        public Game()        {
            // Constructor kosong
        }
    }
}
