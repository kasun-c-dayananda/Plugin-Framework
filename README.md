# Plugin-Framework

Plugin-Framework is the web API project that done to cover the requrement in the test case given, Project is being used .netcore 6 and singleton architecture 
pattern to suit the requrement and there is a one controller which listn to pickup image data. Nullables have being disabled to the requrement in the project
settings.

[HttpPost]
public async Task<object> Post([FromForm] List<RequestDto> imageData){
=> this post methods accepts form type file with mulltiple images with relevent data as the test says
}

=> this is the request body requrement which will be a list in controller to handle mulltiple image uploads at ones
public class RequestDto
{
public int CustomerID { get; set; }
public IFormFile File { get; set; }
public List<int> Effects { get; set; }
public int Radius { get; set; }
public double Size { get; set; }
}

# TestImageEditorAPI

this is the MOQ test class library to test the POST method and IApplicationImageEdit interface to perform unit testing.

=> use TestImageEditData() and run test on this method to check the outputs with given moq data
