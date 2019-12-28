namespace appPhone.Models
{
    public class Phone
    {
     
        public int PersonID { get; set; }

        public string FirstName { get; set; }
    
        public string LastName { get; set; }
  
        public BloodType Blood_Type { get; set; }
  
        public Donator Question_Donator { get; set; }
    
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
