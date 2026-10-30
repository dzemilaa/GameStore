using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Api.DTOs
{
    public record CreateGameDto(
        [Required][StringLength(50)] string Name,
        [Range(1,50)] int GenreId,
        [Range(1,200)]decimal Price,
        DateOnly ReleaseDate
    );
}