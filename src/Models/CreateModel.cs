using System.Collections.Generic;
using System.Text.Json.Serialization;
using OllamaSharp.Models.Chat;

namespace OllamaSharp.Models;

/// <summary>
/// Create a model from:
/// another model;
/// a safetensors directory; or
/// a GGUF file.
/// If you are creating a model from a safetensors directory or from a GGUF file,
/// you must [create a blob] for each of the files and then use the file name and SHA256
/// digest associated with each blob in the `files` field.
///
/// <see href="https://github.com/jmorganca/ollama/blob/main/docs/api.md#create-a-model">Ollama API docs</see>
/// 
/// </summary>
[JsonUnmappedMemberHandling(JsonUnmappedMemberHandling.Skip)]
public class CreateModelRequest : OllamaRequest
{
	/// <summary>
	/// Name of the model to create
	/// </summary>
	[JsonPropertyName("model")]
	public string? Model { get; set; }

	/// <summary>
	/// Name of an existing model to create the new model from (optional)
	/// </summary>
	[JsonPropertyName("from")]
	public string? From { get; set; }

	/// <summary>
	/// A dictionary of file names to SHA256 digests of blobs to create the model from (optional)
	/// </summary>
	[JsonPropertyName("from")]
	public Dictionary<string, string>? Files { get; set; }

	/// <summary>
	/// A dictionary of file names to SHA256 digests of blobs for LORA adapters (optional)
	/// </summary>
	[JsonPropertyName("adapters")]
	public Dictionary<string, string>? Adapters { get; set; }

	/// <summary>
	/// The prompt template for the model (optional)
	/// </summary>
	[JsonPropertyName("template")]
	public string? Template { get; set; }

	/// <summary>
	/// A string or list of strings containing the license or licenses for the model (optional)
	/// </summary>
	[JsonPropertyName("license")]
	public object? License { get; set; }

	/// <summary>
	/// A string containing the system prompt for the model (optional)
	/// </summary>
	[JsonPropertyName("system")]
	public string? System { get; set; }

	/// <summary>
	/// A dictionary of parameters for the model (optional)
	/// </summary>
	[JsonPropertyName("parameters")]
	public Dictionary<string, string>? Parameters { get; set; }

	/// <summary>
	/// A list of message objects used to create a conversation (optional)
	/// </summary>
	[JsonPropertyName("messages")]
	public IEnumerable<Message>? Messages { get; set; }

	/// <summary>
	/// If false the response will be returned as a single response object, rather than a stream of objects (optional)
	/// </summary>
	[JsonPropertyName("stream")]
	public bool Stream { get; set; }

	/// <summary>
	/// Set the quantization level for quantize model when importing (e.g. q4_0, optional)
	/// </summary>
	[JsonPropertyName("quantize")]
	public string? Quantize { get; set; }
}

/// <summary>
/// Represents the response from the /api/create endpoint
/// </summary>
public class CreateModelResponse
{
	/// <summary>
	/// Represents the status of a model creation.
	/// </summary>
	[JsonPropertyName("status")]
	public string Status { get; set; } = null!;
}