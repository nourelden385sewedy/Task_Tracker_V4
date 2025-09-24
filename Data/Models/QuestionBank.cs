using System;
using System.Collections.Generic;

namespace Task_Tracker_V4.Data.Models;

public partial class QuestionBank
{
    public long QuestionId { get; set; }

    public string? QuestionTitle { get; set; }

    public string? OptionA { get; set; }

    public string? OptionB { get; set; }

    public string? OptionC { get; set; }

    public string? OptionD { get; set; }

    public string? OptionE { get; set; }

    public string? OptionF { get; set; }

    public string? OptionG { get; set; }

    public string? OptionH { get; set; }

    public int? UsedOptions { get; set; }

    public string? CorrectAnswer { get; set; }

    public string? QuestionSubject { get; set; }

    public decimal? Mark { get; set; }
}
