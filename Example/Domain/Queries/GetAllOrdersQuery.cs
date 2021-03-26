using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Example.Domain.Queries
{
    public class GetAllOrdersQuery: IRequest<string>
    {

        public class GetAllOrdersHandler : IRequestHandler<GetAllOrdersQuery, string>
        {
            public Task<string> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
            {
                return Task.FromResult("Başarılı");
            }
        }
    }

    public class GetByIdOrderQuery : IRequest<string>
    {
        public GetByIdOrderQuery(int id)
        {
            this.id = id;
        }

        public int id { get; set; }

        public class GetAllOrdersHandler : IRequestHandler<GetByIdOrderQuery, string>
        {
            public Task<string> Handle(GetByIdOrderQuery request, CancellationToken cancellationToken)
            {
                return Task.FromResult(request.id+"  gönderilen data");
            }
        }
    }
}
