namespace NZWalks.Models.DTO
{
    public class AddWalkModel
    {
        public string Name { get; set; }
        public double Length { get; set; }

        public int RegionID { get; set; }
        public int WalkDifficultyID { get; set; }
    }
}
