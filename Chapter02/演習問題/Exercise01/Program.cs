using System.Runtime.CompilerServices;

namespace Exercise01 {
    public class Program {
        static void Main(string[] args) {

            //2-1の3

            var songs = new List<Song>();

            Console.WriteLine("***曲の登録***");

            while (true) {

                Console.WriteLine("曲名");
                string title = Console.ReadLine();

                if (title.Equals("end")) return;

                Console.WriteLine("作者名");
                string artistname = Console.ReadLine();

                Console.WriteLine("演奏時間(秒)");
                int lenght = int.Parse(Console.ReadLine());

                var songer = new Song(title, artistname, lenght);

               /* Song songer =new Song();
                title = title;
                artistname = artistname;
                lenght = lenght;*/

                songs.Add(songer);

                Console.WriteLine();

            }

            printSongs();
        }


        //2-1の4
        public static void printSongs(songs) {

            foreach (var song in songs) {

                var minutes = song.Lenght / 60;
                var second = song.Lenght % 60;

                Console.WriteLine($"{song.Title},{song.ArtistName},{minutes} : {second:00}");

            }
        }
    }
}
