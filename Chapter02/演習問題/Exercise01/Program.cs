using System.Runtime.CompilerServices;

namespace Exercise01 {
    public class Program {
        static void Main(string[] args) {

            //2-1の3
            var songs = new Song[] {
                new Song("Let it be", "The Beatles", 243),
                new Song("Bridge Over Troubled Water", "Simon & Garfunkel", 293),
                new Song("Close To You", "Carpenters", 276),
                new Song("Honesty", "Billy Joel", 231),
                new Song("I Will Always Love You", "Whitney Houston", 273),
            };
            printSongs(songs);
        }


        //2-1の4
        public static void printSongs(Song[] songs) {

            foreach (var song in songs) {

                var minutes = song.Lenght / 60;
                var second = song.Lenght % 60;


                Console.WriteLine($"{song.Title},{song.ArtistName},{minutes} : {second:00}");

            }
        }
    }
}
