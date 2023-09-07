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
    }
}