using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Zamin.Core.Domain.Toolkits.ValueObjects;

namespace Charisma.Infra.Data.Sql.Commands.ValueConversions
{
    public class DescriptionConversion : ValueConverter<Description, string>
    {
        public DescriptionConversion() : base(c => c.Value, c => Description.FromString(c))
        {

        }
    }
}
