namespace LeagueOfLegends.API.Models.Response;

using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// Represents a response from the Riot API.
/// </summary>
public class SummonerResponse
{
    /// <summary>
    /// Encrypted summoner ID. Max length 63 characters.
    /// </summary>
    [Key]
    [JsonPropertyName("id")]
    public string Id { get; init; } = null!;

    /// <summary>
    /// Encrypted account ID. Max length 56 characters.
    /// </summary>
    [JsonPropertyName("accountId")]
    public string AccountId { get; set; } = null!;

    /// <summary>
    /// Encrypted PUUID. Exact length of 78 characters.
    /// </summary>
    [JsonPropertyName("puuid")]
    public string  Puuid { get; set; } = null!;

    /// <summary>
    /// Summoner name.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; } = null!;

    /// <summary>
    /// ID of the summoner icon associated with the summoner.
    /// </summary>
    [JsonPropertyName("profileIconId")]
    public long ProfileIconId { get; set; }
    
    /// <summary>
    /// Date summoner was last modified specified as epoch milliseconds.
    /// The following events will update this timestamp: summoner name change, summoner level change,
    /// or profile icon change.
    /// </summary>
    [JsonPropertyName("revisionDate")]
    public long RevisionDate { get; set; }
    
    /// <summary>
    /// Summoner level associated with the summoner.
    /// </summary>
    [JsonPropertyName("summonerLevel")]
    public int SummonerLevel { get; set; }

    /// <summary>
    /// Override the ToString method to return object fields.
    /// </summary>
    /// <returns>Representation of the object.</returns>
    public override string ToString()
    {
        return "Id: " + Id + '\n' +
               "AccountId: " + AccountId + '\n' +
               "Puuid: " + Puuid + '\n' +
               "Name: " + Name + '\n' +
               "ProfileIconId: " + ProfileIconId + '\n' +
               "RevisionDate: " + RevisionDate + '\n' +
               "SummonerLevel: " + SummonerLevel;
    }
}