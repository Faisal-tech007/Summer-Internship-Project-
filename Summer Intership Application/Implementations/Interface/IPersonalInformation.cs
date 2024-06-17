using Summer_Intership_Application.DTOs;
using Summer_Intership_Application.Models;

namespace Summer_Intership_Application.Implementations.Interface
{
    public interface IPersonalInformation
    {
       Task<DetailInformation> CreateAsync(DetailInformation detailInformation);
    }
}
