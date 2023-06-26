using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace az204_blob.Models
{
    public class GameStat
    {
        public string? Id { get; set; }
        public string? Sport { get; set; }
        public DateTimeOffset DatePlayed { get; set; }
        public string? Game { get; set; }
        public IReadOnlyList<string> Teams { get; set; } = new  List<string>();
        public IReadOnlyList<(string team, int score)>? Results { get; set; }   
    }
}
