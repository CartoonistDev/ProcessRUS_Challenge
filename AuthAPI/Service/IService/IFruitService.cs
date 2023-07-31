using AuthAPI.Models.Dto;

namespace AuthAPI.Service.IService
{
    public interface IFruitService
    {
        Task<ResponseDto> GetAllFruits();
    }
}
