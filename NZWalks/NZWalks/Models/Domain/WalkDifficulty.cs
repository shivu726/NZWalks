using System.ComponentModel.DataAnnotations;

namespace NZWalks.Models.Domain
{
    public class WalkDifficulty
    {
        [Key]
        public Guid WalkID { get; set; }
        public string Code { get; set; }

    }
}
