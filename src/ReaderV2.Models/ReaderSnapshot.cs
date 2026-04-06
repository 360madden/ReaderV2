namespace ReaderV2.Models;

public sealed record ReaderSnapshot(
    PlayerIdentity Player,
    PlayerStats Stats,
    PlayerPosition Position,
    TargetInfo? Target,
    DateTimeOffset Timestamp);
