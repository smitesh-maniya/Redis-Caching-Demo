namespace ODataRedisCaching.Models
{
    [Serializable]
    public class Student
    {
        public int StudentID { get; set; }
        public string FName { get; set;}
        public string SName { get; set; }
        public string IDNumber { get; set; }
        public string EmailAddress { get; set; }
        public DateTime TimeCreated { get; set; }
    }
}