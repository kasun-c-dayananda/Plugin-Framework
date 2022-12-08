using AutoMapper;
using Plugin_Framework.DbContexts;
using Plugin_Framework.Models.Dto;
using Plugin_Framework.Repository.Interfaces;
using System.Linq;

namespace Plugin_Framework.Repository
{
    public class ImageEditorRepo : IImageEditorRepo
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public ImageEditorRepo(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<List<EditedImageList>> AddImageEffects(IEnumerable<RequestDto> images)
        {
            List<EditedImageList> editedImageList = new List<EditedImageList>();

            foreach (var image in images)
            {
                if (image.File != null) 
                {
                //Pass image to add effects
                var _imageFile = await ApplyEffects(image.File, image.Effects);

                //Add Radius and Radius to the edited Image
                var _finalizedImageFile = await ImageResizeComponent(_imageFile, image.Radius, image.Size);

                //store it in to list
                editedImageList.Add(
                    new EditedImageList {
                        CustomerID = image.CustomerID,
                        File = _finalizedImageFile
                    });
                }
            }

            return editedImageList;
        }

        private async Task<IFormFile> ImageResizeComponent(IFormFile _file, int Radius, double Size)
        {
            try
            {
                //Apply radius and size and return the new file

                //using (var memoryStream = new MemoryStream())
                //{
                //    await _file.CopyToAsync(memoryStream);
                //    //TO DO
                //}

                return _file;
            }
            catch (Exception x)
            {
                return null;
            }
        }

        private async Task<IFormFile> ApplyEffects(IFormFile _file, List<int> Effects)
        {
            try
            {
                //Apply Effects
                var IsEffectOne = Effects.Any(x => x == (int)Constants.Constants.Effects.Effect1);
                var IsEffectTwo = Effects.Any(x => x == (int)Constants.Constants.Effects.Effect2);
                var IsEffectThree = Effects.Any(x => x == (int)Constants.Constants.Effects.Effect3);

                if (IsEffectOne)
                {
                    //effects should be add with await so if there is mulltiple effects one will wait for other

                    //using (var memoryStream = new MemoryStream())
                    //{
                    //    await _file.CopyToAsync(memoryStream);
                    //    //TO DO
                    //}
                }
                if (IsEffectTwo)
                {
                    //effects should be add with await so if there is mulltiple effects one will wait for other

                    //using (var memoryStream = new MemoryStream())
                    //{
                    //    await _file.CopyToAsync(memoryStream);
                    //    //TO DO
                    //}
                }
                if (IsEffectThree)
                {
                    //effects should be add with await so if there is mulltiple effects one will wait for other
                    //using (var memoryStream = new MemoryStream())
                    //{
                    //    await _file.CopyToAsync(memoryStream);
                    //    //TO DO
                    //}
                }

                return _file;
            }
            catch (Exception x)
            {
                return null;
            }
        }
    }
}
