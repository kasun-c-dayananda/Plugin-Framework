# Plugin-Framework

Plugin-Framework is the web API project that done to cover the requrement in the test case given, Project is being used .netcore 6 and singleton architecture 
pattern to suits the requrement and there is a one controller which listn to pickup image data. Nullables have being disabled to the requrement in the project
settings.

[HttpPost]
public async Task<object> Post([FromForm] List<RequestDto> imageData){
=> this post methods accepts form type file with mulltiple images with relevent data as the test says
}

# TestImageEditorAPI

this is the MOQ test class library to test the POST method and IApplicationImageEdit interface to perform unit testing.

=> use TestImageEditData() and run test on this method to check the outputs with given moq data
