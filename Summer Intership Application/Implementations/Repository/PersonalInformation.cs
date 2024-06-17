using Summer_Intership_Application.Data;
using Summer_Intership_Application.Implementations.Interface;
using Summer_Intership_Application.Models;

namespace Summer_Intership_Application.Implementations.Repository
{
    public class PersonalInformation : IPersonalInformation
    {
        private readonly DataContext _dataContext;

        public PersonalInformation(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<DetailInformation> CreateAsync(DetailInformation detailInformation)
        {
            if (detailInformation.AddtionalQuestions != null && detailInformation.AddtionalQuestions.Any())
            {
                foreach (var additionalQuestion in detailInformation.AddtionalQuestions)
                {
                    additionalQuestion.DetailInformationId = detailInformation.Id;
                    _dataContext.AddtionalQuestions.Add(additionalQuestion);
                }
            }

            _dataContext.DetailInformations.Add(detailInformation);
            await _dataContext.SaveChangesAsync();

            return detailInformation;
        }
    }
}
