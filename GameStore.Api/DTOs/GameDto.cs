using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Api.DTOs
{
    public record GameDto
    (
        int Id,
        string Name,
        string Genre,
        decimal Price,
        DateOnly RealaseDate
    );
}