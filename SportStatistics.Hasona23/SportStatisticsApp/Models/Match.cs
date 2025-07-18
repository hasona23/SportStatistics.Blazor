﻿using SportStatisticsApp.Data;

namespace SportStatisticsApp.Models;

public class Match
{
    public int Id { get; set; }
    public string Name { get; set; }
    public MatchResult MatchResult { get; set; }
    public DateTime Date { get; set; }
    public List<ApplicationUser> Players { get; set; }
    public List<MatchAction> Actions { get; set; }
}

public enum MatchResult
{
    Win,
    Draw,
    Lose,
    UnSet,
}
