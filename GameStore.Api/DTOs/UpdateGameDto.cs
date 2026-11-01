using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Api.DTOs
{
    public record UpdateGameDto
    (
        [Required][StringLength(50)] string Name,
        [Required][StringLength(20)] string Genre,
        [Range(1,200)]decimal Price,
        DateOnly ReleaseDate
    );
}