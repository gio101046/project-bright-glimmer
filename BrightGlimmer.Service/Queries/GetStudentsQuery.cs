﻿using BrightGlimmer.Domain.Service;
using MediatR;
using System.Collections.Generic;

namespace BrightGlimmer.Service.Queries
{
    public class GetStudentsQuery : IRequest<IEnumerable<Student>>
    {
    }
}
