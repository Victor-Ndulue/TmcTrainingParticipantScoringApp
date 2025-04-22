using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Helpers.DTOs.Request
{
    public record CreateSessionRequest(int TopicId, ICollection<int> StudentIds, ICollection<int> EvaluatorIds);

}
