using Plugin_Framework.Application.Interfaces;
using Plugin_Framework.Models.Dto;
using Plugin_Framework.Repository.Interfaces;

namespace Plugin_Framework.Application
{
    public class ApplicationImageEdit : IApplicationImageEdit
    {
        private IImageEditorRepo _iImageEditorRepo;

        public ApplicationImageEdit(IImageEditorRepo imageEditorRepo)
        {
            _iImageEditorRepo = imageEditorRepo;
        }

        public async Task<List<EditedImageList>> ImageEdditor(IEnumerable<RequestDto> images)
        {
            try
            {
                var responce = await _iImageEditorRepo.AddImageEffects(images);
                return responce;
            }
            catch(Exception x)
            {
                return null;
            }        
        }
    }
}
