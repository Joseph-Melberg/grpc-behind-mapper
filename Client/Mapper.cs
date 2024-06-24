using Domain;

namespace Client;

public static class NumberMapper
{
    public static NumberDto ToDto(this NumberModel model) => new()
    {
        Value = model.Value
    };

    public static NumberModel ToModel(this NumberDto dto) => new()
    {
        Value = dto.Value
    };

    public static NumbersDto ToDto(this IEnumerable<NumberModel> models)
    {
        var dto = new NumbersDto();
        foreach(var model in models)
        {
            dto.Numbers.Add(model.ToDto());
        }

        return dto;
    }

    public static IEnumerable<NumberModel> ToDomainModel(this NumbersDto dto) =>
        dto.Numbers.Select(_ => _.ToModel());
}
