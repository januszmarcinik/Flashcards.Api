using Flashcards.Core;
using Flashcards.Core.Extensions;
using Flashcards.Domain.Enums;
using Flashcards.Domain.Repositories;
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

        public CategoriesController(IMediator mediator, ICategoriesRepository categoriesRepository)
            : base(mediator)
        {
            _categoriesRepository = categoriesRepository;
        }

        [HttpGet]
        public IActionResult Get(string topic)
            => Ok(_categoriesRepository.GetByTopic(topic.ToEnum<Topic>()));

        [HttpGet("{category}")]
        public IActionResult Get(string topic, string category)
            => Ok(_categoriesRepository.GetByName(category));

        [HttpPost]
        public IActionResult Post([FromBody] AddCategoryCommand command)
            => Dispatch(command);

        [HttpPut]
        public IActionResult Put([FromBody] EditCategoryCommand command)
            => Dispatch(command);

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] RemoveCategoryCommand command)
            => Dispatch(command);
    }
}
