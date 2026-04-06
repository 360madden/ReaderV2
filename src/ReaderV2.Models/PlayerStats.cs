namespace ReaderV2.Models;

public sealed record PlayerStats(
    int? Hp,
    int? HpMax,
    string? ResourceKind,
    int? Resource,
    int? ResourceMax);
