using System;
using System.Collections.Generic;
using System.Text;
using Exemplo.Domain.Entities;
using Exemplo.Repository.Data.Contexts;

namespace Exemplo.Repository.Data.Repositories
{
    public class ContatoRepository : BaseRepository<Contato>, IContatoRepository
    {
        public ContatoRepository(Context context) : base(context) { }
    }
}
