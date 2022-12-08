using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Plugin_Framework.Application.Interfaces;
using Plugin_Framework.Models.Dto;

namespace Plugin_Framework.Controllers
{
    // I have used .Netcore 6 for the test and nullable is being disabled
    // Have implemented the singleton architecture
    // Moq project is being implemented to test the controller

    [Route("api/imagehandler")]
    public class ImageHandlerController : ControllerBase
    {
        protected ResponseDto _response;
        private IApplicationImageEdit _applicationImageEdit;

        public ImageHandlerController(IApplicationImageEdit applicationImageEdit)
        {
            _applicationImageEdit = applicationImageEdit;
            this._response = new ResponseDto();
        }

        [HttpPost]
        public async Task<object> Post([FromForm] List<RequestDto> imageData)
        {
            try
            {
                var model = await _applicationImageEdit.ImageEdditor(imageData);

                if(model.Count > 0)
                {
                    _response.IsSuccess = true;
                    _response.DisplayMessage = Constants.Constants.SuccessMsg;
                    _response.Result = model;
                }
                else
                {
                    _response.IsSuccess = false;
                    _response.Result = null;
                    _response.ErrorMessages
                         = new List<string>() { Constants.Constants.FailMsg };
                }

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Result = null;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }

            return _response;
        }
    }
}
