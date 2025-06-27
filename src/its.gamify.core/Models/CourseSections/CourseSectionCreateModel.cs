using its.gamify.core.Models.Lessons;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace its.gamify.core.Models.CourseSections
{
    public class CourseSectionCreateModel
    {
        [JsonPropertyName("id")]
        public Guid? CreateId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        [JsonPropertyName("lessons")]
        public List<LessonCreateModel>? Lessons { get; set; }
    }
    public class JsonModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var valueProviderResult = bindingContext.ValueProvider
                .GetValue(bindingContext.ModelName);

            if (valueProviderResult == ValueProviderResult.None)
            {
                bindingContext.Result = ModelBindingResult.Failed();
                return Task.CompletedTask;
            }

            try
            {
                var value = valueProviderResult.FirstValue;
                var result = JsonSerializer.Deserialize(value, bindingContext.ModelType,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                bindingContext.Result = ModelBindingResult.Success(result);
            }
            catch (JsonException ex)
            {
                bindingContext.ModelState.AddModelError(bindingContext.ModelName, ex.Message);
                bindingContext.Result = ModelBindingResult.Failed();
            }

            return Task.CompletedTask;
        }
    }
}
