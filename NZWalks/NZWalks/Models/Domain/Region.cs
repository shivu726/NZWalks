using System.ComponentModel.DataAnnotations;

namespace NZWalks.Models.Domain
{
    public class Region
    {
        [Key]
        public int RegID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public double Area { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
        public long Population { get; set; }


        // Navigation property

        public IEnumerable<Walk> Walks { get; set; }

    }
}
