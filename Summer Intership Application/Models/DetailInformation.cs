namespace Summer_Intership_Application.Models
{
    public class DetailInformation
    {
        public long Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Nationality { get; set; } = string.Empty;
        public string CountryResidence { get; set; } = string.Empty;
        public string IdNumber { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; } = string.Empty;
        public List<AddtionalQuestions> AddtionalQuestions { get; set; }
    }

    public class AddtionalQuestions
    {
        public int QuestionId { get; set; }
        public string Answer { get; set; }
        public long DetailInformationId { get; set; }
        public DetailInformation DetailInformation { get; set; }
    }
}
