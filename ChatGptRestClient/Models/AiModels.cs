namespace ChatGptRestClient.Models;

public static class AiModels
{
    /// <summary>
    /// The latest GPT-3.5 Turbo model with higher accuracy at responding in requested formats and
    /// a fix for a bug which caused a text encoding issue for non-English language function calls.
    /// Returns a maximum of 4,096 output tokens.
    /// </summary>
    public const string Turbo3dot5 = "gpt-3.5-turbo-0125";

    [Obsolete("This model was deprecated by OpenAI", error: true)]
    public const string Davinci003 = "text-davinci-003";

    [Obsolete("This model was deprecated by OpenAI", error: true)]
    public const string Davinci002 = "text-davinci-002";

    [Obsolete("This model was deprecated by OpenAI", error: true)]
    public const string CodeDavinci002 = "code-davinci-002";

    /// <summary>
    /// The latest GPT-4 Turbo model with vision capabilities.
    /// Vision requests can now use JSON mode and function calling.
    /// </summary>
    public const string Turbo4 = "gpt-4-turbo";

    /// <summary>
    /// The latest GPT-4 Turbo model with vision capabilities.
    /// Vision requests can now use JSON mode and function calling.
    /// </summary>
    public const string Turbo4O = "gpt-4o";

    /// <summary>
    /// GPT-4o-mini
    /// Our affordable and intelligent small model for fast, lightweight tasks.
    /// GPT-4o mini is cheaper and more capable than GPT-3.5 Turbo.
    /// </summary>
    public const string Turbo4oMini = "gpt-4o-mini";

    /// <summary>
    /// The previous DALL·E model released in Nov 2022.
    /// The 2nd iteration of DALL·E with more realistic, accurate,
    /// and 4x greater resolution images than the original model.
    /// </summary>
    public const string DallE2 = "dall-e-2";

    /// <summary>
    /// The latest DALL·E model released in Nov 2023.
    /// Learn more:
    /// https://openai.com/blog/new-models-and-developer-products-announced-at-devday
    /// </summary>
    public const string DallE3 = "dall-e-3";

    public const int MaxNDallE2 = 10;
    public const int MaxNDallE3 = 1;

    public const int MaxPromptSizeDallE2 = 1000;
    public const int MaxPromptSizeDallE3 = 4000;

    public static readonly List<string> ImageSizesDallE2 =
    [
        ..new[]
        {
            "256x256",
            "512x512",
            "1024x1024",
        }
    ];

    public static readonly List<string> ImageSizesDallE3 =
    [
        ..new[]
        {
            "1024x1024",
            "1792x1024",
            "1024x1792",
        }
    ];

    public static string LatestModel => Turbo4O;
    public static string LatestFreePlanModel => Turbo4oMini;
}