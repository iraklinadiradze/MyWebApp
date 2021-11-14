using System;
using System.Collections.Generic;
using System.Text;

using System.Threading;
using System.Threading.Tasks;
using MediatR;

using DataAccessLayer.Model.Core;
using DataAccessLayer;

using Application.Common.Interfaces;
using Application.Common.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Application.Domains.Core.User.Queries.GetUserList
{

    public class GetUserListQuery : IRequest<List<UserView>>
    {
//        public int? id { get; set; }
//        public int? topRecords { get; set; }
//        public string? name { get; set; }

          
    }

    public class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, List<UserView>>
    {

        private readonly IMediator _mediator;
        private readonly ICoreDBContext _context;


        public GetUserListQueryHandler(IMediator mediator, ICoreDBContext context)
        {
            _mediator = mediator;
            _context = context;
        }


        public async Task<List<UserView>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {

           var result = from e in _context.User
                        
                        select new UserView
                           {
                             Id= e.Id,
Firstname= e.Firstname,
Lastname= e.Lastname,
Password= e.Password,
Username= e.Username
                           };


            

            return (List<UserView>)await result.ToListAsync(cancellationToken);
        }

    }
}
