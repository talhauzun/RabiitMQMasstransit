using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Example.Domain.Commads
{

    public class CreateTextCommad : IRequest<string>
    {
        public CreateTextCommad(string text)
        {
            id = Guid.NewGuid();
            Text = text;
        }

        public Guid id { get; set; }
        public string Text { get; set; }

        public class CreateTextHandler : IRequestHandler<CreateTextCommad, string>
        {
            public Task<string> Handle(CreateTextCommad request, CancellationToken cancellationToken)
            {
                return Task.FromResult(request.id + "  " + request.Text + " Başarılı");
            }
        }
    }
}
