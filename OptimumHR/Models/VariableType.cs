using System.ComponentModel.DataAnnotations;

namespace OptimumHR.Models
{
    public class VariableType
    {
        public int Id { get; set; }
        public string Type { get; set; }

        public string AddedBy { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime AddedDate { get; set; }



    }
}
