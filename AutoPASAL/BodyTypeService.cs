using AutoPASAL.IRepository;
using AutoPASAL.Services;
using AutoPASDML;



namespace AutoPASAL
{
    public class BodyTypeService : IBodyTypeService
    {
        
        private readonly IBodyTypeRepo _bodyTypeRepo;

        public  BodyTypeService(IBodyTypeRepo bodyTypeRepo)
        {
            _bodyTypeRepo = bodyTypeRepo;
        }
        

        public async Task<List<bodyType>?> GetAllBodyType()
        {
            return await _bodyTypeRepo.GetAllBodyType();
        }
        public async Task<bodyType> AddBodyType(bodyType bodyType)
        {
            return await _bodyTypeRepo.AddBodyType(bodyType);
        }
        public  bool IsExists(int id)
        {
            return  _bodyTypeRepo.IsExists(id);
        }

    }
}