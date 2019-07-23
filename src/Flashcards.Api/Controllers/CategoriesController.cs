using System.Threading.Tasks;
using Flashcards.Core.Extensions;
using Flashcards.Domain.Enums;
using Flashcards.Domain.Repositories;
using Flashcards.Infrastructure.Commands.Abstract;
using Flashcards.Infrastructure.Commands.Models.Categories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Flashcards.Api.Controllers
{
    [Authorize]
    [Route("api/topics/{topic}/categories")]
    public class CategoriesController : ApiController
    {
        private readonly ICategoriesRepository _categoriesRepository;

        public CategoriesController(ICommandDispatcher commandDispatcher, ICategoriesRepository categoriesRepository)
            : base(commandDispatcher)
        {
            _categoriesRepository = categoriesRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string topic)
            => Ok(await _categoriesRepository.GetByTopic(topic.ToEnum<Topic>()));

        [HttpGet("{category}")]
        public async Task<IActionResult> Get(string topic, string category)
            => Ok(await _categoriesRepository.GetByName(category));

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddCategoryCommandModel command)
            => await DispatchAsync(command);

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] EditCategoryCommandModel command)
            => await DispatchAsync(command);

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] RemoveCategoryCommandModel command)
            => await DispatchAsync(command);
    }
}
