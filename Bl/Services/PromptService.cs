using Bl.Services.Interfaces;
using Dal.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dal.models;

namespace Bl.Services
{
    public class PromptService : IPromptService
    {
        private readonly SubCategoryRepository _subcategoryRepository;
        private readonly CategoryRepository _categoryRepository;
        private readonly PromptRepository _promptRepository;
        private readonly OpenAiService _openAiService;

       
        public PromptService(
           PromptRepository promptRepository,
           CategoryRepository categoryRepository,
           SubCategoryRepository subcategoryRepository,
           OpenAiService openAiService)
        {
            _promptRepository = promptRepository;
            _categoryRepository = categoryRepository;
            _subcategoryRepository = subcategoryRepository;
            _openAiService = openAiService;
        }



        public async Task<string> SubmitPrompt(Prompt prompt)
        {

            var categoryName = await _categoryRepository.GetCategoryNameByIdAsync(prompt.CategoryId);
            var subCategoryName = await _subcategoryRepository.GetSubCategoryNameByIdAsync(prompt.SubCategoryId);


            var lessonResponse = await _openAiService.GetLessonFromOpenAiAsync(categoryName, subCategoryName);

            
            prompt.Response = lessonResponse;


            await _promptRepository.CreatePrompt(prompt);


            return lessonResponse;
        }



    }
}
