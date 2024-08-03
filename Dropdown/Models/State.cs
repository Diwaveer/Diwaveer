namespace Dropdown.Models
{
    public class State
    {
        public int StateId { get; set; }
        public string StateName { get; set; }
        public int CountryId { get; set; } // Consider including this if needed
        public List<District> Districts { get; set; }
    }
}
