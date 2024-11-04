using Core.Entities;
using SweetDictionary.Models.Categories;
namespace SweetDictionary.Service.Abstract;

public interface ICategoryService
{

    ReturnModel<List<CategoryResponseDto>> GetAllCategories();
    ReturnModel<CategoryResponseDto> GetById(int id);
    ReturnModel<NoData> Add(CategoryAddRequestDto dto);
    ReturnModel<NoData> Update(CategoryUpdateRequestDto dto);

    ReturnModel<NoData> Delete(int id);

}
