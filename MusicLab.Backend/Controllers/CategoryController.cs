using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicLab.Backend.Services.Interfaces;
using MusicLab.Repository.Repositories.Interfaces;
using MusicLab.Repository;
using MusicLab.Repository.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MusicLab.Backend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IAWSS3Service _awsS3Service;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryController(IAWSS3Service aWSS3Service, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _awsS3Service = aWSS3Service;
            _categoryRepository = unitOfWork.CategoryRepository;
            _mapper = mapper;
        }

        [HttpGet("/api/get-all-categories")]
        public async Task<IActionResult> GetAllCategories()
        {
            var rs = await _categoryRepository.GetAll().ToListAsync().ConfigureAwait(false);
            return Ok(rs);
        }

        [HttpGet("/api/get-category-byId")]
        public async Task<IActionResult> GetCategoryById(int categoryId)
        {
            var rs = await _categoryRepository.Find(x => x.Id == categoryId).FirstOrDefaultAsync().ConfigureAwait(false);
            return Ok(rs);
        }
    }
}
