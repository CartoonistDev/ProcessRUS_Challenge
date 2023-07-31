
using AuthAPI.Data;
using AuthAPI.Models.Dto;
using AuthAPI.Service.IService;

namespace AuthAPI.Service
{
    public class FruitService : IFruitService
    {
        private readonly AppDbContext _db;

        public FruitService(AppDbContext db) 
        { 
            _db= db;
        }
        public async Task<ResponseDto> GetAllFruits()
        {
            ResponseDto response = new();
            try
            {

                var fruits = _db.FavoriteFruits.ToList();

                if (fruits == null)
                {
                    response = new ResponseDto
                    {
                        Result = "",
                        isSuccess = false,
                        Message = "Failed to return list of fruits."
                    };
                    
                    return response;
                    
                }

                response = new ResponseDto
                {
                    Result = fruits,
                    isSuccess = true,
                    Message = ""
                };

                return response;
            }
            catch (Exception ex)
            {
                response = new ResponseDto
                {
                    Result = "",
                    isSuccess = false,
                    Message = "Error while trying to return list of fruits."
                };

                return response;
            }
        }
    }
}
