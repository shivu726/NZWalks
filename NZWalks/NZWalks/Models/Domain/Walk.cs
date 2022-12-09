namespace NZWalks.Models.Domain
{
    public class Walk
    {
        public Guid WalkID { get; set; }
        public string Name { get; set; }
        public double Length { get; set; }

        public Guid RegionID { get; set; }
        public Guid WalkDiffID { get; set; }

        // Navigation property

        public Region Regions { get; set; }
        public WalkDifficulty walkDifficulty { get; set; }


    }
}
