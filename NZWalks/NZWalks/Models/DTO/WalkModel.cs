namespace NZWalks.Models.DTO
{
    public class WalkModel
    {
        public int WalkID { get; set; }
        public string Name { get; set; }
        public double Length { get; set; }

        public int RegionID { get; set; }
        public int WalkDifficultyID { get; set; }

        // Navigation property

        public RegionModel Regions { get; set; }
        public WalkDifficultyModel WalkDifficulties { get; set; }
    }
}
