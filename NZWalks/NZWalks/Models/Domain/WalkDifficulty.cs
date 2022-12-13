using System.ComponentModel.DataAnnotations;

namespace NZWalks.Models.Domain
{
    public class WalkDifficulty
    {
        [Key]
        public int ID { get; set; }
        public string Code { get; set; }

    }
}
