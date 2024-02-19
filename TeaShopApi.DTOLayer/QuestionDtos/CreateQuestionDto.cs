using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeaShopApi.DTOLayer.QuestionDtos
{
    public class CreateQuestionDto
    {
        public string QuestionDetail { get; set; }
        public string AnswerDetail { get; set; }
    }
}
