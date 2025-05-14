using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    //2-1の1
    public class Song {

        public string Title { get;  set; } = String.Empty;
        public string ArtistName { get;  set; } = String.Empty;
        public int Lenght { get;  set; }


    //2-1の2
        public Song(String Title, String ArtistName, int Lenght) {

           this.Title = Title;
            this.ArtistName = ArtistName;
            this.Lenght = Lenght;

        }

        public Song() {
        }
    }
}
