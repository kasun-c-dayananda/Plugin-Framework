using Plugin_Framework.Models.Dto;

namespace Plugin_Framework.Application.Interfaces
{
    public interface IApplicationImageEdit
    {
        Task<List<EditedImageList>> ImageEdditor(IEnumerable<RequestDto> images);
    }
}
