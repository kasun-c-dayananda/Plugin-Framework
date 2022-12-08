using Plugin_Framework.Models.Dto;

namespace Plugin_Framework.Repository.Interfaces
{
    public interface IImageEditorRepo
    {
        Task<List<EditedImageList>> AddImageEffects(IEnumerable<RequestDto> images);
    }
}
