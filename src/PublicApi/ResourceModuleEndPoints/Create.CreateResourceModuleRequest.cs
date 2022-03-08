namespace Oyster.PublicApi.ResourceModuleEndPoints;

public class CreateResourceModuleRequest:BaseRequest
{
    public string Name { get; set; }
    public string Icon { get; set; }
    public string Aliase { get; set; }
}
