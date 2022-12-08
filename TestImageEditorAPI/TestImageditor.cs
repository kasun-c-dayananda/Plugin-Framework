using AutoFixture;
using AutoFixture.Kernel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Plugin_Framework.Application.Interfaces;
using Plugin_Framework.Controllers;
using Plugin_Framework.Models.Dto;
using Plugin_Framework.Repository;
using Plugin_Framework.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestImageEditorAPI
{
    [TestClass]
    public class TestImageditor
    {
        private Mock<IApplicationImageEdit> _applicationImageEdit;
        private Fixture _fixture;
        private ImageHandlerController _imageHandlerController;

        public TestImageditor()
        {
            _fixture=new Fixture();
            _applicationImageEdit = new Mock<IApplicationImageEdit>();
        }

        [TestMethod]    
        public async Task TestImageEditData()
        {

            var content = "Hello World from a Fake File";
            var fileName = "test.jpg";
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(content);
            writer.Flush();
            stream.Position = 0;
            IFormFile file = new FormFile(stream, 0, stream.Length, "id_from_form", fileName);

            List<RequestDto> responseDto = new List<RequestDto>
            {        
                new RequestDto
                {
                CustomerID = 16748,
                File = file,
                Effects = new List<int> { 1 },
                Radius =4,
                Size = 5.5
                },
                new RequestDto
                {
                CustomerID = 16745678,
                File = file,
                Effects = new List<int> { 1,2 },
                Radius =3,
                Size = 1.5
                }
            };

            List<EditedImageList> responseOut = new List<EditedImageList>
            {
                new EditedImageList
                {
                CustomerID = 16748,
                File = file             
                },
                new EditedImageList
                {
                CustomerID = 16745678,
                File = file
                }
            };         

            _applicationImageEdit.Setup(repo => repo.ImageEdditor(responseDto)).Returns(Task.FromResult(responseOut));
            _imageHandlerController = new ImageHandlerController(_applicationImageEdit.Object);           

            var result = await _imageHandlerController.Post(responseDto);
            var obj = result as ResponseDto;

            Assert.AreEqual(true, obj.IsSuccess);
        }
    }
}
