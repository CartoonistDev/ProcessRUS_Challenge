using FruitsAPI.Models.Dto;

namespace FruitsAPI.Service.IService
{
    public interface IFruitService
    {
        Task<ResponseDto> GetAllFruits();
    }
}
