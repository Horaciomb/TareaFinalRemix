

namespace apiPhone.Models
{
    using System.ComponentModel.DataAnnotations;
    public class Phone
    {
        [Key]
        public int PersonID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public BloodType Blood_Type { get; set; }
        [Required]
        public Donator Question_Donator { get; set; }
        [Required]
        public string Allergies { get; set; }
    }

public enum BloodType
{
    A_positive,
    A_negative,
    B_positive,
    B_negative,
    O,
    AB
}

    public enum Donator
    {
        No,
        Yes
    }
}