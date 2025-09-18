using System;
using System.Collections.Generic;

namespace Task_Tracker_V4.Models;

public partial class ExamQuestionBank
{
    public int Id { get; set; }

    public long? ExamId { get; set; }

    public long? QuestionId { get; set; }
}
