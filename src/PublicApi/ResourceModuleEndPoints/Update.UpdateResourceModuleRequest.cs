namespace Oyster.PublicApi.ResourceModuleEndPoints;

public class UpdateResourceModuleRequest:BaseRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Icon { get; set; }
    public string Aliase { get; set; }
}
