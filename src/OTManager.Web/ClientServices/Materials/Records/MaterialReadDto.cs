namespace OTManager.Web.ClientServices.Materials.Records;

public record MaterialReadDto
(Guid Id,
string Code,
string Name,
string MeasureUnit,
decimal UnitCost);
