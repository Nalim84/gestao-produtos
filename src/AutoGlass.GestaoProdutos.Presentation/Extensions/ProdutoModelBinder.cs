using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text.Json;

namespace AutoGlass.GestaoProdutos.Presentation.Extensions
{
    public class ProdutoModelBinder : IModelBinder
    {
      public Task BindModelAsync(ModelBindingContext bindingContext)
      {
          if (bindingContext == null)
          {
              throw new ArgumentNullException(nameof(bindingContext));
          }
     
          var serializeOptions = new JsonSerializerOptions
          {
              WriteIndented = true,
              Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
              PropertyNameCaseInsensitive = true
          };
     
          return Task.CompletedTask;
      }
    }
}
