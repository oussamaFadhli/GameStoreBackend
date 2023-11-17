using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.Dtos;

public record GameDto(
    int Id,
    string Name,
    string Genre,
    decimal Price,
    DateTime ReleaseDate,
    string ImgUrl
);

public record CreateGameDto(
    [Required][StringLength(50)] string Name,
    [Required][StringLength(30)] string Genre,
    [Range(1, 999)] decimal Price,
    DateTime ReleaseDate,
    [Url][StringLength(100)] string ImgUrl
);
public record UpdateGameDto(
    [Required][StringLength(50)] string Name,
    [Required][StringLength(30)] string Genre,
    [Range(1, 999)] decimal Price,
    DateTime ReleaseDate,
    [Url][StringLength(100)] string ImgUrl
);